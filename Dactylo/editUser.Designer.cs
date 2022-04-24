namespace Dactylo
{
    partial class editUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editUser));
            this.auth = new System.Windows.Forms.TabControl();
            this.personal = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.pos = new System.Windows.Forms.ComboBox();
            this.pedit = new System.Windows.Forms.Button();
            this.patr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.TextBox();
            this.sur = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.aedit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rpass = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.TextBox();
            this.auth.SuspendLayout();
            this.personal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // auth
            // 
            this.auth.Controls.Add(this.personal);
            this.auth.Controls.Add(this.tabPage2);
            this.auth.Location = new System.Drawing.Point(12, 12);
            this.auth.Name = "auth";
            this.auth.SelectedIndex = 0;
            this.auth.Size = new System.Drawing.Size(407, 327);
            this.auth.TabIndex = 6;
            // 
            // personal
            // 
            this.personal.Controls.Add(this.label3);
            this.personal.Controls.Add(this.pos);
            this.personal.Controls.Add(this.pedit);
            this.personal.Controls.Add(this.patr);
            this.personal.Controls.Add(this.label10);
            this.personal.Controls.Add(this.label9);
            this.personal.Controls.Add(this.nam);
            this.personal.Controls.Add(this.sur);
            this.personal.Controls.Add(this.label6);
            this.personal.Location = new System.Drawing.Point(4, 22);
            this.personal.Name = "personal";
            this.personal.Padding = new System.Windows.Forms.Padding(3);
            this.personal.Size = new System.Drawing.Size(399, 301);
            this.personal.TabIndex = 0;
            this.personal.Text = "Личные данные";
            this.personal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Статус";
            // 
            // pos
            // 
            this.pos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pos.Enabled = false;
            this.pos.FormattingEnabled = true;
            this.pos.Location = new System.Drawing.Point(6, 159);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(387, 21);
            this.pos.TabIndex = 4;
            // 
            // pedit
            // 
            this.pedit.Location = new System.Drawing.Point(6, 261);
            this.pedit.Name = "pedit";
            this.pedit.Size = new System.Drawing.Size(387, 34);
            this.pedit.TabIndex = 5;
            this.pedit.Text = "Редактировать";
            this.pedit.UseVisualStyleBackColor = true;
            this.pedit.Click += new System.EventHandler(this.pedit_Click);
            // 
            // patr
            // 
            this.patr.Location = new System.Drawing.Point(6, 120);
            this.patr.Name = "patr";
            this.patr.ReadOnly = true;
            this.patr.Size = new System.Drawing.Size(387, 20);
            this.patr.TabIndex = 3;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Отчество";
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(6, 81);
            this.nam.Name = "nam";
            this.nam.ReadOnly = true;
            this.nam.Size = new System.Drawing.Size(387, 20);
            this.nam.TabIndex = 2;
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(6, 42);
            this.sur.Name = "sur";
            this.sur.ReadOnly = true;
            this.sur.Size = new System.Drawing.Size(387, 20);
            this.sur.TabIndex = 1;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.aedit);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.rpass);
            this.tabPage2.Controls.Add(this.log);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Данные авторизации";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // aedit
            // 
            this.aedit.Location = new System.Drawing.Point(6, 261);
            this.aedit.Name = "aedit";
            this.aedit.Size = new System.Drawing.Size(387, 34);
            this.aedit.TabIndex = 9;
            this.aedit.Text = "Редактировать";
            this.aedit.UseVisualStyleBackColor = true;
            this.aedit.Click += new System.EventHandler(this.aedit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Пароль";
            // 
            // rpass
            // 
            this.rpass.Location = new System.Drawing.Point(6, 81);
            this.rpass.Name = "rpass";
            this.rpass.PasswordChar = '*';
            this.rpass.ReadOnly = true;
            this.rpass.Size = new System.Drawing.Size(387, 20);
            this.rpass.TabIndex = 8;
            this.rpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rpass_KeyPress);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(6, 42);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(387, 20);
            this.log.TabIndex = 7;
            this.log.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rpass_KeyPress);
            // 
            // editUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 349);
            this.Controls.Add(this.auth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "editUser";
            this.Text = "Просмотр пользователя";
            this.Load += new System.EventHandler(this.viewUser_Load);
            this.auth.ResumeLayout(false);
            this.personal.ResumeLayout(false);
            this.personal.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl auth;
        private System.Windows.Forms.TabPage personal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox pos;
        private System.Windows.Forms.Button pedit;
        private System.Windows.Forms.TextBox patr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nam;
        private System.Windows.Forms.TextBox sur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button aedit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rpass;
        private System.Windows.Forms.TextBox log;
    }
}