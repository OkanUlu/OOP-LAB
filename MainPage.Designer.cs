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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(667, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "SETTINGS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_profilescreen
            // 
            this.btn_profilescreen.Location = new System.Drawing.Point(667, 66);
            this.btn_profilescreen.Name = "btn_profilescreen";
            this.btn_profilescreen.Size = new System.Drawing.Size(121, 29);
            this.btn_profilescreen.TabIndex = 6;
            this.btn_profilescreen.Text = "PROFILE";
            this.btn_profilescreen.UseVisualStyleBackColor = true;
            this.btn_profilescreen.Click += new System.EventHandler(this.btn_profilescreen_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_profilescreen);
            this.Controls.Add(this.button1);
            this.Name = "MainPage";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ToolStripMenuItem customToolStripMenuItem1;
        private Button button1;
        private Button btn_profilescreen;
    }
}