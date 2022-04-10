namespace OOP_LAB
{
    public partial class LoginPage : Form
    {
        public static List<User> UserList = new List<User>();
        public static string UserFilePath = "C:/Users/Okan/source/repos/OOP_LAB/OOP_LAB/data.csv";
        string Lastuser = Settings.Default.Lastuser;
        public LoginPage()

        {
            InitializeComponent();
            txtUsername.Text = Lastuser;
            Util.LoadCsv(UserList, UserFilePath);
        }

        private void BtnLogin_Click(object sender, EventArgs e)//Uygulamaya kullanýcý giriþi yapýlýr.
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            
            
            for (int i = 0; i < UserList.Count; i++)
            {
                User user = UserList[i];
                if (user.UserName == Username && user.Password == Password)
                {
                    Settings.Default.Lastuser = Username;
                    Settings.Default.Save();

                    LoginUser.getInstance().User = user;
                    
                    MainPage main = new MainPage();
                    this.Hide();
                    main.Show();
                }
                else
                {
                    LblLoginMessage.Text = "Warning!! USERNAME/PASSWORD is incorrect";
                    LblLoginMessage.ForeColor = Color.Red;
                    LblLoginMessage.Visible = true;
                    
                }
                if(Password != Username)
                {
                    Settings.Default.Lastuser = null;
                    Settings.Default.Save();
                }
            }

        


        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)

            && !char.IsSeparator(e.KeyChar);
        }

        private void Goster_CheckedChanged(object sender, EventArgs e)
        {
            if (Goster.Checked == true )
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

    }
}