using System;
using System.Data;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class LoginForm : Form
    {
        internal UserSession Session { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += (s, e) => Ui.Safe(SignIn);
            btnGuest.Click += (s, e) => SignInGuest();
            txtLogin.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Ui.Safe(SignIn); }
            };
            Ui.Logo(picLogo);
            Ui.SetIcon(this);
        }

        private void SignIn()
        {
            string login = txtLogin.Text.Trim();
            if (login.Length == 0) throw new Exception("Введите логин.");
            DataTable data = Db.Read(
                "SELECT u.Id,u.Surname,u.FirstName,u.Patronymic,r.Name AS Role " +
                "FROM dbo.Users u JOIN dbo.Roles r ON r.Id=u.RoleId WHERE u.Login=@login",
                Db.P("@login", login));
            if (data.Rows.Count == 0) throw new Exception("Логин не найден в базе.");
            DataRow row = data.Rows[0];
            Session = new UserSession();
            Session.UserId = Convert.ToInt32(row["Id"]);
            Session.FullName = (row["Surname"] + " " + row["FirstName"] + " " + row["Patronymic"]).Trim();
            Session.Role = row["Role"].ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SignInGuest()
        {
            Session = new UserSession();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
