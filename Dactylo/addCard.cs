using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Devart.Data.MySql;

namespace Dactylo
{
    public partial class addCard : Form
    {
        public addCard()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public cardsForm form;
        string path;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();

        int statusCode;
        string statusString;

        public void openclearPicture(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pb.ImageLocation == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Файлы изображений (*.bmp, *.jpg, *.png, *mpeg, *tif, *tiff)|*.bmp;*.jpg;*.png;*mpeg;*tif;*tiff";
                openFile.ShowDialog();
                path = openFile.FileName;
                pb.ImageLocation = path;
                pb.Tag = DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(path);
            }
            else pb.ImageLocation = null;
        }

        public void uploadYaDisk(string yadiskpath, string path)
        {
            string href = "";
            string url = "https://cloud-api.yandex.net/v1/disk/resources/upload?path=/Fingers/";

            string authHeader = "OAuth AgAAAABASrkrAAZTA0np5GtdZUW1hHO1OHiUFiQ";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + yadiskpath + "&fields=href");
            request.PreAuthenticate = true;
            request.Method = "GET";
            request.Headers.Add("Authorization", authHeader);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[1000];
            int count = streamRead.Read(readBuff, 0, 1000);
            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                href = outputData;
                statusCode = (int)response.StatusCode;
                statusString = (string)response.StatusDescription;
                count = streamRead.Read(readBuff, 0, 1000);
            }            
            streamResponse.Close();
            streamRead.Close();
            response.Close();

            href = href.Substring(9);
            href = href.Substring(0, href.Length - 2);

            new WebClient().UploadFile(href, path);
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (fpl.SelectedIndex != -1 && dbase.SelectedIndex != -1)
            {
                var Pic = new PictureBox[]{pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,
                pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10,pictureBox11,pictureBox12,
                pictureBox13,pictureBox14};

                string[] iFing = { "lt", "li", "lm", "ll", "lr", "rt", "ri", "rm", "rl", "rr", "lcontrol", "rcontrol", "lpalm", "rpalm" };

                string stamp = DateTime.Now.ToString("ddMMyyyyHHmmss") + DataBank.usid;
                string formula = frmd.Text.Trim();
                string formclass = frmcl.Text.Trim();
                string note = nt.Text.Trim();
                string idfing = fpl.Text.IndexOf(" ").ToString();
                idfing = fpl.Text.Substring(1, int.Parse(idfing));
                string idbase = dbase.Text.IndexOf(" ").ToString();
                idbase = dbase.Text.Substring(1, int.Parse(idbase));

                MySqlConnection con = new MySqlConnection(conString);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string SQLcom = "INSERT INTO cards (id_fingerprintable, id_base, formula, formclass, note, id_worker, stamp, `delete`) VALUES (@idf, @idb, @F, @Fc, @Nt, @idw, @S, 0)";
                con.Open();
                cmd.Parameters.AddWithValue("@idf", int.Parse(idfing));
                cmd.Parameters.AddWithValue("@idb", int.Parse(idbase));
                cmd.Parameters.AddWithValue("@F", formula);
                cmd.Parameters.AddWithValue("@Fc", formclass);
                cmd.Parameters.AddWithValue("@Nt", note);
                cmd.Parameters.AddWithValue("@idw", DataBank.usid);
                cmd.Parameters.AddWithValue("@S", stamp);
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                cmd.Parameters.Clear();
                con.Close();
                progress ps = new progress();
                ps.form = this;
                ps.Owner = this;
                ps.TopMost = true;
                ps.Show();
                for (int i = 0; i < 14; i++)
                {
                    if (Pic[i].ImageLocation != null)
                    {
                        try
                        {
                            ps.progressBar1.Value = i;
                            string yadiskpath = iFing[i] + Pic[i].Tag.ToString();
                            string path = Pic[i].ImageLocation.ToString();
                            uploadYaDisk(yadiskpath, path);
                            SQLcom = string.Format("UPDATE cards SET {0} = '{1}' WHERE stamp = @S", iFing[i], yadiskpath);
                            cmd.Parameters.AddWithValue("@S", stamp);
                            cmd.Connection = con;
                            cmd.CommandText = SQLcom;
                            adapter.SelectCommand = cmd;
                            adapter.Fill(table);
                            cmd.Parameters.Clear();
                            con.Close();
                        }
                        catch
                        {
                            
                        }
                    }
                }
                ps.Hide();
                form.Show();
                form.UpdateF();
                Hide();
            }
            else MessageBox.Show("Не все обязательные поля заполнены", "Проверка заполнения полей");
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.UpdateF();
            form.Show();
            Hide();
        }

        private void addCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }

        private void addCard_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT fingerprintables.id_fingerprintable, surname, `name`, patronymic FROM fingerprintables WHERE fingerprintables.id_fingerprintable not in (select id_fingerprintable from cards) and fingerprintables.id_worker = @idw and fingerprintables.`delete` = 0";
            cmd.Parameters.AddWithValue("@idw", DataBank.usid);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            fpl.Items.Clear();
            while (reader.Read())
            {
                fpl.Items.Add("№" + reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();

            SQLcom = "SELECT id_base, b_type, title, date FROM bases, bases_types WHERE bases.id_type = bases_types.id_type and id_worker = @idw and `delete` = 0";
            con.Open();
            cmd.Parameters.AddWithValue("@idw", DataBank.usid);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dbase.Items.Add("№" + reader[0].ToString() + " " + reader[2].ToString() + " от " + DateTime.Parse(reader[3].ToString()).ToShortDateString() + " г.");
            }
            cmd.Parameters.Clear();
            con.Close();
            comp.Text = DataBank.ussur + " " + DataBank.usname + " " + DataBank.uspatr;
        }

        private void vdbase_Click(object sender, EventArgs e)
        {
            string idbase = dbase.Text.IndexOf(" ").ToString();
            idbase = dbase.Text.Substring(1, int.Parse(idbase));
            DataBank.vbase = int.Parse(idbase);
            new vBase().ShowDialog();
        }

        private void dbase_SelectedIndexChanged(object sender, EventArgs e)
        {
            vdbase.Enabled = dbase.SelectedIndex == -1 ? false : true;
        }

        private void fpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            vCard.Enabled = fpl.SelectedIndex == -1 ? false : true;
        }

        private void vCard_Click(object sender, EventArgs e)
        {
            string idfpl = fpl.Text.IndexOf(" ").ToString();
            idfpl = fpl.Text.Substring(1, int.Parse(idfpl));
            DataBank.id_fingerprintable = int.Parse(idfpl);
            new vFingerprintable().ShowDialog();
        }
    }
}
