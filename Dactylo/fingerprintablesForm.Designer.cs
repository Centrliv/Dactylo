namespace Dactylo
{
    partial class fingerprintablesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fingerprintablesForm));
            this.fingerprintablesTable = new System.Windows.Forms.DataGridView();
            this.vfingerprintablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dactylo_dbDataSet = new Dactylo.dactylo_dbDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.view = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.v_fingerprintablesTableAdapter = new Dactylo.dactylo_dbDataSetTableAdapters.v_fingerprintablesTableAdapter();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldS = new System.Windows.Forms.TextBox();
            this.fieldN = new System.Windows.Forms.TextBox();
            this.fieldP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.snpSrch = new System.Windows.Forms.Button();
            this.idfingerprintableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idworkerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fingerprintablesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vfingerprintablesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dactylo_dbDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fingerprintablesTable
            // 
            this.fingerprintablesTable.AllowUserToAddRows = false;
            this.fingerprintablesTable.AllowUserToDeleteRows = false;
            this.fingerprintablesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fingerprintablesTable.AutoGenerateColumns = false;
            this.fingerprintablesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fingerprintablesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fingerprintablesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfingerprintableDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.patronymicDataGridViewTextBoxColumn,
            this.birthdateDataGridViewTextBoxColumn,
            this.idworkerDataGridViewTextBoxColumn});
            this.fingerprintablesTable.DataSource = this.vfingerprintablesBindingSource;
            this.fingerprintablesTable.Location = new System.Drawing.Point(21, 63);
            this.fingerprintablesTable.MultiSelect = false;
            this.fingerprintablesTable.Name = "fingerprintablesTable";
            this.fingerprintablesTable.ReadOnly = true;
            this.fingerprintablesTable.Size = new System.Drawing.Size(764, 331);
            this.fingerprintablesTable.TabIndex = 0;
            this.fingerprintablesTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fingerprintablesTable_CellClick);
            this.fingerprintablesTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.fingerprintablesTable_CellEnter);
            // 
            // vfingerprintablesBindingSource
            // 
            this.vfingerprintablesBindingSource.DataMember = "v_fingerprintables";
            this.vfingerprintablesBindingSource.DataSource = this.dactylo_dbDataSet;
            // 
            // dactylo_dbDataSet
            // 
            this.dactylo_dbDataSet.DataSetName = "dactylo_dbDataSet";
            this.dactylo_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.view, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.back, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.delete, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 400);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 38);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // view
            // 
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Location = new System.Drawing.Point(118, 3);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(109, 33);
            this.view.TabIndex = 2;
            this.view.Text = "Просмотр";
            this.view.UseVisualStyleBackColor = true;
            this.view.Click += new System.EventHandler(this.view_Click);
            // 
            // add
            // 
            this.add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add.Location = new System.Drawing.Point(3, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(109, 33);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // back
            // 
            this.back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back.Location = new System.Drawing.Point(657, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(113, 33);
            this.back.TabIndex = 4;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // delete
            // 
            this.delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(233, 3);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(109, 33);
            this.delete.TabIndex = 3;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // v_fingerprintablesTableAdapter
            // 
            this.v_fingerprintablesTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.reset, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.snpSrch, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(773, 48);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.fieldS, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.fieldN, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.fieldP, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 42);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Отчество";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Фамилия";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldS
            // 
            this.fieldS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldS.Location = new System.Drawing.Point(3, 19);
            this.fieldS.Name = "fieldS";
            this.fieldS.Size = new System.Drawing.Size(185, 20);
            this.fieldS.TabIndex = 9;
            this.fieldS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldS_KeyPress);
            // 
            // fieldN
            // 
            this.fieldN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldN.Location = new System.Drawing.Point(194, 19);
            this.fieldN.Name = "fieldN";
            this.fieldN.Size = new System.Drawing.Size(185, 20);
            this.fieldN.TabIndex = 10;
            this.fieldN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldS_KeyPress);
            // 
            // fieldP
            // 
            this.fieldP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldP.Location = new System.Drawing.Point(385, 19);
            this.fieldP.Name = "fieldP";
            this.fieldP.Size = new System.Drawing.Size(185, 20);
            this.fieldP.TabIndex = 11;
            this.fieldP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldS_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Имя";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reset
            // 
            this.reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reset.Location = new System.Drawing.Point(705, 3);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(65, 42);
            this.reset.TabIndex = 9;
            this.reset.Text = "Сброс";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // snpSrch
            // 
            this.snpSrch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snpSrch.Location = new System.Drawing.Point(582, 3);
            this.snpSrch.Name = "snpSrch";
            this.snpSrch.Size = new System.Drawing.Size(117, 42);
            this.snpSrch.TabIndex = 8;
            this.snpSrch.Text = "Поиск";
            this.snpSrch.UseVisualStyleBackColor = true;
            this.snpSrch.Click += new System.EventHandler(this.snpSrch_Click);
            // 
            // idfingerprintableDataGridViewTextBoxColumn
            // 
            this.idfingerprintableDataGridViewTextBoxColumn.DataPropertyName = "id_fingerprintable";
            this.idfingerprintableDataGridViewTextBoxColumn.HeaderText = "№";
            this.idfingerprintableDataGridViewTextBoxColumn.Name = "idfingerprintableDataGridViewTextBoxColumn";
            this.idfingerprintableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "Отчество";
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            this.patronymicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthdateDataGridViewTextBoxColumn
            // 
            this.birthdateDataGridViewTextBoxColumn.DataPropertyName = "birthdate";
            this.birthdateDataGridViewTextBoxColumn.HeaderText = "Дата рождения";
            this.birthdateDataGridViewTextBoxColumn.Name = "birthdateDataGridViewTextBoxColumn";
            this.birthdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idworkerDataGridViewTextBoxColumn
            // 
            this.idworkerDataGridViewTextBoxColumn.DataPropertyName = "id_worker";
            this.idworkerDataGridViewTextBoxColumn.HeaderText = "id_worker";
            this.idworkerDataGridViewTextBoxColumn.Name = "idworkerDataGridViewTextBoxColumn";
            this.idworkerDataGridViewTextBoxColumn.ReadOnly = true;
            this.idworkerDataGridViewTextBoxColumn.Visible = false;
            // 
            // fingerprintablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.fingerprintablesTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "fingerprintablesForm";
            this.Text = "Дактилоскопируемые";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fingerprintablesForm_FormClosed);
            this.Load += new System.EventHandler(this.fingerprintablesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fingerprintablesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vfingerprintablesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dactylo_dbDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView fingerprintablesTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button view;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button delete;
        private dactylo_dbDataSet dactylo_dbDataSet;
        private System.Windows.Forms.BindingSource vfingerprintablesBindingSource;
        private dactylo_dbDataSetTableAdapters.v_fingerprintablesTableAdapter v_fingerprintablesTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox fieldS;
        private System.Windows.Forms.TextBox fieldN;
        private System.Windows.Forms.TextBox fieldP;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button snpSrch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfingerprintableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idworkerDataGridViewTextBoxColumn;
    }
}