using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Data;
using System.Net;
using System.Windows.Forms;
using PatternRecognition.FingerprintRecognition.Core;
using PatternRecognition.FingerprintRecognition.FeatureDisplay;
using Devart.Data.MySql;

namespace PatternRecognition.FingerprintRecognition.Applications
{
    public partial class VisualFingerprintMatchingFrm : Form
    {
        public FMExperimenterForm form;
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        double srchScore = 0;
        int idcard, match;
        string finger;
        public VisualFingerprintMatchingFrm(IMatcher matcher, IResourceProvider resourceProvider, string resourcePath)
        {
            InitializeComponent();
            this.matcher = matcher;
            provider = resourceProvider;
            this.resourcePath = resourcePath;
            repository = new ResourceRepository(resourcePath);
            WindowState = FormWindowState.Maximized;
        }

        private void btnLoadQueryImg_Click(object sender, EventArgs e)
        {
            if (pbxQueryImg.Image == null)
            {
                openFileDialog1.InitialDirectory = resourcePath;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string shortFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    try
                    {
                        qFeatures = provider.GetResource(shortFileName, repository);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to load features " + provider.GetSignature() + ". Try using different parameters.", "Feature Loading Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    qImage = ImageLoader.LoadImage(openFileDialog1.FileName);
                    pbxQueryImg.Image = qImage;
                }
            }
            else pbxQueryImg.Image = null;
        }

        public void endimg()
        {
            string href = "";
            string filename = finger;
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
            char[] readBuff = new Char[1000];
            int count = streamRead.Read(readBuff, 0, 1000);
            while (count > 0)
            {
                string outputData = new string(readBuff, 0, count);
                href = outputData;
                count = streamRead.Read(readBuff, 0, 1000);
            }
            streamResponse.Dispose();
            streamRead.Dispose();
            myHttpWebResponse.Close() ;

            href = href.Substring(9);
            href = href.Substring(0, href.Length - 2);
            string shortFileName;
            string fullFilename;
            fullFilename = "temp\\end";

            WebRequest rq = WebRequest.Create(href);
            WebResponse resp = rq.GetResponse();
            Stream rs = resp.GetResponseStream();
            Bitmap bm = new Bitmap(rs);
            bm.Save(fullFilename + ".tif");
            //using (var client = new WebClient())
            //{
            //    client.DownloadFile(href, fullFilename + ".tif");
            //}

            //Bitmap bm = new Bitmap(fullFilename + ".tif");
            string[] pack = fullFilename.Split('\\');
            string folder = pack[0];
            shortFileName = pack[1];

            repository.ResourcePath = folder + "\\";
            tFeatures = new object();
            tFeatures = provider.GetResource(shortFileName, repository);
            tImage = ImageLoader.LoadImage(fullFilename + ".tif");
            pbxTemplateImg.Image = tImage;

            File.Delete(fullFilename + ".tif");

            // Matching features
            List<MinutiaPair> matchingMtiae = null;
            double score;
            IMinutiaMatcher minutiaMatcher = matcher as IMinutiaMatcher;
            if (minutiaMatcher != null)
            {
                score = minutiaMatcher.Match(qFeatures, tFeatures, out matchingMtiae);

                if (qFeatures is List<Minutia> && tFeatures is List<Minutia>)
                {
                    pbxQueryImg.Image = qImage.Clone() as Bitmap;
                    Graphics g1 = Graphics.FromImage(pbxQueryImg.Image);
                    ShowBlueMinutiae(qFeatures as List<Minutia>, g1);

                    pbxTemplateImg.Image = tImage.Clone() as Bitmap;
                    Graphics g2 = Graphics.FromImage(pbxTemplateImg.Image);
                    ShowBlueMinutiae(tFeatures as List<Minutia>, g2);

                    if (score == 0 || matchingMtiae == null)
                    { }
                    else
                    {
                        List<Minutia> qMtiae = new List<Minutia>();
                        List<Minutia> tMtiae = new List<Minutia>();
                        foreach (MinutiaPair mPair in matchingMtiae)
                        {
                            qMtiae.Add(mPair.QueryMtia);
                            tMtiae.Add(mPair.TemplateMtia);
                        }
                        IFeatureDisplay<List<Minutia>> display = new MinutiaeDisplay();

                        display.Show(qMtiae, g1);
                        pbxQueryImg.Invalidate();

                        display.Show(tMtiae, g2);
                        pbxTemplateImg.Invalidate();

                        MessageBox.Show(string.Format("Similarity: {0}. Matching minutiae: {1}.", score,
                                                      matchingMtiae.Count));
                    }
                }
                else
                {
                    if (score == 0 || matchingMtiae == null)
                    { }
                    else
                    {
                        List<Minutia> qMtiae = new List<Minutia>();
                        List<Minutia> tMtiae = new List<Minutia>();
                        foreach (MinutiaPair mPair in matchingMtiae)
                        {
                            qMtiae.Add(mPair.QueryMtia);
                            tMtiae.Add(mPair.TemplateMtia);
                        }
                        IFeatureDisplay<List<Minutia>> display = new MinutiaeDisplay();

                        pbxQueryImg.Image = qImage.Clone() as Bitmap;
                        Graphics g = Graphics.FromImage(pbxQueryImg.Image);
                        display.Show(qMtiae, g);
                        pbxQueryImg.Invalidate();

                        pbxTemplateImg.Image = tImage.Clone() as Bitmap;
                        g = Graphics.FromImage(pbxTemplateImg.Image);
                        display.Show(tMtiae, g);
                        pbxTemplateImg.Invalidate();
                    }
                }
            }
            else
                score = matcher.Match(qFeatures, tFeatures);
        }

