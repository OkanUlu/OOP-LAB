namespace OOP_LAB
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.LblLoginMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "PASSWORD";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(336, 132);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(125, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(336, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(125, 27);
            this.txtPassword.TabIndex = 2;
            // 
            // BtnLogin
            // 
            this.BtnLogin.CausesValidation = false;
            this.BtnLogin.Location = new System.Drawing.Point(336, 247);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(125, 29);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LblLoginMessage
            // 
            this.LblLoginMessage.AutoSize = true;
            this.LblLoginMessage.Location = new System.Drawing.Point(349, 215);
            this.LblLoginMessage.Name = "LblLoginMessage";
            this.LblLoginMessage.Size = new System.Drawing.Size(97, 20);
            this.LblLoginMessage.TabIndex = 5;
            this.LblLoginMessage.Text = "Warninglabel";
            this.LblLoginMessage.Visible = false;
            // 
            // LoginPage
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblLoginMessage);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginPage";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button BtnLogin;
        private Label LblLoginMessage;
    }
}