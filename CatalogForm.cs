using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class CatalogForm : Form
    {
        private UserSession session;
        private int? addToOrderId;
        private DataTable products;

        // Пустой конструктор нужен для дизайнера Visual Studio.
        public CatalogForm()
        {
            InitializeComponent();
            btnCart.Click += (s, e) => Ui.Safe(OpenCart);
            btnOrders.Click += (s, e) => Ui.Safe(OpenOrders);
            btnLogout.Click += (s, e) => { DialogResult = addToOrderId.HasValue ? DialogResult.Cancel : DialogResult.Retry; Close(); };
            txtSearch.TextChanged += (s, e) => Ui.Safe(ApplyFilters);
            cmbCategory.SelectedIndexChanged += (s, e) => Ui.Safe(ApplyFilters);
            cmbSort.SelectedIndexChanged += (s, e) => Ui.Safe(ApplyFilters);
            Load += (s, e) => { if (session != null) Ui.Safe(RefreshCatalog); };
            Ui.Logo(picLogo);
            Ui.SetIcon(this);
        }

        internal CatalogForm(UserSession current, int? orderId = null) : this()
        {
            session = current;
            addToOrderId = orderId;
        }

        private void RefreshCatalog()
        {
            lblUser.Text = session.FullName;
            btnOrders.Visible = session.IsStaff && !addToOrderId.HasValue;
            btnCart.Visible = !session.IsGuest && !addToOrderId.HasValue;
            btnLogout.Text = addToOrderId.HasValue ? "Назад" : "Выйти";
            if (addToOrderId.HasValue)
                btnLogout.Text = "К заказу";
            btnCart.Text = "Корзина (" + session.Cart.Count + ")";
            lblHelp.Text = session.IsGuest ? "Гость: только просмотр каталога и карточек товаров." :
                (addToOrderId.HasValue ? "Выберите модель для добавления в заказ №" + addToOrderId :
                    "Нажмите «Подробнее» для выбора размера и количества.");
            products = Db.Read("SELECT * FROM dbo.vCatalog ORDER BY Name");
            if (cmbCategory.Items.Count == 0)
            {
                cmbCategory.Items.Add(new Choice(0, "Все категории"));
                DataTable categories = Db.Read("SELECT Id,Name FROM dbo.Categories ORDER BY Name");
                foreach (DataRow row in categories.Rows)
                    cmbCategory.Items.Add(new Choice(Convert.ToInt32(row["Id"]), row["Name"].ToString()));
                cmbCategory.SelectedIndex = 0;
            }
            if (cmbSort.Items.Count == 0)
            {
                cmbSort.Items.AddRange(new object[] { "Без сортировки", "Цена: по возрастанию", "Цена: по убыванию" });
                cmbSort.SelectedIndex = 0;
            }
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (products == null) return;
            int category = cmbCategory.SelectedItem == null ? 0 : ((Choice)cmbCategory.SelectedItem).Id;
            string query = txtSearch.Text.Trim();
            List<DataRow> rows = products.Rows.Cast<DataRow>().Where(row =>
                (category == 0 || Convert.ToInt32(row["CategoryId"]) == category) &&
                (row["Name"] + " " + row["Description"]).IndexOf(query,
                    StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (cmbSort.SelectedIndex == 1) rows = rows.OrderBy(row => Convert.ToDecimal(row["FinalPrice"])).ToList();
            if (cmbSort.SelectedIndex == 2) rows = rows.OrderByDescending(row => Convert.ToDecimal(row["FinalPrice"])).ToList();
            foreach (Control card in flpCatalog.Controls)
                foreach (Control item in card.Controls)
                    if (item is PictureBox && ((PictureBox)item).Image != null) ((PictureBox)item).Image.Dispose();
            flpCatalog.Controls.Clear();
            flpCatalog.SuspendLayout();
            foreach (DataRow row in rows) AddCard(row);
            flpCatalog.ResumeLayout();
        }

        private void AddCard(DataRow row)
        {
            int id = Convert.ToInt32(row["Id"]);
            int available = Convert.ToInt32(row["TotalQuantity"]);
            decimal price = Convert.ToDecimal(row["FinalPrice"]);
            decimal original = Convert.ToDecimal(row["BasePrice"]);
            var card = new Panel
            {
                Size = new Size(1017, 127),
                Margin = new Padding(8),
                BackColor = available <= 3 ? Ui.Warning : Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            var picture = new PictureBox
            {
                Location = new Point(7, 7), Size = new Size(120, 111),
                Image = Ui.Picture(row["ImageFile"].ToString(), true),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            var title = new Label
            {
                Location = new Point(139, 8), Size = new Size(670, 28),
                Font = new Font(Font, FontStyle.Bold), AutoEllipsis = true,
                Text = row["Manufacturer"] + " | " + row["Name"]
            };
            var detail = new Label
            {
                Location = new Point(139, 38), Size = new Size(700, 52), AutoEllipsis = true,
                Text = "Категория: " + row["Category"] + "\nСостав: " + row["Composition"]
            };
            var bottom = new Label
            {
                Location = new Point(139, 94), Size = new Size(710, 25), AutoEllipsis = true,
                Text = "Количество: " + (available > 5 ? "много" : "мало") +
                    " (" + available + " пар)    Цена: " + price.ToString("0.00") + " ₽" +
                    (original != price ? "  (скидка 25%)" : "")
            };
            var open = new Button
            {
                Location = new Point(867, 43), Size = new Size(135, 41),
                BackColor = Ui.Teal, Text = "Подробнее"
            };
            open.Click += (s, e) => Ui.Safe(() => OpenProduct(id));
            card.Controls.Add(picture);
            card.Controls.Add(title);
            card.Controls.Add(detail);
            card.Controls.Add(bottom);
            card.Controls.Add(open);
            picture.Click += (s, e) => Ui.Safe(() => OpenProduct(id));
            title.Click += (s, e) => Ui.Safe(() => OpenProduct(id));
            flpCatalog.Controls.Add(card);
        }

        private void OpenProduct(int productId)
        {
            using (var form = new ProductForm(session, productId, addToOrderId))
                form.ShowDialog(this);
            RefreshCatalog();
        }

        private void OpenCart()
        {
            if (session.IsGuest) throw new Exception("Чтобы сделать заказ, войдите по логину.");
            using (var form = new CartForm(session)) form.ShowDialog(this);
            RefreshCatalog();
        }

        private void OpenOrders()
        {
            if (!session.IsStaff) throw new Exception("Раздел доступен только сотрудникам.");
            using (var form = new OrdersForm(session)) form.ShowDialog(this);
            RefreshCatalog();
        }
    }
}