        private void loadimg(string url,int iter)
        {
            string shortFileName;
            string fullFilename;
            fullFilename = "temp\\temp" + iter.ToString();

            using (var client = new WebClient())
            {
                client.DownloadFile(url, fullFilename + ".tif");
            }
            
            Bitmap bm = new Bitmap(fullFilename + ".tif");
            string[] pack = fullFilename.Split('\\');
            string folder = pack[0];
            shortFileName = pack[1];

            repository.ResourcePath = folder + "\\";
            tFeatures = new object();
            tFeatures = provider.GetResource(shortFileName, repository);
            tImage = ImageLoader.LoadImage(fullFilename + ".tif");
            pbxTemplateImg.Image = tImage;           
        }

        private void ShowResults(int id, string fing, double matchingScore, List<MinutiaPair> matchingMtiae)
        {
            if (matchingScore == 0 || matchingMtiae == null)
            { }
            else
            {
                List<Minutia> qMtiae = new List<Minutia>();
                List<Minutia> tMtiae = new List<Minutia>();
                foreach (MinutiaPair mPair in matchingMtiae)
                {
                    qMtiae.Add(mPair.QueryMtia);
                    tMtiae.Add(mPair.TemplateMtia);
                }
                IFeatureDisplay<List<Minutia>> display = new MinutiaeDisplay();

                pbxQueryImg.Image = qImage.Clone() as Bitmap;
                Graphics g = Graphics.FromImage(pbxQueryImg.Image);
                display.Show(qMtiae, g);
                pbxQueryImg.Invalidate();

                pbxTemplateImg.Image = tImage.Clone() as Bitmap;
                g = Graphics.FromImage(pbxTemplateImg.Image);
                display.Show(tMtiae, g);
                pbxTemplateImg.Invalidate();
                if (matchingScore > srchScore)
                {
                    srchScore = matchingScore;
                    match = matchingMtiae.Count;
                    idcard = id;
                    finger = fing;                        
                }
            }
        }

        #region private fields

        private Bitmap qImage, tImage;

        private IResourceProvider provider;

        private ResourceRepository repository;

        private string resourcePath;

        private IMatcher matcher;

        private object qFeatures, tFeatures;

        #endregion

