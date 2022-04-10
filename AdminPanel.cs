﻿using System;
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
    public partial class AdminPanel : Form
    {
        public static int tmp;
        List<User> userlist = new List<User>();
        SHA256Managed sha256 = new SHA256Managed();
        public AdminPanel()
        {
            
            userlist = LoginPage.UserList;
            
            InitializeComponent();
            userlistrenew();


        }

        private void addnewuser_admin_Click(object sender, EventArgs e)
        {
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txt_password_admin.Text);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            User Usersignup = new User(txt_username_admin.Text, sifreliVeri, txt_namesurname_admin.Text, txt_phonenumber_admin.Text, txt_address_admin.Text, txt_city_admin.Text, txt_country_admin.Text, txt_email_admin.Text);
            userlist.Add(Usersignup);
            Util.SaveCsv(userlist);
            userlistrenew();

        }
        private void userlistrenew()
        {
            for (int i = 0; i < LoginPage.UserList.Count(); i++)
            {
                if (i == 0)
                {
                    txt_userlistbox_admin.Text = LoginPage.UserList[i].UserName;
                }
                else
                {
                    txt_userlistbox_admin.Text += LoginPage.UserList[i].UserName;
                }
                txt_userlistbox_admin.Text += Environment.NewLine;
            }
        }

        private void btn_userinfo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LoginPage.UserList.Count(); i++)
            {
                if (LoginPage.UserList[i].UserName == txt_edtuser_username.Text)
            {
                    tmp = i;
                    //txt_edtuser_password.Text = LoginPage.UserList[i].Password;
                    txt_edtuser_nameusername.Text = LoginPage.UserList[i].Namesurname;
                    txt_edtuser_phonenumber.Text = LoginPage.UserList[i].Phonenumber;
                    txt_edtuser_address.Text = LoginPage.UserList[i].Address;
                    txt_edtuser_city.Text = LoginPage.UserList[i].City;
                    txt_edtuser_country.Text = LoginPage.UserList[i].Country;
                    txt_edtuser_email.Text = LoginPage.UserList[i].Email;

                }
        }
        }

        private void btn_useredit_Click(object sender, EventArgs e)
        {
           if(txt_edtuser_password.Text != "")
             {
                byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txt_edtuser_password.Text);
                string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));
                LoginPage.UserList[tmp].Password = sifreliVeri;
             }
                    

            LoginPage.UserList[tmp].Namesurname = txt_edtuser_nameusername.Text;
            LoginPage.UserList[tmp].Phonenumber = txt_edtuser_phonenumber.Text;
            LoginPage.UserList[tmp].Address = txt_edtuser_address.Text;
            LoginPage.UserList[tmp].City = txt_edtuser_city.Text;
            LoginPage.UserList[tmp].Country = txt_edtuser_country.Text;
            LoginPage.UserList[tmp].Email = txt_edtuser_email.Text;
                       
            Util.SaveCsv(LoginPage.UserList);

        }

        private void btn_dltuser_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < LoginPage.UserList.Count(); i++)
            if(LoginPage.UserList[i].UserName == txt_dltuser.Text)
                {
                    LoginPage.UserList.RemoveAt(i);
                    Util.SaveCsv(LoginPage.UserList);
                    userlistrenew();
                    break;
                }

        }
    }
}
