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
    public partial class vFingerprintable : Form
    {
        public vFingerprintable()
        {
            InitializeComponent();
        }
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        string osur, onam, opatr, ocit, obirthpl, oreg;
        int osex;
        DateTime obirth;       

        private void addFingerprintable_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT surname, `name`, patronymic, sex, citizenship, birthdate, birthplace, regplace FROM fingerprintables WHERE id_fingerprintable = @id";
            con.Open();
            cmd.Parameters.AddWithValue("@id", DataBank.id_fingerprintable);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sur.Text = reader[0].ToString();
                osur = reader[0].ToString();
                nam.Text = reader[1].ToString();
                onam = reader[1].ToString();
                patr.Text = reader[2].ToString();
                opatr = reader[2].ToString();
                sx.SelectedIndex = int.Parse(reader[3].ToString());
                osex = int.Parse(reader[3].ToString());
                citsh.Text = reader[4].ToString();
                ocit = reader[4].ToString();
                birth.Value = DateTime.Parse(reader[5].ToString());
                obirth = DateTime.Parse(reader[5].ToString());
                birthpl.Text = reader[6].ToString();
                obirthpl = reader[6].ToString();
                regpl.Text = reader[7].ToString();
                oreg = reader[7].ToString();
            }
            cmd.Parameters.Clear();
            con.Close();
            birth.MaxDate = DateTime.Today;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void addFingerprintable_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }
    }
}
