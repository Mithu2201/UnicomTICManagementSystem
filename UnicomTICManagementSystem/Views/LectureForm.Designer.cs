namespace UnicomTICManagementSystem
{
    partial class LectureForm
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
            this.LecdataGridView = new System.Windows.Forms.DataGridView();
            this.LecAddress = new System.Windows.Forms.TextBox();
            this.LecPhone = new System.Windows.Forms.TextBox();
            this.Lecname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LecdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LecdataGridView
            // 
            this.LecdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LecdataGridView.Location = new System.Drawing.Point(73, 151);
            this.LecdataGridView.Name = "LecdataGridView";
            this.LecdataGridView.Size = new System.Drawing.Size(422, 133);
            this.LecdataGridView.TabIndex = 48;
            this.LecdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LecdataGridView_CellContentClick);
            // 
            // LecAddress
            // 
            this.LecAddress.Location = new System.Drawing.Point(191, 63);
            this.LecAddress.Name = "LecAddress";
            this.LecAddress.Size = new System.Drawing.Size(304, 20);
            this.LecAddress.TabIndex = 47;
            // 
            // LecPhone
            // 
            this.LecPhone.Location = new System.Drawing.Point(191, 30);
            this.LecPhone.Name = "LecPhone";
            this.LecPhone.Size = new System.Drawing.Size(304, 20);
            this.LecPhone.TabIndex = 46;
            // 
            // Lecname
            // 
            this.Lecname.Location = new System.Drawing.Point(191, 1);
            this.Lecname.Name = "Lecname";
            this.Lecname.Size = new System.Drawing.Size(304, 20);
            this.Lecname.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "ADDRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "PHONE NO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "NAME";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(114, 107);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 41;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click_1);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(216, 107);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 40;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click_1);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(316, 107);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 39;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // LectureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LecdataGridView);
            this.Controls.Add(this.LecAddress);
            this.Controls.Add(this.LecPhone);
            this.Controls.Add(this.Lecname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LectureForm";
            this.Text = "LectureForm";
            this.Load += new System.EventHandler(this.LectureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LecdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView LecdataGridView;
        private System.Windows.Forms.TextBox LecAddress;
        private System.Windows.Forms.TextBox LecPhone;
        private System.Windows.Forms.TextBox Lecname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
    }
}