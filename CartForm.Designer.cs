// Элементы ниже видны через «Просмотреть конструктор» (Shift+F7).
namespace ChudoObuv
{
    partial class CartForm
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
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblQtyPrompt;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblQtyPrompt = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1044, 75);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(14, 10);
            this.picLogo.Size = new System.Drawing.Size(58, 55);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(90, 12);
            this.lblTitle.Size = new System.Drawing.Size(420, 48);
            this.lblTitle.Text = "Корзина";
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.gridCart.Name = "gridCart";
            this.gridCart.Location = new System.Drawing.Point(14, 92);
            this.gridCart.Size = new System.Drawing.Size(1014, 344);
            this.gridCart.ReadOnly = true;
            this.gridCart.MultiSelect = false;
            this.gridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCart.AllowUserToAddRows = false;
            this.gridCart.AllowUserToDeleteRows = false;
            this.gridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCart.RowHeadersVisible = false;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Location = new System.Drawing.Point(16, 451);
            this.lblTotal.Size = new System.Drawing.Size(575, 35);
            this.lblTotal.Text = "Итого: 0 ₽";
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQtyPrompt.Name = "lblQtyPrompt";
            this.lblQtyPrompt.Location = new System.Drawing.Point(18, 505);
            this.lblQtyPrompt.Size = new System.Drawing.Size(232, 28);
            this.lblQtyPrompt.Text = "Количество выбранного товара";
            this.lblQtyPrompt.AutoEllipsis = true;
            this.numQty.Name = "numQty";
            this.numQty.Location = new System.Drawing.Point(257, 505);
            this.numQty.Size = new System.Drawing.Size(106, 30);
            this.numQty.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numQty.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.numQty.Value = new decimal(new int[] {1, 0, 0, 0});
            this.btnChange.Name = "btnChange";
            this.btnChange.Location = new System.Drawing.Point(379, 503);
            this.btnChange.Size = new System.Drawing.Size(127, 37);
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Location = new System.Drawing.Point(514, 503);
            this.btnRemove.Size = new System.Drawing.Size(143, 37);
            this.btnRemove.Text = "Удалить позицию";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Location = new System.Drawing.Point(17, 560);
            this.lblCustomer.Size = new System.Drawing.Size(207, 27);
            this.lblCustomer.Text = "Клиент";
            this.lblCustomer.AutoEllipsis = true;
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Location = new System.Drawing.Point(227, 557);
            this.cmbCustomer.Size = new System.Drawing.Size(351, 34);
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Location = new System.Drawing.Point(619, 557);
            this.btnConfirm.Size = new System.Drawing.Size(194, 40);
            this.btnConfirm.Text = "Подтвердить заказ";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnClear.Name = "btnClear";
            this.btnClear.Location = new System.Drawing.Point(824, 557);
            this.btnClear.Size = new System.Drawing.Size(115, 40);
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnBack.Name = "btnBack";
            this.btnBack.Location = new System.Drawing.Point(941, 557);
            this.btnBack.Size = new System.Drawing.Size(86, 40);
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.Controls.Add(this.pnlHeader);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblQtyPrompt);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.ClientSize = new System.Drawing.Size(1044, 615);
            this.Name = "CartForm";
            this.Text = "Чудо Обувь — Корзина";
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
