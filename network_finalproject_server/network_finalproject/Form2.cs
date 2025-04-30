using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WMPLib;
using System.Net;
using System.Net.Sockets;
using System.IO;//for streaming io
using System.Threading;//for running threads
using System.Runtime.ConstrainedExecution;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace network_finalproject_server
{
    delegate void UpdateTextBox(string msg);
    public partial class Form2 : Form

    {
        private TcpListener ConnectionListener;//variable needed to listen for connections
        private BinaryReader MessageReader;//variable for reading messages
        private BinaryWriter MessageWriter;//variable for writing messages
        private Socket ClientConnection;//variable for holding the client connection
        private NetworkStream DataStream;//variable for keeping server and client in a stream and synchronized
        private Thread ListeningThread;
        int i = 1;
        int page = 0;
        int ss = 1;
        int sc = 0;
        int timescore = 0;
        private System.Windows.Forms.Timer countdownTimer;
        private int remainingSeconds = 30;
        private int getPoint = 0;
        public int intPort = 0;

        WMPLib.WindowsMediaPlayer mus = new WMPLib.WindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 設置計時器間隔為1秒（1000毫秒）
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            page++;
            Ask(page);
            try
            {
                if (ClientConnection.Connected)
                {
                    MessageWriter.Write("NextStep");//send message via stream
                    //textBox4.Clear();//clear text box after sending
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no client is connected");//signal the error in a messagebox
            }
        }

        private void button1_Action()
        {
            page++;
            Ask(page);

        }
        private void Ask(int q)
        {
            switch (q)
            {
                case 1:
                    textBox1.Text = "大家好阿 !!!! 我是海綿寶寶\r\n最近我當上了海底交警王\r\n我會海底維持秩序保護好大家!";
                    pictureBox4.Visible = false;
                    pictureBox6.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    break;
                case 2:
                    textBox1.Text = "我今天要去參加合唱團，\r\n夢想成為K歌大明星\r\n誰也別想攔住我\r\n今天我是最閃亮的星！";
                    pictureBox4.Visible = true;
                    pictureBox6.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
                case 3:
                    textBox1.Text = "章魚哥!!請稍等，\r\n最近治安不佳!過路需要檢查！\r\n這裡可是交警的地盤，\r\n安全第一!不能大意！";
                    pictureBox4.Visible = false;
                    pictureBox6.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    break;
                case 4:
                    textBox1.Text = "海綿寶寶 快讓開\r\n我的時間可不多！\r\n合唱團在等我\r\n今天我要一展歌喉！";
                    pictureBox4.Visible = true;
                    pictureBox6.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
                case 5:
                    textBox1.Text = "章魚哥!來比交警K歌王，\r\n讓我看看你的實力!贏了就讓你通過!輸了就要配合檢查";
                    pictureBox6.Visible = true;
                    pictureBox4.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    break;
                case 6:
                    textBox1.Text = "來啊!海綿寶寶";
                    pictureBox4.Visible = true;
                    pictureBox6.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
                case 7:
                    song();
                    break;
                case 8:
                    textBox1.Text = "那我們來公布結果囉~這次的贏家是...";
                    pictureBox4.Visible = false;
                    pictureBox6.Visible = false;
                    break;
                case 9:
                    if (timescore > getPoint)
                    {
                        textBox1.Text = "哈哈哈!章魚哥我贏了~你必須配合檢查才可以通過";
                    }

                    else if (timescore == getPoint)
                    {
                        textBox1.Text = "看來我們不分上下嘛~就讓你過吧!";
                    }

                    else
                    {
                        textBox1.Text = "歐~我輸了...";
                    }
                    pictureBox4.Visible = true;
                    pictureBox6.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    break;
                case 10:
                    if (timescore > getPoint)
                    {
                        textBox1.Text = "歐~我輸了...你快檢查吧海綿寶寶\n我怕趕不上合唱團";
                    }

                    else if (timescore == getPoint)
                    {
                        textBox1.Text = "下次不可能再跟你平手了!";
                    }

                    else
                    {
                        textBox1.Text = "滾開輸家海綿寶寶!我要去參加合唱團";
                    }
                    pictureBox4.Visible = false;
                    pictureBox6.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    break;



            }



        }



        private void song()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;
            button3.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            label1.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

        }
        private void pp()
        {
            page++;
            Ask(page);
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox4.Visible = true;
            pictureBox6.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Visible = true;
            button3.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            label1.Visible = false;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            page--;
            Ask(page);
            try
            {
                if (ClientConnection.Connected)
                {
                    MessageWriter.Write("LastStep");//send message via stream
                    //textBox4.Clear();//clear text box after sending
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no client is connected");//signal the error in a messagebox
            }
        }

        private void button2_Action()
        {
            page--;
            Ask(page);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            countdownTimer.Start();
            switch (ss)
            {
                case 1:

                    mus.URL = "BoysWhoCry.mp4";
                    mus.controls.play();
                    break;
                case 2:
                    mus.URL = "fafolo.mP4";
                    mus.controls.play();

                    break;
                case 3:
                    mus.URL = "GaryComeHome.mp4";
                    mus.controls.play();

                    break;
                case 4:
                    mus.URL = "humberger.mp4";
                    mus.controls.play();
                    break;
                case 5:
                    mus.URL = "jellyfish.mp4";
                    mus.controls.play();

                    break;
                case 6:
                    mus.URL = "moin.mp4";
                    mus.controls.play();

                    break;

                case 7:
                    mus.URL = "sprinkle.mp4";
                    mus.controls.play();

                    break;
                case 8:
                    mus.URL = "Sweetvictory.mp4";
                    mus.controls.play();
                    break;
                case 9:
                    mus.URL = "underwear.mp4";
                    mus.controls.play();

                    break;
                case 10:
                    mus.URL = "theme.mp4";
                    mus.controls.play();

                    break;
                default:
                    break;
            }

            try
            {
                if (ClientConnection.Connected)
                {
                    MessageWriter.Write("Music");//send message via stream
                    //textBox4.Clear();//clear text box after sending
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no client is connected");//signal the error in a messagebox
            }
        }

        private void button3_Action()
        {
            countdownTimer.Start();
            switch (ss)
            {
                case 1:

                    mus.URL = "BoysWhoCry.mp4";
                    mus.controls.play();
                    break;
                case 2:
                    mus.URL = "fafolo.mP4";
                    mus.controls.play();

                    break;
                case 3:
                    mus.URL = "GaryComeHome.mp4";
                    mus.controls.play();

                    break;
                case 4:
                    mus.URL = "humberger.mp4";
                    mus.controls.play();
                    break;
                case 5:
                    mus.URL = "jellyfish.mp4";
                    mus.controls.play();

                    break;
                case 6:
                    mus.URL = "moin.mp4";
                    mus.controls.play();

                    break;

                case 7:
                    mus.URL = "sprinkle.mp4";
                    mus.controls.play();

                    break;
                case 8:
                    mus.URL = "Sweetvictory.mp4";
                    mus.controls.play();
                    break;
                case 9:
                    mus.URL = "underwear.mp4";
                    mus.controls.play();

                    break;
                case 10:
                    mus.URL = "theme.mp4";
                    mus.controls.play();


                    break;
                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mus.controls.pause();
            countdownTimer.Stop();
            switch (ss)
            {
                case 1:
                    label1.Text = "第二題";
                    button5.Text = "費加洛";
                    button6.Text = "費德勒";
                    button7.Text = "費洛蒙";
                    button8.Text = "費玉清";
                    break;
                case 2:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第三題";
                    button5.Text = "Gary";
                    button6.Text = "Sandy";
                    button7.Text = "Sandy Come Home";
                    button8.Text = "Gary Come Home";

                    break;
                case 3:
                    label1.Text = "第四題";
                    button5.Text = "蟹老闆之歌";
                    button6.Text = "美味蟹堡之歌";
                    button7.Text = "蟹堡王之歌";
                    button8.Text = "蟹堡秘方之歌";

                    break;
                case 4:
                    label1.Text = "第五題";
                    button5.Text = "水母";
                    button6.Text = "jellyfish jam";
                    button7.Text = "水母歌";
                    button8.Text = "字母歌";
              
                    break;
                case 5:
                    label1.Text = "第六題";
                    button5.Text = "穿腦魔音";
                    button6.Text = "魔音穿腦";
                    button7.Text = "魔音傳腦";
                    button8.Text = "傳腦魔音";
                    break;

                case 6:
                    label1.Text = "第七題";
                    button5.Text = "一閃一閃亮晶晶";
                    button6.Text = "一閃一閃派大星";
                    button7.Text = "一閃一閃小星星";
                    button8.Text = "一閃一閃小珍珍";
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    break;

                case 7:
                    label1.Text = "第八題";
                    button5.Text = "Sweet music";
                    button6.Text = "Sweet";
                    button7.Text = "victory";
                    button8.Text = "Sweet victory";
                 
                    break;
                case 8:
                    label1.Text = "第九題";
                    button5.Text = "新牛仔褲之歌";
                    button6.Text = "破褲子之歌";
                    button7.Text = "破內褲之歌";
                    button8.Text = "破衣服之歌";
                   
                    break;
                case 9:
                    label1.Text = "第十題";
                    button5.Text = "深海的大鳳梨";
                    button6.Text = "是的!船長";
                    button7.Text = "方方黃黃伸縮自如";
                    button8.Text = "海綿寶寶主題曲";

                    break;
                case 10:

                    MessageWriter.Write(label8.Text) ;
                    MessageBox.Show("完成作答!統計分數中...");

                    pp();

                    break;


                default:
                    break;
            }

            ss++;
            remainingSeconds = 30;
            label6.Text = "30";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            mus.controls.pause();
            countdownTimer.Stop();
            switch (ss)
            {
                case 1:
                    label1.Text = "第二題";
                    button5.Text = "費加洛";
                    button6.Text = "費德勒";
                    button7.Text = "費洛蒙";
                    button8.Text = "費玉清";
                    break;
                case 2:
                    
                    label1.Text = "第三題";
                    button5.Text = "Gary";
                    button6.Text = "Sandy";
                    button7.Text = "Sandy Come Home";
                    button8.Text = "Gary Come Home";

                    break;
                case 3:
                    label1.Text = "第四題";
                    button5.Text = "蟹老闆之歌";
                    button6.Text = "美味蟹堡之歌";
                    button7.Text = "蟹堡王之歌";
                    button8.Text = "蟹堡秘方之歌";

                    break;
                case 4:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第五題";
                    button5.Text = "水母";
                    button6.Text = "jellyfish jam";
                    button7.Text = "水母歌";
                    button8.Text = "字母歌";

                    break;
                case 5:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第六題";
                    button5.Text = "穿腦魔音";
                    button6.Text = "魔音穿腦";
                    button7.Text = "魔音傳腦";
                    button8.Text = "傳腦魔音";
                    break;

                case 6:
                    label1.Text = "第七題";
                    button5.Text = "一閃一閃亮晶晶";
                    button6.Text = "一閃一閃派大星";
                    button7.Text = "一閃一閃小星星";
                    button8.Text = "一閃一閃小珍珍";
                   
                    break;

                case 7:
                    label1.Text = "第八題";
                    button5.Text = "Sweet music";
                    button6.Text = "Sweet";
                    button7.Text = "victory";
                    button8.Text = "Sweet victory";

                    break;
                case 8:
                    label1.Text = "第九題";
                    button5.Text = "新牛仔褲之歌";
                    button6.Text = "破褲子之歌";
                    button7.Text = "破內褲之歌";
                    button8.Text = "破衣服之歌";

                    break;
                case 9:
                    label1.Text = "第十題";
                    button5.Text = "深海的大鳳梨";
                    button6.Text = "是的!船長";
                    button7.Text = "方方黃黃伸縮自如";
                    button8.Text = "海綿寶寶主題曲";
                    break;
                case 10:

                    MessageWriter.Write(label8.Text);
                    MessageBox.Show("完成作答!統計分數中...");

                    pp();

                    break;

                    
                default:
                    break;
            }
            ss++;
            remainingSeconds = 30;
            label6.Text = "30";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mus.controls.pause();
            countdownTimer.Stop();
            switch (ss)
            {
                case 1:
                    label1.Text = "第二題";
                    button5.Text = "費加洛";
                    button6.Text = "費德勒";
                    button7.Text = "費洛蒙";
                    button8.Text = "費玉清";
                    break;
                case 2:
                    
                    label1.Text = "第三題";
                    button5.Text = "Gary";
                    button6.Text = "Sandy";
                    button7.Text = "Sandy Come Home";
                    button8.Text = "Gary Come Home";

                    break;
                case 3:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第四題";
                    button5.Text = "蟹老闆之歌";
                    button6.Text = "美味蟹堡之歌";
                    button7.Text = "蟹堡王之歌";
                    button8.Text = "蟹堡秘方之歌";

                    break;
                case 4:
                    label1.Text = "第五題";
                    button5.Text = "水母";
                    button6.Text = "jellyfish jam";
                    button7.Text = "水母歌";
                    button8.Text = "字母歌";

                    break;
                case 5:
                    label1.Text = "第六題";
                    button5.Text = "穿腦魔音";
                    button6.Text = "魔音穿腦";
                    button7.Text = "魔音傳腦";
                    button8.Text = "傳腦魔音";
                    break;

                case 6:
                    label1.Text = "第七題";
                    button5.Text = "一閃一閃亮晶晶";
                    button6.Text = "一閃一閃派大星";
                    button7.Text = "一閃一閃小星星";
                    button8.Text = "一閃一閃小珍珍";
                    
                    break;

                case 7:
                    label1.Text = "第八題";
                    button5.Text = "Sweet music";
                    button6.Text = "Sweet";
                    button7.Text = "victory";
                    button8.Text = "Sweet victory";

                    break;
                case 8:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第九題";
                    button5.Text = "新牛仔褲之歌";
                    button6.Text = "破褲子之歌";
                    button7.Text = "破內褲之歌";
                    button8.Text = "破衣服之歌";

                    break;
                case 9:
                    label1.Text = "第十題";
                    button5.Text = "深海的大鳳梨";
                    button6.Text = "是的!船長";
                    button7.Text = "方方黃黃伸縮自如";
                    button8.Text = "海綿寶寶主題曲";

                    break;
                case 10:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    MessageWriter.Write(label8.Text);
                    MessageBox.Show("完成作答!統計分數中...");

                    pp();

                    break;

                default:
                    break;
            }

            ss++;
            remainingSeconds = 30;
            label6.Text = "30";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            mus.controls.pause();
            countdownTimer.Stop();
            switch (ss)
            {
                case 1:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第二題";
                    button5.Text = "費加洛";
                    button6.Text = "費德勒";
                    button7.Text = "費洛蒙";
                    button8.Text = "費玉清";
                    break;
                case 2:
                    
                    label1.Text = "第三題";
                    button5.Text = "Gary";
                    button6.Text = "Sandy";
                    button7.Text = "Sandy Come Home";
                    button8.Text = "Gary Come Home";

                    break;
                case 3:
                    label1.Text = "第四題";
                    button5.Text = "蟹老闆之歌";
                    button6.Text = "美味蟹堡之歌";
                    button7.Text = "蟹堡王之歌";
                    button8.Text = "蟹堡秘方之歌";

                    break;
                case 4:
                    label1.Text = "第五題";
                    button5.Text = "水母";
                    button6.Text = "jellyfish jam";
                    button7.Text = "水母歌";
                    button8.Text = "字母歌";

                    break;
                case 5:
                    label1.Text = "第六題";
                    button5.Text = "穿腦魔音";
                    button6.Text = "魔音穿腦";
                    button7.Text = "魔音傳腦";
                    button8.Text = "傳腦魔音";
                    break;

                case 6:
                    label1.Text = "第七題";
                    button5.Text = "一閃一閃亮晶晶";
                    button6.Text = "一閃一閃派大星";
                    button7.Text = "一閃一閃小星星";
                    button8.Text = "一閃一閃小珍珍";
                   
                    break;

                case 7:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第八題";
                    button5.Text = "Sweet music";
                    button6.Text = "Sweet";
                    button7.Text = "victory";
                    button8.Text = "Sweet victory";

                    break;
                case 8:
                    label1.Text = "第九題";
                    button5.Text = "新牛仔褲之歌";
                    button6.Text = "破褲子之歌";
                    button7.Text = "破內褲之歌";
                    button8.Text = "破衣服之歌";

                    break;
                case 9:
                    sc++;
                    timescore = timescore + 10 * remainingSeconds;
                    label8.Text = $"{timescore}";
                    label1.Text = "第十題";
                    button5.Text = "深海的大鳳梨";
                    button6.Text = "是的!船長";
                    button7.Text = "方方黃黃伸縮自如";
                    button8.Text = "海綿寶寶主題曲";


                    break;
                case 10:
                    MessageWriter.Write(label8.Text);
                    MessageBox.Show("完成作答!統計分數中...");


                    pp();

                    break;
                default:
                    break;
            }

            ss++;
            remainingSeconds = 30;
            label6.Text = "30";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timeout()
        {
            mus.controls.pause();
            switch (ss)
            {
                case 1:
                    label1.Text = "第二題";
                    button5.Text = "費加洛";
                    button6.Text = "費德勒";
                    button7.Text = "費洛蒙";
                    button8.Text = "費玉清";
                    break;
                case 2:

                    label1.Text = "第三題";
                    button5.Text = "Gary";
                    button6.Text = "Sandy";
                    button7.Text = "Sandy Come Home";
                    button8.Text = "Gary Come Home";

                    break;
                case 3:
                    label1.Text = "第四題";
                    button5.Text = "蟹老闆之歌";
                    button6.Text = "美味蟹堡之歌";
                    button7.Text = "蟹堡王之歌";
                    button8.Text = "蟹堡秘方之歌";

                    break;
                case 4:
                    label1.Text = "第五題";
                    button5.Text = "水母";
                    button6.Text = "jellyfish jam";
                    button7.Text = "水母歌";
                    button8.Text = "字母歌";

                    break;
                case 5:
                    label1.Text = "第六題";
                    button5.Text = "穿腦魔音";
                    button6.Text = "魔音穿腦";
                    button7.Text = "魔音傳腦";
                    button8.Text = "傳腦魔音";
                    break;

                case 6:
                    label1.Text = "第七題";
                    button5.Text = "一閃一閃亮晶晶";
                    button6.Text = "一閃一閃派大星";
                    button7.Text = "一閃一閃小星星";
                    button8.Text = "一閃一閃小珍珍";

                    break;

                case 7:
                    label1.Text = "第八題";
                    button5.Text = "Sweet music";
                    button6.Text = "Sweet";
                    button7.Text = "victory";
                    button8.Text = "Sweet victory";

                    break;
                case 8:
                    label1.Text = "第九題";
                    button5.Text = "新牛仔褲之歌";
                    button6.Text = "破褲子之歌";
                    button7.Text = "破內褲之歌";
                    button8.Text = "破衣服之歌";

                    break;
                case 9:
                    label1.Text = "第十題";
                    button5.Text = "深海的大鳳梨";
                    button6.Text = "是的!船長";
                    button7.Text = "方方黃黃伸縮自如";
                    button8.Text = "海綿寶寶主題曲";


                    break;
                case 10:
                    MessageWriter.Write(label8.Text);
                    MessageBox.Show("完成作答!統計分數中...");


                    pp();

                    break;
                default:
                    break;
            }
            ss++;
            remainingSeconds = 30;
            label6.Text = "30";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            System.Net.IPAddress SvrIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            textBox2.Text = SvrIP.ToString();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            intPort = int.Parse(textBox3.Text);

            if (!BackWork_UDP.IsBusy) BackWork_UDP.RunWorkerAsync();

            try
            {
                IPAddress.Parse(textBox2.Text);//
                ListeningThread = new Thread(new ThreadStart(ListenForConnections));//assign thread variable with the blocking function
                ListeningThread.Start();//start the thread that will wait for connections
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Ip Address");//signal the error in a message box
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientConnection.Connected)
                {
                    MessageWriter.Write(textBox4.Text);//send message via stream
                    ChangeTextBoxContent("海綿寶寶：" + textBox4.Text);
                    textBox4.Clear();//clear text box after sending
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no client is connected");//signal the error in a messagebox
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClientConnection.Close();
            //System.Environment.Exit(System.Environment.ExitCode);//exit and close all threads and release all recources
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //if enter key was pressed
            if (e.KeyCode == Keys.Enter)//check if enter key was pressed
            {
                //check if the their is a client first
                try
                {
                    if (ClientConnection.Connected)
                    {
                        MessageWriter.Write(textBox4.Text);//send message via stream
                        ChangeTextBoxContent("海綿寶寶：" + textBox4.Text);
                        textBox4.Clear();//clear text box after sending
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("no client is connected");//signal the error in a messagebox
                }
            }
        }

        private void ListenForConnections()
        {
            //try listening with the given ip address
            try
            {
                ConnectionListener = new TcpListener(IPAddress.Parse(textBox2.Text), 80);//listen to given ip on port 80 allways
                ConnectionListener.Start();//start listening;
                ChangeTextBoxContent("Listening For Connections");
                ClientConnection = ConnectionListener.AcceptSocket();//wait untill client connects (blocking function) if connected return a socket 
                DataStream = new NetworkStream(ClientConnection);//initialize a stream 
                MessageReader = new BinaryReader(DataStream);//use reader within the stream
                MessageWriter = new BinaryWriter(DataStream);//use writer within the stream
                ChangeTextBoxContent("Connection Received");
                HandleConnection();//handle the reading and writing 
                //here the client disconnected or something went wrong with the connection
                MessageReader.Close();//close the reader;
                MessageWriter.Close();//close the writer;
                DataStream.Close();//close the stream;
                ClientConnection.Close();//close thre connection
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect, wrong ip address");//signal the error in a message box
            }
        }
        private void HandleConnection()
        {
            string message;
            //loop until infinity
            do
            {
                //try reading from the data stream if anything went wrong with the connection break
                try
                {
                    message = MessageReader.ReadString(); // Read message
                    if (message == "NextStep")
                    {
                        // Use Invoke to ensure the function runs on the UI thread
                        this.Invoke(new Action(button1_Action));
                    }
                    else if (message == "LastStep")
                    {
                        // Use Invoke to ensure the function runs on the UI thread
                        this.Invoke(new Action(button2_Action));
                    }
                    else if (message == "Music")
                    {
                        // Use Invoke to ensure the function runs on the UI thread
                        this.Invoke(new Action(button3_Action));
                    }
                    else if (int.TryParse(message, out int number))
                    {
                        getPoint = int.Parse(message);
                        this.Invoke(new Action(button1_Action));
                    }
                    else
                    {
                        // Update the text box content
                        message = "章魚哥：" + message;
                        this.Invoke(new Action(() => ChangeTextBoxContent(message)));
                    }
                }
                catch (Exception)
                {
                    // Connection lost
                    this.Invoke(new Action(() => ChangeTextBoxContent("Connection Lost")));
                    break; // Exit the while loop
                }
            } while (true);
        }
        private void ChangeTextBoxContent(string tx)
        {
            if (richTextBox1.InvokeRequired)//if the messages text box needs a delegate invoking
            {
                Invoke(new UpdateTextBox(ChangeTextBoxContent), new object[] { tx });
            }
            else
            {
                //if no invoking required then change
                richTextBox1.Text += tx + "\r\n";//concatinate the original with the given message and a new line
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                label6.Text = $"{remainingSeconds}";
            }
            else
            {
                countdownTimer.Stop();
                MessageBox.Show("時間到！");
                timeout();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private String SendUDP(String strSendIP, int intSendPort, String strSendData)
        {
            String strMSG = String.Empty;
            try
            {
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(strSendIP), intSendPort);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SendTo(Encoding.UTF8.GetBytes(strSendData), IPEP);
                strMSG = "Send done";
            }
            catch (Exception ex)
            {
                strMSG = ex.Message;
            }

            return strMSG;
        }

        private void BackWork_UDP_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, intPort);
                Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                newsock.Bind(ipep);
                IPEndPoint sendert = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sendert);
                while (true)
                {
                    if (BackWork_UDP.CancellationPending)
                    {
                        e.Cancel = true;
                        newsock.Close();
                        break;
                    }
                    else
                    {
                        byte[] data = new byte[1024];
                        int recv = newsock.ReceiveFrom(data, ref Remote);
                        BackWork_UDP.ReportProgress(0, Encoding.UTF8.GetString(data, 0, recv));
                        System.Threading.Thread.Sleep(10);
                    }
                }

            }
            catch (Exception ex)
            {
                BackWork_UDP.ReportProgress(0, ex.Message);
            }
        }

        private void BackWork_UDP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            richTextBox2.Text = e.UserState.ToString() + "\r\n" ;
        }

        private void BackWork_UDP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                richTextBox2.AppendText(e.Error.Message + "\r\n");
            }
            else if (e.Cancelled)
            {
                richTextBox2.AppendText("Stop \r\n");
            }
            else
            {
                richTextBox2.AppendText("Work done \r\n");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
