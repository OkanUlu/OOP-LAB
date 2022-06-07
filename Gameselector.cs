using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace OOP_LAB
{
    public partial class Gameselector : Form
    {
        public Gameselector()
        {
            InitializeComponent();
            var strHostName = "";
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            var addr = ipEntry.AddressList;
            label6.Text = addr[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.ShowDialog();
        }

        private void btn_createhost_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            MessageBox.Show("You must use the connection information shown on the screen", "WARNING");


            Multiplayergame.ishost = true;
            Multiplayergame multigame = new Multiplayergame();
            multigame.ShowDialog();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            Multiplayergame.ishost = false;
            Multiplayergame.ipaddress = IPAddress.Parse(txt_ip.Text);
            Multiplayergame.port = int.Parse(txt_port.Text);
            Multiplayergame multigame = new Multiplayergame();
            multigame.ShowDialog();
        }
    }
}
