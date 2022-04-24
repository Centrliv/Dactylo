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
    public partial class viewCard : Form
    {
        public viewCard()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public cardsForm form;
        string path;
        int ofpl, obase, idw;
        string oform, oformcl, ont;
        string[] oFing = new string[14];
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
            else
            {
                pb.ImageLocation = null;
                pb.Tag = "";
            }
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

        public void deleteYaDisk(string yadiskpath)
        {
            string url = "https://cloud-api.yandex.net/v1/disk/resources/?path=/Fingers/";

            string authHeader = "OAuth AgAAAABASrkrAAZTA0np5GtdZUW1hHO1OHiUFiQ";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + yadiskpath + "&permanently=true");
            request.PreAuthenticate = true;
            request.Method = "GET";
            request.Headers.Add("Authorization", authHeader);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamResponse = response.GetResponseStream();
            streamResponse.Close();
            response.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            var Pic = new PictureBox[]{pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,
                pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10,pictureBox11,pictureBox12,
                pictureBox13,pictureBox14};
            if (edit.Text == "Редактировать")
            {
                frmcl.ReadOnly = false;
                frmd.ReadOnly = false;
                nt.ReadOnly = false;
                dbase.Enabled = true;
                for (int i = 0; i < 14; i++)
                {
                    Pic[i].Enabled = true;
                }
                edit.Text = "Сохранить";
            }
            else if (edit.Text == "Сохранить")
            {
                string idbase = dbase.Text.IndexOf(" ").ToString();
                idbase = dbase.Text.Substring(1, int.Parse(idbase));
                string dform = frmd.Text.Trim();
                string formcl = frmcl.Text.Trim();
                string note = nt.Text.Trim();

                if (int.Parse(idbase) != obase || dform != oform || formcl != oformcl || note != ont)
                {
                    DialogResult result = MessageBox.Show("Сохранить внесенные изменения", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    TopMost = true;
                    if (result == DialogResult.Yes)
                    {
                        string[] iFing = { "lt", "li", "lm", "ll", "lr", "rt", "ri", "rm", "rl", "rr", "lcontrol", "rcontrol", "lpalm", "rpalm" };

                        MySqlConnection con = new MySqlConnection(conString);
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();

                        string SQLcom = "UPDATE cards SET id_base = @idb, formula = @F, formclass = @Fc, note = @N WHERE id_card = @idc";
                        con.Open();
                        cmd.Parameters.AddWithValue("@idb", int.Parse(idbase));
                        cmd.Parameters.AddWithValue("@F", dform);
                        cmd.Parameters.AddWithValue("@Fc", formcl);
                        cmd.Parameters.AddWithValue("@N", note);
                        cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                        cmd.Connection = con;
                        cmd.CommandText = SQLcom;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(table);
                        cmd.Parameters.Clear();
                        con.Close();
                        int schn = 0, schnn = 0, sch = 0;
                        for (int i = 0; i < 14; i++)
                        {
                            if (Pic[i].ImageLocation == null && oFing[i] != null)
                            {
                                schn += 1;
                            }
                            if (Pic[i].ImageLocation != null && oFing[i] == null)
                            {
                                schnn += 1;
                            }
                            if (Pic[i].ImageLocation != oFing[i] && Pic[i].ImageLocation != null && oFing[i] != null)
                            {
                                sch += 1;
                            }
                        }
                        if (schn > 0 || schnn > 0 || sch > 0)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                if (Pic[i].ImageLocation != null && oFing[i] != null)
                                {
                                    if (Pic[i].ImageLocation.Contains(oFing[i]) == false)
                                    {
                                        string yadiskpath = oFing[i];
                                        deleteYaDisk(yadiskpath);
                                        yadiskpath = iFing[i] + Pic[i].Tag.ToString();
                                        string path = Pic[i].ImageLocation.ToString();
                                        uploadYaDisk(yadiskpath, path);
                                        SQLcom = string.Format("UPDATE cards SET {0} = '{1}' WHERE id_card = @idc", iFing[i], yadiskpath);
                                        cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                        cmd.Connection = con;
                                        cmd.CommandText = SQLcom;
                                        adapter.SelectCommand = cmd;
                                        adapter.Fill(table);
                                        cmd.Parameters.Clear();
                                        con.Close();
                                    }
                                }
                                if (Pic[i].ImageLocation == null && oFing[i] != null)
                                {
                                    SQLcom = string.Format("UPDATE cards SET {0} = NULL WHERE id_card = @idc", iFing[i]);
                                    cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                    deleteYaDisk(oFing[i]);
                                    oFing[i] = null;
                                }
                                if (Pic[i].ImageLocation != null && oFing[i] == null)
                                {
                                    string yadiskpath = iFing[i] + Pic[i].Tag.ToString();
                                    string path = Pic[i].ImageLocation.ToString();
                                    uploadYaDisk(yadiskpath, path);
                                    SQLcom = string.Format("UPDATE cards SET {0} = '{1}' WHERE id_card = @idc", iFing[i], yadiskpath);
                                    cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                }
                            }
                        }
                    }
                    frmcl.ReadOnly = true;
                    frmd.ReadOnly = true;
                    nt.ReadOnly = true;
                    dbase.Enabled = false;
                    for (int i = 0; i < 14; i++)
                    {
                        Pic[i].Enabled = false;
                    }
                    edit.Text = "Редактировать";
                }
                else if (int.Parse(idbase) != -1 || dform != "" || formcl != "" || note != "")
                {
                    string[] iFing = { "lt", "li", "lm", "ll", "lr", "rt", "ri", "rm", "rl", "rr", "lcontrol", "rcontrol", "lpalm", "rpalm" };

                    MySqlConnection con = new MySqlConnection(conString);
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    int schn = 0, schnn = 0, sch = 0;
                    for (int i = 0; i < 14; i++)
                    {
                        if (Pic[i].ImageLocation == null && oFing[i] != null)
                        {
                            schn += 1;
                        }
                        if (Pic[i].ImageLocation != null && oFing[i] == null)
                        {
                            schnn += 1;
                        }
                        if (Pic[i].ImageLocation != oFing[i] && Pic[i].ImageLocation != null && oFing[i] != null)
                        {
                            sch += 1;
                        }
                    }
                    if (schn > 0 || schnn > 0 || sch > 0)
                    {
                        DialogResult result = MessageBox.Show("Сохранить внесенные изменения", "Подверждение сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        TopMost = true;
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                if (Pic[i].ImageLocation != null && oFing[i] != null)
                                {
                                    if (Pic[i].ImageLocation.Contains(oFing[i]) == false)
                                    {
                                        string yadiskpath = oFing[i];
                                        deleteYaDisk(yadiskpath);
                                        yadiskpath = iFing[i] + Pic[i].Tag.ToString();
                                        string path = Pic[i].ImageLocation.ToString();
                                        uploadYaDisk(yadiskpath, path);
                                        string SQLcom = string.Format("UPDATE cards SET {0} = '{1}' WHERE id_card = @idc", iFing[i], yadiskpath);
                                        cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                        cmd.Connection = con;
                                        cmd.CommandText = SQLcom;
                                        adapter.SelectCommand = cmd;
                                        adapter.Fill(table);
                                        cmd.Parameters.Clear();
                                        con.Close();
                                    }
                                }
                                if (Pic[i].ImageLocation == null && oFing[i] != null)
                                {
                                    string SQLcom = string.Format("UPDATE cards SET {0} = NULL WHERE id_card = @idc", iFing[i]);
                                    cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                    deleteYaDisk(oFing[i]);
                                    oFing[i] = null;
                                }
                                if (Pic[i].ImageLocation != null && oFing[i] == null)
                                {
                                    string yadiskpath = iFing[i] + Pic[i].Tag.ToString();
                                    string path = Pic[i].ImageLocation.ToString();
                                    uploadYaDisk(yadiskpath, path);
                                    string SQLcom = string.Format("UPDATE cards SET {0} = '{1}' WHERE id_card = @idc", iFing[i], yadiskpath);
                                    cmd.Parameters.AddWithValue("@idc", DataBank.id_card);
                                    cmd.Connection = con;
                                    cmd.CommandText = SQLcom;
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(table);
                                    cmd.Parameters.Clear();
                                    con.Close();
                                }
                            }
                        }
                        frmcl.ReadOnly = true;
                        frmd.ReadOnly = true;
                        nt.ReadOnly = true;
                        dbase.Enabled = false;
                        for (int i = 0; i < 14; i++)
                        {
                            Pic[i].Enabled = false;
                        }
                        edit.Text = "Редактировать";
                    }
                }
                else MessageBox.Show("Не все обязательные поля заполнены.", "Ошибка");
            }            
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            form.UpdateF();
            Hide();
        }

        private void vfpl_Click(object sender, EventArgs e)
        {
            new vFingerprintable().ShowDialog();
        }

        private void addCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            form.UpdateF();
            Hide();
        }

        private void addCard_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            MySqlConnection con = new MySqlConnection(conString);
            cmd.Connection = con;
            con.Open();
            string SQLcom = "SELECT id_base, cards.id_fingerprintable, surname, `name`, patronymic, formula, formclass, note, cards.id_worker, "
            + "lt, li, lm, ll, lr, rt, ri, rm, rl, rr, lcontrol, rcontrol, lpalm, rpalm "
            + "FROM cards, fingerprintables WHERE cards.id_fingerprintable = fingerprintables.id_fingerprintable and id_card = @id and cards.`delete` = 0";
            cmd.Parameters.AddWithValue("@id", DataBank.id_card);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obase = int.Parse(reader[0].ToString());
                ofpl = int.Parse(reader[1].ToString());
                DataBank.id_fingerprintable = int.Parse(reader[1].ToString());
                fpl.Text = reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();
                oform = reader[5].ToString();
                frmd.Text = reader[5].ToString();
                oformcl = reader[6].ToString();
                frmcl.Text = reader[6].ToString();
                ont = reader[7].ToString();
                nt.Text = reader[7].ToString();
                idw = int.Parse(reader[8].ToString());
                for (int i = 9; i < 23; i++)
                {
                    if (reader[i].ToString() != "")
                    {
                        var Pic = new PictureBox[]{pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,
                            pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10,pictureBox11,pictureBox12,
                            pictureBox13,pictureBox14};
                        string href = "";
                        string filename = reader[i].ToString();
                        string url = "https://cloud-api.yandex.net/v1/disk/resources/download?path=/Fingers/";
                        string url2 = "&fields=href";
                        string authHeader = "OAuth AgAAAABASrkrAAZTA0np5GtdZUW1hHO1OHiUFiQ";
                        HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url + filename + url2);
                        myHttpWebRequest.PreAuthenticate = true;
                        myHttpWebRequest.Method = "GET";
                        myHttpWebRequest.Headers.Add("Authorization", authHeader);
                        HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                        Stream streamResponse = myHttpWebResponse.GetResponseStream();
                        StreamReader streamRead = new StreamReader(streamResponse);
                        Char[] readBuff = new Char[1000];
                        int count = streamRead.Read(readBuff, 0, 1000);
                        while (count > 0)
                        {
                            String outputData = new String(readBuff, 0, count);
                            href = outputData;
                            count = streamRead.Read(readBuff, 0, 1000);
                        }
                        streamResponse.Close();
                        streamRead.Close();
                        myHttpWebResponse.Close();
                        href = href.Substring(9);
                        href = href.Substring(0, href.Length - 2);
                        Pic[i - 9].ImageLocation = href;
                        Pic[i - 9].Tag = reader[i].ToString();
                        oFing[i - 9] = reader[i].ToString();
                    }
                }
            }
            cmd.Parameters.Clear();
            con.Close();

            if (DataBank.creator != DataBank.usid)
            {
                SQLcom = "SELECT id_base, b_type, title, date FROM bases, bases_types WHERE bases.id_type = bases_types.id_type and id_worker = @idw and `delete` = 0";
                con.Open();
                cmd.Parameters.AddWithValue("@idw", DataBank.creator);
                cmd.Connection = con;
                cmd.CommandText = SQLcom;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dbase.Items.Add("№" + reader[0].ToString() + " " + reader[2].ToString() + " от " + DateTime.Parse(reader[3].ToString()).ToShortDateString() + " г.");
                    if (int.Parse(reader[0].ToString()) == obase)
                    {
                        dbase.SelectedIndex = dbase.Items.Count - 1;
                    }
                }
                cmd.Parameters.Clear();
                con.Close();
            }
            else
            {
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
                    if (int.Parse(reader[0].ToString()) == obase)
                    {
                        dbase.SelectedIndex = dbase.Items.Count - 1;
                    }
                }
                cmd.Parameters.Clear();
                con.Close();
            }

            SQLcom = "SELECT surname, `name`, patronymic FROM workers WHERE id_worker = @idw";
            con.Open();
            cmd.Parameters.AddWithValue("@idw", idw);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comp.Text = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();
            }
            cmd.Parameters.Clear();
            con.Close();
            edit.Enabled = DataBank.usid == DataBank.creator || DataBank.uspos >= 1 ? true : false;
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
    }
}
