namespace UnicomTICManagementSystem
{
    partial class Login
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
            this.LogName = new System.Windows.Forms.TextBox();
            this.LogPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Create = new System.Windows.Forms.Button();
            this.Sign = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogName
            // 
            this.LogName.Location = new System.Drawing.Point(691, 213);
            this.LogName.Name = "LogName";
            this.LogName.Size = new System.Drawing.Size(212, 20);
            this.LogName.TabIndex = 1;
            // 
            // LogPass
            // 
            this.LogPass.Location = new System.Drawing.Point(691, 256);
            this.LogPass.Name = "LogPass";
            this.LogPass.Size = new System.Drawing.Size(212, 20);
            this.LogPass.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "USER NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(546, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "PASSWORD";
            // 
            // Create
            // 
            this.Create.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create.Location = new System.Drawing.Point(691, 332);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(119, 23);
            this.Create.TabIndex = 6;
            this.Create.Text = "CREATE ACCOUNT";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Sign
            // 
            this.Sign.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign.Location = new System.Drawing.Point(828, 332);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(75, 23);
            this.Sign.TabIndex = 7;
            this.Sign.Text = "SIGN IN";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.Sign_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UnicomTICManagementSystem.Properties.Resources.Login_Unicom;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(482, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(974, 561);
            this.Controls.Add(this.Sign);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogPass);
            this.Controls.Add(this.LogName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox LogName;
        private System.Windows.Forms.TextBox LogPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Sign;
    }
}