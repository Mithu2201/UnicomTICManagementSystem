namespace UnicomTICManagementSystem
{
    partial class RoomForm
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
            this.RoomdataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomcomboBox = new System.Windows.Forms.ComboBox();
            this.RoRoomcomboBox = new System.Windows.Forms.ComboBox();
            this.RoTypecomboBox = new System.Windows.Forms.ComboBox();
            this.StucomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RoomdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RoomdataGridView
            // 
            this.RoomdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomdataGridView.Location = new System.Drawing.Point(141, 179);
            this.RoomdataGridView.Name = "RoomdataGridView";
            this.RoomdataGridView.Size = new System.Drawing.Size(422, 133);
            this.RoomdataGridView.TabIndex = 58;
            this.RoomdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomdataGridView_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "ROOM TYPE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "ROOM NAME";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(141, 135);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 53;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(236, 135);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 52;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(317, 135);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 51;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(407, 135);
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
            this.label1.Location = new System.Drawing.Point(145, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "SESSION NAME";
            // 
            // RoomcomboBox
            // 
            this.RoomcomboBox.FormattingEnabled = true;
            this.RoomcomboBox.Location = new System.Drawing.Point(259, 28);
            this.RoomcomboBox.Name = "RoomcomboBox";
            this.RoomcomboBox.Size = new System.Drawing.Size(304, 21);
            this.RoomcomboBox.TabIndex = 61;
            // 
            // RoRoomcomboBox
            // 
            this.RoRoomcomboBox.FormattingEnabled = true;
            this.RoRoomcomboBox.Location = new System.Drawing.Point(259, 54);
            this.RoRoomcomboBox.Name = "RoRoomcomboBox";
            this.RoRoomcomboBox.Size = new System.Drawing.Size(304, 21);
            this.RoRoomcomboBox.TabIndex = 62;
            // 
            // RoTypecomboBox
            // 
            this.RoTypecomboBox.FormattingEnabled = true;
            this.RoTypecomboBox.Location = new System.Drawing.Point(259, 81);
            this.RoTypecomboBox.Name = "RoTypecomboBox";
            this.RoTypecomboBox.Size = new System.Drawing.Size(304, 21);
            this.RoTypecomboBox.TabIndex = 63;
            // 
            // StucomboBox
            // 
            this.StucomboBox.FormattingEnabled = true;
            this.StucomboBox.Location = new System.Drawing.Point(259, 2);
            this.StucomboBox.Name = "StucomboBox";
            this.StucomboBox.Size = new System.Drawing.Size(304, 21);
            this.StucomboBox.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "STUDY MODE";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.StucomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RoTypecomboBox);
            this.Controls.Add(this.RoRoomcomboBox);
            this.Controls.Add(this.RoomcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RoomdataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomForm";
            this.Text = "Room";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView RoomdataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RoomcomboBox;
        private System.Windows.Forms.ComboBox RoRoomcomboBox;
        private System.Windows.Forms.ComboBox RoTypecomboBox;
        private System.Windows.Forms.ComboBox StucomboBox;
        private System.Windows.Forms.Label label4;
    }
}