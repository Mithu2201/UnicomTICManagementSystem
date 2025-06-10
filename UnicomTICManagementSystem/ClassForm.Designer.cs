namespace UnicomTICManagementSystem
{
    partial class ClassForm
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
            this.Sadd = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Ssearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Stdname = new System.Windows.Forms.TextBox();
            this.StdAddress = new System.Windows.Forms.TextBox();
            this.StddataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StddataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(414, 108);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 38;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(324, 108);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 39;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(243, 108);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 40;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(148, 108);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 41;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "TOPIC NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "STUDY MODE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Stdname
            // 
            this.Stdname.Location = new System.Drawing.Point(266, 2);
            this.Stdname.Name = "Stdname";
            this.Stdname.Size = new System.Drawing.Size(304, 20);
            this.Stdname.TabIndex = 45;
            // 
            // StdAddress
            // 
            this.StdAddress.Location = new System.Drawing.Point(266, 45);
            this.StdAddress.Name = "StdAddress";
            this.StdAddress.Size = new System.Drawing.Size(304, 20);
            this.StdAddress.TabIndex = 46;
            // 
            // StddataGridView
            // 
            this.StddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StddataGridView.Location = new System.Drawing.Point(148, 152);
            this.StddataGridView.Name = "StddataGridView";
            this.StddataGridView.Size = new System.Drawing.Size(422, 133);
            this.StddataGridView.TabIndex = 48;
            // 
            // ClassForm
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
            this.Name = "ClassForm";
            this.Text = "ClassForm";
            ((System.ComponentModel.ISupportInitialize)(this.StddataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sadd;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Stdname;
        private System.Windows.Forms.TextBox StdAddress;
        private System.Windows.Forms.DataGridView StddataGridView;
    }
}