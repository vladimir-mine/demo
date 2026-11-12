using System;
using System.Data;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class OrdersForm : Form
    {
        private UserSession session;
        private int selectedOrderId;

        public OrdersForm()
        {
            InitializeComponent();
            Ui.Logo(picLogo);
            Ui.SetIcon(this);
            btnBack.Click += (s, e) => Close();
            btnNewOrder.Click += (s, e) => Ui.Safe(NewOrder);
            btnDeleteOrder.Click += (s, e) => Ui.Safe(DeleteOrder);
            btnAddItem.Click += (s, e) => Ui.Safe(AddItem);
            btnDeleteItem.Click += (s, e) => Ui.Safe(DeleteItem);
            btnChangeDate.Click += (s, e) => Ui.Safe(ChangeDate);
            gridOrders.SelectionChanged += (s, e) => Ui.Safe(SelectOrder);
            Load += (s, e) => { if (session != null) Ui.Safe(RefreshOrders); };
        }

        internal OrdersForm(UserSession current) : this() { session = current; }

        private void RefreshOrders()
        {
            if (!session.IsStaff) throw new Exception("Просмотр заказов доступен сотрудникам.");
            btnChangeDate.Enabled = session.IsAdmin;
            btnDeleteItem.Enabled = session.IsAdmin;
            dtpOrderDate.Enabled = session.IsAdmin;
            DataTable orders = Db.Read(
                "SELECT o.Id,o.OrderDate AS Дата," +
                "u.Surname+' '+u.FirstName+' '+u.Patronymic AS Клиент," +
                "ISNULL(SUM(i.Quantity*i.UnitPrice),0) AS Сумма " +
                "FROM dbo.Orders o JOIN dbo.Users u ON u.Id=o.UserId " +
                "LEFT JOIN dbo.OrderItems i ON i.OrderId=o.Id " +
                "GROUP BY o.Id,o.OrderDate,u.Surname,u.FirstName,u.Patronymic " +
                "ORDER BY o.OrderDate DESC,o.Id DESC");
            selectedOrderId = 0;
            Ui.Bind(gridOrders, orders);
            if (gridOrders.Rows.Count > 0)
            {
                gridOrders.Rows[0].Selected = true;
                gridOrders.CurrentCell = gridOrders.Rows[0].Cells["Дата"];
                SelectOrder();
            }
            else
            {
                Ui.Bind(gridItems, new DataTable());
                lblCustomer.Text = "Заказов пока нет";
                lblTotal.Text = "Итого: 0 ₽";
            }
        }

        private void SelectOrder()
        {
            if (gridOrders.CurrentRow == null) return;
            selectedOrderId = Ui.SelectedId(gridOrders);
            DataRow row = ((DataRowView)gridOrders.CurrentRow.DataBoundItem).Row;
            lblCustomer.Text = "Заказ №" + selectedOrderId + " — " + row["Клиент"];
            dtpOrderDate.Value = Convert.ToDateTime(row["Дата"]);
            DataTable lines = Db.Read(
                "SELECT i.Id,p.Name AS Модель,m.Name AS Производитель," +
                "sz.Value AS Размер,i.Quantity AS Количество,i.UnitPrice AS Цена," +
                "i.Quantity*i.UnitPrice AS Сумма " +
                "FROM dbo.OrderItems i JOIN dbo.Stock s ON s.Id=i.StockId " +
                "JOIN dbo.Products p ON p.Id=s.ProductId " +
                "JOIN dbo.Manufacturers m ON m.Id=p.ManufacturerId " +
                "JOIN dbo.Sizes sz ON sz.Id=s.SizeId WHERE i.OrderId=@id ORDER BY i.Id",
                Db.P("@id", selectedOrderId));
            Ui.Bind(gridItems, lines);
            decimal total = 0;
            foreach (DataRow item in lines.Rows) total += Convert.ToDecimal(item["Сумма"]);
            lblTotal.Text = "Итого: " + total.ToString("0.00") + " ₽";
        }

        private void NewOrder()
        {
            // Менеджер создаёт заказ через каталог → корзину → выбор клиента.
            using (var catalog = new CatalogForm(session)) catalog.ShowDialog(this);
            RefreshOrders();
        }

        private void AddItem()
        {
            if (selectedOrderId == 0) throw new Exception("Выберите заказ.");
            // Для добавления позиции открывается тот же каталог в специальном режиме.
            using (var catalog = new CatalogForm(session, selectedOrderId)) catalog.ShowDialog(this);
            RefreshOrders();
        }

        private void DeleteItem()
        {
            if (!session.IsAdmin) throw new Exception("Удалять позиции может только администратор.");
            int id = Ui.SelectedId(gridItems);
            if (!Ui.Ask("Удалить выбранную позицию и вернуть пары на склад?")) return;
            Db.DeleteItem(id);
            RefreshOrders();
        }

        private void DeleteOrder()
        {
            if (selectedOrderId == 0) throw new Exception("Выберите заказ.");
            if (!Ui.Ask("Удалить заказ №" + selectedOrderId + " и вернуть пары на склад?")) return;
            Db.DeleteOrder(selectedOrderId);
            RefreshOrders();
        }

        private void ChangeDate()
        {
            if (!session.IsAdmin) throw new Exception("Дату может менять только администратор.");
            if (selectedOrderId == 0) throw new Exception("Выберите заказ.");
            Db.Run("UPDATE dbo.Orders SET OrderDate=@date WHERE Id=@id",
                Db.P("@date", dtpOrderDate.Value.Date), Db.P("@id", selectedOrderId));
            RefreshOrders();
        }
    }
}
