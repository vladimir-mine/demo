// Элементы ниже видны через «Просмотреть конструктор» (Shift+F7).
namespace ChudoObuv
{
    partial class CatalogForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.FlowLayoutPanel flpCatalog;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.flpCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1102, 75);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(14, 10);
            this.picLogo.Size = new System.Drawing.Size(58, 55);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(90, 12);
            this.lblTitle.Size = new System.Drawing.Size(420, 48);
            this.lblTitle.Text = "Каталог обуви";
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblUser.Name = "lblUser";
            this.lblUser.Location = new System.Drawing.Point(560, 16);
            this.lblUser.Size = new System.Drawing.Size(247, 45);
            this.lblUser.Text = "ФИО пользователя";
            this.lblUser.AutoEllipsis = true;
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Location = new System.Drawing.Point(805, 22);
            this.btnOrders.Size = new System.Drawing.Size(90, 36);
            this.btnOrders.Text = "Заказы";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnCart.Name = "btnCart";
            this.btnCart.Location = new System.Drawing.Point(902, 22);
            this.btnCart.Size = new System.Drawing.Size(90, 36);
            this.btnCart.Text = "Корзина";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(997, 22);
            this.btnLogout.Size = new System.Drawing.Size(89, 36);
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Location = new System.Drawing.Point(15, 103);
            this.lblSearch.Size = new System.Drawing.Size(85, 30);
            this.lblSearch.Text = "Поиск";
            this.lblSearch.AutoEllipsis = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Location = new System.Drawing.Point(102, 103);
            this.txtSearch.Size = new System.Drawing.Size(343, 31);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Location = new System.Drawing.Point(461, 103);
            this.lblCategory.Size = new System.Drawing.Size(91, 30);
            this.lblCategory.Text = "Категория";
            this.lblCategory.AutoEllipsis = true;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Location = new System.Drawing.Point(554, 103);
            this.cmbCategory.Size = new System.Drawing.Size(240, 31);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblSort.Name = "lblSort";
            this.lblSort.Location = new System.Drawing.Point(807, 103);
            this.lblSort.Size = new System.Drawing.Size(108, 30);
            this.lblSort.Text = "Сортировка";
            this.lblSort.AutoEllipsis = true;
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Location = new System.Drawing.Point(910, 103);
            this.cmbSort.Size = new System.Drawing.Size(178, 31);
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Location = new System.Drawing.Point(15, 149);
            this.lblHelp.Size = new System.Drawing.Size(1040, 29);
            this.lblHelp.Text = "Нажми «Подробнее» для просмотра размеров и описания.";
            this.lblHelp.AutoEllipsis = true;
            this.flpCatalog.Name = "flpCatalog";
            this.flpCatalog.Location = new System.Drawing.Point(12, 186);
            this.flpCatalog.Size = new System.Drawing.Size(1072, 533);
            this.flpCatalog.AutoScroll = true;
            this.flpCatalog.WrapContents = false;
            this.flpCatalog.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCatalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlHeader);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.btnOrders);
            this.pnlHeader.Controls.Add(this.btnCart);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.flpCatalog);
            this.ClientSize = new System.Drawing.Size(1102, 730);
            this.Name = "CatalogForm";
            this.Text = "Чудо Обувь — Каталог товаров";
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
