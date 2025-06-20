namespace UnicomTICManagementSystem
{
    partial class AddClassForm
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
            this.CldataGridView = new System.Windows.Forms.DataGridView();
            this.Clname = new System.Windows.Forms.TextBox();
            this.Clcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CldataGridView
            // 
            this.CldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CldataGridView.Location = new System.Drawing.Point(158, 152);
            this.CldataGridView.Name = "CldataGridView";
            this.CldataGridView.Size = new System.Drawing.Size(327, 133);
            this.CldataGridView.TabIndex = 46;
            this.CldataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CldataGridView_CellContentClick);
            // 
            // Clname
            // 
            this.Clname.Location = new System.Drawing.Point(231, 3);
            this.Clname.Name = "Clname";
            this.Clname.Size = new System.Drawing.Size(304, 20);
            this.Clname.TabIndex = 45;
            // 
            // Clcode
            // 
            this.Clcode.Location = new System.Drawing.Point(231, 40);
            this.Clcode.Name = "Clcode";
            this.Clcode.Size = new System.Drawing.Size(304, 20);
            this.Clcode.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "TOPIC NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "CLASS MODE";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(113, 109);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 41;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(208, 109);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 40;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(289, 109);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 39;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(379, 109);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 38;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click);
            // 
            // AddClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CldataGridView);
            this.Controls.Add(this.Clname);
            this.Controls.Add(this.Clcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddClassForm";
            this.Text = "AddClass";
            this.Load += new System.EventHandler(this.AddClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CldataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView CldataGridView;
        private System.Windows.Forms.TextBox Clname;
        private System.Windows.Forms.TextBox Clcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
    }
}