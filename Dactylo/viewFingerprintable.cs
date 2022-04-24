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
    public partial class viewFingerprintable : Form
    {
        public viewFingerprintable()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public fingerprintablesForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        string osur, onam, opatr, ocit, obirthpl, oreg;
        int osex;
        DateTime obirth;

        private void add_Click(object sender, EventArgs e)
        {
            if (edit.Text == "Редактировать")
            {
                sur.ReadOnly = false;
                nam.ReadOnly = false;
                patr.ReadOnly = false;
                sx.Enabled = true;
                birth.Enabled = true;
                citsh.ReadOnly = false;
                birthpl.ReadOnly = false;
                regpl.ReadOnly = false;
                edit.Text = "Сохранить";
            }
            else if (edit.Text == "Сохранить")
            {
                string surname = sur.Text.Trim();
                string name = nam.Text.Trim();
                string patronymic = patr.Text.Trim();
                int sex = sx.SelectedIndex;
                DateTime birthdate = birth.Value;
                string citizenship = citsh.Text.Trim();
                string birthplace = birthpl.Text.Trim();
                string regplace = regpl.Text.Trim();
                if (surname != osur || name != onam || patronymic != opatr || sex != osex || birthdate != obirth || citizenship != ocit || birthplace != obirthpl || regplace != oreg)
                {
                    if (surname != "" && name != "" && patronymic != "" && citizenship != "" && birthplace != "" && regplace != "")
                    {
                        DialogResult result = MessageBox.Show("Сохранить внесенные изменения", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        TopMost = true;
                        if (result == DialogResult.Yes)
                        {
                            MySqlConnection con = new MySqlConnection(conString);
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string SQLcom = "UPDATE fingerprintables SET surname = @S, name = @N, patronymic = @P, sex = @Sx, citizenship = @C, birthdate = @Bd, birthplace = @Bp, regplace = @R WHERE id_fingerprintable = @id";
                            con.Open();
                            cmd.Parameters.AddWithValue("@S", surname);
                            cmd.Parameters.AddWithValue("@N", name);
                            cmd.Parameters.AddWithValue("@P", patronymic);
                            cmd.Parameters.AddWithValue("@Sx", sex);
                            cmd.Parameters.AddWithValue("@C", citizenship);
                            cmd.Parameters.AddWithValue("@Bd", birthdate.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Bp", birthplace);
                            cmd.Parameters.AddWithValue("@R", regplace);
                            cmd.Parameters.AddWithValue("@id", DataBank.id_fingerprintable);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            adapter.SelectCommand = cmd;
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            cmd.Parameters.Clear();
                            con.Close();
                            form.UpdateF();
                            sur.ReadOnly = true;
                            nam.ReadOnly = true;
                            patr.ReadOnly = true;
                            sx.Enabled = false;
                            birth.Enabled = false;
                            citsh.ReadOnly = true;
                            birthpl.ReadOnly = true;
                            regpl.ReadOnly = true;
                            edit.Text = "Редактировать";
                        }
                    }
                    else MessageBox.Show("Не все обязательные поля заполнены", "Ошибка");
                }
                else
                {
                    sur.ReadOnly = true;
                    nam.ReadOnly = true;
                    patr.ReadOnly = true;
                    sx.Enabled = false;
                    birth.Enabled = false;
                    citsh.ReadOnly = true;
                    birthpl.ReadOnly = true;
                    regpl.ReadOnly = true;
                    edit.Text = "Редактировать";
                }
            }
        }

        private void addFingerprintable_Load(object sender, EventArgs e)
        {
            edit.Enabled = DataBank.usid == DataBank.fcreator || DataBank.uspos >= 1 ? true : false;
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
