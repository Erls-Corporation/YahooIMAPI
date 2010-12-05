namespace RemoveBuddy
{
    partial class RemoveBuddy
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RemoveBuddyButton = new System.Windows.Forms.Button();
            this.NickTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.BuddyTextBox = new System.Windows.Forms.TextBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(70, 112);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Buddy";
            // 
            // RemoveBuddyButton
            // 
            this.RemoveBuddyButton.Enabled = false;
            this.RemoveBuddyButton.Location = new System.Drawing.Point(70, 187);
            this.RemoveBuddyButton.Name = "RemoveBuddyButton";
            this.RemoveBuddyButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveBuddyButton.TabIndex = 4;
            this.RemoveBuddyButton.Text = "Remove";
            this.RemoveBuddyButton.UseVisualStyleBackColor = true;
            this.RemoveBuddyButton.Click += new System.EventHandler(this.RemoveBuddyButton_Click);
            // 
            // NickTextBox
            // 
            this.NickTextBox.Location = new System.Drawing.Point(70, 26);
            this.NickTextBox.Name = "NickTextBox";
            this.NickTextBox.Size = new System.Drawing.Size(191, 20);
            this.NickTextBox.TabIndex = 5;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(70, 75);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(191, 20);
            this.PasswordTextBox.TabIndex = 6;
            // 
            // BuddyTextBox
            // 
            this.BuddyTextBox.Location = new System.Drawing.Point(70, 150);
            this.BuddyTextBox.Name = "BuddyTextBox";
            this.BuddyTextBox.Size = new System.Drawing.Size(191, 20);
            this.BuddyTextBox.TabIndex = 7;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Enabled = false;
            this.LogoutButton.Location = new System.Drawing.Point(186, 112);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 23);
            this.LogoutButton.TabIndex = 8;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // RemoveBuddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.BuddyTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.NickTextBox);
            this.Controls.Add(this.RemoveBuddyButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.Name = "RemoveBuddy";
            this.Text = "RemoveBuddy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoveBuddy_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RemoveBuddyButton;
        private System.Windows.Forms.TextBox NickTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox BuddyTextBox;
        private System.Windows.Forms.Button LogoutButton;
    }
}