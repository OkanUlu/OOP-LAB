using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB
{
    public class LoginUser //Giriş yapmış olan kullanıcının verilerini tutan sınıftır.
    {
        private int index;
        private User user;

        private static LoginUser loginUser;

        public User User { get => user; set => user = value; }

        public static LoginUser getInstance()
        {
            if (loginUser == null)
            {
                loginUser = new LoginUser();
            }
            return loginUser;
        }

    }
}
