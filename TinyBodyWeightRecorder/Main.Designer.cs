namespace TinyBodyWeightRecorder
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recordData = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBodyWight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextRowRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.add = new System.Windows.Forms.Button();
            this.bodyWight = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordData)).BeginInit();
            this.contextMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodyWight)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.recordData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.973045F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.02695F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // recordData
            // 
            this.recordData.AllowUserToAddRows = false;
            this.recordData.AllowUserToDeleteRows = false;
            this.recordData.AllowUserToResizeColumns = false;
            this.recordData.AllowUserToResizeRows = false;
            this.recordData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnBodyWight});
            this.recordData.ContextMenuStrip = this.contextMain;
            this.recordData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordData.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.recordData.Location = new System.Drawing.Point(3, 46);
            this.recordData.MultiSelect = false;
            this.recordData.Name = "recordData";
            this.recordData.RowTemplate.Height = 21;
            this.recordData.Size = new System.Drawing.Size(348, 388);
            this.recordData.TabIndex = 4;
            this.recordData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.recordData_CellMouseDown);
            this.recordData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordData_CellValueChanged);
            // 
            // ColumnDate
            // 
            this.ColumnDate.DataPropertyName = "WeighingDate";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnDate.HeaderText = "日付";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnBodyWight
            // 
            this.ColumnBodyWight.DataPropertyName = "Wight";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.ColumnBodyWight.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnBodyWight.HeaderText = "体重";
            this.ColumnBodyWight.Name = "ColumnBodyWight";
            // 
            // contextMain
            // 
            this.contextMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextRowRemove});
            this.contextMain.Name = "contextMenuStrip1";
            this.contextMain.Size = new System.Drawing.Size(99, 26);
            // 
            // contextRowRemove
            // 
            this.contextRowRemove.Name = "contextRowRemove";
            this.contextRowRemove.Size = new System.Drawing.Size(98, 22);
            this.contextRowRemove.Text = "削除";
            this.contextRowRemove.Click += new System.EventHandler(this.contextRowRemove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.add);
            this.panel1.Controls.Add(this.bodyWight);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 37);
            this.panel1.TabIndex = 5;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(249, 1);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 2;
            this.add.Text = "追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // bodyWight
            // 
            this.bodyWight.DecimalPlaces = 1;
            this.bodyWight.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.bodyWight.Location = new System.Drawing.Point(150, 3);
            this.bodyWight.Name = "bodyWight";
            this.bodyWight.Size = new System.Drawing.Size(92, 19);
            this.bodyWight.TabIndex = 1;
            this.bodyWight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bodyWight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bodyWight_KeyDown);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dateTimePicker.Location = new System.Drawing.Point(37, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(107, 19);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2018, 2, 10, 0, 0, 0, 0);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemGraph,
            this.MenuItemOptions});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(354, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSaveFile});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(53, 20);
            this.MenuItemFile.Text = "ファイル";
            // 
            // MenuItemSaveFile
            // 
            this.MenuItemSaveFile.Name = "MenuItemSaveFile";
            this.MenuItemSaveFile.Size = new System.Drawing.Size(98, 22);
            this.MenuItemSaveFile.Text = "保存";
            this.MenuItemSaveFile.Click += new System.EventHandler(this.MenuItemSaveFile_Click);
            // 
            // MenuItemGraph
            // 
            this.MenuItemGraph.Name = "MenuItemGraph";
            this.MenuItemGraph.Size = new System.Drawing.Size(68, 20);
            this.MenuItemGraph.Text = "グラフ表示";
            this.MenuItemGraph.Click += new System.EventHandler(this.MenuItemGraph_Click);
            // 
            // MenuItemOptions
            // 
            this.MenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAutoSave});
            this.MenuItemOptions.Name = "MenuItemOptions";
            this.MenuItemOptions.Size = new System.Drawing.Size(63, 20);
            this.MenuItemOptions.Text = "オプション";
            // 
            // toolStripMenuItemAutoSave
            // 
            this.toolStripMenuItemAutoSave.Checked = true;
            this.toolStripMenuItemAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemAutoSave.Name = "toolStripMenuItemAutoSave";
            this.toolStripMenuItemAutoSave.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAutoSave.Text = "自動保存";
            this.toolStripMenuItemAutoSave.Click += new System.EventHandler(this.toolStripMenuItemAutoSave_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 1000);
            this.MinimumSize = new System.Drawing.Size(370, 500);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "簡易版体重記録ツール";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordData)).EndInit();
            this.contextMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodyWight)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ContextMenuStrip contextMain;
        private System.Windows.Forms.DataGridView recordData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown bodyWight;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGraph;
        private System.Windows.Forms.ToolStripMenuItem contextRowRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBodyWight;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutoSave;
    }
}

