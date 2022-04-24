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
    public partial class basesForm : Form
    {
        public basesForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public mainForm form;

        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void basesForm_Load(object sender, EventArgs e)
        {
            UpdateF();
        }

        public void cellChech()
        {
            if (Convert.ToInt32(basesTable.CurrentRow.Cells[4].Value.ToString()) == DataBank.usid || DataBank.uspos >= 1)
                delete.Enabled = true;
            else delete.Enabled = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            addBase ab = new addBase();
            ab.form = this;
            ab.Owner = this;
            ab.TopLevel = true;
            ab.Show();
            Hide();
        }
        public void UpdateF()
        {
            this.v_workersTableAdapter.Fill(this.dactylo_dbDataSet.v_workers);

            if (basesTable.Rows.Count < 1)
            {
                view.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
                view.Enabled = true;
                delete.Enabled = true;
                cellChech();
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
            DataBank.id_base = int.Parse(basesTable.CurrentRow.Cells[0].Value.ToString());
            DataBank.creator = int.Parse(basesTable.CurrentRow.Cells[4].Value.ToString());
            viewBase vb = new viewBase();
            vb.form = this;
            vb.Owner = this;
            vb.TopLevel = true;
            vb.Show();
            Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить выбранное основание", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            TopMost = true;
            if (result == DialogResult.Yes)
            {
                int del = int.Parse(basesTable.CurrentRow.Cells[0].Value.ToString());

                MySqlConnection con = new MySqlConnection(conString);
                BindingSource bindingSorce = new BindingSource();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string SQLcom = "SELECT count(*) FROM cards WHERE id_base = @id and `delete` = 0";
                cmd.Parameters.AddWithValue("@id", del);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                long count = (long)cmd.ExecuteScalar();
                if (count > 0)
                {
                    SQLcom = "SELECT id_card FROM cards WHERE id_base = @id and `delete` = 0";
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    string message = "";
                    while (reader.Read())
                    {
                        message += "№" + reader[0].ToString() + ", ";
                    }
                    MessageBox.Show("Невозможно удалить запись основания, так как она привязана к картам: " + message + "\nСначала удалите данные карты, а потом основание", "Ошибка удаления");
                }
                else
                {
                    SQLcom = "UPDATE bases SET `delete` = 1 WHERE id_base = @id";
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                }             
                con.Close();
                cmd.Parameters.Clear();
                UpdateF();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void basesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }

        private void basesTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }
    }
}
