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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }
        public usersForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        private void close_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string surname, name, patronymic, login, fpassword, spassword;
            int status;
            surname = sur.Text.Trim().ToString();
            name = nam.Text.Trim().ToString();
            patronymic = patr.Text.Trim().ToString();
            login = log.Text.ToString();
            fpassword = rpass.Text.ToString();
            spassword = rconfpass.Text.ToString();
            status = stat.SelectedIndex;
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
                        MessageBox.Show("Введенный логином уже занят", "Ошибка регистрации");
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                    else
                    {
                        SQLcom = "INSERT INTO workers (surname, name, patronymic, position, login, password, `delete`) VALUES (@Sn, @N, @P, @Pos, @Log, @Pass, 0)";
                        con.Open();
                        cmd.Parameters.AddWithValue("@Sn", surname);
                        cmd.Parameters.AddWithValue("@N", name);
                        cmd.Parameters.AddWithValue("@P", patronymic);
                        cmd.Parameters.AddWithValue("@Pos", status);
                        cmd.Parameters.AddWithValue("@Log", login);
                        cmd.Parameters.AddWithValue("@Pass", fpassword);
                        cmd.CommandText = SQLcom;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(table);
                        cmd.Parameters.Clear();
                        con.Close();
                        sur.Clear(); nam.Clear(); patr.Clear(); log.Clear(); rpass.Clear(); rconfpass.Clear();
                        MessageBox.Show("Регистрация прошла успешно \nТеперь пользователь может авторизоваться по указанным логину и паролю", "Успех");
                        Hide();
                        form.cellChech();
                        form.UpdateF();
                    }
                }
                else MessageBox.Show("Пароли не совпадают", "Ошибка");
            }
            else MessageBox.Show("Поля со знаком \" * \" (звездочка) обязательны к заполнению", "Не все поля заполнены");
        }

        private void addUser_Load(object sender, EventArgs e)
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
                stat.Items.Add(reader[0].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
            stat.SelectedIndex = 0;
        }

        private void addUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }

        private void log_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }
    }
}
