namespace OOP_LAB
{
    public partial class LoginPage : Form
    {
        public static List<User> UserList = new List<User>();
        public static string UserFilePath = @"data/data.csv";
        public LoginPage()

        {
            InitializeComponent();
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
            }

        


        }

    }
}