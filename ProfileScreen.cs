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
    public partial class ProfileScreen : Form
    {
        SHA256Managed sha256 = new SHA256Managed();
        public ProfileScreen()
        {
            InitializeComponent();
            lbl_user.Text = "Logined user: " + LoginUser.getInstance().User.UserName;
            txt_username_profile.Text = LoginUser.getInstance().User.UserName;
            txt_password_profile.Text = LoginUser.getInstance().User.Password;
            txt_namesurname_profile.Text = LoginUser.getInstance().User.Namesurname;
            txt_phonenumber_profile.Text = LoginUser.getInstance().User.Phonenumber;
            txt_address_profile.Text = LoginUser.getInstance().User.Address;
            txt_city_profile.Text = LoginUser.getInstance().User.City;
            txt_country_profile.Text = LoginUser.getInstance().User.Country;
            txt_email_profile.Text = LoginUser.getInstance().User.Email;
        }

        private void btn_saveprofile_Click(object sender, EventArgs e)
        {
            byte[] bitDizisi2 = System.Text.Encoding.UTF8.GetBytes(currentpassword.Text);
            string sifreliVeri2 = Convert.ToBase64String(sha256.ComputeHash(bitDizisi2));

            if (sifreliVeri2 == LoginUser.getInstance().User.Password)
            {
                for (int i = 0; i < LoginPage.UserList.Count(); i++)
                {
                    if (LoginPage.UserList[i].UserName == lbl_user.Text)
                    {
                        LoginPage.UserList[i].UserName = txt_username_profile.Text;
                        
                        LoginPage.UserList[i].Namesurname = txt_namesurname_profile.Text;
                        LoginPage.UserList[i].Phonenumber = txt_phonenumber_profile.Text;
                        LoginPage.UserList[i].Address = txt_address_profile.Text;
                        LoginPage.UserList[i].City = txt_city_profile.Text;
                        LoginPage.UserList[i].Country = txt_country_profile.Text;
                        LoginPage.UserList[i].Email = txt_email_profile.Text;

                        if(txt_password_profile.Text != "")
                        {
                            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txt_password_profile.Text);
                            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

                            LoginPage.UserList[i].Password = sifreliVeri;
                        }

                        Util.SaveCsv(LoginPage.UserList);

                    }
                }
            }
            else
            {
                label10.Text = "Şifreniz yanlış lütfen tekrar deneyiniz";
            }
            

        }

        private void ProfileScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
