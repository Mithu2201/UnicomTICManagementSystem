namespace UnicomTICManagementSystem
{
    partial class StudentForm
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
            this.StddAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.StdddataGridView = new System.Windows.Forms.DataGridView();
            this.StddPhone = new System.Windows.Forms.TextBox();
            this.Stddname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StdddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StddAddress
            // 
            this.StddAddress.Location = new System.Drawing.Point(186, 63);
            this.StddAddress.Name = "StddAddress";
            this.StddAddress.Size = new System.Drawing.Size(304, 20);
            this.StddAddress.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StdddataGridView
            // 
            this.StdddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StdddataGridView.Location = new System.Drawing.Point(68, 152);
            this.StdddataGridView.Name = "StdddataGridView";
            this.StdddataGridView.Size = new System.Drawing.Size(422, 133);
            this.StdddataGridView.TabIndex = 35;
            this.StdddataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StdddataGridView_CellContentClick);
            // 
            // StddPhone
            // 
            this.StddPhone.Location = new System.Drawing.Point(186, 31);
            this.StddPhone.Name = "StddPhone";
            this.StddPhone.Size = new System.Drawing.Size(304, 20);
            this.StddPhone.TabIndex = 34;
            // 
            // Stddname
            // 
            this.Stddname.Location = new System.Drawing.Point(186, 2);
            this.Stddname.Name = "Stddname";
            this.Stddname.Size = new System.Drawing.Size(304, 20);
            this.Stddname.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "STUDENT ADDRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "STUDENT PH NO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "STUDENT NAME";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(117, 108);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 29;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(215, 108);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 28;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(315, 108);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 27;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.StddAddress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StdddataGridView);
            this.Controls.Add(this.StddPhone);
            this.Controls.Add(this.Stddname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StdddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StddAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView StdddataGridView;
        private System.Windows.Forms.TextBox StddPhone;
        private System.Windows.Forms.TextBox Stddname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
    }
}