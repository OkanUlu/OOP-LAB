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
    public class User { 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Namesurname { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int Maxscore { get; set; }
        public string Difficultysetting { get; set; }
        
        


        public User(string username, string password, string namesurname, string phonenumber, string address, string city, string country, string email,int maxscore,string difficultysetting)
        {
            UserName = username;
            Password = password;
            Namesurname = namesurname;
            Phonenumber = phonenumber;
            Address = address;
            City = city;
            Country = country;
            Email = email;
            Maxscore = maxscore;
            Difficultysetting = difficultysetting;
        }

        //public string ToStringCsv()
        //{
        //    return UserName + "," + Password + "," + Namesurname + "," + Phonenumber + "," + Address + "," + City + "," + Country + "," + Email + "," + Maxscore;
        //}
    }


}
