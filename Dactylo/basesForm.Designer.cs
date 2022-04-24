namespace Dactylo
{
    partial class basesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(basesForm));
            this.basesTable = new System.Windows.Forms.DataGridView();
            this.idbaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idworkerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vworkersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dactylo_dbDataSet = new Dactylo.dactylo_dbDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.view = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.v_workersTableAdapter = new Dactylo.dactylo_dbDataSetTableAdapters.v_workersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.basesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vworkersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dactylo_dbDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // basesTable
            // 
            this.basesTable.AllowUserToAddRows = false;
            this.basesTable.AllowUserToDeleteRows = false;
            this.basesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basesTable.AutoGenerateColumns = false;
            this.basesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.basesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.basesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbaseDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.idworkerDataGridViewTextBoxColumn});
            this.basesTable.DataSource = this.vworkersBindingSource;
            this.basesTable.Location = new System.Drawing.Point(15, 12);
            this.basesTable.MultiSelect = false;
            this.basesTable.Name = "basesTable";
            this.basesTable.ReadOnly = true;
            this.basesTable.Size = new System.Drawing.Size(735, 357);
            this.basesTable.TabIndex = 0;
            this.basesTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.basesTable_CellEnter);
            // 
            // idbaseDataGridViewTextBoxColumn
            // 
            this.idbaseDataGridViewTextBoxColumn.DataPropertyName = "id_base";
            this.idbaseDataGridViewTextBoxColumn.HeaderText = "№";
            this.idbaseDataGridViewTextBoxColumn.Name = "idbaseDataGridViewTextBoxColumn";
            this.idbaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Название";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Основание";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idworkerDataGridViewTextBoxColumn
            // 
            this.idworkerDataGridViewTextBoxColumn.DataPropertyName = "id_worker";
            this.idworkerDataGridViewTextBoxColumn.HeaderText = "id_worker";
            this.idworkerDataGridViewTextBoxColumn.Name = "idworkerDataGridViewTextBoxColumn";
            this.idworkerDataGridViewTextBoxColumn.ReadOnly = true;
            this.idworkerDataGridViewTextBoxColumn.Visible = false;
            // 
            // vworkersBindingSource
            // 
            this.vworkersBindingSource.DataMember = "v_workers";
            this.vworkersBindingSource.DataSource = this.dactylo_dbDataSet;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 376);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 38);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // view
            // 
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Location = new System.Drawing.Point(114, 3);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(105, 33);
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
            this.add.Size = new System.Drawing.Size(105, 33);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // back
            // 
            this.back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back.Location = new System.Drawing.Point(632, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(106, 33);
            this.back.TabIndex = 4;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // delete
            // 
            this.delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(225, 3);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(105, 33);
            this.delete.TabIndex = 3;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // v_workersTableAdapter
            // 
            this.v_workersTableAdapter.ClearBeforeFill = true;
            // 
            // basesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.basesTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(781, 465);
            this.Name = "basesForm";
            this.Text = "Основания к проведению дактилоскопической регистрации";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.basesForm_FormClosed);
            this.Load += new System.EventHandler(this.basesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vworkersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dactylo_dbDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView basesTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button view;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button delete;
        private dactylo_dbDataSet dactylo_dbDataSet;
        private System.Windows.Forms.BindingSource vworkersBindingSource;
        private dactylo_dbDataSetTableAdapters.v_workersTableAdapter v_workersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idworkerDataGridViewTextBoxColumn;
    }
}