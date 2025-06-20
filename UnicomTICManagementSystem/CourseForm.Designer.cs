namespace UnicomTICManagementSystem
{
    partial class CourseForm
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
            this.CoursedataGridView = new System.Windows.Forms.DataGridView();
            this.Couname = new System.Windows.Forms.TextBox();
            this.Coucode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CoursedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CoursedataGridView
            // 
            this.CoursedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursedataGridView.Location = new System.Drawing.Point(154, 151);
            this.CoursedataGridView.Name = "CoursedataGridView";
            this.CoursedataGridView.Size = new System.Drawing.Size(422, 133);
            this.CoursedataGridView.TabIndex = 36;
            // 
            // Couname
            // 
            this.Couname.Location = new System.Drawing.Point(272, 45);
            this.Couname.Name = "Couname";
            this.Couname.Size = new System.Drawing.Size(304, 20);
            this.Couname.TabIndex = 34;
            // 
            // Coucode
            // 
            this.Coucode.Location = new System.Drawing.Point(272, 1);
            this.Coucode.Name = "Coucode";
            this.Coucode.Size = new System.Drawing.Size(304, 20);
            this.Coucode.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "COURSE NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "COURSE CODE";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(154, 107);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 29;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(249, 107);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 28;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(330, 107);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 27;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(420, 107);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 26;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CoursedataGridView);
            this.Controls.Add(this.Couname);
            this.Controls.Add(this.Coucode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoursedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView CoursedataGridView;
        private System.Windows.Forms.TextBox Couname;
        private System.Windows.Forms.TextBox Coucode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
    }
}