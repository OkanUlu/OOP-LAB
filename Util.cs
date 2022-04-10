using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Kullanıcı verilerinin dosyadan okunması için oluşturulmuştur.
 */
namespace OOP_LAB
{
    public class Util
    {
        public static string UserFilePath = @"data/data.csv";
        public static void LoadCsv(List<User> userlist, string csvPath) //Csv dosyasından verilerin okunması ve gerekli değişkenlere tanımlanması sağlanır.
        {

            userlist.Clear();
            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var values = line.Split(',');
                    string username = values[0];
                    string password = values[1];
                    string namesurname = values[2];
                    string phonenumber = values[3];
                    string address = values[4];
                    string city = values[5];
                    string country = values[6];
                    string email = values[7];

                    userlist.Add(new User(username, password, namesurname, phonenumber, address,city,country,email));

                }
            }
        }
        public static void SaveCsv(List<User> userlist)
        {

            using (var writer = new StreamWriter(UserFilePath))
            {
                foreach (User user in userlist)
                {
                    writer.WriteLine(user.ToStringCsv());
                }
            }
        }
    }
}


