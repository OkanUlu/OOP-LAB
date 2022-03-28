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

                        userlist.Add(new User(username, password));
                    
                    }
                }
        }
    }
}

