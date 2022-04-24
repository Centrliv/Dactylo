﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PatternRecognition.FingerprintRecognition.Core;

namespace PatternRecognition.FingerprintRecognition.Applications
{
    public partial class FeatureDisplayForm : Form
    {
        public Form form;
        public List<Type> l = new List<Type>();
        public List<Type> l2 = new List<Type>();
        public FeatureDisplayForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Assembly thisAss = Assembly.GetExecutingAssembly();
            string dir = Path.GetDirectoryName(thisAss.Location);
            foreach (string fileName in Directory.GetFiles(dir))
            {
                string fileExtension = Path.GetExtension(fileName);
                if (fileExtension == ".dll")
                {
                    try
                    {
                        Assembly currAssembly = Assembly.LoadFile(fileName);
                        foreach (Type type in currAssembly.GetExportedTypes())
                        {
                            var currInterface = type.GetInterface("IFeatureDisplay`1");
                            if (type.IsClass && !type.IsAbstract && currInterface != null)
                            {
                                var featType = currInterface.GetGenericArguments()[0];
                                featTypeByDisplay.Add(type, featType);
                            }

                            currInterface = type.GetInterface("IFeatureExtractor`1");
                            if (type.IsClass && !type.IsAbstract && currInterface != null)
                            {
                                var featType = currInterface.GetGenericArguments()[0];
                                if (!extractorsByFeatType.ContainsKey(featType))
                                    extractorsByFeatType.Add(featType, new List<Type>());
                                extractorsByFeatType[featType].Add(type);
                            }
                        }
                    }
                    catch { }
                }
            }
            var toDelete = new List<Type>();
            foreach (var pair in featTypeByDisplay)
                if (!extractorsByFeatType.ContainsKey(pair.Value))
                    toDelete.Add(pair.Key);
            foreach (var type in toDelete)
                featTypeByDisplay.Remove(type);            
        }
       
        private void frmFeaturesDisplay_Load(object sender, EventArgs e)
        {
            l.Clear();
            cbxFeatureDisplayers.Items.Clear();
            foreach(Type t in featTypeByDisplay.Keys)
            {
                if (t.Name.ToString() == "MinutiaeDisplay") cbxFeatureDisplayers.Items.Add("Особенности папиллярных линий");
                if (t.Name.ToString() == "MTripletsDisplay") cbxFeatureDisplayers.Items.Add("Особенности папиллярных узоров");
                if (t.Name.ToString() == "OrientationImageDisplay") cbxFeatureDisplayers.Items.Add("Дактилоскопическая экспертиза");
                if (t.Name.ToString() == "SkeletonImageDisplay") cbxFeatureDisplayers.Items.Add("Скелетизация");
                l.Add(t);
            }
            cbxFeatureDisplayers.SelectedIndex = 0;
        }

        private void cbxFeatureTypes_SelectedValueChanged(object sender, EventArgs e)
        {
           if (cbxFeatureDisplayers.SelectedIndex != -1)
           {
                cbxFeatureExtractors.Items.Clear();
                Type selectedType = l[cbxFeatureDisplayers.SelectedIndex];
                currFeatDisplay = Activator.CreateInstance(selectedType) as IFeatureDisplay;
                Type currFeatType = featTypeByDisplay[selectedType];
                l2.Clear();
                cbxFeatureExtractors.Items.Clear();
                foreach (Type t in extractorsByFeatType[currFeatType])
                {
                    if (t.Name.ToString() == "Ratha1995MinutiaeExtractor") cbxFeatureExtractors.Items.Add("Метод 1");
                    if (t.Name.ToString() == "Ratha1995OrImgExtractor") cbxFeatureExtractors.Items.Add("Метод 1");
                    if (t.Name.ToString() == "Sherlock1994OrImgExtractor") cbxFeatureExtractors.Items.Add("Метод 2");
                    if (t.Name.ToString() == "Ratha1995SkeImgExtractor") cbxFeatureExtractors.Items.Add("Метод 1");
                    l2.Add(t);
                }
                cbxFeatureExtractors.SelectedIndex = 0;
            }
        }

        private void cbxFeatureExtractors_SelectedValueChanged(object sender, EventArgs e)
        {
            object selectedValue = ((ComboBox)sender).SelectedItem;
            if (cbxFeatureExtractors.SelectedIndex!=-1)
            {
                Type selectedType = l2[cbxFeatureExtractors.SelectedIndex];
                currExtractor = Activator.CreateInstance(selectedType) as IFeatureExtractor;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = ImageLoader.LoadImage(openFileDialog1.FileName);
                picFinger.Image = img;
            }
        }

        private void btnShowFeatures_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                MessageBox.Show("Не выбрано изображение для исследования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            picFinger.Image = img.Clone() as Bitmap;
            Graphics g = Graphics.FromImage(picFinger.Image);
            //try
            {
                var features = currExtractor.ExtractFeatures(img);
                currFeatDisplay.Show(features, g);
            }
            //catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Displaying error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        readonly Dictionary<Type, Type> featTypeByDisplay = new Dictionary<Type, Type>();
        readonly Dictionary<Type, List<Type>> extractorsByFeatType = new Dictionary<Type, List<Type>>();
        private IFeatureDisplay currFeatDisplay;
        private IFeatureExtractor currExtractor;
        private Bitmap img = null;

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (picFinger.Image == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    img = ImageLoader.LoadImage(openFileDialog1.FileName);
                    picFinger.Image = img;
                }
            }
            else picFinger.Image = null;
        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void FeatureDisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }
    }
}