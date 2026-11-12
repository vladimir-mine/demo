using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class ProductForm : Form
    {
        private UserSession session;
        private int productId;
        private int? orderId;
        private DataTable sizes;

        public ProductForm()
        {
            InitializeComponent();
            Ui.Logo(picLogo);
            Ui.SetIcon(this);
            btnAdd.Click += (s, e) => Ui.Safe(AddProduct);
            btnBack.Click += (s, e) => Close();
            cmbSizes.SelectedIndexChanged += (s, e) => UpdateLimit();
            Load += (s, e) => { if (productId > 0) Ui.Safe(LoadProduct); };
            FormClosed += (s, e) => { if (picProduct.Image != null) picProduct.Image.Dispose(); };
        }

        internal ProductForm(UserSession current, int id, int? targetOrderId = null) : this()
        {
            session = current;
            productId = id;
            orderId = targetOrderId;
        }

        private void LoadProduct()
        {
            DataTable table = Db.Read("SELECT * FROM dbo.vCatalog WHERE Id=@id", Db.P("@id", productId));
            if (table.Rows.Count == 0) throw new Exception("Товар не найден.");
            DataRow row = table.Rows[0];
            picProduct.Image = Ui.Picture(row["ImageFile"].ToString(), true);
            lblProductName.Text = row["Name"].ToString();
            lblManufacturer.Text = "Производство: " + row["Manufacturer"];
            lblCategory.Text = "Категория: " + row["Category"] + ", " + row["Subcategory"];
            lblComposition.Text = "Состав: " + row["Composition"];
            lblDescription.Text = "Описание: " + row["Description"];
            lblPrice.Text = "Цена: " + Convert.ToDecimal(row["FinalPrice"]).ToString("0.00") +
                " ₽ (скидка " + row["DiscountPercent"] + "%)";
            sizes = Db.Read("SELECT st.Id,sz.Value,st.Quantity FROM dbo.Stock st " +
                "JOIN dbo.Sizes sz ON sz.Id=st.SizeId WHERE st.ProductId=@id ORDER BY sz.Value",
                Db.P("@id", productId));
            lblAvailable.Text = "Размерный ряд: " + string.Join(", ",
                sizes.Rows.Cast<DataRow>().Select(r => r["Value"].ToString()).ToArray());
            foreach (DataRow r in sizes.Rows)
            {
                int count = Convert.ToInt32(r["Quantity"]);
                if (count > 0)
                    cmbSizes.Items.Add(new StockChoice(Convert.ToInt32(r["Id"]), r["Value"].ToString(), count));
            }
            if (cmbSizes.Items.Count > 0) cmbSizes.SelectedIndex = 0;
            if (session.IsGuest)
            {
                btnAdd.Enabled = false;
                btnAdd.Text = "Только просмотр";
                numQty.Enabled = false;
                cmbSizes.Enabled = false;
            }
            else if (orderId.HasValue)
                btnAdd.Text = "Добавить в заказ";
            if (cmbSizes.Items.Count == 0)
            {
                btnAdd.Enabled = false;
                lblAvailable.Text += "   (в наличии нет)";
            }
        }

        private void UpdateLimit()
        {
            StockChoice choice = cmbSizes.SelectedItem as StockChoice;
            if (choice == null) return;
            numQty.Value = 1;
            numQty.Maximum = choice.Available;
        }

        private void AddProduct()
        {
            if (session.IsGuest) throw new Exception("Гостю нельзя оформлять заказ.");
            StockChoice choice = cmbSizes.SelectedItem as StockChoice;
            if (choice == null) throw new Exception("Выберите размер в наличии.");
            int qty = Convert.ToInt32(numQty.Value);
            if (orderId.HasValue)
            {
                if (!session.IsStaff) throw new Exception("Нет прав изменять этот заказ.");
                Db.AddItem(orderId.Value, choice.Id, qty);
                Ui.Done("Позиция добавлена в заказ.");
            }
            else
            {
                CartLine line = session.Cart.FirstOrDefault(item => item.StockId == choice.Id);
                int currentQty = line == null ? 0 : line.Quantity;
                if (currentQty + qty > choice.Available)
                    throw new Exception("Недостаточно пар этого размера с учётом корзины.");
                if (line == null) session.Cart.Add(new CartLine { StockId = choice.Id, Quantity = qty });
                else line.Quantity += qty;
                Ui.Done("Товар добавлен в корзину.");
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