        private void VisualFingerprintMatchingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
            form.back();
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
            form.back();
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            if (qImage == null)
            {
                MessageBox.Show("Исходное изображение отпечатка не задано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT id_card, lt, li, lm, ll, lr, rt, ri, rm, rr, rl FROM cards WHERE `delete` = 0";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            int iter = 1;
            while (reader.Read())
            {
                for (int i = 1; i < 11; i++)
                {
                    if (reader[i].ToString() != "")
                    {
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
                        iter = iter + 1;
                        loadimg(href, iter);
                        // Matching features
                        List<MinutiaPair> matchingMtiae = null;
                        double score;
                        IMinutiaMatcher minutiaMatcher = matcher as IMinutiaMatcher;
                        if (minutiaMatcher != null)
                        {
                           score = minutiaMatcher.Match(qFeatures, tFeatures, out matchingMtiae);

                            if (qFeatures is List<Minutia> && tFeatures is List<Minutia>)
                            {
                                pbxQueryImg.Image = qImage.Clone() as Bitmap;
                                Graphics g1 = Graphics.FromImage(pbxQueryImg.Image);
                                ShowBlueMinutiae(qFeatures as List<Minutia>, g1);

                                pbxTemplateImg.Image = tImage.Clone() as Bitmap;
                                Graphics g2 = Graphics.FromImage(pbxTemplateImg.Image);
                                ShowBlueMinutiae(tFeatures as List<Minutia>, g2);

                                if (score == 0 || matchingMtiae == null)
                                    MessageBox.Show(string.Format("Similarity: {0}.", score));
                                else
                                {
                                    List<Minutia> qMtiae = new List<Minutia>();
                                    List<Minutia> tMtiae = new List<Minutia>();
                                    foreach (MinutiaPair mPair in matchingMtiae)
                                    {
                                        qMtiae.Add(mPair.QueryMtia);
                                        tMtiae.Add(mPair.TemplateMtia);
                                    }
                                    IFeatureDisplay<List<Minutia>> display = new MinutiaeDisplay();

                                    display.Show(qMtiae, g1);
                                    pbxQueryImg.Invalidate();

                                    display.Show(tMtiae, g2);
                                    pbxTemplateImg.Invalidate();

                                    MessageBox.Show(string.Format("Similarity: {0}. Matching minutiae: {1}.", score,
                                                                  matchingMtiae.Count));
                                }
                            }
                            else
                                ShowResults(int.Parse(reader[0].ToString()), reader[i].ToString(), score, matchingMtiae);
                        }
                        else
                            score = matcher.Match(qFeatures, tFeatures);
                    }
                }
            }
            endimg();
            MessageBox.Show(string.Format("Наиболее схожий отпечаток ({0}%) найден в карте №{1}. Совпаднеий особых точек: {2}.", srchScore, idcard, match));
            DirectoryInfo dirInfo = new DirectoryInfo("temp\\");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        public void ShowBlueMinutiae(List<Minutia> features, Graphics g)
        {
            int mtiaRadius = 6;
            int lineLength = 18;
            Pen pen = new Pen(Brushes.Blue) { Width = 3 };
            pen.Color = Color.LightBlue;

            Pen whitePen = new Pen(Brushes.Blue) { Width = 5 };
            whitePen.Color = Color.White;

            int i = 0;
            foreach (Minutia mtia in (IList<Minutia>)features)
            {
                g.DrawEllipse(whitePen, mtia.X - mtiaRadius, mtia.Y - mtiaRadius, 2 * mtiaRadius + 1, 2 * mtiaRadius + 1);
                g.DrawLine(whitePen, mtia.X, mtia.Y, Convert.ToInt32(mtia.X + lineLength * Math.Cos(mtia.Angle)), Convert.ToInt32(mtia.Y + lineLength * Math.Sin(mtia.Angle)));

                pen.Color = Color.LightBlue;

                g.DrawEllipse(pen, mtia.X - mtiaRadius, mtia.Y - mtiaRadius, 2 * mtiaRadius + 1, 2 * mtiaRadius + 1);
                g.DrawLine(pen, mtia.X, mtia.Y, Convert.ToInt32(mtia.X + lineLength * Math.Cos(mtia.Angle)), Convert.ToInt32(mtia.Y + lineLength * Math.Sin(mtia.Angle)));
                i++;
            }

            Minutia lastMtia = ((IList<Minutia>)features)[((IList<Minutia>)features).Count - 1];
            pen.Color = Color.LightBlue;
            g.DrawEllipse(pen, lastMtia.X - mtiaRadius, lastMtia.Y - mtiaRadius, 2 * mtiaRadius + 1, 2 * mtiaRadius + 1);
            g.DrawLine(pen, lastMtia.X, lastMtia.Y, Convert.ToInt32(lastMtia.X + lineLength * Math.Cos(lastMtia.Angle)), Convert.ToInt32(lastMtia.Y + lineLength * Math.Sin(lastMtia.Angle)));
        }
    }
}