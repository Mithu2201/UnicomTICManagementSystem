﻿namespace UnicomTICManagementSystem
{
    partial class AddTimeForm
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
            this.TidateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.TidataGridView = new System.Windows.Forms.DataGridView();
            this.TiSlot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ssearch = new System.Windows.Forms.Button();
            this.Sdelete = new System.Windows.Forms.Button();
            this.Sedit = new System.Windows.Forms.Button();
            this.Sadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TidataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TidateTimePicker
            // 
            this.TidateTimePicker.Location = new System.Drawing.Point(232, 6);
            this.TidateTimePicker.Name = "TidateTimePicker";
            this.TidateTimePicker.Size = new System.Drawing.Size(304, 20);
            this.TidateTimePicker.TabIndex = 58;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TidataGridView
            // 
            this.TidataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TidataGridView.Location = new System.Drawing.Point(164, 158);
            this.TidataGridView.Name = "TidataGridView";
            this.TidataGridView.Size = new System.Drawing.Size(323, 133);
            this.TidataGridView.TabIndex = 56;
            // 
            // TiSlot
            // 
            this.TiSlot.Location = new System.Drawing.Point(232, 50);
            this.TiSlot.Name = "TiSlot";
            this.TiSlot.Size = new System.Drawing.Size(304, 20);
            this.TiSlot.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "TIME SLOT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "DAY_DATE";
            // 
            // Ssearch
            // 
            this.Ssearch.Location = new System.Drawing.Point(114, 112);
            this.Ssearch.Name = "Ssearch";
            this.Ssearch.Size = new System.Drawing.Size(75, 23);
            this.Ssearch.TabIndex = 52;
            this.Ssearch.Text = "Search";
            this.Ssearch.UseVisualStyleBackColor = true;
            this.Ssearch.Click += new System.EventHandler(this.Ssearch_Click_1);
            // 
            // Sdelete
            // 
            this.Sdelete.Location = new System.Drawing.Point(209, 112);
            this.Sdelete.Name = "Sdelete";
            this.Sdelete.Size = new System.Drawing.Size(75, 23);
            this.Sdelete.TabIndex = 51;
            this.Sdelete.Text = "Delete";
            this.Sdelete.UseVisualStyleBackColor = true;
            this.Sdelete.Click += new System.EventHandler(this.Sdelete_Click_1);
            // 
            // Sedit
            // 
            this.Sedit.Location = new System.Drawing.Point(290, 112);
            this.Sedit.Name = "Sedit";
            this.Sedit.Size = new System.Drawing.Size(75, 23);
            this.Sedit.TabIndex = 50;
            this.Sedit.Text = "Edit";
            this.Sedit.UseVisualStyleBackColor = true;
            this.Sedit.Click += new System.EventHandler(this.Sedit_Click_1);
            // 
            // Sadd
            // 
            this.Sadd.Location = new System.Drawing.Point(380, 112);
            this.Sadd.Name = "Sadd";
            this.Sadd.Size = new System.Drawing.Size(75, 23);
            this.Sadd.TabIndex = 49;
            this.Sadd.Text = "Add";
            this.Sadd.UseVisualStyleBackColor = true;
            this.Sadd.Click += new System.EventHandler(this.Sadd_Click_1);
            // 
            // AddTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.TidateTimePicker);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TidataGridView);
            this.Controls.Add(this.TiSlot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ssearch);
            this.Controls.Add(this.Sdelete);
            this.Controls.Add(this.Sedit);
            this.Controls.Add(this.Sadd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTimeForm";
            this.Text = "AddTime";
            this.Load += new System.EventHandler(this.AddTimeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TidataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker TidateTimePicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView TidataGridView;
        private System.Windows.Forms.TextBox TiSlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ssearch;
        private System.Windows.Forms.Button Sdelete;
        private System.Windows.Forms.Button Sedit;
        private System.Windows.Forms.Button Sadd;
    }
}