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
    public partial class editUser : Form
    {
        public editUser()
        {
            InitializeComponent();
        }
        public usersForm form;
        string oldlog, oldsur, oldnam, oldpatr;
        int oldpos;

        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void aedit_Click(object sender, EventArgs e)
        {
            if (aedit.Text == "Редактировать")
            {
                log.ReadOnly = false; rpass.ReadOnly = false;
                aedit.Text = "Сохранить";
            }
            else
            {
                string login = log.Text.Trim();
                string pass = rpass.Text.Trim();

                if (oldlog == login)
                {
                    if (pass == "")
                    {
                        aedit.Text = "Редактировать";
                        log.ReadOnly = true;
                        rpass.ReadOnly = true;
                        rpass.Clear();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        TopMost = true;
                        if (result == DialogResult.Yes)
                        {
                            MySqlConnection con = new MySqlConnection(conString);
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string SQLcom = "UPDATE workers SET password = @Pass WHERE id_worker = @idw";
                            con.Open();
                            cmd.Parameters.AddWithValue("@Pass", pass);
                            cmd.Parameters.AddWithValue("@idw", DataBank.workid);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            adapter.SelectCommand = cmd;
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            cmd.Parameters.Clear();
                            con.Close();
                            aedit.Text = "Редактировать";
                            log.ReadOnly = true;
                            rpass.ReadOnly = true;
                            rpass.Clear();
                            form.UpdateF();
                        }
                    }
                }
                else
                {
                    if (login != "")
                    {
                        if (pass == "")
                        {
                            MySqlConnection con = new MySqlConnection(conString);
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string SQLcom = "SELECT count(*) FROM workers WHERE login = @Log";
                            con.Open();
                            cmd.Parameters.AddWithValue("@Log", login);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            long count = (long)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("Выбранный логин уже занят", "Ошибка");
                                cmd.Parameters.Clear();
                                con.Close();
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                TopMost = true;
                                if (result == DialogResult.Yes)
                                {
                                    SQLcom = "UPDATE workers SET login = @Log WHERE id_worker = @idw";
                                    con.Open();
                                    cmd.Parameters.AddWithValue("@idw", DataBank.workid);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    DataTable table = new DataTable();
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                    aedit.Text = "Редактировать";
                                    log.ReadOnly = true;
                                    rpass.ReadOnly = true;
                                    rpass.Clear();
                                    form.UpdateF();
                                }
                            }
                        }
                        else
                        {
                            MySqlConnection con = new MySqlConnection(conString);
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string SQLcom = "SELECT count(*) FROM workers WHERE login = @Log";
                            con.Open();
                            cmd.Parameters.AddWithValue("@Log", login);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            long count = (long)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("Выбранный логин уже занят", "Ошибка");
                                cmd.Parameters.Clear();
                                con.Close();
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                TopMost = true;
                                if (result == DialogResult.Yes)
                                {
                                    SQLcom = "UPDATE workers SET login = @Log, password = @Pass WHERE id_worker = @idw";
                                    con.Open();
                                    cmd.Parameters.AddWithValue("@Pass", pass);
                                    cmd.Parameters.AddWithValue("@idw", DataBank.workid);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    DataTable table = new DataTable();
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                    aedit.Text = "Редактировать";
                                    log.ReadOnly = true;
                                    rpass.ReadOnly = true;
                                    rpass.Clear();
                                    form.UpdateF();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void rpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void viewUser_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT pos_name FROM work_position WHERE id_position < 2";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pos.Items.Add(reader[0].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();

            SQLcom = string.Format("SELECT surname, `name`, patronymic, login, password, position FROM workers WHERE id_worker = {0}", DataBank.workid);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sur.Text = reader[0].ToString();
                oldsur = reader[0].ToString();
                nam.Text = reader[1].ToString();
                oldnam = reader[1].ToString();
                patr.Text = reader[2].ToString();
                oldpatr = reader[2].ToString();
                log.Text = reader[3].ToString();
                oldlog = reader[3].ToString();
                pos.SelectedIndex = int.Parse(reader[5].ToString());
                oldpos = int.Parse(reader[5].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
        }

        private void pedit_Click(object sender, EventArgs e)
        {
            if (pedit.Text == "Редактировать")
            {
                sur.ReadOnly = false; nam.ReadOnly = false; patr.ReadOnly = false; pos.Enabled = true;
                pedit.Text = "Сохранить";
            }
            else
            {
                string surname = sur.Text.Trim();
                string name = nam.Text.Trim();
                string patronymic = patr.Text.Trim();
                int position = pos.SelectedIndex;

                if (surname != oldsur || name != oldnam || patronymic != oldpatr || position != oldpos)
                {
                    DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    TopMost = true;
                    if (result == DialogResult.Yes)
                    {
                        if (surname != "" && name != "")
                        {
                            if (oldpos != position)
                            {
                                result = MessageBox.Show("Статус пользователя в системе будет изменен. \nПродолжить?", "Подверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                TopMost = true;
                                if (result == DialogResult.Yes)
                                {
                                    MySqlConnection con = new MySqlConnection(conString);
                                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                                    string SQLcom = "UPDATE workers SET surname = @S, `name` = @N, patronymic = @P, position = @Pos WHERE id_worker = @idw";
                                    con.Open();
                                    cmd.Parameters.AddWithValue("@S", surname);
                                    cmd.Parameters.AddWithValue("@N", name);
                                    cmd.Parameters.AddWithValue("@P", patronymic);
                                    cmd.Parameters.AddWithValue("@Pos", position);
                                    cmd.Parameters.AddWithValue("@idw", DataBank.workid);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    DataTable table = new DataTable();
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();                                    
                                    form.UpdateF();
                                    if (DataBank.uspos != 2)
                                    Hide();
                                }
                            } 
                            else
                            {
                                MySqlConnection con = new MySqlConnection(conString);
                                MySqlDataAdapter adapter = new MySqlDataAdapter();
                                string SQLcom = "UPDATE workers SET surname = @S, `name` = @N, patronymic = @P WHERE id_worker = @idw";
                                con.Open();
                                cmd.Parameters.AddWithValue("@S", surname);
                                cmd.Parameters.AddWithValue("@N", name);
                                cmd.Parameters.AddWithValue("@P", patronymic);
                                cmd.Parameters.AddWithValue("@idw", DataBank.workid);
                                cmd.Connection = con;
                                cmd.CommandText = SQLcom;
                                adapter.SelectCommand = cmd;
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                cmd.Parameters.Clear();
                                con.Close();
                                sur.ReadOnly = true; nam.ReadOnly = true; patr.ReadOnly = true; pos.Enabled = false;
                                oldsur = surname;
                                oldnam = name;
                                oldpatr = patronymic;
                                pedit.Text = "Редактировать";
                                sur.ReadOnly = true; nam.ReadOnly = true; patr.ReadOnly = true; pos.Enabled = false;
                                form.UpdateF();
                            }
                        }
                        else MessageBox.Show("Поля Фамилия и Имя не должны быть пустыми", "Пустые поля");
                    }
                }
                else
                {
                    pedit.Text = "Редактировать";
                    sur.ReadOnly = true; nam.ReadOnly = true; patr.ReadOnly = true; pos.Enabled = false;
                }
            }
        }
    }
}
