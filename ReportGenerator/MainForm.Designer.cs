namespace ReportGeneratorUI_0._1
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbPathToDir = new System.Windows.Forms.TextBox();
            this.lblPathToDirectory = new System.Windows.Forms.Label();
            this.btnDownloadCSV = new System.Windows.Forms.Button();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassedCount = new System.Windows.Forms.Label();
            this.lblFailedCount = new System.Windows.Forms.Label();
            this.lblFail = new System.Windows.Forms.Label();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.rbShowPassed = new System.Windows.Forms.RadioButton();
            this.rbShowFailed = new System.Windows.Forms.RadioButton();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.resultRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testResultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultRecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPathToDir
            // 
            this.tbPathToDir.Location = new System.Drawing.Point(109, 18);
            this.tbPathToDir.Name = "tbPathToDir";
            this.tbPathToDir.Size = new System.Drawing.Size(319, 20);
            this.tbPathToDir.TabIndex = 0;
            // 
            // lblPathToDirectory
            // 
            this.lblPathToDirectory.AutoSize = true;
            this.lblPathToDirectory.Location = new System.Drawing.Point(13, 21);
            this.lblPathToDirectory.Name = "lblPathToDirectory";
            this.lblPathToDirectory.Size = new System.Drawing.Size(90, 13);
            this.lblPathToDirectory.TabIndex = 2;
            this.lblPathToDirectory.Text = "Path To Directory";
            // 
            // btnDownloadCSV
            // 
            this.btnDownloadCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownloadCSV.Location = new System.Drawing.Point(16, 643);
            this.btnDownloadCSV.Name = "btnDownloadCSV";
            this.btnDownloadCSV.Size = new System.Drawing.Size(100, 23);
            this.btnDownloadCSV.TabIndex = 5;
            this.btnDownloadCSV.Text = "Download CSV";
            this.btnDownloadCSV.UseVisualStyleBackColor = true;
            this.btnDownloadCSV.Click += new System.EventHandler(this.btnDownloadCSV_Click);
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToAddRows = false;
            this.gvResults.AllowUserToDeleteRows = false;
            this.gvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvResults.AutoGenerateColumns = false;
            this.gvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testNumberDataGridViewTextBoxColumn,
            this.testResultDataGridViewTextBoxColumn,
            this.imageNameDataGridViewTextBoxColumn});
            this.gvResults.DataSource = this.resultRecordBindingSource;
            this.gvResults.Location = new System.Drawing.Point(16, 113);
            this.gvResults.Name = "gvResults";
            this.gvResults.Size = new System.Drawing.Size(1113, 524);
            this.gvResults.TabIndex = 6;
            this.gvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResults_CellDoubleClick);
            // 
            // btnDirectory
            // 
            this.btnDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectory.Location = new System.Drawing.Point(434, 16);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(29, 23);
            this.btnDirectory.TabIndex = 7;
            this.btnDirectory.Text = "...";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(469, 16);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(61, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(890, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Passed:";
            // 
            // lblPassedCount
            // 
            this.lblPassedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassedCount.AutoSize = true;
            this.lblPassedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedCount.ForeColor = System.Drawing.Color.Green;
            this.lblPassedCount.Location = new System.Drawing.Point(964, 15);
            this.lblPassedCount.Name = "lblPassedCount";
            this.lblPassedCount.Size = new System.Drawing.Size(21, 24);
            this.lblPassedCount.TabIndex = 10;
            this.lblPassedCount.Text = "0";
            // 
            // lblFailedCount
            // 
            this.lblFailedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFailedCount.AutoSize = true;
            this.lblFailedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedCount.ForeColor = System.Drawing.Color.Red;
            this.lblFailedCount.Location = new System.Drawing.Point(1090, 14);
            this.lblFailedCount.Name = "lblFailedCount";
            this.lblFailedCount.Size = new System.Drawing.Size(21, 24);
            this.lblFailedCount.TabIndex = 11;
            this.lblFailedCount.Text = "0";
            // 
            // lblFail
            // 
            this.lblFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFail.AutoSize = true;
            this.lblFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFail.ForeColor = System.Drawing.Color.Red;
            this.lblFail.Location = new System.Drawing.Point(1004, 14);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(74, 24);
            this.lblFail.TabIndex = 12;
            this.lblFail.Text = "Failed:";
            // 
            // rbShowAll
            // 
            this.rbShowAll.AutoSize = true;
            this.rbShowAll.Checked = true;
            this.rbShowAll.Location = new System.Drawing.Point(6, 19);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(36, 17);
            this.rbShowAll.TabIndex = 13;
            this.rbShowAll.TabStop = true;
            this.rbShowAll.Text = "All";
            this.rbShowAll.UseVisualStyleBackColor = true;
            this.rbShowAll.CheckedChanged += new System.EventHandler(this.filter_Changed);
            // 
            // rbShowPassed
            // 
            this.rbShowPassed.AutoSize = true;
            this.rbShowPassed.Location = new System.Drawing.Point(48, 19);
            this.rbShowPassed.Name = "rbShowPassed";
            this.rbShowPassed.Size = new System.Drawing.Size(60, 17);
            this.rbShowPassed.TabIndex = 14;
            this.rbShowPassed.Text = "Passed";
            this.rbShowPassed.UseVisualStyleBackColor = true;
            this.rbShowPassed.CheckedChanged += new System.EventHandler(this.filter_Changed);
            // 
            // rbShowFailed
            // 
            this.rbShowFailed.AutoSize = true;
            this.rbShowFailed.Location = new System.Drawing.Point(114, 19);
            this.rbShowFailed.Name = "rbShowFailed";
            this.rbShowFailed.Size = new System.Drawing.Size(53, 17);
            this.rbShowFailed.TabIndex = 15;
            this.rbShowFailed.Text = "Failed";
            this.rbShowFailed.UseVisualStyleBackColor = true;
            this.rbShowFailed.CheckedChanged += new System.EventHandler(this.filter_Changed);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.tbFilter);
            this.groupBoxFilter.Controls.Add(this.rbShowAll);
            this.groupBoxFilter.Controls.Add(this.rbShowFailed);
            this.groupBoxFilter.Controls.Add(this.rbShowPassed);
            this.groupBoxFilter.Location = new System.Drawing.Point(16, 59);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(969, 48);
            this.groupBoxFilter.TabIndex = 16;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(277, 18);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(670, 20);
            this.tbFilter.TabIndex = 17;
            this.tbFilter.TextChanged += new System.EventHandler(this.filter_Changed);
            this.tbFilter.Enter += new System.EventHandler(this.tbFilter_Enter);
            this.tbFilter.Leave += new System.EventHandler(this.tbFilter_Leave);
            // 
            // resultRecordBindingSource
            // 
            this.resultRecordBindingSource.DataSource = typeof(ReportGeneratorUI_0._1.Model.ResultRecord);
            // 
            // testNumberDataGridViewTextBoxColumn
            // 
            this.testNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.testNumberDataGridViewTextBoxColumn.DataPropertyName = "TestNumber";
            this.testNumberDataGridViewTextBoxColumn.FillWeight = 70F;
            this.testNumberDataGridViewTextBoxColumn.HeaderText = "TestNumber";
            this.testNumberDataGridViewTextBoxColumn.Name = "testNumberDataGridViewTextBoxColumn";
            this.testNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.testNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.testNumberDataGridViewTextBoxColumn.Width = 90;
            // 
            // testResultDataGridViewTextBoxColumn
            // 
            this.testResultDataGridViewTextBoxColumn.DataPropertyName = "TestResult";
            this.testResultDataGridViewTextBoxColumn.FillWeight = 750F;
            this.testResultDataGridViewTextBoxColumn.HeaderText = "TestResult";
            this.testResultDataGridViewTextBoxColumn.Name = "testResultDataGridViewTextBoxColumn";
            this.testResultDataGridViewTextBoxColumn.ReadOnly = true;
            this.testResultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // imageNameDataGridViewTextBoxColumn
            // 
            this.imageNameDataGridViewTextBoxColumn.DataPropertyName = "ImageThumbnail";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.imageNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.imageNameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.imageNameDataGridViewTextBoxColumn.HeaderText = "ImageThumbnail";
            this.imageNameDataGridViewTextBoxColumn.Name = "imageNameDataGridViewTextBoxColumn";
            this.imageNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.imageNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imageNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 697);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.lblFail);
            this.Controls.Add(this.lblFailedCount);
            this.Controls.Add(this.lblPassedCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnDirectory);
            this.Controls.Add(this.gvResults);
            this.Controls.Add(this.btnDownloadCSV);
            this.Controls.Add(this.lblPathToDirectory);
            this.Controls.Add(this.tbPathToDir);
            this.Name = "MainForm";
            this.Text = "Report Generator";
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultRecordBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPathToDir;
        private System.Windows.Forms.Label lblPathToDirectory;
        private System.Windows.Forms.Button btnDownloadCSV;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.BindingSource resultRecordBindingSource;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassedCount;
        private System.Windows.Forms.Label lblFailedCount;
        private System.Windows.Forms.Label lblFail;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.RadioButton rbShowPassed;
        private System.Windows.Forms.RadioButton rbShowFailed;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn testNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn imageNameDataGridViewTextBoxColumn;
    }
}

