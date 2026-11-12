using System;
using System.Windows.Forms;

namespace ChudoObuv
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // После «Выйти» опять показываем авторизацию.
            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break;
                    using (var catalog = new CatalogForm(login.Session))
                    {
                        if (catalog.ShowDialog() != DialogResult.Retry)
                            break;
                    }
                }
            }
        }
    }
}
