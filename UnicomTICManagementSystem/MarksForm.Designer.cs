namespace UnicomTICManagementSystem
{
    partial class MarksForm
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
            this.MarkdataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.MarkcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Markgrade = new System.Windows.Forms.TextBox();
            this.MarkScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CoursecomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SelectcomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MarkdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MarkdataGridView
            // 
            this.MarkdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MarkdataGridView.Location = new System.Drawing.Point(78, 200);
            this.MarkdataGridView.Name = "MarkdataGridView";
            this.MarkdataGridView.Size = new System.Drawing.Size(422, 133);
            this.MarkdataGridView.TabIndex = 58;
            this.MarkdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MarkdataGridView_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "GRADE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "SCORE";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(78, 164);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 53;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(173, 164);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 52;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(254, 164);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 51;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(344, 164);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 50;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // MarkcomboBox
            // 
            this.MarkcomboBox.FormattingEnabled = true;
            this.MarkcomboBox.Location = new System.Drawing.Point(196, 60);
            this.MarkcomboBox.Name = "MarkcomboBox";
            this.MarkcomboBox.Size = new System.Drawing.Size(304, 21);
            this.MarkcomboBox.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "STUDENT NAME";
            // 
            // Markgrade
            // 
            this.Markgrade.Location = new System.Drawing.Point(196, 120);
            this.Markgrade.Name = "Markgrade";
            this.Markgrade.Size = new System.Drawing.Size(304, 20);
            this.Markgrade.TabIndex = 63;
            // 
            // MarkScore
            // 
            this.MarkScore.Location = new System.Drawing.Point(196, 89);
            this.MarkScore.Name = "MarkScore";
            this.MarkScore.Size = new System.Drawing.Size(304, 20);
            this.MarkScore.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "COURSE NAME";
            // 
            // CoursecomboBox
            // 
            this.CoursecomboBox.FormattingEnabled = true;
            this.CoursecomboBox.Location = new System.Drawing.Point(196, 3);
            this.CoursecomboBox.Name = "CoursecomboBox";
            this.CoursecomboBox.Size = new System.Drawing.Size(304, 21);
            this.CoursecomboBox.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "SUBJECT NAME";
            // 
            // SelectcomboBox
            // 
            this.SelectcomboBox.FormattingEnabled = true;
            this.SelectcomboBox.Location = new System.Drawing.Point(196, 32);
            this.SelectcomboBox.Name = "SelectcomboBox";
            this.SelectcomboBox.Size = new System.Drawing.Size(304, 21);
            this.SelectcomboBox.TabIndex = 66;
            // 
            // MarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectcomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CoursecomboBox);
            this.Controls.Add(this.Markgrade);
            this.Controls.Add(this.MarkScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MarkcomboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MarkdataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MarksForm";
            this.Text = "MarksForm";
            this.Load += new System.EventHandler(this.MarksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MarkdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView MarkdataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.ComboBox MarkcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Markgrade;
        private System.Windows.Forms.TextBox MarkScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CoursecomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SelectcomboBox;
    }
}