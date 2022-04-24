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
    public partial class addFingerprintable : Form
    {
        public addFingerprintable()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public fingerprintablesForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void add_Click(object sender, EventArgs e)
        {
            string surname = sur.Text.Trim();
            string name = nam.Text.Trim();
            string patronymic = patr.Text.Trim();
            int sex = sx.SelectedIndex;
            DateTime birthdate = birth.Value;
            string citizenship = citsh.Text.Trim();
            string birthplace = birthpl.Text.Trim();
            string regplace = regpl.Text.Trim();
            MySqlConnection con = new MySqlConnection(conString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (surname != "" && name != "" && citizenship != "" && birthplace != "" && regplace != "")
            {
                string SQLcom = "INSERT INTO fingerprintables (surname, name, patronymic, sex, citizenship, birthdate, birthplace, regplace, id_worker, `delete`) VALUES (@S, @N, @P, @Sx, @C, @Bd, @Bp, @R, @W, 0)";
                con.Open();
                cmd.Parameters.AddWithValue("@S", surname);
                cmd.Parameters.AddWithValue("@N", name);
                cmd.Parameters.AddWithValue("@P", patronymic);
                cmd.Parameters.AddWithValue("@Sx", sex);
                cmd.Parameters.AddWithValue("@C", citizenship);
                cmd.Parameters.AddWithValue("@Bd", birthdate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Bp", birthplace);
                cmd.Parameters.AddWithValue("@R", regplace);
                cmd.Parameters.AddWithValue("@W", DataBank.usid);
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                cmd.Parameters.Clear();
                con.Close();                
                form.Show();
                form.fingerprintablesForm_Load(sender, e);
                Hide();
            }
            else
            {
                MessageBox.Show("Не все обязательные поля заполнены", "Ошибка");
            }
        }

        private void addFingerprintable_Load(object sender, EventArgs e)
        {
            sx.SelectedIndex = 0;
            birth.MaxDate = DateTime.Today;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void addFingerprintable_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }
    }
}
