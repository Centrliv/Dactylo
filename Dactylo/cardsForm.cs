using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace Dactylo
{
    public partial class cardsForm : Form
    {
        public cardsForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public mainForm form;

        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Persist Security Info=True;unicode=True";
        MySqlCommand cmd = new MySqlCommand();
        string oldS = null, oldN = null, oldP = null;

        private void mainForm_Load(object sender, EventArgs e)
        {
            UpdateF();
        }
        public void UpdateF()
        {
            v_cardsTableAdapter.Fill(dactylo_dbDataSet.v_cards);
            if (cardsTab.Rows.Count == 0)
            {
                delete.Enabled = false;
                view.Enabled = false;
            }
            else
            {
                delete.Enabled = true;
                view.Enabled = true;
                cellChech();
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }
        private void add_Click(object sender, EventArgs e)
        {
            addCard ac = new addCard();
            ac.form = this;
            ac.Owner = this;
            ac.Show();
            Hide();
        }
        private void view_Click(object sender, EventArgs e)
        {
            DataBank.id_card = int.Parse(cardsTab.CurrentRow.Cells[0].Value.ToString());
            DataBank.creator = int.Parse(cardsTab.CurrentRow.Cells[5].Value.ToString());
            viewCard vc = new viewCard();
            vc.form = this;
            vc.Owner = this;
            vc.Show();
            Hide();
        }
        private void snpSrch_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            BindingSource bindingSorce = new BindingSource();
            MySqlConnection con = new MySqlConnection(conString);
            if (fieldN.Text != "" || fieldS.Text != "" || fieldP.Text != "")
            {
                cmd.CommandText = "SELECT id_card, fingerprintables.surname, fingerprintables.`name`, fingerprintables.patronymic, fingerprintables.birthdate, cards.id_worker FROM cards, fingerprintables WHERE surname LIKE @s and `name` LIKE @n and patronymic LIKE @p and cards.id_fingerprintable = fingerprintables.id_fingerprintable AND cards.`delete` = 0";
                cmd.Parameters.AddWithValue("@s", "%" + fieldS.Text + "%");
                cmd.Parameters.AddWithValue("@n", "%" + fieldN.Text + "%");
                cmd.Parameters.AddWithValue("@p", "%" + fieldP.Text + "%");
                oldS = fieldS.Text;
                oldN = fieldN.Text;
                oldP = fieldP.Text;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                bindingSorce.DataSource = dataset.Tables[0];
                cardsTab.DataSource = bindingSorce;
            }
            cmd.Parameters.Clear();
            UpdateF();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            BindingSource bindingSorce = new BindingSource();
            MySqlConnection con = new MySqlConnection(conString);
            cmd.Connection = con;
            cmd.CommandText = "SELECT id_card, fingerprintables.surname, fingerprintables.`name`, fingerprintables.patronymic, fingerprintables.birthdate, cards.id_worker FROM cards, fingerprintables WHERE cards.id_fingerprintable = fingerprintables.id_fingerprintable AND cards.`delete` = 0;";
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            bindingSorce.DataSource = dataset.Tables[0];
            cardsTab.DataSource = bindingSorce;
            cmd.Parameters.Clear();
            UpdateF();
            fieldS.Clear(); oldS = null;
            fieldN.Clear(); oldN = null;
            fieldP.Clear(); oldP = null;
        }
        private void cardsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }
        public void cellChech()
        {
            int position = 0;
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT position FROM workers WHERE id_worker = @idww";
            cmd.Parameters.AddWithValue("@idww", Convert.ToInt32(cardsTab.CurrentRow.Cells[5].Value.ToString()));
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                position = int.Parse(reader[0].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
            if (Convert.ToInt32(cardsTab.CurrentRow.Cells[5].Value.ToString()) == DataBank.usid || DataBank.uspos >= position)
                delete.Enabled = true;
            else delete.Enabled = false;
        }

        private void cardsTab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }

        private void cardsTab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }
    }
}
