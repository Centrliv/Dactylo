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
    public partial class fingerprintablesForm : Form
    {
        public fingerprintablesForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public mainForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        string oldS = null, oldN = null, oldP = null;

        public void fingerprintablesForm_Load(object sender, EventArgs e)
        {
            UpdateF();
        }

        public void cellChech()
        {
            if (fingerprintablesTable.Rows.Count != 0)
            {
                int position = 0;
                MySqlConnection con = new MySqlConnection(conString);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string SQLcom = "SELECT position FROM workers WHERE id_worker = @idww";
                cmd.Parameters.AddWithValue("@idww", Convert.ToInt32(fingerprintablesTable.CurrentRow.Cells[5].Value.ToString()));
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
                if (Convert.ToInt32(fingerprintablesTable.CurrentRow.Cells[5].Value.ToString()) == DataBank.usid || DataBank.uspos >= position)
                    delete.Enabled = true;
                else delete.Enabled = false;
            }
        }

        public void UpdateF()
        {
            v_fingerprintablesTableAdapter.Fill(dactylo_dbDataSet.v_fingerprintables);
            if (fingerprintablesTable.Rows.Count == 0)
            {
                view.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
                view.Enabled = true;
                delete.Enabled = true;
            }
            cellChech();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить выбранного дактилоскопируемого?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            TopMost = true;
            if (result == DialogResult.Yes)
            {
                int del = int.Parse(fingerprintablesTable.CurrentRow.Cells[0].Value.ToString());

                MySqlConnection con = new MySqlConnection(conString);
                BindingSource bindingSorce = new BindingSource();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string SQLcom = "SELECT count(*) FROM cards WHERE id_fingerprintable = @id and `delete` = 0";
                cmd.Parameters.AddWithValue("@id", del);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                long count = (long)cmd.ExecuteScalar();
                if (count > 0)
                {
                    SQLcom = "SELECT id_card FROM cards WHERE id_fingerprintable = @id and `delete` = 0";
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    string message = "";
                    while (reader.Read())
                    {
                        message += "№" + reader[0].ToString() + ". ";
                    }
                    MessageBox.Show("Невозможно удалить дактилоскопируемого, так как он привязан к карте: " + message + "\nСначала удалите данную карту, а потом дактилоскопируемого", "Ошибка удаления");
                }
                else
                {
                    SQLcom = "UPDATE fingerprintables SET `delete` = 1 WHERE id_fingerprintable = @id";
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (oldS != null || oldN != null || oldP != null)
                    {
                        cmd.CommandText = "SELECT id_fingerprintable, surname, `name`, patronymic, birthdate, id_worker FROM fingerprintables WHERE surname LIKE @s and `name` LIKE @n and patronymic LIKE @p and `delete` = 0";
                        cmd.Parameters.AddWithValue("@s", "%" + oldS + "%");
                        cmd.Parameters.AddWithValue("@n", "%" + oldN + "%");
                        cmd.Parameters.AddWithValue("@p", "%" + oldP + "%");
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        bindingSorce.DataSource = dataset.Tables[0];
                        fingerprintablesTable.DataSource = bindingSorce;
                    }
                }
                con.Close();
                cmd.Parameters.Clear();
                UpdateF();
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
            DataBank.id_fingerprintable = int.Parse(fingerprintablesTable.CurrentRow.Cells[0].Value.ToString());
            DataBank.fcreator = int.Parse(fingerprintablesTable.CurrentRow.Cells[5].Value.ToString());
            viewFingerprintable vf = new viewFingerprintable();
            vf.form = this;
            vf.Owner = this;
            vf.TopLevel = true;
            vf.Show();
            Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            addFingerprintable af = new addFingerprintable();
            af.form = this;
            af.TopLevel = true;
            af.Show();
            Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void fingerprintablesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }

        private void snpSrch_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            BindingSource bindingSorce = new BindingSource();
            MySqlConnection con = new MySqlConnection(conString);
            cmd.Connection = con;
            if (fieldN.Text != "" || fieldS.Text != "" || fieldP.Text != "")
            {
                cmd.CommandText = "SELECT id_fingerprintable, surname, `name`, patronymic, birthdate, id_worker FROM fingerprintables WHERE surname LIKE @s and `name` LIKE @n and patronymic LIKE @p and `delete` = 0";
                cmd.Parameters.AddWithValue("@s", "%" + fieldS.Text + "%");
                cmd.Parameters.AddWithValue("@n", "%" + fieldN.Text + "%");
                cmd.Parameters.AddWithValue("@p", "%" + fieldP.Text + "%");
                oldS = fieldS.Text;
                oldN = fieldN.Text;
                oldP = fieldP.Text;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                bindingSorce.DataSource = dataset.Tables[0];
                fingerprintablesTable.DataSource = bindingSorce;
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
            cmd.CommandText = "SELECT id_fingerprintable, surname, `name`, patronymic, birthdate, id_worker FROM fingerprintables WHERE `delete` = 0";
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            bindingSorce.DataSource = dataset.Tables[0];
            fingerprintablesTable.DataSource = bindingSorce;
            cmd.Parameters.Clear();
            UpdateF();
            fieldS.Clear(); oldS = null;
            fieldN.Clear(); oldN = null;
            fieldP.Clear(); oldP = null;
        }

        private void fingerprintablesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }

        private void fingerprintablesTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }

        private void fieldS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }
    }
}
