namespace PatternRecognition.FingerprintRecognition.Applications
{
    partial class FeatureDisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeatureDisplayForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picFinger = new System.Windows.Forms.PictureBox();
            this.cbxFeatureDisplayers = new System.Windows.Forms.ComboBox();
            this.btnShowFeatures = new System.Windows.Forms.Button();
            this.cbxFeatureExtractors = new System.Windows.Forms.ComboBox();
            this.lblFeatDisplay = new System.Windows.Forms.Label();
            this.lblFeatExtractor = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.png;*.tif)|*.bmp;*.gif;*.jpg;*.png;*.tif";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.picFinger);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 441);
            this.panel2.TabIndex = 5;
            // 
            // picFinger
            // 
            this.picFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFinger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFinger.Location = new System.Drawing.Point(0, 0);
            this.picFinger.Name = "picFinger";
            this.picFinger.Size = new System.Drawing.Size(340, 441);
            this.picFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFinger.TabIndex = 0;
            this.picFinger.TabStop = false;
            this.picFinger.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // cbxFeatureDisplayers
            // 
            this.cbxFeatureDisplayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFeatureDisplayers.FormattingEnabled = true;
            this.cbxFeatureDisplayers.Location = new System.Drawing.Point(65, 12);
            this.cbxFeatureDisplayers.Name = "cbxFeatureDisplayers";
            this.cbxFeatureDisplayers.Size = new System.Drawing.Size(222, 21);
            this.cbxFeatureDisplayers.TabIndex = 0;
            this.cbxFeatureDisplayers.SelectedValueChanged += new System.EventHandler(this.cbxFeatureTypes_SelectedValueChanged);
            // 
            // btnShowFeatures
            // 
            this.btnShowFeatures.Location = new System.Drawing.Point(9, 104);
            this.btnShowFeatures.Name = "btnShowFeatures";
            this.btnShowFeatures.Size = new System.Drawing.Size(278, 37);
            this.btnShowFeatures.TabIndex = 1;
            this.btnShowFeatures.Text = "Показать";
            this.btnShowFeatures.UseVisualStyleBackColor = true;
            this.btnShowFeatures.Click += new System.EventHandler(this.btnShowFeatures_Click);
            // 
            // cbxFeatureExtractors
            // 
            this.cbxFeatureExtractors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFeatureExtractors.FormattingEnabled = true;
            this.cbxFeatureExtractors.Location = new System.Drawing.Point(65, 55);
            this.cbxFeatureExtractors.Name = "cbxFeatureExtractors";
            this.cbxFeatureExtractors.Size = new System.Drawing.Size(222, 21);
            this.cbxFeatureExtractors.Sorted = true;
            this.cbxFeatureExtractors.TabIndex = 2;
            this.cbxFeatureExtractors.SelectedValueChanged += new System.EventHandler(this.cbxFeatureExtractors_SelectedValueChanged);
            // 
            // lblFeatDisplay
            // 
            this.lblFeatDisplay.AutoSize = true;
            this.lblFeatDisplay.Location = new System.Drawing.Point(6, 15);
            this.lblFeatDisplay.Name = "lblFeatDisplay";
            this.lblFeatDisplay.Size = new System.Drawing.Size(53, 13);
            this.lblFeatDisplay.TabIndex = 3;
            this.lblFeatDisplay.Text = "Функция";
            // 
            // lblFeatExtractor
            // 
            this.lblFeatExtractor.AutoSize = true;
            this.lblFeatExtractor.Location = new System.Drawing.Point(6, 58);
            this.lblFeatExtractor.Name = "lblFeatExtractor";
            this.lblFeatExtractor.Size = new System.Drawing.Size(39, 13);
            this.lblFeatExtractor.TabIndex = 4;
            this.lblFeatExtractor.Text = "Метод";
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Location = new System.Drawing.Point(169, 391);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(118, 38);
            this.back.TabIndex = 5;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.back);
            this.panel3.Controls.Add(this.lblFeatExtractor);
            this.panel3.Controls.Add(this.lblFeatDisplay);
            this.panel3.Controls.Add(this.cbxFeatureExtractors);
            this.panel3.Controls.Add(this.btnShowFeatures);
            this.panel3.Controls.Add(this.cbxFeatureDisplayers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(340, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 441);
            this.panel3.TabIndex = 4;
            // 
            // FeatureDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(655, 480);
            this.Name = "FeatureDisplayForm";
            this.Text = "Исследование отпечатка";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FeatureDisplayForm_FormClosed);
            this.Load += new System.EventHandler(this.frmFeaturesDisplay_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picFinger;
        private System.Windows.Forms.ComboBox cbxFeatureDisplayers;
        private System.Windows.Forms.Button btnShowFeatures;
        private System.Windows.Forms.ComboBox cbxFeatureExtractors;
        private System.Windows.Forms.Label lblFeatDisplay;
        private System.Windows.Forms.Label lblFeatExtractor;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel panel3;
    }
}