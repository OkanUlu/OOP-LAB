﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LAB
{

    public partial class SettingsPage : Form
    {
        private User user;
        public string Difficulty;
        public int int1, int2;
        public bool chk1, chk2, chk3;
        public bool chk4, chk5, chk6;
        public SettingsPage()
        {
            InitializeComponent();
            Difficulty = LoginUser.getInstance().User.Difficultysetting;
            switch (Difficulty) //Kaydedilen ayarlar kayıt alanından alınarak uygulamaya eklenir.
            {
                case "easy":
                    easyToolStripMenuItem.Checked = true;
                    break;
                case "normal":
                    normalToolStripMenuItem.Checked = true;
                    break;
                case "hard":
                    hardToolStripMenuItem.Checked = true;
                    break;

                case "custom":
                    customToolStripMenuItem.Checked = true;
                    break;
            }
            /*if(Settings.Default.square == null || Settings.Default.triangle == null || Settings.Default.roundshape == null)
            {
                Settings.Default.square = false;
                Settings.Default.triangle = false;
                Settings.Default.roundshape = false;
            }*/

            checkBox1.Checked = Settings.Default.square;
            checkBox2.Checked = Settings.Default.triangle;
            checkBox3.Checked = Settings.Default.roundshape;

            checkBox4.Checked = Settings.Default.renk1; //tekrar başladığında eski seçimi döndürmek için
            checkBox5.Checked = Settings.Default.renk2;
            checkBox6.Checked = Settings.Default.renk3;



            toolStripTextBox2.Text = Settings.Default.customint2.ToString();
            toolStripTextBox1.Text = Settings.Default.customint1.ToString();

            chk1 = Settings.Default.square;
            chk2 = Settings.Default.triangle;
            chk3 = Settings.Default.roundshape;

            label4.ForeColor = Settings.Default.color1;
            label5.ForeColor = Settings.Default.color2;
            label6.ForeColor = Settings.Default.color3;


        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e) //easy zorluk seviyesi seçilir.
        {
            User user;
            user = LoginUser.getInstance().User;

            //Settings.Default.Difficulty = "easy";
            //Settings.Default.Save();
            Difficulty = "easy";
            normalToolStripMenuItem.Checked = false;
            easyToolStripMenuItem.Checked = true;
            hardToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User user;
            user = LoginUser.getInstance().User;
            Difficulty = "normal";
            normalToolStripMenuItem.Checked = true;
            easyToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User user;
            user = LoginUser.getInstance().User;

            Difficulty = "hard";
            hardToolStripMenuItem.Checked = true;
            easyToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
        }
        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User user;
            user = LoginUser.getInstance().User;

            Difficulty = "custom";
            int1 = int.Parse(toolStripTextBox1.Text);
            int2 = int.Parse(toolStripTextBox2.Text);

            if (toolStripTextBox1.Text == "" || toolStripTextBox2.Text == "")
            {
                label1.Text = "Custom modunda 2 adet integer girmeniz gerekir bu alanlar boş bırakılamaz.";
                label1.Visible = true;
            }

            else
            {


                customToolStripMenuItem.Checked = true;
                hardToolStripMenuItem.Checked = false;
                easyToolStripMenuItem.Checked = false;
                normalToolStripMenuItem.Checked = false;
            }
        }
        //Square,triangle,rounshape seçimleri yapılır.
        public void square_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;

            }
            chk1 = checkBox1.Checked;

        }
        private void triangle_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;

            }
            else
            {
                checkBox2.Checked = true;

            }
            chk2 = checkBox2.Checked;
        }
        private void roundshape_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Checked = false;
            }
            else
            {
                checkBox3.Checked = true;
            }
            chk3 = checkBox3.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chk1 = checkBox1.Checked;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chk2 = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chk3 = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chk4 = checkBox4.Checked;
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chk5 = checkBox5.Checked;
        }

        private void SettingsPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Page_Refresh();
            this.Hide();
            main.ShowDialog();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            chk6 = checkBox6.Checked;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            int1 = int.Parse(toolStripTextBox1.Text);
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            int2 = int.Parse(toolStripTextBox2.Text);
        }
        //Uygulamanın genel save i oluşturulur.
        private void btnSave_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if(chk1 == true)
            {
                counter++;
            }
            if(chk2 == true)
            {
                counter++;
            }
            if(chk3 == true)
            {
                counter++;
            }
            if(chk4 == true)
            {
                counter++;
            }
            if(chk5 == true)
            {
                counter++;
            }
            if (chk6 == true)
            {
                counter++;
            }


            if(counter < 3)
            {
                MessageBox.Show("En az 3 şekil veya renk seçmelisiniz, LÜTFEN TEKRAR SEÇİM YAPINIZ");
            }
            else
            {
                LoginUser.getInstance().User.Difficultysetting = Difficulty;

                databaseprocess databaseprocess = new databaseprocess();
                databaseprocess.updatedata(LoginUser.getInstance().User);
                //Settings.Default.Difficulty = Difficulty;
                Settings.Default.customint1 = int1;
                Settings.Default.customint2 = int2;
                Settings.Default.square = chk1;
                Settings.Default.triangle = chk2;
                Settings.Default.roundshape = chk3;
                Settings.Default.renk1 = chk4;
                Settings.Default.renk2 = chk5;
                Settings.Default.renk3 = chk6;
                Settings.Default.Save();
            }
            

        }
    }
}
