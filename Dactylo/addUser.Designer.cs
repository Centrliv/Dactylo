namespace Dactylo
{
    partial class addUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addUser));
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
            this.stat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rconfpass
            // 
            this.rconfpass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rconfpass.Location = new System.Drawing.Point(15, 259);
            this.rconfpass.Name = "rconfpass";
            this.rconfpass.PasswordChar = '*';
            this.rconfpass.Size = new System.Drawing.Size(384, 20);
            this.rconfpass.TabIndex = 7;
            this.rconfpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Подтверждение пароля*";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(15, 181);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(384, 20);
            this.log.TabIndex = 5;
            this.log.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // rpass
            // 
            this.rpass.Location = new System.Drawing.Point(15, 220);
            this.rpass.Name = "rpass";
            this.rpass.PasswordChar = '*';
            this.rpass.Size = new System.Drawing.Size(384, 20);
            this.rpass.TabIndex = 6;
            this.rpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Фамилия*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Пароль*";
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(15, 25);
            this.sur.Name = "sur";
            this.sur.Size = new System.Drawing.Size(384, 20);
            this.sur.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Логин*";
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(15, 64);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(384, 20);
            this.nam.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Отчество";
            // 
            // patr
            // 
            this.patr.Location = new System.Drawing.Point(15, 103);
            this.patr.Name = "patr";
            this.patr.Size = new System.Drawing.Size(384, 20);
            this.patr.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Имя*";
            // 
            // stat
            // 
            this.stat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stat.FormattingEnabled = true;
            this.stat.Location = new System.Drawing.Point(15, 141);
            this.stat.Name = "stat";
            this.stat.Size = new System.Drawing.Size(384, 21);
            this.stat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Статус";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(280, 310);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(119, 34);
            this.close.TabIndex = 9;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(15, 310);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(119, 34);
            this.add.TabIndex = 8;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // addUser
            // 
            this.AcceptButton = this.add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 356);
            this.Controls.Add(this.close);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stat);
            this.Controls.Add(this.rconfpass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.rpass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sur);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.patr);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addUser";
            this.Text = "Добавление пользователя";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addUser_FormClosed);
            this.Load += new System.EventHandler(this.addUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox stat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button add;
    }
}