using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace OOP_LAB
{
    public partial class Multiplayergame : Form
    {
        public static int myturn = 0;
        int turn;
        string str;
        string[] receivedlblcheck = new string[400];
        string socketsendmessage;
        public static bool ishost;
        public string[] selected_colors = new string[3];
        public string[] selected_objects = new string[3];
        public int row = 0, col = 0;
        Button[] btn = new Button[400];
        string[] lblcheck = new string[400];
        public int flag1, flag2;
        int clrselect = 0;
        int objselect = 0;
        string temp = "empty";
        int tempnum;
        List<int> painteddots = new List<int>();
        List<int> roadsave = new List<int>();
        List<int> scoredots = new List<int>();
        int scorerule;
        String difficulty;
        System.Media.SoundPlayer gamesound = new System.Media.SoundPlayer("../../../music/oyun.wav");
        System.Media.SoundPlayer scoresound = new System.Media.SoundPlayer("../../../music/scoree.wav");
        private Socket socket;
        private Socket ClientSocket;
        public static IPAddress ipaddress;
        public static int port;
        
        Socket soket;
        NetworkStream stream;
        TcpListener tcpListener = new TcpListener(IPAddress.Any,47132);
        databaseprocess databs = new databaseprocess();
        


        public Multiplayergame()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            label3.Text = LoginUser.getInstance().User.Maxscore.ToString();//YOUR BEST SCORE alanını doldurur.

        }
        private void soketdinle()
        {
            databs.turncloner();

            byte[] data = new byte[4000];
            if (ishost)
            {
                if(turn == myturn)
                {
                    while (true)
                    {
                        int numBytesRead = stream.Read(data, 0, data.Length);
                        if (numBytesRead > 0)
                        {
                            str = Encoding.ASCII.GetString(data, 0, numBytesRead);
                            receivedlblcheck = str.Split(",");

                            for (int i = 0; i < lblcheck.Length; i++)
                            {
                                lblcheck[i] = receivedlblcheck[i];
                            }
                            myturn++;
                            databs.turnupdater();
                            UnFreezeButtons();
                            Page_Refresh();
                        }
                    }
                }
                
            }
            else
            {
                if(turn == myturn)
                {
                    while (true)
                    {
                        int numBytesRead = stream.Read(data, 0, data.Length);
                        if (numBytesRead > 0)
                        {
                            str = Encoding.ASCII.GetString(data, 0, numBytesRead);
                            receivedlblcheck = str.Split(",");

                            for (int i = 0; i < lblcheck.Length; i++)
                            {
                                lblcheck[i] = receivedlblcheck[i];
                            }
                            UnFreezeButtons();
                            Page_Refresh();
                        }
                    }
                }
                
            }
            
        }
        private void button1_Click(object sender, EventArgs e)//settings ekranına geçişi sağlar.
        {
            SettingsPage settings = new SettingsPage();
            settings.Show();

        }
        public void Page_Refresh()
        {
            for (int i = 0; i < row*col; i++)
            {
                switch (lblcheck[i])
                {
                    case "empty":
                        btn[i].Image = default;
                        break;
                    case "bluesquare":
                        btn[i].Image = Image.FromFile("../../../IMAGES/bluesquare.png");

                        break;
                    case "bluetriangle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/bluetriangle.png");

                        break;
                    case "bluecircle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/bluecircle.png");

                        break;
                    case "purplesquare":
                        btn[i].Image = Image.FromFile("../../../IMAGES/purplesquare.png");

                        break;
                    case "purpletriangle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/purpletriangle.png");

                        break;
                    case "purplecircle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/purplecircle.png");

                        break;
                    case "orangesquare":
                        btn[i].Image = Image.FromFile("../../../IMAGES/orangesquare.png");

                        break;
                    case "orangetriangle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/orangetriangle.png");

                        break;
                    case "orangecircle":
                        btn[i].Image = Image.FromFile("../../../IMAGES/orangecircle.png");

                        break;
                }

            }
           }
        private void Multiplayergame_Load(object sender, EventArgs e) //Oyunun hazır hale gelmesi için zorluk,seçimler gibi ayarlar gerekli yerlerden çekilir.
        {
            for (int i = 0; i < 400; i++)
            {
                lblcheck[i] = "empty";
            }

            difficulty = LoginUser.getInstance().User.Difficultysetting;

            switch (difficulty)
            {
                case "easy":
                    row = 15;
                    col = 15;
                    scorerule = 1;
                    break;
                case "normal":
                    row = 9;
                    col = 9;
                    scorerule = 3;
                    break;
                case "hard":
                    row = 6;
                    col = 6;
                    scorerule = 5;
                    break;
                case "custom":
                    row = Settings.Default.customint2;
                    col = Settings.Default.customint1;
                    scorerule = 2;
                    break;
            }

            int number = 0;
            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < row; i++)
                {
                    btn[number] = new Button();
                    btn[number].Name = number.ToString();
                    btn[number].Size = new Size(35, 35);
                    btn[number].Location = new Point(35 * j, 35 * i);
                    btn[number].BackColor = SystemColors.Control;
                    btn[number].Click += new EventHandler(ButtonArray_click);
                    btn[number].MouseEnter += new EventHandler(ButtonArray_MouseEnter);
                    Controls.Add(btn[number]);
                    number++;
                }
            }
            color_object_selector();

            

            if (ishost)
            {

                tcpListener = new TcpListener(1453);
                tcpListener.Start();
                soket = tcpListener.AcceptSocket();
                stream = new NetworkStream(soket);
                Thread dinle = new Thread(soketdinle);
                dinle.Start();

            }
            else
            {

                randompicker();
                IPEndPoint localEndPoint = new IPEndPoint(ipaddress, port);

                socket = new Socket(ipaddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(localEndPoint);

                socketsendmessage = "";

                for (int i = 0; i < lblcheck.Length; i++)
                {
                    socketsendmessage += lblcheck[i] + ",";
                }
                byte[] sendbytei = new byte[4000];
                sendbytei = Encoding.Default.GetBytes(socketsendmessage);

                socket.Send(sendbytei);
                //socket.Close();

                tcpListener = new TcpListener(80);
                tcpListener.Start();
                //soket = tcpListener.AcceptSocket();

                stream = new NetworkStream(socket);
                Thread dinle = new Thread(soketdinle);
                dinle.Start();





            }

        }

        private void Sendlbl()
        {
            socketsendmessage = "";
            if (ishost)
            {
                for (int i = 0; i < lblcheck.Length; i++)
                {
                    socketsendmessage += lblcheck[i] + ",";
                }
                byte[] sendbyte = new byte[2048];
                sendbyte = Encoding.Default.GetBytes(socketsendmessage);

                soket.Send(sendbyte);
                FreezeButtons();
            }
            else
            {
                for (int i = 0; i < lblcheck.Length; i++)
                {
                    socketsendmessage += lblcheck[i] + ",";
                }
                byte[] sendbyte = new byte[4000];
                sendbyte = Encoding.Default.GetBytes(socketsendmessage);

                socket.Send(sendbyte);
                FreezeButtons();
            }
            

        }
        private void Receivelbl()
        {
            
            byte[] buffer3 = new byte[2048];
            
            int numberofbytesreceived = socket.Receive(buffer3);
            byte[] receivedbytes = new byte[numberofbytesreceived];
            Array.Copy(buffer3, receivedbytes, numberofbytesreceived);
            string receivedmessage = Encoding.Default.GetString(receivedbytes);

            receivedlblcheck = receivedmessage.Split(',');


            for (int i = 0; i < receivedlblcheck.Length; i++)
            {
                lblcheck[i] = receivedlblcheck[i];
            }

            Page_Refresh();
            
            
        }//KULLANIM DIŞI
        private void FreezeButtons()
        {
            for (int i = 0; i < row*col; i++)
            {
                
               btn[i].Enabled = false;
                label4.Text = "rakibin sırası";
                
            }
        }
        private void UnFreezeButtons()
        {

            for (int i = 0; i < row*col; i++)
            {

                btn[i].Enabled = true;
                label4.Text = "sizin sıranız";

            }


        }
        void ButtonArray_click(object sender, EventArgs e) //Dinamik butonların çalışma mekanizmasıdır.
        {
            PaintEraser();
            Button btn_now = sender as Button;
            int num = int.Parse(btn_now.Name);
            if (lblcheck[num] != "empty")
            {
                temp = lblcheck[num];
                tempnum = num;
            }
            else
            {
                gamesound.Play();
                if (temp != "empty")
                {
                    lblcheck[tempnum] = "empty";
                    btn[tempnum].Image = default;
                    lblcheck[num] = temp;
                    for (int i = 0; i < roadsave.Count; i++)
                    {
                        if (i == roadsave.Count - 2)
                        {
                            break;
                        }
                        if (roadsave.Count > 1)
                        {
                            if (roadsave[i] == roadsave[i + 2])
                            {
                                roadsave.RemoveAt(i + 2);
                            }
                        }

                    }
                    for (int i = 0; i < roadsave.Count; i++)
                    {
                        Task.Delay(1000).Wait();
                        btn[roadsave[i]].Image = Image.FromFile("../../../IMAGES/" + temp + ".png");
                        if (i != 0)
                        {
                            btn[roadsave[i - 1]].Image = default;
                        }
                    }
                    temp = "empty";
                    randompicker();
                    GameScoreEngine();

                    Sendlbl();
                    
                    
                }
            }
            GameScoreEngine();
            GameFinisher();
        }
        private void btn_profilescreen_Click(object sender, EventArgs e) //Profil ekranına gönderir.
        {
            ProfileScreen profileScreen = new ProfileScreen();
            profileScreen.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e) //about ekranına gönderir.
        {
            AboutScreen about = new AboutScreen();
            about.ShowDialog();
        }
        private void color_object_selector() //Oyunda kullanılmak için kullanıcının seçtiği objeleri ayarlist e ekler.
        {
            SettingsPage settings = new SettingsPage();
            if (settings.chk1)
            {
                arrayadder("objects", "square");
            }
            if (settings.chk2)
            {
                arrayadder("objects", "triangle");
            }
            if (settings.chk3)
            {
                arrayadder("objects", "circle");
            }
            if (settings.chk4)
            {
                arrayadder("colors", "blue");
            }
            if (settings.chk5)
            {
                arrayadder("colors", "purple");
            }
            if (settings.chk6)
            {
                arrayadder("colors", "orange");
            }
        }
        private void arrayadder(String arr, string str)
        {
            switch (arr)
            {
                case "colors":

                    selected_colors[clrselect] = str;
                    flag1 = clrselect;
                    clrselect++;
                    break;

                    break;

                case "objects":
                    selected_objects[objselect] = str;
                    flag2 = objselect;
                    objselect++;
                    break;

                    break;
            }
        }
        private void randompicker() //random 3 adet şekil ataması yapar.
        {
            for (int b = 0; b < 3; b++)
            {
                for (int a = 0; ; a++)
                {
                    Random random = new Random();
                    int rand = random.Next(row * col);

                    Random randcolor = new Random();
                    int obj = random.Next(0, flag2 + 1);

                    Random randobj = new Random();
                    int clr = random.Next(0, flag1 + 1);

                    if (lblcheck[rand] == "empty")
                    {
                        switch (selected_colors[clr])
                        {
                            case "blue":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/bluesquare.png");
                                        lblcheck[rand] = "bluesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/bluetriangle.png");
                                        lblcheck[rand] = "bluetriangle";
                                        break;
                                    case "circle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/bluecircle.png");
                                        lblcheck[rand] = "bluecircle";
                                        break;
                                }
                                break;
                            case "purple":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/purplesquare.png");
                                        lblcheck[rand] = "purplesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/purpletriangle.png");
                                        lblcheck[rand] = "purpletriangle";
                                        break;
                                    case "circle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/purplecircle.png");
                                        lblcheck[rand] = "purplecircle";
                                        break;
                                }
                                break;
                            case "orange":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/orangesquare.png");
                                        lblcheck[rand] = "orangesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/orangetriangle.png");
                                        lblcheck[rand] = "orangetriangle";
                                        break;
                                    case "circle":
                                        btn[rand].Image = Image.FromFile("../../../IMAGES/orangecircle.png");
                                        lblcheck[rand] = "orangecircle";
                                        break;
                                }
                                
                                break;
                        }
                        Page_Refresh();
                        break;
                    
                    }
                 
                }
            }
        
        }
        private void roadscribe(int number) //Şekillerin üstünden geçmeden izlenecek yolu hesaplar ve yeşil renge boyar.
        {

            PaintEraser();

            int x = tempnum % row;
            int y = (tempnum - x) / row;
            int goalx = number % row;
            int goaly = (number - goalx) / row;
            roadsave.Clear();

            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int rand = random.Next(2);
                if (lblcheck[goaly * row + goalx] != "empty")
                {
                    break;
                }

                if (y == goaly)
                {
                    if (x > goalx)
                    {
                        if (lblcheck[y * row + x - 1] != "empty")
                        {
                            if (y != 0)
                            {
                                if (lblcheck[(y - 1) * row + x] == "empty")
                                {
                                    y -= 1;
                                }
                                else if (lblcheck[(y + 1) * row + x] == "empty")
                                {
                                    y += 1;
                                }
                            }
                        }
                        else
                        {
                            x -= 1;
                        }
                    }
                    else if (x < goalx)
                    {
                        if (lblcheck[y * row + x + 1] != "empty")
                        {
                            if (y != 0)
                            {
                                if (lblcheck[(y - 1) * row + x] == "empty")
                                {
                                    y -= 1;
                                }
                                else if (lblcheck[(y + 1) * row + x] == "empty")
                                {
                                    y += 1;
                                }
                            }
                        }
                        else
                        {
                            x += 1;
                        }
                    }
                }
                else if (x == goalx)
                {
                    if (y > goaly)
                    {
                        if (lblcheck[(y - 1) * row + x] != "empty")
                        {
                            if (lblcheck[y * row + x + 1] == "empty")
                            {
                                x += 1;
                            }
                            else
                            {
                                x -= 1;
                            }
                        }
                        else
                        {
                            y -= 1;
                        }
                    }
                    else if (y < goaly)
                    {
                        if (lblcheck[(y + 1) * row + x] != "empty")
                        {
                            if (lblcheck[y * row + x - 1] == "empty")
                            {
                                x -= 1;
                            }
                            else if (lblcheck[y * row + x + 1] == "empty")
                            {
                                x += 1;
                            }
                        }
                        else if (lblcheck[(y + 1) * row + x] == "empty")
                        {
                            y += 1;
                        }
                    }
                }

                else
                {
                    if (rand == 0 && x != goalx)
                    {
                        if (x > goalx)
                        {
                            if (lblcheck[y * row + x - 1] == "empty")
                            {
                                x -= 1;
                            }
                        }
                        else if (x < goalx)
                        {
                            if (lblcheck[y * row + x + 1] == "empty")
                            {
                                x += 1;
                            }
                        }
                    }
                    else if (rand == 1 && y != goaly)
                    {
                        if (y > goaly)
                        {
                            if (y == 1)
                            {
                                continue;
                            }
                            if (lblcheck[(y - 1) * (row) - x] == "empty")
                            {
                                y -= 1;
                            }
                        }
                        else if (y < goaly)
                        {
                            if (y == 1)
                            {
                                continue;
                            }
                            if (y != 0)
                            {
                                if (lblcheck[(y + 1) * (row) + x] == "empty")
                                {
                                    y += 1;
                                }
                            }
                        }
                    }
                }

                int paint = y * row + x;
                roadsave.Add(paint);
                btn[paint].BackColor = Color.Green;
                painteddots.Add(paint);
                if (goalx == x && y == goaly)
                {
                    break;
                }

                if (lblcheck[goaly * row + goalx] != "empty")
                {
                    PaintEraser();
                    break;
                }
            }
        }
        private void ButtonArray_MouseEnter(object sender, EventArgs e)
        {
            if (temp != "empty")
            {
                Button btn_now = sender as Button;
                int numBER = int.Parse(btn_now.Name);
                if (lblcheck[numBER] == "empty")
                {
                    roadscribe(numBER);
                }
                else
                {
                    PaintEraser();
                }

            }
        } //Roadscribe için yol çizilmesi gereken butonun konumunu alır ve gönderir.
        private void PaintEraser()
        {
            Task.Delay(0);
            for (int iN = 0; iN < painteddots.Count; iN++)
            {
                btn[painteddots[iN]].BackColor = SystemColors.Control;
            }
        } //objen taşınma esnasında objenin gideceği renkli yolun silimini yapar.

        private void Formclosed(object sender, FormClosedEventArgs e)
        {
            databaseprocess data = new databaseprocess();
            data.turnzero();
        }

       

        private void GameScoreEngine() //Oyunun puanlandırma mekanizmasını çalıştırır.
        {
            for (int iN = 0; iN < col; iN++)
            {
                for (int i = 0; i < row - 4; i++)
                {
                    if (lblcheck[iN * row + i] == lblcheck[iN * row + i + 1] && lblcheck[iN * row + i + 1] == lblcheck[iN * row + i + 2] && lblcheck[iN * row + i + 2] == lblcheck[iN * row + i + 3] && lblcheck[iN * row + i + 3] == lblcheck[iN * row + i + 4] && lblcheck[iN * row + i + 4] != "empty")
                    {
                        int sc = int.Parse(scorelbl.Text.ToString());
                        sc += scorerule;
                        scorelbl.Text = sc.ToString();
                        scoresound.Play();
                        if (sc > LoginUser.getInstance().User.Maxscore)
                        {
                            LoginUser.getInstance().User.Maxscore = sc;
                            databaseprocess databaseprocess = new databaseprocess();
                            databaseprocess.updatedata(LoginUser.getInstance().User);
                        }
                        for (int j = i; j < 5 + i; j++)
                        {
                            btn[iN * row + j].Image = default;
                            lblcheck[iN * row + j] = "empty";
                        }
                    }
                }
            }
            for (int iN = 0; iN < row; iN++)
            {
                for (int i = 0; i < col - 4; i++)
                {
                    if (lblcheck[i * row + iN] == lblcheck[(i + 1) * row + iN] && lblcheck[(i + 1) * row + iN] == lblcheck[(i + 2) * row + iN] && lblcheck[(i + 2) * row + iN] == lblcheck[(i + 3) * row + iN] && lblcheck[(i + 3) * row + iN] == lblcheck[(i + 4) * row + iN] && lblcheck[(i + 4) * row + iN] != "empty")
                    {
                        int sca = int.Parse(scorelbl.Text.ToString());
                        sca += scorerule;
                        scorelbl.Text = sca.ToString();
                        scoresound.Play();
                        if (sca > LoginUser.getInstance().User.Maxscore)
                        {
                            LoginUser.getInstance().User.Maxscore = sca;
                            databaseprocess databaseprocess = new databaseprocess();
                            databaseprocess.updatedata(LoginUser.getInstance().User);
                        }
                        for (int j = i; j < 5 + i; j++)
                        {
                            btn[j * row + iN].Image = default;
                            lblcheck[j * row + iN] = "empty";
                        }
                    }
                }

            }
        }

        private void GameFinisher() //Eeğer yeterli boşluk kalmadıysa oyunu sonlandırır.
        {
            int finisher = 0;
            for (int i = 0; i < 400; i++)
            {
                if (lblcheck[i] != "empty")
                {
                    finisher++;
                }
            }
            if (finisher > (row) * (col) - 3)
            {
                MessageBox.Show("Kaybettiniz 5 saniye sonra oyun kapatılacaktır");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
