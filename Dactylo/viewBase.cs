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
    public partial class viewBase : Form
    {
        public viewBase()
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
            edit.Enabled = DataBank.usid == DataBank.creator || DataBank.uspos >= 1 ? true : false;
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
            cmd.Parameters.Clear();
            con.Close();
            SQLcom = "SELECT id_type, title, content, date FROM bases WHERE id_base = @id";
            con.Open();
            cmd.Parameters.AddWithValue("@id", DataBank.id_base);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                typ.Value = int.Parse(reader[0].ToString());
                tit.Text = reader[1].ToString();
                txt.Text = reader[2].ToString();
                dat.Value = DateTime.Parse(reader[3].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
            typ.Maximum = type.Count;
            typ_ValueChanged(sender, e);
        }

        private void typ_ValueChanged(object sender, EventArgs e)
        {
            ttype.Text = type[Convert.ToInt32(typ.Value - 1)]; 
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (edit.Text == "Редактировать")
            {
                tit.ReadOnly = false;
                typ.ReadOnly = false;
                typ.Enabled = true;
                dat.Enabled = true;
                txt.ReadOnly = false;
                edit.Text = "Сохранить";
            }
            else if (edit.Text == "Сохранить")
            {
                DialogResult result = MessageBox.Show("Сохранить внесенные изменения", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                TopMost = true;
                if (result == DialogResult.Yes)
                {
                    int id_type = Convert.ToInt32(typ.Value);
                    string title = tit.Text.ToString().Trim();
                    string content = txt.Text.ToString().Trim();
                    DateTime date = dat.Value;
                    MySqlConnection con = new MySqlConnection(conString);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    if (title != "" && content != "")
                    {
                        string SQLcom = "UPDATE bases SET `id_type`= @id, `title`= @T, `content`= @C, `date`= @D WHERE `id_base`= @idb";
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", id_type);
                        cmd.Parameters.AddWithValue("@T", title);
                        cmd.Parameters.AddWithValue("@C", content);
                        cmd.Parameters.AddWithValue("@D", date.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@idb", DataBank.id_base);
                        cmd.Connection = con;
                        cmd.CommandText = SQLcom;
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table); //чето тут не так
                        cmd.Parameters.Clear();
                        con.Close();
                        edit.Text = "Редактировать";
                        tit.ReadOnly = true;
                        typ.ReadOnly = true;
                        typ.Enabled = false;
                        dat.Enabled = false;
                        txt.ReadOnly = true;
                        form.UpdateF();
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка");
                    }
                }
            } 
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Update();
            form.Show();
            Hide();
        }

        private void viewBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Update();
            form.Show();
            Hide();
        }
    }
}
