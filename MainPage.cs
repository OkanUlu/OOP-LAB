using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LAB
{
    public partial class MainPage : Form
    {
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
        public MainPage()
        {           
            InitializeComponent();  
        }
        private void button1_Click(object sender, EventArgs e)//settings ekranına geçişi sağlar.
        {
            SettingsPage settings = new SettingsPage();           
            settings.Show();            
        }
        public void Page_Refresh()
        {
            this.Hide();
        }
        private void MainPage_Load(object sender, EventArgs e)
        {
            for(int i= 0; i < 400; i++)
            {
                lblcheck[i] = "empty";
            }
            if (Settings.Default.Difficulty == null)
            {
                difficulty = "easy";
            }
            else
            {
                difficulty = Settings.Default.Difficulty;
            }
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
            
            int number=0;
            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < row; i++)
                {
                    btn[number] = new Button();
                    btn[number].Name =  number.ToString();
                    btn[number].Size = new Size(35, 35);
                    btn[number].Location = new Point(35*j, 35 * i);
                    btn[number].BackColor = SystemColors.Control;
                    btn[number].Click += new EventHandler(ButtonArray_click);
                    btn[number].MouseEnter += new EventHandler(ButtonArray_MouseEnter);
                    Controls.Add(btn[number]);
                    number++;
                }
            }
            color_object_selector();
            randompicker();
        }
        void ButtonArray_click(object sender, EventArgs e)
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
                if(temp != "empty")
                {
                    lblcheck[tempnum] = "empty";
                    btn[tempnum].Image = default;
                    lblcheck[num] = temp;
                    for (int i = 0; i < roadsave.Count; i++)
                    {
                        if(i == roadsave.Count - 2)
                        {
                            break;
                        }
                        if (roadsave[i] == roadsave[i + 2])
                        {
                            roadsave.RemoveAt(i+2);
                        }
                    }
                        for (int i = 0; i < roadsave.Count; i++)
                    {
                        Task.Delay(1000).Wait();
                        btn[roadsave[i]].Image = Image.FromFile("IMAGES/" + temp + ".png");
                        if (i != 0)
                        {
                            btn[roadsave[i - 1]].Image = default;
                        }
                    }
                    temp = "empty";
                    randompicker();
                }
            }
            GameScoreEngine();
            GameFinisher();
        }
        private void btn_profilescreen_Click(object sender, EventArgs e)
        {
            ProfileScreen profileScreen = new ProfileScreen();
            profileScreen.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AboutScreen about = new AboutScreen();
            about.ShowDialog();
        }
        private void color_object_selector()
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
        private void arrayadder(String arr,string str)
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
        private void randompicker()
        {
            for(int b = 0; b < 3; b++)
            {
                for (int a = 0; ; a++)
                {
                    Random random = new Random();
                    int rand = random.Next(row * col);

                    Random randcolor = new Random();
                    int clr = random.Next(0,flag2+1);

                    Random randobj = new Random();
                    int obj = random.Next(0,flag1+1);

                    if (lblcheck[rand] == "empty")
                    {
                        switch (selected_colors[clr])
                        {
                            case "blue":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("IMAGES/bluesquare.png");
                                        lblcheck[rand] = "bluesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("IMAGES/bluetriangle.png");
                                        lblcheck[rand] = "bluetriangle";
                                        break;
                                    case "circle":
                                        btn[rand].Image = Image.FromFile("IMAGES/bluecircle.png");
                                        lblcheck[rand] = "bluecircle";
                                        break;
                                }
                                break;
                            case "purple":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("IMAGES/purplesquare.png");
                                        lblcheck[rand] = "purplesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("IMAGES/purpletriangle.png");
                                        lblcheck[rand] = "purpletriangle";
                                        break;
                                    case "circle": 
                                        btn[rand].Image = Image.FromFile("IMAGES/purplecircle.png");
                                        lblcheck[rand] = "purplecircle";
                                        break;
                                }
                                break;
                            case "orange":
                                switch (selected_objects[obj])
                                {
                                    case "square":
                                        btn[rand].Image = Image.FromFile("IMAGES/orangesquare.png");
                                        lblcheck[rand] = "orangesquare";
                                        break;
                                    case "triangle":
                                        btn[rand].Image = Image.FromFile("IMAGES/orangetriangle.png");
                                        lblcheck[rand] = "orangetriangle";
                                        break;
                                    case "circle":
                                        btn[rand].Image = Image.FromFile("IMAGES/orangecircle.png");
                                        lblcheck[rand] = "orangecircle";
                                        break;
                                }
                                break;
                        }
                        break;
                    }
                    
                }
            }
        }
        private void roadscribe(int number)
        {
            PaintEraser();
            int x = tempnum % row;
            int y = (tempnum-x) / row;
            int goalx = number % row;
            int goaly = (number - goalx) / row;
            roadsave.Clear();
           
            for (int i = 0;i<100 ; i++)
            {
                Random random = new Random();
                int rand = random.Next(2);
                if(lblcheck[goaly * row + goalx] != "empty")
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
                            if(y != 0)
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
                        if (lblcheck[(y-1) * row + x] != "empty")
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
                            if (lblcheck[(y+1) * row + x] != "empty")
                            {
                             if (lblcheck[y * row + x - 1] == "empty")
                                {
                                   x -= 1;
                             }
                             else if(lblcheck[y * row + x + 1] == "empty")
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
                            if(y == 1)
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
                            if (y!= 0)
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

                if (lblcheck[goaly*row + goalx] != "empty" )
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
        }
        private void PaintEraser()
        {
            Task.Delay(0);
            for (int iN = 0; iN < painteddots.Count; iN++)
            {
                btn[painteddots[iN]].BackColor = SystemColors.Control;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpScreen help = new HelpScreen();
            help.ShowDialog();
        }

        private void GameScoreEngine()
        {
            for(int iN = 0;iN < col; iN++)
            {
                for (int i = 0; i < row - 4; i++)
                {
                    if(lblcheck[iN*row + i] == lblcheck[iN * row + i+1] && lblcheck[iN * row + i + 1]== lblcheck[iN * row + i + 2]&& lblcheck[iN * row + i + 2]== lblcheck[iN * row + i + 3]&& lblcheck[iN * row + i + 3]== lblcheck[iN * row + i + 4]&& lblcheck[iN * row + i + 4] !="empty")
                    {
                        int sc = int.Parse(scorelbl.Text.ToString());
                        sc += scorerule;
                        scorelbl.Text = sc.ToString();
                        for(int j = i; j < 5 + i; j++)
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
                    if(lblcheck[i*row + iN]== lblcheck[(i+1) * row + iN]&& lblcheck[(i + 1) * row + iN] == lblcheck[(i + 2) * row + iN]&& lblcheck[(i + 2) * row + iN]== lblcheck[(i + 3) * row + iN]&& lblcheck[(i + 3) * row + iN] == lblcheck[(i + 4) * row + iN]&& lblcheck[(i + 4) * row + iN]!="empty")
                    {
                        int sca = int.Parse(scorelbl.Text.ToString());
                        sca += scorerule;
                        scorelbl.Text = sca.ToString();
                        for (int j = i; j < 5 + i; j++)
                        {
                           btn[j * row + iN].Image = default;
                           lblcheck[j * row + iN] = "empty";
                         }
                    }
                }

            }
        }     
        private void GameFinisher()
        {
            int finisher = 0;
            for(int i = 0; i < 400; i++)
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
