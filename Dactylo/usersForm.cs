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
    public partial class usersForm : Form
    {
        public usersForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public mainForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void add_Click(object sender, EventArgs e)
        {
            addUser au = new addUser();
            au.form = this;
            au.Owner = this;
            au.TopLevel = true;
            au.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить выбранного пользователя?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            TopMost = true;
            if (result == DialogResult.Yes)
            {
                int del = int.Parse(usersTable.CurrentRow.Cells[0].Value.ToString());

                MySqlConnection con = new MySqlConnection(conString);
                BindingSource bindingSorce = new BindingSource();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string SQLcom = "SELECT count(*) FROM cards WHERE id_worker = @id and `delete` = 0";
                cmd.Parameters.AddWithValue("@id", del);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                long count = (long)cmd.ExecuteScalar();
                if (count > 0)
                {
                    SQLcom = "SELECT id_card FROM cards WHERE id_worker = @id and `delete` = 0";
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
                    MessageBox.Show("Невозможно удалить пользователя, так как он привязан к картам: " + message + "\nСначала удалите карты, а потом пользователя", "Ошибка удаления");
                }
                else
                {
                    SQLcom = "SELECT count(*) FROM bases WHERE id_worker = @id and `delete` = 0";
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        SQLcom = "SELECT id_base FROM bases WHERE id_worker = @id and `delete` = 0";
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
                        MessageBox.Show("Невозможно удалить пользователя, так как он привязан к основаниям проведения дактилорегистрации: " + message + "\nСначала удалите основания, а потом пользователя", "Ошибка удаления");
                    }
                    else
                    {
                        SQLcom = "SELECT count(*) FROM fingerprintables WHERE id_worker = @id and `delete` = 0";
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = SQLcom;
                        count = (long)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            SQLcom = "SELECT id_fingerprintable FROM fingerprintables WHERE id_worker = @id and `delete` = 0";
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
                            MessageBox.Show("Невозможно удалить пользователя, так как он привязан к дактилоскопируемым: " + message + "\nСначала удалите дактилоскопируемых, а потом пользователя", "Ошибка удаления");
                        }
                        else
                        {
                            SQLcom = "UPDATE workers SET `delete` = 1 WHERE id_worker = @id";
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            adapter.SelectCommand = cmd;
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            MessageBox.Show("Пользователь успешно удален.", "Успех");
                        }
                    }
                }
                con.Close();
                cmd.Parameters.Clear();
                UpdateF();
                cellChech();
            }
        }

        private void usersForm_Load(object sender, EventArgs e)
        {
            UpdateF();
            cellChech();
        }

        public void UpdateF()
        {
            this.v_usersTableAdapter.Fill(this.dactylo_dbDataSet.v_users);
        }

        public void cellChech()
        {
            if (Convert.ToInt32(usersTable.CurrentRow.Cells[0].Value.ToString()) != DataBank.usid)
            {
                if (Convert.ToInt32(usersTable.CurrentRow.Cells[6].Value.ToString()) >= DataBank.uspos)
                {
                    edit.Enabled = false;
                    delete.Enabled = false;
                }
                else
                {
                    edit.Enabled = true;
                    delete.Enabled = true;
                }
            }
            else
            {
                edit.Enabled = true;
                delete.Enabled = false;
            }
        }

        private void usersTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (DataBank.usid == int.Parse(usersTable.CurrentRow.Cells[0].Value.ToString()))
            {
                accountForm af = new accountForm();
                af.form2 = this;
                af.Owner = this;
                af.TopLevel = true;
                af.ShowDialog();
            }
            else
            {
                DataBank.workid = int.Parse(usersTable.CurrentRow.Cells[0].Value.ToString());
                editUser eu = new editUser();
                eu.form = this;
                eu.Owner = this;
                eu.TopLevel = true;
                eu.Show();
            }
        }

        private void usersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellChech();
        }

        private void usersTable_Click(object sender, EventArgs e)
        {
            cellChech();
        }

        private void usersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }
    }
}
