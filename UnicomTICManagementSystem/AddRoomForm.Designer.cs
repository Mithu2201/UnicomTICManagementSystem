namespace UnicomTICManagementSystem
{
    partial class AddRoomForm
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
            this.RodataGridView = new System.Windows.Forms.DataGridView();
            this.Roname = new System.Windows.Forms.TextBox();
            this.Rocode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RodataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RodataGridView
            // 
            this.RodataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RodataGridView.Location = new System.Drawing.Point(179, 152);
            this.RodataGridView.Name = "RodataGridView";
            this.RodataGridView.Size = new System.Drawing.Size(305, 133);
            this.RodataGridView.TabIndex = 46;
            this.RodataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RodataGridView_CellContentClick);
            // 
            // Roname
            // 
            this.Roname.Location = new System.Drawing.Point(236, 39);
            this.Roname.Name = "Roname";
            this.Roname.Size = new System.Drawing.Size(304, 20);
            this.Roname.TabIndex = 45;
            // 
            // Rocode
            // 
            this.Rocode.Location = new System.Drawing.Point(236, 6);
            this.Rocode.Name = "Rocode";
            this.Rocode.Size = new System.Drawing.Size(304, 20);
            this.Rocode.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "ROOM NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "ROOM TYPE";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(118, 108);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 41;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(213, 108);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 40;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(294, 108);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 39;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(384, 108);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 38;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // AddRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RodataGridView);
            this.Controls.Add(this.Roname);
            this.Controls.Add(this.Rocode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddRoomForm";
            this.Text = "AddRoom";
            this.Load += new System.EventHandler(this.AddRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RodataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView RodataGridView;
        private System.Windows.Forms.TextBox Roname;
        private System.Windows.Forms.TextBox Rocode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
    }
}