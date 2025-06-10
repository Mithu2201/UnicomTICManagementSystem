namespace UnicomTICManagementSystem
{
    partial class TimeTablesForm
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
            this.StddataGridView = new System.Windows.Forms.DataGridView();
            this.StdAddress = new System.Windows.Forms.TextBox();
            this.Stdname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StddataGridView
            // 
            this.StddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StddataGridView.Location = new System.Drawing.Point(163, 151);
            this.StddataGridView.Name = "StddataGridView";
            this.StddataGridView.Size = new System.Drawing.Size(422, 133);
            this.StddataGridView.TabIndex = 58;
            // 
            // StdAddress
            // 
            this.StdAddress.Location = new System.Drawing.Point(281, 44);
            this.StdAddress.Name = "StdAddress";
            this.StdAddress.Size = new System.Drawing.Size(304, 20);
            this.StdAddress.TabIndex = 57;
            // 
            // Stdname
            // 
            this.Stdname.Location = new System.Drawing.Point(281, 1);
            this.Stdname.Name = "Stdname";
            this.Stdname.Size = new System.Drawing.Size(304, 20);
            this.Stdname.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "TIME SLOT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "DAY";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(163, 107);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 53;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(258, 107);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 52;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(339, 107);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 51;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(429, 107);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 50;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            // 
            // TimeTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StddataGridView);
            this.Controls.Add(this.StdAddress);
            this.Controls.Add(this.Stdname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeTablesForm";
            this.Text = "TimeTables";
            ((System.ComponentModel.ISupportInitialize)(this.StddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView StddataGridView;
        private System.Windows.Forms.TextBox StdAddress;
        private System.Windows.Forms.TextBox Stdname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
    }
}