// Элементы ниже видны через «Просмотреть конструктор» (Shift+F7).
namespace ChudoObuv
{
    partial class OrdersForm
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
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Button btnChangeDate;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.btnChangeDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1108, 75);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(14, 10);
            this.picLogo.Size = new System.Drawing.Size(58, 55);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(90, 12);
            this.lblTitle.Size = new System.Drawing.Size(420, 48);
            this.lblTitle.Text = "Управление заказами";
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.Location = new System.Drawing.Point(13, 96);
            this.gridOrders.Size = new System.Drawing.Size(1080, 221);
            this.gridOrders.ReadOnly = true;
            this.gridOrders.MultiSelect = false;
            this.gridOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOrders.AllowUserToAddRows = false;
            this.gridOrders.AllowUserToDeleteRows = false;
            this.gridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOrders.RowHeadersVisible = false;
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Location = new System.Drawing.Point(13, 330);
            this.btnNewOrder.Size = new System.Drawing.Size(143, 36);
            this.btnNewOrder.Text = "Новый заказ";
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Location = new System.Drawing.Point(164, 330);
            this.btnDeleteOrder.Size = new System.Drawing.Size(171, 36);
            this.btnDeleteOrder.Text = "Удалить заказ";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnBack.Name = "btnBack";
            this.btnBack.Location = new System.Drawing.Point(965, 330);
            this.btnBack.Size = new System.Drawing.Size(128, 36);
            this.btnBack.Text = "К каталогу";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Location = new System.Drawing.Point(13, 378);
            this.lblCustomer.Size = new System.Drawing.Size(717, 31);
            this.lblCustomer.Text = "Выберите заказ";
            this.lblCustomer.AutoEllipsis = true;
            this.gridItems.Name = "gridItems";
            this.gridItems.Location = new System.Drawing.Point(13, 411);
            this.gridItems.Size = new System.Drawing.Size(1080, 231);
            this.gridItems.ReadOnly = true;
            this.gridItems.MultiSelect = false;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.RowHeadersVisible = false;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Location = new System.Drawing.Point(16, 657);
            this.lblTotal.Size = new System.Drawing.Size(410, 34);
            this.lblTotal.Text = "Итого: 0 ₽";
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Location = new System.Drawing.Point(425, 650);
            this.btnAddItem.Size = new System.Drawing.Size(159, 37);
            this.btnAddItem.Text = "Добавить позицию";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Location = new System.Drawing.Point(592, 650);
            this.btnDeleteItem.Size = new System.Drawing.Size(158, 37);
            this.btnDeleteItem.Text = "Удалить позицию";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Location = new System.Drawing.Point(755, 651);
            this.dtpOrderDate.Size = new System.Drawing.Size(180, 36);
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btnChangeDate.Name = "btnChangeDate";
            this.btnChangeDate.Location = new System.Drawing.Point(942, 650);
            this.btnChangeDate.Size = new System.Drawing.Size(151, 37);
            this.btnChangeDate.Text = "Изменить дату";
            this.btnChangeDate.UseVisualStyleBackColor = false;
            this.btnChangeDate.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.Controls.Add(this.pnlHeader);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.btnChangeDate);
            this.ClientSize = new System.Drawing.Size(1108, 711);
            this.Name = "OrdersForm";
            this.Text = "Чудо Обувь — Заказы";
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
