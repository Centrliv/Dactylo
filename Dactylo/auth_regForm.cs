using System;
using System.Data;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace Dactylo
{
    public partial class auth_regForm : Form
    {
        public auth_regForm()
        {
            InitializeComponent();
        }

        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void log_in_Click(object sender, EventArgs e)
        {
            string login, password;
            login = alog.Text.ToString();
            password = apass.Text.ToString();
            if (login != "" && password != "")
            {
                MySqlConnection con = new MySqlConnection(conString);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string SQLcom = "SELECT count(*) FROM workers WHERE login = @Log and password = @Pass";
                con.Open();
                cmd.Parameters.AddWithValue("@Log", login);
                cmd.Parameters.AddWithValue("@Pass", password);
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                long count = (long)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                con.Close();
                if (count > 0)
                {
                    int del = 0;
                    string SQLcoma = "SELECT workers.delete FROM workers WHERE login = @Log";
                    con.Open();
                    cmd.Parameters.AddWithValue("@Log", login);
                    cmd.Connection = con;
                    cmd.CommandText = SQLcoma;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(table);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        del = Convert.ToInt32(rdr[0].ToString());
                    }
                    if (del == 0)
                    {
                        string SQLcomm = "SELECT surname, name, patronymic, position, id_worker FROM workers WHERE login = @Log";
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = SQLcomm;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(table);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DataBank.ussur = reader[0].ToString();
                            DataBank.usname = reader[1].ToString();
                            DataBank.uspatr = reader[2].ToString();
                            DataBank.uspos = Convert.ToInt32(reader[3].ToString());
                            DataBank.usid = Convert.ToInt32(reader[4].ToString());
                        }
                        cmd.Parameters.Clear();
                        con.Close();
                        alog.Clear(); apass.Clear();
                        mainForm mf = new mainForm();
                        mf.form = this;
                        mf.Owner = this;
                        mf.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ваш аккаунт удален. Обратитесь к преподавателю.", "Ошибка входа");
                        cmd.Parameters.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Не удаётся войти. \nПожалуйста, проверьте правильность написания логина и пароля.", "Ошибка входа");
                    cmd.Parameters.Clear();
                }
            }
            else MessageBox.Show("Одно или несколько полей не заполнены");
        }

        private void reg_Click(object sender, EventArgs e)
        {
            string surname, name, patronymic, login, fpassword, spassword;
            surname = sur.Text.Trim().ToString();
            name = nam.Text.Trim().ToString();
            patronymic = patr.Text.Trim().ToString();
            login = rlog.Text.ToString();
            fpassword = rpass.Text.ToString();
            spassword = rconfpass.Text.ToString();
            if (surname != "" && name != "" && login != "" && fpassword != "" && spassword != "")
            {
                if (fpassword == spassword)
                {
                    MySqlConnection con = new MySqlConnection(conString);
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    string SQLcom = "SELECT count(*) FROM workers WHERE login = @Log";                    
                    con.Open();
                    cmd.Parameters.AddWithValue("@Log", login);
                    cmd.Connection = con;
                    cmd.CommandText = SQLcom;
                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка регистрации");
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                    else
                    {
                        string SQLcom2 = "INSERT INTO workers (surname, name, patronymic, position, login, password, workers.delete) VALUES (@Sn, @N, @P, @Pos, @Log, @Pass, 0)";
                        con.Open();
                        cmd.Parameters.AddWithValue("@Sn", surname);
                        cmd.Parameters.AddWithValue("@N", name);
                        cmd.Parameters.AddWithValue("@P", patronymic);
                        cmd.Parameters.AddWithValue("@Pos", 0);
                        cmd.Parameters.AddWithValue("@Log", login);
                        cmd.Parameters.AddWithValue("@Pass", fpassword);
                        cmd.CommandText = SQLcom2;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(table);
                        cmd.Parameters.Clear();
                        con.Close();
                        sur.Clear(); nam.Clear(); patr.Clear(); rlog.Clear(); rpass.Clear(); rconfpass.Clear();
                        auth_reg.SelectedTab = authPage;
                        MessageBox.Show("Регистрация прошла успешно \nТеперь Вы можете авторизоваться по указанным логину и паролю", "Успех");
                    }
                }
                else MessageBox.Show("Пароли не совпадают", "Ошибка");
            }
            else MessageBox.Show("Поля со знаком \" * \" (звездочка) обязательны к заполнению", "Не все поля заполнены");
        }

        private void alog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void auth_reg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (auth_reg.SelectedIndex == 0)
            {
                sur.Clear(); nam.Clear(); patr.Clear(); rlog.Clear(); rpass.Clear(); rconfpass.Clear();
            }
            else
            {
                alog.Clear(); apass.Clear();
            }
        }
    }
}
