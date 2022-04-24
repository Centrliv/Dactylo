namespace Dactylo
{
    partial class auth_regForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(auth_regForm));
            this.auth_reg = new System.Windows.Forms.TabControl();
            this.authPage = new System.Windows.Forms.TabPage();
            this.alog = new System.Windows.Forms.TextBox();
            this.apass = new System.Windows.Forms.TextBox();
            this.log_in = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regPage = new System.Windows.Forms.TabPage();
            this.rconfpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rlog = new System.Windows.Forms.TextBox();
            this.rpass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.sur = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.patr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.auth_reg.SuspendLayout();
            this.authPage.SuspendLayout();
            this.regPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // auth_reg
            // 
            this.auth_reg.Controls.Add(this.authPage);
            this.auth_reg.Controls.Add(this.regPage);
            this.auth_reg.Location = new System.Drawing.Point(12, 12);
            this.auth_reg.Name = "auth_reg";
            this.auth_reg.SelectedIndex = 0;
            this.auth_reg.Size = new System.Drawing.Size(408, 330);
            this.auth_reg.TabIndex = 13;
            this.auth_reg.SelectedIndexChanged += new System.EventHandler(this.auth_reg_SelectedIndexChanged);
            // 
            // authPage
            // 
            this.authPage.Controls.Add(this.alog);
            this.authPage.Controls.Add(this.apass);
            this.authPage.Controls.Add(this.log_in);
            this.authPage.Controls.Add(this.label2);
            this.authPage.Controls.Add(this.label3);
            this.authPage.Location = new System.Drawing.Point(4, 22);
            this.authPage.Name = "authPage";
            this.authPage.Padding = new System.Windows.Forms.Padding(3);
            this.authPage.Size = new System.Drawing.Size(400, 304);
            this.authPage.TabIndex = 0;
            this.authPage.Text = "Вход";
            this.authPage.UseVisualStyleBackColor = true;
            // 
            // alog
            // 
            this.alog.Location = new System.Drawing.Point(8, 82);
            this.alog.Name = "alog";
            this.alog.Size = new System.Drawing.Size(384, 20);
            this.alog.TabIndex = 1;
            this.alog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alog_KeyPress);
            // 
            // apass
            // 
            this.apass.Location = new System.Drawing.Point(8, 128);
            this.apass.Name = "apass";
            this.apass.PasswordChar = '*';
            this.apass.Size = new System.Drawing.Size(384, 20);
            this.apass.TabIndex = 2;
            this.apass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alog_KeyPress);
            // 
            // log_in
            // 
            this.log_in.Location = new System.Drawing.Point(8, 207);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(384, 41);
            this.log_in.TabIndex = 3;
            this.log_in.Text = "Войти в программу";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Логин";
            // 
            // regPage
            // 
            this.regPage.Controls.Add(this.rconfpass);
            this.regPage.Controls.Add(this.label1);
            this.regPage.Controls.Add(this.rlog);
            this.regPage.Controls.Add(this.rpass);
            this.regPage.Controls.Add(this.label6);
            this.regPage.Controls.Add(this.reg);
            this.regPage.Controls.Add(this.label7);
            this.regPage.Controls.Add(this.sur);
            this.regPage.Controls.Add(this.label8);
            this.regPage.Controls.Add(this.nam);
            this.regPage.Controls.Add(this.label9);
            this.regPage.Controls.Add(this.patr);
            this.regPage.Controls.Add(this.label10);
            this.regPage.Location = new System.Drawing.Point(4, 22);
            this.regPage.Name = "regPage";
            this.regPage.Padding = new System.Windows.Forms.Padding(3);
            this.regPage.Size = new System.Drawing.Size(400, 304);
            this.regPage.TabIndex = 1;
            this.regPage.Text = "Регистрация";
            this.regPage.UseVisualStyleBackColor = true;
            // 
            // rconfpass
            // 
            this.rconfpass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rconfpass.Location = new System.Drawing.Point(8, 218);
            this.rconfpass.Name = "rconfpass";
            this.rconfpass.PasswordChar = '*';
            this.rconfpass.Size = new System.Drawing.Size(384, 20);
            this.rconfpass.TabIndex = 6;
            this.rconfpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alog_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Подтверждение пароля*";
            // 
            // rlog
            // 
            this.rlog.Location = new System.Drawing.Point(8, 140);
            this.rlog.Name = "rlog";
            this.rlog.Size = new System.Drawing.Size(384, 20);
            this.rlog.TabIndex = 4;
            this.rlog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alog_KeyPress);
            // 
            // rpass
            // 
            this.rpass.Location = new System.Drawing.Point(8, 179);
            this.rpass.Name = "rpass";
            this.rpass.PasswordChar = '*';
            this.rpass.Size = new System.Drawing.Size(384, 20);
            this.rpass.TabIndex = 5;
            this.rpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alog_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Фамилия*";
            // 
            // reg
            // 
            this.reg.Location = new System.Drawing.Point(8, 255);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(384, 41);
            this.reg.TabIndex = 7;
            this.reg.Text = "Регистрация";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Пароль*";
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(8, 23);
            this.sur.Name = "sur";
            this.sur.Size = new System.Drawing.Size(384, 20);
            this.sur.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Логин*";
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(8, 62);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(384, 20);
            this.nam.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Отчество";
            // 
            // patr
            // 
            this.patr.Location = new System.Drawing.Point(8, 101);
            this.patr.Name = "patr";
            this.patr.Size = new System.Drawing.Size(384, 20);
            this.patr.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Имя*";
            // 
            // auth_regForm
            // 
            this.AcceptButton = this.log_in;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 348);
            this.Controls.Add(this.auth_reg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "auth_regForm";
            this.Text = "Дактилоскопическая информационная система \"Импринт\"";
            this.auth_reg.ResumeLayout(false);
            this.authPage.ResumeLayout(false);
            this.authPage.PerformLayout();
            this.regPage.ResumeLayout(false);
            this.regPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl auth_reg;
        private System.Windows.Forms.TabPage authPage;
        private System.Windows.Forms.TextBox alog;
        private System.Windows.Forms.TextBox apass;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage regPage;
        private System.Windows.Forms.TextBox rlog;
        private System.Windows.Forms.TextBox rpass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox patr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox rconfpass;
        private System.Windows.Forms.Label label1;
    }
}