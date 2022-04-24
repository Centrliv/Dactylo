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
    public partial class accountForm : Form
    {
        public accountForm()
        {
            InitializeComponent();
        }

        public mainForm form;
        public usersForm form2;
        string oldpass, oldlog, oldsur, oldnam, oldpatr;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void chlog_CheckedChanged(object sender, EventArgs e)
        {
            log.ReadOnly = chlog.Checked ? false : true;
        }

        private void log_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void accountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                form2.UpdateF();
            }
            catch
            {

            }
        }

        private void chpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chpass.Checked)
            {
                opass.ReadOnly = false;
                rpass.ReadOnly = false;
                rconfpass.ReadOnly = false;
            }
            else
            {
                opass.ReadOnly = true;
                rpass.ReadOnly = true;
                rconfpass.ReadOnly = true;
                opass.Clear();
                rpass.Clear();
                rconfpass.Clear();
            }
        }

        private void pedit_Click(object sender, EventArgs e)
        {
            if (pedit.Text == "Редактировать")
            {
                sur.ReadOnly = false; nam.ReadOnly = false; patr.ReadOnly = false;
                pedit.Text = "Сохранить";
            }
            else
            {
                string surname = sur.Text.Trim();
                string name = nam.Text.Trim();
                string patronymic = patr.Text.Trim();

                if (surname != oldsur || name != oldnam || patronymic != oldpatr)
                {
                    DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    TopMost = true;
                    if (result == DialogResult.Yes)
                    {
                        if (surname != "" && name != "")
                        {
                            MySqlConnection con = new MySqlConnection(conString);
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string SQLcom = "UPDATE workers SET surname = @S, `name` = @N, patronymic = @P WHERE id_worker = @idw";
                            con.Open();
                            cmd.Parameters.AddWithValue("@S", surname);
                            cmd.Parameters.AddWithValue("@N", name);
                            cmd.Parameters.AddWithValue("@P", patronymic);
                            cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            adapter.SelectCommand = cmd;
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            cmd.Parameters.Clear();
                            con.Close();
                            sur.ReadOnly = true; nam.ReadOnly = true; patr.ReadOnly = true;
                            oldsur = surname; DataBank.ussur = surname;
                            oldnam = name; DataBank.usname = name;
                            oldpatr = patronymic; DataBank.uspatr = patronymic;
                            pedit.Text = "Редактировать";
                        }
                        else MessageBox.Show("Поля Фамилия и Имя не должны быть пустыми", "Пустые поля");
                    }
                }
                else
                {
                    sur.ReadOnly = true; nam.ReadOnly = true; patr.ReadOnly = true;
                    pedit.Text = "Редактировать";
                }
            }
        }

        private void accountForm_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = string.Format("SELECT surname, name, patronymic, login, password FROM workers WHERE id_worker = {0}", DataBank.usid);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
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
                oldpass = reader[4].ToString();
            }
            cmd.Parameters.Clear();
            con.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (aedit.Text == "Редактировать")
            {
                chlog.Enabled = true; chpass.Enabled = true;
                aedit.Text = "Сохранить";
            }
            else
            {
                string login = log.Text.Trim();
                string oldpassword = opass.Text.Trim();
                string pass1 = rpass.Text.Trim();
                string pass2 = rconfpass.Text.Trim();

                if (chlog.Checked && chpass.Checked == false)
                {
                    if (login != "")
                    {
                        if (login != oldlog)
                        {
                            DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            TopMost = true;
                            if (result == DialogResult.Yes)
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
                                    SQLcom = "UPDATE workers SET login = @L WHERE id_worker = @idw";
                                    con.Open();
                                    cmd.Parameters.AddWithValue("@L", login);
                                    cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    DataTable table = new DataTable();
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                    chlog.Checked = false; chlog.Enabled = false;
                                    oldlog = login;
                                }
                            }
                        }
                        else
                        {
                            aedit.Text = "Редактировать";
                            chlog.Checked = false;
                            chlog.Enabled = false;
                        }
                    }
                    else MessageBox.Show("Поле Логин не должно быть пустым", "Пустое поле");
                }
                if (chlog.Checked == false && chpass.Checked)
                {
                    if (oldpassword != "" && pass1 != "" && pass2 != "")
                    {
                        if (oldpassword == oldpass)
                        {
                            if (pass2 == pass1)
                            {
                                if (pass1 != oldpassword)
                                {
                                    DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                    TopMost = true;
                                    if (result == DialogResult.Yes)
                                    {
                                        MySqlConnection con = new MySqlConnection(conString);
                                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                                        string SQLcom = "UPDATE workers SET password = @Pass WHERE id_worker = @idw";
                                        con.Open();
                                        cmd.Parameters.AddWithValue("@Pass", pass1);
                                        cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                                        cmd.Connection = con;
                                        cmd.CommandText = SQLcom;
                                        adapter.SelectCommand = cmd;
                                        DataTable table = new DataTable();
                                        adapter.Fill(table);
                                        cmd.Parameters.Clear();
                                        con.Close();
                                        chpass.Checked = false; chpass.Enabled = false;
                                        oldpass = pass1;
                                    }
                                }
                                else MessageBox.Show("Старый и новый пароль совпадают.", "Ошибка");
                            }
                            else MessageBox.Show("Новый пароль повторен неправильно.", "Неверный пароль");
                        }
                        else MessageBox.Show("Прежний пароль введен неправильно. \nЕсли Вы его забыли, обратитесь к преподавателю.", "Неверный пароль");
                    }
                    else MessageBox.Show("Поля Старый пароль, Новый пароль и Подтверждение пароля не должны быть пустыми.", "Пустые поля");
                }
                if (chlog.Checked && chpass.Checked)
                {
                    if (login != "" && oldpassword != "" && pass1 != "" && pass2 != "")
                    {
                        if (login == oldlog)
                        {
                            if (oldpassword == oldpass)
                            {
                                if (pass2 == pass1)
                                {
                                    if (pass1 != oldpass)
                                    {
                                        DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                        TopMost = true;
                                        if (result == DialogResult.Yes)
                                        {
                                            MySqlConnection con = new MySqlConnection(conString);
                                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                                            string SQLcom = "UPDATE workers SET password = @Pass WHERE id_worker = @idw";
                                            con.Open();
                                            cmd.Parameters.AddWithValue("@Pass", pass1);
                                            cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                                            cmd.Connection = con;
                                            cmd.CommandText = SQLcom;
                                            adapter.SelectCommand = cmd;
                                            DataTable table = new DataTable();
                                            adapter.Fill(table);
                                            cmd.Parameters.Clear();
                                            con.Close();
                                            chpass.Checked = false; chpass.Enabled = false;
                                            chlog.Checked = false; chlog.Enabled = false;
                                            oldpass = pass1;
                                        }
                                    }
                                    else MessageBox.Show("Старый и новый пароли совпадают.", "Ошибка");
                                }
                                else MessageBox.Show("Новый пароль повторен неправильно.", "Неверный пароль");
                            }
                            else MessageBox.Show("Прежний пароль введен неправильно. \nЕсли Вы его забыли, обратитесь к преподавателю.", "Неверный пароль");
                        }
                        else
                        {
                            if (oldpassword == oldpass)
                            {
                                if (pass2 == pass1)
                                {
                                    if (pass1 != oldpass)
                                    {
                                        DialogResult result = MessageBox.Show("Сохранить внесенные изменения?", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                        TopMost = true;
                                        if (result == DialogResult.Yes)
                                        {
                                            MySqlConnection con = new MySqlConnection(conString);
                                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                                            string SQLcom = "UPDATE workers SET login = @L, password = @Pass WHERE id_worker = @idw";
                                            con.Open();
                                            cmd.Parameters.AddWithValue("@L", login);
                                            cmd.Parameters.AddWithValue("@Pass", pass1);
                                            cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                                            cmd.Connection = con;
                                            cmd.CommandText = SQLcom;
                                            adapter.SelectCommand = cmd;
                                            DataTable table = new DataTable();
                                            adapter.Fill(table);
                                            cmd.Parameters.Clear();
                                            con.Close();
                                            chpass.Checked = false; chpass.Enabled = false;
                                            chlog.Checked = false; chlog.Enabled = false;
                                            opass.Clear(); rpass.Clear(); rconfpass.Clear();
                                            oldpass = pass1;
                                        }
                                    }
                                    else MessageBox.Show("Старый и новый пароли совпадают.", "Ошибка");
                                }
                            }
                            else MessageBox.Show("Прежний пароль введен неправильно. \nЕсли Вы его забыли, обратитесь к преподавателю.", "Неверный пароль");
                        }
                    }
                    else MessageBox.Show("Поля Логин, Старый пароль, Новый пароль и Подтверждение пароля не должны быть пустыми.", "Пустые поля");
                }
                if (chlog.Checked == false && chpass.Checked == false)
                {
                    aedit.Text = "Редактировать";
                    chpass.Enabled = false;
                    chlog.Enabled = false;
                }
            }
        }
    }
}