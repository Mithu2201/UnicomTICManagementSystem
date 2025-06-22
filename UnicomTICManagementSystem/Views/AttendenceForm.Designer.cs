namespace UnicomTICManagementSystem
{
    partial class AttendenceForm
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
            this.AttSubcomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AttStacomboBox = new System.Windows.Forms.ComboBox();
            this.AttStucomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AttenddataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.AttenddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AttSubcomboBox
            // 
            this.AttSubcomboBox.FormattingEnabled = true;
            this.AttSubcomboBox.Location = new System.Drawing.Point(226, 4);
            this.AttSubcomboBox.Name = "AttSubcomboBox";
            this.AttSubcomboBox.Size = new System.Drawing.Size(304, 21);
            this.AttSubcomboBox.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "SUBJECT NAME";
            // 
            // AttStacomboBox
            // 
            this.AttStacomboBox.FormattingEnabled = true;
            this.AttStacomboBox.Location = new System.Drawing.Point(226, 100);
            this.AttStacomboBox.Name = "AttStacomboBox";
            this.AttStacomboBox.Size = new System.Drawing.Size(304, 21);
            this.AttStacomboBox.TabIndex = 81;
            // 
            // AttStucomboBox
            // 
            this.AttStucomboBox.FormattingEnabled = true;
            this.AttStucomboBox.Location = new System.Drawing.Point(226, 35);
            this.AttStucomboBox.Name = "AttStucomboBox";
            this.AttStucomboBox.Size = new System.Drawing.Size(304, 21);
            this.AttStucomboBox.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "STUDENT NAME";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 77;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AttenddataGridView
            // 
            this.AttenddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttenddataGridView.Location = new System.Drawing.Point(108, 205);
            this.AttenddataGridView.Name = "AttenddataGridView";
            this.AttenddataGridView.Size = new System.Drawing.Size(422, 133);
            this.AttenddataGridView.TabIndex = 76;
            this.AttenddataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttenddataGridView_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "STATUS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "DAY";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(536, 33);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 73;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(115, 169);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 72;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(226, 169);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 71;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(335, 169);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 70;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(226, 65);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(304, 20);
            this.dateTimePicker.TabIndex = 86;
            // 
            // AttendenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.AttSubcomboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AttStacomboBox);
            this.Controls.Add(this.AttStucomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AttenddataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AttendenceForm";
            this.Text = "AttendenceForm";
            this.Load += new System.EventHandler(this.AttendenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AttenddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AttSubcomboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox AttStacomboBox;
        private System.Windows.Forms.ComboBox AttStucomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView AttenddataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}