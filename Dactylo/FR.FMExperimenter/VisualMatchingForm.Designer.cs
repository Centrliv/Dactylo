namespace PatternRecognition.FingerprintRecognition.Applications
{
    partial class VisualFingerprintMatchingFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualFingerprintMatchingFrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxQueryFingerprint = new System.Windows.Forms.GroupBox();
            this.pnlQueryImage = new System.Windows.Forms.Panel();
            this.pbxQueryImg = new System.Windows.Forms.PictureBox();
            this.gbxTemplateFingerprint = new System.Windows.Forms.GroupBox();
            this.pnlTemplateImage = new System.Windows.Forms.Panel();
            this.pbxTemplateImg = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMatch = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxQueryFingerprint.SuspendLayout();
            this.pnlQueryImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQueryImg)).BeginInit();
            this.gbxTemplateFingerprint.SuspendLayout();
            this.pnlTemplateImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTemplateImg)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxQueryFingerprint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbxTemplateFingerprint);
            this.splitContainer1.Size = new System.Drawing.Size(705, 349);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbxQueryFingerprint
            // 
            this.gbxQueryFingerprint.Controls.Add(this.pnlQueryImage);
            this.gbxQueryFingerprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxQueryFingerprint.Location = new System.Drawing.Point(0, 0);
            this.gbxQueryFingerprint.Name = "gbxQueryFingerprint";
            this.gbxQueryFingerprint.Size = new System.Drawing.Size(347, 349);
            this.gbxQueryFingerprint.TabIndex = 0;
            this.gbxQueryFingerprint.TabStop = false;
            this.gbxQueryFingerprint.Text = "Исходный отпечаток";
            // 
            // pnlQueryImage
            // 
            this.pnlQueryImage.AutoScroll = true;
            this.pnlQueryImage.Controls.Add(this.pbxQueryImg);
            this.pnlQueryImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQueryImage.Location = new System.Drawing.Point(3, 16);
            this.pnlQueryImage.Name = "pnlQueryImage";
            this.pnlQueryImage.Size = new System.Drawing.Size(341, 330);
            this.pnlQueryImage.TabIndex = 0;
            // 
            // pbxQueryImg
            // 
            this.pbxQueryImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxQueryImg.Location = new System.Drawing.Point(0, 0);
            this.pbxQueryImg.Name = "pbxQueryImg";
            this.pbxQueryImg.Size = new System.Drawing.Size(341, 330);
            this.pbxQueryImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxQueryImg.TabIndex = 0;
            this.pbxQueryImg.TabStop = false;
            this.pbxQueryImg.DoubleClick += new System.EventHandler(this.btnLoadQueryImg_Click);
            // 
            // gbxTemplateFingerprint
            // 
            this.gbxTemplateFingerprint.Controls.Add(this.pnlTemplateImage);
            this.gbxTemplateFingerprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTemplateFingerprint.Location = new System.Drawing.Point(0, 0);
            this.gbxTemplateFingerprint.Name = "gbxTemplateFingerprint";
            this.gbxTemplateFingerprint.Size = new System.Drawing.Size(354, 349);
            this.gbxTemplateFingerprint.TabIndex = 1;
            this.gbxTemplateFingerprint.TabStop = false;
            this.gbxTemplateFingerprint.Text = "Проверяемый отпечаток";
            // 
            // pnlTemplateImage
            // 
            this.pnlTemplateImage.AutoScroll = true;
            this.pnlTemplateImage.Controls.Add(this.pbxTemplateImg);
            this.pnlTemplateImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplateImage.Location = new System.Drawing.Point(3, 16);
            this.pnlTemplateImage.Name = "pnlTemplateImage";
            this.pnlTemplateImage.Size = new System.Drawing.Size(348, 330);
            this.pnlTemplateImage.TabIndex = 2;
            // 
            // pbxTemplateImg
            // 
            this.pbxTemplateImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxTemplateImg.Location = new System.Drawing.Point(0, 0);
            this.pbxTemplateImg.Name = "pbxTemplateImg";
            this.pbxTemplateImg.Size = new System.Drawing.Size(348, 330);
            this.pbxTemplateImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxTemplateImg.TabIndex = 1;
            this.pbxTemplateImg.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files|*.tif;*.bmp;*.jpg";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.tableLayoutPanel1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 349);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(705, 60);
            this.pnlBottom.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.btnMatch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.back, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnMatch
            // 
            this.btnMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMatch.Location = new System.Drawing.Point(3, 3);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(98, 46);
            this.btnMatch.TabIndex = 7;
            this.btnMatch.Text = "Поиск";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Location = new System.Drawing.Point(594, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(102, 46);
            this.back.TabIndex = 9;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // VisualFingerprintMatchingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 409);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(721, 448);
            this.Name = "VisualFingerprintMatchingFrm";
            this.Text = "Поиск по отпечатку";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VisualFingerprintMatchingFrm_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxQueryFingerprint.ResumeLayout(false);
            this.pnlQueryImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxQueryImg)).EndInit();
            this.gbxTemplateFingerprint.ResumeLayout(false);
            this.pnlTemplateImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTemplateImg)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxQueryFingerprint;
        private System.Windows.Forms.Panel pnlQueryImage;
        private System.Windows.Forms.GroupBox gbxTemplateFingerprint;
        private System.Windows.Forms.PictureBox pbxQueryImg;
        private System.Windows.Forms.Panel pnlTemplateImage;
        private System.Windows.Forms.PictureBox pbxTemplateImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button back;
    }
}