namespace UnicomTICManagementSystem
{
    partial class StudentTimetableForm
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
            this.StdTidataGridView = new System.Windows.Forms.DataGridView();
            this.StdTicomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StdTiCourse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StdTiSearchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StdTiPhone = new System.Windows.Forms.TextBox();
            this.StdTiAddress = new System.Windows.Forms.TextBox();
            this.StdTiName = new System.Windows.Forms.TextBox();
            this.StdTiSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StdTidataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StdTidataGridView
            // 
            this.StdTidataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StdTidataGridView.Location = new System.Drawing.Point(69, 157);
            this.StdTidataGridView.Name = "StdTidataGridView";
            this.StdTidataGridView.Size = new System.Drawing.Size(512, 111);
            this.StdTidataGridView.TabIndex = 28;
            this.StdTidataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StdTidataGridView_CellContentClick);
            // 
            // StdTicomboBox
            // 
            this.StdTicomboBox.FormattingEnabled = true;
            this.StdTicomboBox.Location = new System.Drawing.Point(401, 101);
            this.StdTicomboBox.Name = "StdTicomboBox";
            this.StdTicomboBox.Size = new System.Drawing.Size(191, 21);
            this.StdTicomboBox.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Subject Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Course Name";
            // 
            // StdTiCourse
            // 
            this.StdTiCourse.Location = new System.Drawing.Point(120, 101);
            this.StdTiCourse.Name = "StdTiCourse";
            this.StdTiCourse.Size = new System.Drawing.Size(191, 20);
            this.StdTiCourse.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Phone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name";
            // 
            // StdTiSearchBtn
            // 
            this.StdTiSearchBtn.Location = new System.Drawing.Point(506, 4);
            this.StdTiSearchBtn.Name = "StdTiSearchBtn";
            this.StdTiSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.StdTiSearchBtn.TabIndex = 20;
            this.StdTiSearchBtn.Text = "Search";
            this.StdTiSearchBtn.UseVisualStyleBackColor = true;
            this.StdTiSearchBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter Student ID";
            // 
            // StdTiPhone
            // 
            this.StdTiPhone.Location = new System.Drawing.Point(492, 48);
            this.StdTiPhone.Name = "StdTiPhone";
            this.StdTiPhone.Size = new System.Drawing.Size(148, 20);
            this.StdTiPhone.TabIndex = 18;
            // 
            // StdTiAddress
            // 
            this.StdTiAddress.Location = new System.Drawing.Point(257, 47);
            this.StdTiAddress.Name = "StdTiAddress";
            this.StdTiAddress.Size = new System.Drawing.Size(148, 20);
            this.StdTiAddress.TabIndex = 17;
            // 
            // StdTiName
            // 
            this.StdTiName.Location = new System.Drawing.Point(52, 47);
            this.StdTiName.Name = "StdTiName";
            this.StdTiName.Size = new System.Drawing.Size(148, 20);
            this.StdTiName.TabIndex = 16;
            // 
            // StdTiSearch
            // 
            this.StdTiSearch.Location = new System.Drawing.Point(208, 4);
            this.StdTiSearch.Name = "StdTiSearch";
            this.StdTiSearch.Size = new System.Drawing.Size(249, 20);
            this.StdTiSearch.TabIndex = 15;
            // 
            // StudentTimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.StdTidataGridView);
            this.Controls.Add(this.StdTicomboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StdTiCourse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StdTiSearchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StdTiPhone);
            this.Controls.Add(this.StdTiAddress);
            this.Controls.Add(this.StdTiName);
            this.Controls.Add(this.StdTiSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentTimetableForm";
            this.Text = "StudentManagementForm";
            this.Load += new System.EventHandler(this.StudentTimetableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StdTidataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StdTidataGridView;
        private System.Windows.Forms.ComboBox StdTicomboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StdTiCourse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StdTiSearchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StdTiPhone;
        private System.Windows.Forms.TextBox StdTiAddress;
        private System.Windows.Forms.TextBox StdTiName;
        private System.Windows.Forms.TextBox StdTiSearch;
    }
}