using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace OOP_LAB
{
    
    public partial class SignUp : Form //Yeni kullanıcı kaydı yapılır.
    {

        SHA256Managed sha256 = new SHA256Managed();
        

        List<User> userlist = new List<User>();
        
        public SignUp()
        {
            userlist = LoginPage.UserList;
            InitializeComponent();
        }

        private void btn_SignUp_after_Click(object sender, EventArgs e)
        {
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txt_password.Text);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            User Usersignup = new User(txt_username.Text, sifreliVeri, txt_namesurname.Text, txt_phonenumber.Text, txt_address.Text, txt_city.Text, txt_country.Text, txt_email.Text,0,"normal");
            userlist.Add(Usersignup);  

            databaseprocess databaseprocess = new databaseprocess();
            databaseprocess.adddata(Usersignup);
        }
    }
}
