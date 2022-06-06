using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_LAB
{
    public class databaseprocess //database işlemlerini yapar.
    {
        SqlConnection connection = new SqlConnection("workstation id=okanulu.mssql.somee.com;packet size=4096;user id=okan141411_SQLLogin_1;pwd=zbo7epetb7;data source=okanulu.mssql.somee.com;persist security info=False;initial catalog=okanulu");



        public void openconnection() //Veritabanı bağlantısını sağlayan fonksiyondur.
        {
            if(connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            
        }
        public void closeconnection() //Veri güvenliği açısından veritabanı bağlantısını kesen fonksiyondur.
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Close();
            }
            connection.Close();
        }

        public void adddata(User usr) //Veritabanına yeni kullanıcı eklenmesi için kullanılan fonksiyondur.
        {
            String okan = "insert into UserData([user],pass,namesurname,phone,adress,city,country,email,maxscore,difficulty) values (@user,@pass,@namesurname,@phone,@adress,@city,@country,@email,@maxscore,@difficulty)";
            SqlCommand komut = new SqlCommand(okan,connection);

            komut.Parameters.AddWithValue("@user", usr.UserName.ToString());
            komut.Parameters.AddWithValue("@pass", usr.Password.ToString());
            komut.Parameters.AddWithValue("@namesurname", usr.Namesurname.ToString());
            komut.Parameters.AddWithValue("@phone", usr.Phonenumber.ToString());
            komut.Parameters.AddWithValue("@adress", usr.Address.ToString());
            komut.Parameters.AddWithValue("@city", usr.City.ToString());
            komut.Parameters.AddWithValue("@country", usr.Country.ToString());
            komut.Parameters.AddWithValue("@email", usr.Email.ToString());
            komut.Parameters.AddWithValue("@maxscore", usr.Maxscore.ToString());
            komut.Parameters.AddWithValue("@difficulty", usr.Difficultysetting.ToString());

            openconnection();
            komut.ExecuteNonQuery();
            closeconnection();
        }
        public void updatedata(User usr) //Veritabanında daha önceden bulunan bir kullanıcının verilerini güncelleyen fanksiyondur.
        {
            String str = "UPDATE UserData SET pass = @pass , namesurname = @namesurname , phone = @phone , adress = @adress , city = @city , country = @country , email = @email , maxscore = @maxscore , difficulty = @difficulty WHERE [user] = @user";
            

            SqlCommand komut = new SqlCommand(str, connection);
            komut.Parameters.AddWithValue("@user", usr.UserName.ToString());

            komut.Parameters.AddWithValue("@pass", usr.Password.ToString());
            komut.Parameters.AddWithValue("@namesurname", usr.Namesurname.ToString());
            komut.Parameters.AddWithValue("@phone", usr.Phonenumber.ToString());
            komut.Parameters.AddWithValue("@adress", usr.Address.ToString());
            komut.Parameters.AddWithValue("@city", usr.City.ToString());
            komut.Parameters.AddWithValue("@country", usr.Country.ToString());
            komut.Parameters.AddWithValue("@email", usr.Email.ToString());
            komut.Parameters.AddWithValue("@maxscore", usr.Maxscore);
            komut.Parameters.AddWithValue("@difficulty", usr.Difficultysetting.ToString());

            openconnection();
            komut.ExecuteNonQuery();
            closeconnection();
        }
        public void deletedata(string username) //Veritabanından belirli bir kullanıcıyı silen fonksiyondur.
        {
            String str = "DELETE FROM UserData WHERE [user] = @user ";
            SqlCommand komut = new SqlCommand(str, connection);
            komut.Parameters.AddWithValue("@user", username);
            openconnection();
            komut.ExecuteNonQuery();
            closeconnection();
        }
        public void clonedata(List<User> userlist) //Veritabanındaki verileri uygulama içerisinde kullanılabilmesi açısından gerekli yerlere aktaran fonksiyondur.
        {
            userlist.Clear();
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM UserData",connection);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                string username = read[0].ToString();
                string password = read[1].ToString();
                string namesurname = read[2].ToString();
                string phonenumber = read[3].ToString();
                string address = read[4].ToString();
                string city = read[5].ToString();
                string country = read[6].ToString();
                string email = read[7].ToString();
                int maxscore = int.Parse(read[8].ToString());
                string difficulty = read[9].ToString();
                userlist.Add(new User(username, password, namesurname, phonenumber, address, city, country, email, maxscore,difficulty));
            }
            connection.Close();
        }
        public void turnupdater()
        {
            String str = "UPDATE UserData SET turn = @turn WHERE [user] = @user";
            SqlCommand komut = new SqlCommand(str, connection);
            komut.Parameters.AddWithValue("@user", "admin");

            komut.Parameters.AddWithValue("@turn", Multiplayergame.myturn);

            openconnection();
            komut.ExecuteNonQuery();
            closeconnection();
        }
        public void turncloner()
        {
            
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT turn FROM UserData where phone ='5522754330'", connection);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                Multiplayergame.myturn = int.Parse(read[0].ToString());
                
                
            }
            connection.Close();
        }
        public void turnzero()
        {
            String str = "UPDATE UserData SET turn = @turn WHERE [user] = @user";
            SqlCommand komut = new SqlCommand(str, connection);
            komut.Parameters.AddWithValue("@user", "admin");

            komut.Parameters.AddWithValue("@turn", 0);

            openconnection();
            komut.ExecuteNonQuery();
            closeconnection();
        }
    }
}
