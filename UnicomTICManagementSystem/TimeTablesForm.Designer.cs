namespace UnicomTICManagementSystem
{
    partial class TimeTablesForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.TimedataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TimecomboBox = new System.Windows.Forms.ComboBox();
            this.TiDaycomboBox = new System.Windows.Forms.ComboBox();
            this.TiSlotcomboBox = new System.Windows.Forms.ComboBox();
            this.CoursecomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SelectcomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LecturecomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimedataGridView
            // 
            this.TimedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TimedataGridView.Location = new System.Drawing.Point(133, 227);
            this.TimedataGridView.Name = "TimedataGridView";
            this.TimedataGridView.Size = new System.Drawing.Size(422, 117);
            this.TimedataGridView.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "TIME SLOT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "DAY";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(563, 62);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 53;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(140, 185);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 52;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(251, 185);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 51;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(360, 185);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 50;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "ROOM NAME";
            // 
            // TimecomboBox
            // 
            this.TimecomboBox.FormattingEnabled = true;
            this.TimecomboBox.Location = new System.Drawing.Point(251, 92);
            this.TimecomboBox.Name = "TimecomboBox";
            this.TimecomboBox.Size = new System.Drawing.Size(304, 21);
            this.TimecomboBox.TabIndex = 61;
            // 
            // TiDaycomboBox
            // 
            this.TiDaycomboBox.FormattingEnabled = true;
            this.TiDaycomboBox.Location = new System.Drawing.Point(251, 125);
            this.TiDaycomboBox.Name = "TiDaycomboBox";
            this.TiDaycomboBox.Size = new System.Drawing.Size(304, 21);
            this.TiDaycomboBox.TabIndex = 62;
            // 
            // TiSlotcomboBox
            // 
            this.TiSlotcomboBox.FormattingEnabled = true;
            this.TiSlotcomboBox.Location = new System.Drawing.Point(251, 157);
            this.TiSlotcomboBox.Name = "TiSlotcomboBox";
            this.TiSlotcomboBox.Size = new System.Drawing.Size(304, 21);
            this.TiSlotcomboBox.TabIndex = 63;
            // 
            // CoursecomboBox
            // 
            this.CoursecomboBox.FormattingEnabled = true;
            this.CoursecomboBox.Location = new System.Drawing.Point(251, 31);
            this.CoursecomboBox.Name = "CoursecomboBox";
            this.CoursecomboBox.Size = new System.Drawing.Size(304, 21);
            this.CoursecomboBox.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "COURSE NAME";
            // 
            // SelectcomboBox
            // 
            this.SelectcomboBox.FormattingEnabled = true;
            this.SelectcomboBox.Location = new System.Drawing.Point(251, 61);
            this.SelectcomboBox.Name = "SelectcomboBox";
            this.SelectcomboBox.Size = new System.Drawing.Size(304, 21);
            this.SelectcomboBox.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "SUBJECT NAME";
            // 
            // LecturecomboBox
            // 
            this.LecturecomboBox.FormattingEnabled = true;
            this.LecturecomboBox.Location = new System.Drawing.Point(251, 4);
            this.LecturecomboBox.Name = "LecturecomboBox";
            this.LecturecomboBox.Size = new System.Drawing.Size(304, 21);
            this.LecturecomboBox.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "LECTURE NAME";
            // 
            // TimeTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LecturecomboBox);
            this.Controls.Add(this.SelectcomboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CoursecomboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TiSlotcomboBox);
            this.Controls.Add(this.TiDaycomboBox);
            this.Controls.Add(this.TimecomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimedataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeTablesForm";
            this.Text = "TimeTables";
            this.Load += new System.EventHandler(this.TimeTablesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView TimedataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TimecomboBox;
        private System.Windows.Forms.ComboBox TiDaycomboBox;
        private System.Windows.Forms.ComboBox TiSlotcomboBox;
        private System.Windows.Forms.ComboBox CoursecomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SelectcomboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LecturecomboBox;
        private System.Windows.Forms.Label label4;
    }
}