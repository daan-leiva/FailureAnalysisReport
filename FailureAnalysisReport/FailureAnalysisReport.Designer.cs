namespace FailureAnalysisReport
{
    partial class FailureAnalysisReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ncDataButton = new System.Windows.Forms.Button();
            this.cpaDataButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.ViewHoursButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.estimatedHoursTextBox = new System.Windows.Forms.TextBox();
            this.combinedTimeTrackingButton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Failure Analysis Report";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(49, 103);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 1;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(49, 168);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 2;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(46, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(49, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date";
            // 
            // ncDataButton
            // 
            this.ncDataButton.Location = new System.Drawing.Point(282, 111);
            this.ncDataButton.Name = "ncDataButton";
            this.ncDataButton.Size = new System.Drawing.Size(75, 67);
            this.ncDataButton.TabIndex = 5;
            this.ncDataButton.Text = "View NC Data";
            this.ncDataButton.UseVisualStyleBackColor = true;
            this.ncDataButton.Click += new System.EventHandler(this.ncDataButton_Click);
            // 
            // cpaDataButton
            // 
            this.cpaDataButton.Location = new System.Drawing.Point(363, 111);
            this.cpaDataButton.Name = "cpaDataButton";
            this.cpaDataButton.Size = new System.Drawing.Size(75, 67);
            this.cpaDataButton.TabIndex = 6;
            this.cpaDataButton.Text = "View CPA Data";
            this.cpaDataButton.UseVisualStyleBackColor = true;
            this.cpaDataButton.Click += new System.EventHandler(this.cpaDataButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(49, 242);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1153, 503);
            this.dataGridView.TabIndex = 7;
            // 
            // rowsLabel
            // 
            this.rowsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(1134, 752);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(37, 13);
            this.rowsLabel.TabIndex = 8;
            this.rowsLabel.Text = "Rows:";
            // 
            // ViewHoursButton
            // 
            this.ViewHoursButton.Location = new System.Drawing.Point(444, 111);
            this.ViewHoursButton.Name = "ViewHoursButton";
            this.ViewHoursButton.Size = new System.Drawing.Size(75, 67);
            this.ViewHoursButton.TabIndex = 9;
            this.ViewHoursButton.Text = "View Failure Analysis";
            this.ViewHoursButton.UseVisualStyleBackColor = true;
            this.ViewHoursButton.Click += new System.EventHandler(this.ViewHoursButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Estimated Total Hours:";
            // 
            // estimatedHoursTextBox
            // 
            this.estimatedHoursTextBox.Location = new System.Drawing.Point(660, 207);
            this.estimatedHoursTextBox.Name = "estimatedHoursTextBox";
            this.estimatedHoursTextBox.Size = new System.Drawing.Size(120, 20);
            this.estimatedHoursTextBox.TabIndex = 11;
            this.estimatedHoursTextBox.TextChanged += new System.EventHandler(this.estimatedHoursTextBox_TextChanged);
            // 
            // combinedTimeTrackingButton
            // 
            this.combinedTimeTrackingButton.Location = new System.Drawing.Point(525, 111);
            this.combinedTimeTrackingButton.Name = "combinedTimeTrackingButton";
            this.combinedTimeTrackingButton.Size = new System.Drawing.Size(75, 67);
            this.combinedTimeTrackingButton.TabIndex = 12;
            this.combinedTimeTrackingButton.Text = "Time Tracking Combined PBMA";
            this.combinedTimeTrackingButton.UseVisualStyleBackColor = true;
            this.combinedTimeTrackingButton.Click += new System.EventHandler(this.combinedTimeTrackingButton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Location = new System.Drawing.Point(804, 111);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(75, 67);
            this.exportToExcelButton.TabIndex = 13;
            this.exportToExcelButton.Text = "Export To Excel Sheet";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // FailureAnalysisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 778);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.combinedTimeTrackingButton);
            this.Controls.Add(this.estimatedHoursTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ViewHoursButton);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cpaDataButton);
            this.Controls.Add(this.ncDataButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.label1);
            this.Name = "FailureAnalysisReport";
            this.Text = "Failure Analysis Report";
            this.Load += new System.EventHandler(this.FailureAnalysisReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ncDataButton;
        private System.Windows.Forms.Button cpaDataButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Button ViewHoursButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox estimatedHoursTextBox;
        private System.Windows.Forms.Button combinedTimeTrackingButton;
        private System.Windows.Forms.Button exportToExcelButton;
    }
}

