using System;
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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//settings ekranına geçişi sağlar.
        {
            SettingsPage settings = new SettingsPage();
            settings.ShowDialog();
           // this.Hide();

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void btn_profilescreen_Click(object sender, EventArgs e)
        {
            ProfileScreen profileScreen = new ProfileScreen();
            profileScreen.ShowDialog();
        }
    }
}
