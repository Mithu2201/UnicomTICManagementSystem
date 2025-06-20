namespace UnicomTICManagementSystem
{
    partial class CourseMenuForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CoursePannel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Create Course";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Exit";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // CoursePannel
            // 
            this.CoursePannel.Location = new System.Drawing.Point(104, 62);
            this.CoursePannel.Name = "CoursePannel";
            this.CoursePannel.Size = new System.Drawing.Size(650, 350);
            this.CoursePannel.TabIndex = 21;
            this.CoursePannel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "COURSE SUBJECT MENU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Create Subjects";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CourseMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 411);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CoursePannel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseMenuForm";
            this.Text = "CourseMenuForm";
            this.Load += new System.EventHandler(this.CourseMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel CoursePannel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}