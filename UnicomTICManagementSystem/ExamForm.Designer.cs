namespace UnicomTICManagementSystem
{
    partial class ExamForm
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
            this.ExamdataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExamcomboBox = new System.Windows.Forms.ComboBox();
            this.TypecomboBox = new System.Windows.Forms.ComboBox();
            this.ExcomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExamdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ExamdataGridView
            // 
            this.ExamdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExamdataGridView.Location = new System.Drawing.Point(109, 151);
            this.ExamdataGridView.Name = "ExamdataGridView";
            this.ExamdataGridView.Size = new System.Drawing.Size(422, 133);
            this.ExamdataGridView.TabIndex = 58;
            this.ExamdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExdataGridView_CellContentClick_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "EXAM TYPE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "EXAM NAME";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(537, 2);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 53;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(125, 107);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 52;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(227, 107);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 51;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(335, 107);
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
            this.label1.Location = new System.Drawing.Point(111, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "SUBJECT NAME";
            // 
            // ExamcomboBox
            // 
            this.ExamcomboBox.FormattingEnabled = true;
            this.ExamcomboBox.Location = new System.Drawing.Point(227, 2);
            this.ExamcomboBox.Name = "ExamcomboBox";
            this.ExamcomboBox.Size = new System.Drawing.Size(304, 21);
            this.ExamcomboBox.TabIndex = 62;
            // 
            // TypecomboBox
            // 
            this.TypecomboBox.FormattingEnabled = true;
            this.TypecomboBox.Location = new System.Drawing.Point(227, 64);
            this.TypecomboBox.Name = "TypecomboBox";
            this.TypecomboBox.Size = new System.Drawing.Size(304, 21);
            this.TypecomboBox.TabIndex = 64;
            // 
            // ExcomboBox
            // 
            this.ExcomboBox.FormattingEnabled = true;
            this.ExcomboBox.Location = new System.Drawing.Point(227, 34);
            this.ExcomboBox.Name = "ExcomboBox";
            this.ExcomboBox.Size = new System.Drawing.Size(304, 21);
            this.ExcomboBox.TabIndex = 63;
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.TypecomboBox);
            this.Controls.Add(this.ExcomboBox);
            this.Controls.Add(this.ExamcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExamdataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            this.Load += new System.EventHandler(this.ExamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExamdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView ExamdataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ExamcomboBox;
        private System.Windows.Forms.ComboBox TypecomboBox;
        private System.Windows.Forms.ComboBox ExcomboBox;
    }
}