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
    public partial class AdminPanel : Form //Oyunun yönetim panelidir, kullanıcı bilgilerinin değişikliğinin yönetici tarafından yapılabilmesi için kullanılır.
    {
        public static int tmp;
        List<User> userlist = new List<User>();
        List<string> maxscore = new List<string>();
        SHA256Managed sha256 = new SHA256Managed();
        public AdminPanel()
        {
            
            userlist = LoginPage.UserList;
            
            
            InitializeComponent();
            userlistrenew();
            for (int i = 0; i < userlist.Count; i++)
            {
                maxscore.Add(userlist[i].Maxscore + " " + userlist[i].UserName);
            }
            


        }

        private void addnewuser_admin_Click(object sender, EventArgs e) //Yeni kullanıcı bilgileri girildikten sonra kullanıcının bilgilerinin kaydedilmesi için kullanılır.
        {
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txt_password_admin.Text);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            User Usersignup = new User(txt_username_admin.Text, sifreliVeri, txt_namesurname_admin.Text, txt_phonenumber_admin.Text, txt_address_admin.Text, txt_city_admin.Text, txt_country_admin.Text, txt_email_admin.Text,0,"normal");
            userlist.Add(Usersignup);
            userlistrenew();
            databaseprocess databaseprocess = new databaseprocess();
            databaseprocess.adddata(Usersignup);

        }
        private void userlistrenew() //Form içerisinde yeni kullanıcı eklenmesi veya var olan kullanıcının güncellenmesi sonrası ekrande görüntülenen kullanıcı listesinin güncellenmesi için kullanılan fonksiyondur.
        {
            for (int i = 0; i < LoginPage.UserList.Count(); i++)
            {
                if (i == 0)
                {
                    userlistbox.Items.Add(LoginPage.UserList[i].UserName);
                }
                else
                {
                    userlistbox.Items.Add(LoginPage.UserList[i].UserName);
                }
            }
        }

        private void btn_userinfo_Click(object sender, EventArgs e) //username i girilen kullanıcının verilerinin editlenebilmesi için verileri sınıflandırıp gerekli boşlukları doldurur.
        {
            for (int i = 0; i < LoginPage.UserList.Count(); i++)
            {
                if (LoginPage.UserList[i].UserName == txt_edtuser_username.Text)
            {
                    tmp = i;
                    txt_edtuser_nameusername.Text = LoginPage.UserList[i].Namesurname;
                    txt_edtuser_phonenumber.Text = LoginPage.UserList[i].Phonenumber;
                    txt_edtuser_address.Text = LoginPage.UserList[i].Address;
                    txt_edtuser_city.Text = LoginPage.UserList[i].City;
                    txt_edtuser_country.Text = LoginPage.UserList[i].Country;
                    txt_edtuser_email.Text = LoginPage.UserList[i].Email;

                }
        }
        }

        private void btn_useredit_Click(object sender, EventArgs e)//Kullanıcı verilerinin düzenlendikten sonra kaydedilmesini sağlayan fonksiyondur.
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

            databaseprocess databaseprocess = new databaseprocess();
            databaseprocess.updatedata(LoginPage.UserList[tmp]);


        }

        private void btn_dltuser_Click(object sender, EventArgs e)//Username i girilen kullanıcıyı sistemden silen fonksiyondur.
        {
            var result = MessageBox.Show(@"Silmek İstediğinizden Emin misiniz?", @"Uyarı",
                      MessageBoxButtons.OKCancel,
                      MessageBoxIcon.Information);

            if (result.Equals(DialogResult.OK))
            {
                for (int i = 0; i < LoginPage.UserList.Count(); i++)
                    if (LoginPage.UserList[i].UserName == txt_dltuser.Text)
                    {
                        LoginPage.UserList.RemoveAt(i);
                        userlistrenew();
                        break;
                    }
                databaseprocess databaseprocess = new databaseprocess();
                databaseprocess.deletedata(txt_dltuser.Text);
            }
            

        }

        private void button1_Click(object sender, EventArgs e) //max score sıralamasını artan şekilde yapan fonksiyondur.
        {
            maxscores.Items.Clear();
            maxscore.Sort();
            for (int i = 0; i < maxscore.Count; i++)
            {
                maxscores.Items.Add(maxscore[i]);
            }
        }

        private void btn_descending_Click(object sender, EventArgs e) //max score sıralamasını azalan şekilde yapan fonksiyondur.
        {
            maxscores.Items.Clear();
            maxscore.Sort();
            maxscore.Reverse();
            for (int i = 0; i < maxscore.Count; i++)
            {
                maxscores.Items.Add(maxscore[i]);
            }
        }
    }
}
