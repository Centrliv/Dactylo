namespace Dactylo
{
    partial class accountForm
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
            this.rconfpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.rpass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sur = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.patr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.opass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aedit = new System.Windows.Forms.Button();
            this.chpass = new System.Windows.Forms.CheckBox();
            this.chlog = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pedit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rconfpass
            // 
            this.rconfpass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rconfpass.Location = new System.Drawing.Point(6, 182);
            this.rconfpass.Name = "rconfpass";
            this.rconfpass.PasswordChar = '*';
            this.rconfpass.ReadOnly = true;
            this.rconfpass.Size = new System.Drawing.Size(387, 20);
            this.rconfpass.TabIndex = 12;
            this.rconfpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Подтверждение пароля";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(6, 42);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(387, 20);
            this.log.TabIndex = 9;
            this.log.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // rpass
            // 
            this.rpass.Location = new System.Drawing.Point(6, 143);
            this.rpass.Name = "rpass";
            this.rpass.PasswordChar = '*';
            this.rpass.ReadOnly = true;
            this.rpass.Size = new System.Drawing.Size(387, 20);
            this.rpass.TabIndex = 11;
            this.rpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Фамилия";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Новый пароль";
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(6, 42);
            this.sur.Name = "sur";
            this.sur.ReadOnly = true;
            this.sur.Size = new System.Drawing.Size(387, 20);
            this.sur.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Логин";
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(6, 81);
            this.nam.Name = "nam";
            this.nam.ReadOnly = true;
            this.nam.Size = new System.Drawing.Size(387, 20);
            this.nam.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Отчество";
            // 
            // patr
            // 
            this.patr.Location = new System.Drawing.Point(6, 120);
            this.patr.Name = "patr";
            this.patr.ReadOnly = true;
            this.patr.Size = new System.Drawing.Size(387, 20);
            this.patr.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Имя";
            // 
            // opass
            // 
            this.opass.Location = new System.Drawing.Point(6, 104);
            this.opass.Name = "opass";
            this.opass.PasswordChar = '*';
            this.opass.ReadOnly = true;
            this.opass.Size = new System.Drawing.Size(387, 20);
            this.opass.TabIndex = 10;
            this.opass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Старый пароль";
            // 
            // aedit
            // 
            this.aedit.Location = new System.Drawing.Point(6, 261);
            this.aedit.Name = "aedit";
            this.aedit.Size = new System.Drawing.Size(387, 34);
            this.aedit.TabIndex = 6;
            this.aedit.Text = "Редактировать";
            this.aedit.UseVisualStyleBackColor = true;
            this.aedit.Click += new System.EventHandler(this.edit_Click);
            // 
            // chpass
            // 
            this.chpass.AutoSize = true;
            this.chpass.Enabled = false;
            this.chpass.Location = new System.Drawing.Point(6, 68);
            this.chpass.Name = "chpass";
            this.chpass.Size = new System.Drawing.Size(116, 17);
            this.chpass.TabIndex = 8;
            this.chpass.Text = "Изменить пароль";
            this.chpass.UseVisualStyleBackColor = true;
            this.chpass.CheckedChanged += new System.EventHandler(this.chpass_CheckedChanged);
            // 
            // chlog
            // 
            this.chlog.AutoSize = true;
            this.chlog.Enabled = false;
            this.chlog.Location = new System.Drawing.Point(6, 6);
            this.chlog.Name = "chlog";
            this.chlog.Size = new System.Drawing.Size(109, 17);
            this.chlog.TabIndex = 7;
            this.chlog.Text = "Изменить логин";
            this.chlog.UseVisualStyleBackColor = true;
            this.chlog.CheckedChanged += new System.EventHandler(this.chlog_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 327);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pedit);
            this.tabPage1.Controls.Add(this.patr);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.nam);
            this.tabPage1.Controls.Add(this.sur);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Личные данные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pedit
            // 
            this.pedit.Location = new System.Drawing.Point(6, 261);
            this.pedit.Name = "pedit";
            this.pedit.Size = new System.Drawing.Size(387, 34);
            this.pedit.TabIndex = 1;
            this.pedit.Text = "Редактировать";
            this.pedit.UseVisualStyleBackColor = true;
            this.pedit.Click += new System.EventHandler(this.pedit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chlog);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.aedit);
            this.tabPage2.Controls.Add(this.chpass);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.rpass);
            this.tabPage2.Controls.Add(this.log);
            this.tabPage2.Controls.Add(this.opass);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.rconfpass);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Данные авторизации";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // accountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 351);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "accountForm";
            this.Text = "Редактирование профиля";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.accountForm_FormClosed);
            this.Load += new System.EventHandler(this.accountForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox rconfpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.TextBox rpass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox patr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox opass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button aedit;
        private System.Windows.Forms.CheckBox chpass;
        private System.Windows.Forms.CheckBox chlog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button pedit;
        private System.Windows.Forms.TabPage tabPage2;
    }
}