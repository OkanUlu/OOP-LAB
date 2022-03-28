using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 User genel sınıfıdır kullanıcı verilerinin tutulması için oluşturulmuştur.
 */
namespace OOP_LAB
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
       /* public string Difficulty { get; set; }
        public int Customint1 { get; set; }
        public int Customint2 { get; set; }*/


        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        /*public string ToStringCsv()
        {
            return UserName + "," + Password;
        }*/
    }


}
