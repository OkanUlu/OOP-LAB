namespace OOP_LAB
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_profilescreen = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scorelbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1079, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "SETTINGS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_profilescreen
            // 
            this.btn_profilescreen.Location = new System.Drawing.Point(1079, 85);
            this.btn_profilescreen.Name = "btn_profilescreen";
            this.btn_profilescreen.Size = new System.Drawing.Size(121, 29);
            this.btn_profilescreen.TabIndex = 6;
            this.btn_profilescreen.Text = "PROFILE";
            this.btn_profilescreen.UseVisualStyleBackColor = true;
            this.btn_profilescreen.Click += new System.EventHandler(this.btn_profilescreen_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1079, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "ABOUT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1079, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "SCORE";
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scorelbl.ForeColor = System.Drawing.Color.Red;
            this.scorelbl.Location = new System.Drawing.Point(1119, 218);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(38, 46);
            this.scorelbl.TabIndex = 9;
            this.scorelbl.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1064, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Your best score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1119, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 46);
            this.label3.TabIndex = 11;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 814);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scorelbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_profilescreen);
            this.Controls.Add(this.button1);
            this.Name = "MainPage";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStripMenuItem customToolStripMenuItem1;
        private Button button1;
        private Button btn_profilescreen;
        private Button button2;
        private Label label1;
        private Label scorelbl;
        private Label label2;
        private Label label3;
    }
}