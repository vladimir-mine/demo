using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class CartForm : Form
    {
        private UserSession session;

        public CartForm()
        {
            InitializeComponent();
            Ui.Logo(picLogo);
            Ui.SetIcon(this);
            btnChange.Click += (s, e) => Ui.Safe(ChangeQuantity);
            btnRemove.Click += (s, e) => Ui.Safe(RemoveLine);
            btnClear.Click += (s, e) => { if (Ui.Ask("Очистить корзину?")) { session.Cart.Clear(); RefreshCart(); } };
            btnConfirm.Click += (s, e) => Ui.Safe(Confirm);
            btnBack.Click += (s, e) => Close();
            gridCart.SelectionChanged += (s, e) => CopyQuantity();
            Load += (s, e) => { if (session != null) Ui.Safe(Prepare); };
        }

        internal CartForm(UserSession current) : this() { session = current; }

        private void Prepare()
        {
            if (session.IsGuest) throw new Exception("Гостю нельзя оформлять заказы.");
            lblCustomer.Text = "Клиент: " + session.FullName;
            cmbCustomer.Visible = session.IsStaff;
            if (session.IsStaff)
            {
                lblCustomer.Text = "Выберите клиента:";
                DataTable users = Db.Read(
                    "SELECT u.Id,u.Surname+' '+u.FirstName+' '+u.Patronymic AS FullName " +
                    "FROM dbo.Users u JOIN dbo.Roles r ON r.Id=u.RoleId " +
                    "WHERE r.Name=N'Авторизованный пользователь' ORDER BY FullName");
                foreach (DataRow row in users.Rows)
                    cmbCustomer.Items.Add(new Choice(Convert.ToInt32(row["Id"]), row["FullName"].ToString()));
                if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;
            }
            RefreshCart();
        }

        private void RefreshCart()
        {
            var table = new DataTable();
            table.Columns.Add("StockId", typeof(int));
            table.Columns.Add("Товар", typeof(string));
            table.Columns.Add("Размер", typeof(string));
            table.Columns.Add("Количество", typeof(int));
            table.Columns.Add("Цена", typeof(decimal));
            table.Columns.Add("Сумма", typeof(decimal));
            decimal total = 0;
            foreach (CartLine line in session.Cart)
            {
                DataTable detail = Db.Read(
                    "SELECT p.Name,sz.Value,v.FinalPrice FROM dbo.Stock s " +
                    "JOIN dbo.Products p ON p.Id=s.ProductId " +
                    "JOIN dbo.Sizes sz ON sz.Id=s.SizeId " +
                    "JOIN dbo.vCatalog v ON v.Id=p.Id WHERE s.Id=@id", Db.P("@id", line.StockId));
                if (detail.Rows.Count == 0) throw new Exception("Товар в корзине больше не существует.");
                DataRow row = detail.Rows[0];
                decimal price = Convert.ToDecimal(row["FinalPrice"]);
                decimal amount = price * line.Quantity;
                total += amount;
                table.Rows.Add(line.StockId, row["Name"], row["Value"], line.Quantity, price, amount);
            }
            Ui.Bind(gridCart, table);
            lblTotal.Text = "Итого: " + total.ToString("0.00") + " ₽";
            btnConfirm.Enabled = session.Cart.Count > 0;
        }

        private void CopyQuantity()
        {
            if (gridCart.CurrentRow == null) return;
            object value = gridCart.CurrentRow.Cells["Количество"].Value;
            if (value == null || value == DBNull.Value) return;
            int qty = Convert.ToInt32(value);
            numQty.Value = Math.Min(numQty.Maximum, Math.Max(numQty.Minimum, qty));
        }

        private void ChangeQuantity()
        {
            int id = Convert.ToInt32(gridCart.CurrentRow.Cells["StockId"].Value);
            int available = Convert.ToInt32(Db.Scalar(
                "SELECT Quantity FROM dbo.Stock WHERE Id=@id", Db.P("@id", id)));
            if (numQty.Value > available)
                throw new Exception("На складе только " + available + " пар выбранного размера.");
            session.Cart.First(item => item.StockId == id).Quantity = Convert.ToInt32(numQty.Value);
            RefreshCart();
        }

        private void RemoveLine()
        {
            if (gridCart.CurrentRow == null) throw new Exception("Выберите позицию.");
            int id = Convert.ToInt32(gridCart.CurrentRow.Cells["StockId"].Value);
            session.Cart.RemoveAll(item => item.StockId == id);
            RefreshCart();
        }

        private void Confirm()
        {
            if (session.Cart.Count == 0) throw new Exception("Корзина пуста.");
            int userId = session.UserId;
            if (session.IsStaff)
            {
                Choice customer = cmbCustomer.SelectedItem as Choice;
                if (customer == null) throw new Exception("Выберите клиента.");
                userId = customer.Id;
            }
            if (!Ui.Ask("Подтвердить создание заказа?")) return;
            Db.CreateOrder(userId, session.Cart);
            session.Cart.Clear();
            Ui.Done("Заказ создан. Остатки пересчитаны.");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
