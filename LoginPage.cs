using System.Security.Cryptography;

namespace OOP_LAB
{
    public partial class LoginPage : Form
    {
        public static List<User> UserList = new List<User>();
        public static string UserFilePath = @"data/data.csv";
        SHA256Managed sha256 = new SHA256Managed();
        public static int a = 0;

        public LoginPage()

        {
            InitializeComponent();
            Util.LoadCsv(UserList, UserFilePath);
            txtUsername.Text = Settings.Default.lastuser;
        }

        private void BtnLogin_Click(object sender, EventArgs e)//Uygulamaya kullanýcý giriþi yapýlýr.
        {
            a = 0;
            string Username = txtUsername.Text;

            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(txtPassword.Text);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            string Password = sifreliVeri;
            for (int i = 0; i < UserList.Count; i++)
            {
                User user = UserList[i];
                if(user.UserName == "admin" && user.Password == Password)
                {
                    AdminPanel adminpanel = new AdminPanel();
                    Settings.Default.lastuser = Username;
                    Settings.Default.Save();
                    a = 1;
                    adminpanel.ShowDialog();
                    
                    LblLoginMessage.Visible = false;
                    break;
                }
                
                else if (user.UserName == Username && user.Password == Password)
                {
                    LoginUser.getInstance().User = user;
                    Settings.Default.lastuser = Username;
                    Settings.Default.Save();

                    MainPage main = new MainPage();
                    // this.Hide();
                    a = 1;
                    main.ShowDialog();
                   
                    LblLoginMessage.Visible = false;
                    break;

                }
                
            }
            if (a == 0)
            {
                LblLoginMessage.Text = "Warning!! USERNAME/PASSWORD is incorrect";
                LblLoginMessage.ForeColor = Color.Red;
                LblLoginMessage.Visible = true;
            }



        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.ShowDialog();

        }

        private void Goster_CheckedChanged(object sender, EventArgs e)
        {

            if (Goster.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)

            && !char.IsSeparator(e.KeyChar);
        }
    }
}