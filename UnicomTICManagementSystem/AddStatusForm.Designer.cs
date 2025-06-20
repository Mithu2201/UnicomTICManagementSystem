namespace UnicomTICManagementSystem
{
    partial class AddStatusForm
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
            this.StatusdataGridView = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            this.StatusSea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatusdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusdataGridView
            // 
            this.StatusdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatusdataGridView.Location = new System.Drawing.Point(160, 137);
            this.StatusdataGridView.Name = "StatusdataGridView";
            this.StatusdataGridView.Size = new System.Drawing.Size(325, 133);
            this.StatusdataGridView.TabIndex = 56;
            this.StatusdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StatusdataGridView_CellContentClick);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(232, 3);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(304, 20);
            this.Status.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "STATUS";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(121, 54);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 51;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(139, 93);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 50;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(243, 93);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 49;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(349, 93);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 48;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // StatusSea
            // 
            this.StatusSea.Location = new System.Drawing.Point(232, 54);
            this.StatusSea.Name = "StatusSea";
            this.StatusSea.Size = new System.Drawing.Size(304, 20);
            this.StatusSea.TabIndex = 58;
            // 
            // AddStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.StatusSea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StatusdataGridView);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddStatusForm";
            this.Text = "AddStatusForm";
            this.Load += new System.EventHandler(this.AddStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StatusdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView StatusdataGridView;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.TextBox StatusSea;
    }
}