using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChudoObuv
{
    internal sealed class UserSession
    {
        public int UserId;
        public string FullName = "Гость";
        public string Role = "";
        public readonly List<CartLine> Cart = new List<CartLine>();
        public bool IsGuest { get { return UserId == 0; } }
        public bool IsStaff { get { return Role == "Менеджер" || Role == "Администратор"; } }
        public bool IsAdmin { get { return Role == "Администратор"; } }
    }

    internal class Choice
    {
        public int Id;
        public string Name;
        public Choice(int id, string name) { Id = id; Name = name; }
        public override string ToString() { return Name; }
    }

    internal sealed class StockChoice : Choice
    {
        public int Available;
        public StockChoice(int id, string name, int available) : base(id, name) { Available = available; }
        public override string ToString() { return Name + " (осталось " + Available + ")"; }
    }

    internal static class Ui
    {
        public static readonly Color Mint = Color.FromArgb(210, 246, 231);
        public static readonly Color Teal = Color.FromArgb(112, 178, 175);
        public static readonly Color Warning = Color.FromArgb(255, 219, 219);

        public static void Safe(Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПроверьте данные и повторите действие.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Ask(string message)
        {
            return MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public static void Done(string message)
        {
            MessageBox.Show(message, "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static Image Picture(string filename, bool product)
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(root, product ? "Images" : "", filename ?? "");
            if (!File.Exists(path)) path = Path.Combine(root, "picture.png");
            if (!File.Exists(path)) return new Bitmap(90, 90);
            using (var image = Image.FromFile(path)) return new Bitmap(image);
        }

        public static void SetIcon(Form form)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
            if (File.Exists(path)) form.Icon = new Icon(path);
        }

        public static void Logo(PictureBox box)
        {
            box.Image = Picture("logo.png", false);
        }

        public static int SelectedId(DataGridView grid)
        {
            if (grid.CurrentRow == null) throw new Exception("Выберите запись в таблице.");
            return Convert.ToInt32(grid.CurrentRow.Cells["Id"].Value);
        }

        public static void Bind(DataGridView grid, DataTable data)
        {
            grid.DataSource = data;
            if (grid.Columns.Contains("Id")) grid.Columns["Id"].Visible = false;
            if (grid.Columns.Contains("StockId")) grid.Columns["StockId"].Visible = false;
            if (grid.Columns.Contains("UserId")) grid.Columns["UserId"].Visible = false;
            grid.ClearSelection();
        }
    }
}
