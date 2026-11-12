// Элементы ниже видны через «Просмотреть конструктор» (Shift+F7).
namespace ChudoObuv
{
    partial class LoginForm
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
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Label lblHint;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(710, 83);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(17, 12);
            this.picLogo.Size = new System.Drawing.Size(63, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(95, 21);
            this.lblTitle.Size = new System.Drawing.Size(510, 44);
            this.lblTitle.Text = "Чудо Обувь — Вход";
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Location = new System.Drawing.Point(138, 124);
            this.lblPrompt.Size = new System.Drawing.Size(440, 34);
            this.lblPrompt.Text = "Введите логин (без пароля)";
            this.lblPrompt.AutoEllipsis = true;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Location = new System.Drawing.Point(138, 163);
            this.txtLogin.Size = new System.Drawing.Size(435, 34);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Location = new System.Drawing.Point(138, 222);
            this.btnLogin.Size = new System.Drawing.Size(207, 44);
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Location = new System.Drawing.Point(366, 222);
            this.btnGuest.Size = new System.Drawing.Size(207, 44);
            this.btnGuest.Text = "Войти как гость";
            this.btnGuest.UseVisualStyleBackColor = false;
            this.btnGuest.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.lblHint.Name = "lblHint";
            this.lblHint.Location = new System.Drawing.Point(138, 289);
            this.lblHint.Size = new System.Drawing.Size(442, 58);
            this.lblHint.Text = "Гость может только просматривать каталог.\nАвторизованные пользователи могут оформлять заказ.";
            this.lblHint.AutoEllipsis = true;
            this.Controls.Add(this.pnlHeader);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.lblHint);
            this.ClientSize = new System.Drawing.Size(710, 400);
            this.Name = "LoginForm";
            this.Text = "Чудо Обувь — Авторизация";
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
