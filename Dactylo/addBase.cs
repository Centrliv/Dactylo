using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace Dactylo
{
    public partial class addBase : Form
    {
        public addBase()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public basesForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        public List<string> type = new List<string>();

        private void addBase_Load(object sender, EventArgs e)
        {
            dat.MaxDate = DateTime.Today;
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT * FROM bases_types";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                type.Add(reader[1].ToString());
            }
            typ.Maximum = type.Count;
            ttype.Text = type[0];
            cmd.Parameters.Clear();
            con.Close();
        }

        private void typ_ValueChanged(object sender, EventArgs e)
        {
            ttype.Text = type[Convert.ToInt32(typ.Value - 1)]; 
        }

        private void add_Click(object sender, EventArgs e)
        {
            int id_type = Convert.ToInt32(typ.Value);
            string title = tit.Text.ToString();
            string content = txt.Text.ToString();
            DateTime date = dat.Value;
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (title != "" && content != "")
            {
                string SQLcom = "INSERT INTO bases (id_type, title, content, date, id_worker, bases.delete) VALUES (@id, @T, @C, @D, @W, 0)";
                con.Open();
                cmd.Parameters.AddWithValue("@id", typ.Value);
                cmd.Parameters.AddWithValue("@T", title);
                cmd.Parameters.AddWithValue("@C", content);
                cmd.Parameters.AddWithValue("@D", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@W", DataBank.usid);
                cmd.CommandText = SQLcom;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                cmd.Parameters.Clear();
                con.Close();
                form.UpdateF();
                form.cellChech();
                form.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void addBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }
    }
}
