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
            this.CldataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ClcomboBox = new System.Windows.Forms.ComboBox();
            this.ClNamecomboBox = new System.Windows.Forms.ComboBox();
            this.ClModecomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(369, 108);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 38;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(267, 108);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 39;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(158, 108);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 40;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(563, 33);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 41;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "TOPIC NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "STUDY MODE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CldataGridView
            // 
            this.CldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CldataGridView.Location = new System.Drawing.Point(130, 152);
            this.CldataGridView.Name = "CldataGridView";
            this.CldataGridView.Size = new System.Drawing.Size(422, 133);
            this.CldataGridView.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "SUBJECT NAME";
            // 
            // ClcomboBox
            // 
            this.ClcomboBox.FormattingEnabled = true;
            this.ClcomboBox.Location = new System.Drawing.Point(248, 3);
            this.ClcomboBox.Name = "ClcomboBox";
            this.ClcomboBox.Size = new System.Drawing.Size(304, 21);
            this.ClcomboBox.TabIndex = 61;
            // 
            // ClNamecomboBox
            // 
            this.ClNamecomboBox.FormattingEnabled = true;
            this.ClNamecomboBox.Location = new System.Drawing.Point(248, 34);
            this.ClNamecomboBox.Name = "ClNamecomboBox";
            this.ClNamecomboBox.Size = new System.Drawing.Size(304, 21);
            this.ClNamecomboBox.TabIndex = 62;
            // 
            // ClModecomboBox
            // 
            this.ClModecomboBox.FormattingEnabled = true;
            this.ClModecomboBox.Location = new System.Drawing.Point(248, 66);
            this.ClModecomboBox.Name = "ClModecomboBox";
            this.ClModecomboBox.Size = new System.Drawing.Size(304, 21);
            this.ClModecomboBox.TabIndex = 63;
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.ClModecomboBox);
            this.Controls.Add(this.ClNamecomboBox);
            this.Controls.Add(this.ClcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CldataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClassForm";
            this.Text = "ClassForm";
            this.Load += new System.EventHandler(this.ClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CldataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView CldataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClcomboBox;
        private System.Windows.Forms.ComboBox ClNamecomboBox;
        private System.Windows.Forms.ComboBox ClModecomboBox;
    }
}