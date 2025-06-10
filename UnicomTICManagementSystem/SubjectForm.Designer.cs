namespace UnicomTICManagementSystem
{
    partial class SubjectForm
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
            this.Sadd = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Ssearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubCode = new System.Windows.Forms.TextBox();
            this.SubName = new System.Windows.Forms.TextBox();
            this.SubdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SubcomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SubdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(424, 108);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 26;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(334, 108);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 27;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(253, 108);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 28;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(158, 108);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 29;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "SUBJECT NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "COURSE NAME";
            // 
            // SubCode
            // 
            this.SubCode.Location = new System.Drawing.Point(276, 34);
            this.SubCode.Name = "SubCode";
            this.SubCode.Size = new System.Drawing.Size(304, 20);
            this.SubCode.TabIndex = 33;
            // 
            // SubName
            // 
            this.SubName.Location = new System.Drawing.Point(276, 64);
            this.SubName.Name = "SubName";
            this.SubName.Size = new System.Drawing.Size(304, 20);
            this.SubName.TabIndex = 34;
            // 
            // SubdataGridView
            // 
            this.SubdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubdataGridView.Location = new System.Drawing.Point(158, 152);
            this.SubdataGridView.Name = "SubdataGridView";
            this.SubdataGridView.Size = new System.Drawing.Size(422, 133);
            this.SubdataGridView.TabIndex = 36;
            this.SubdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StddataGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "SUBJECT CODE";
            // 
            // SubcomboBox
            // 
            this.SubcomboBox.FormattingEnabled = true;
            this.SubcomboBox.Location = new System.Drawing.Point(276, 2);
            this.SubcomboBox.Name = "SubcomboBox";
            this.SubcomboBox.Size = new System.Drawing.Size(304, 21);
            this.SubcomboBox.TabIndex = 40;
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SubcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubdataGridView);
            this.Controls.Add(this.SubName);
            this.Controls.Add(this.SubCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubjectForm";
            this.Text = "SubjectForm";
            this.Load += new System.EventHandler(this.SubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SubdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubCode;
        private System.Windows.Forms.TextBox SubName;
        private System.Windows.Forms.DataGridView SubdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SubcomboBox;
    }
}