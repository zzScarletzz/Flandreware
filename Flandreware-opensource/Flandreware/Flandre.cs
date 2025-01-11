using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Flandreware
{
    public partial class Flandre : Form
    {
        public Flandre()
        {
            InitializeComponent();

            SoundPlayer audio = new SoundPlayer(Flandreware.Properties.Resources.tobeornottobe);
            audio.Play();
            MessageBox.Show("Can you die for someone?", "to be or not to be");
            MessageBox.Show("この先は、Flandreware(ランサムウェア)\nFlandreware (ransomware) beyond this point.", "Flandreware");
            MessageBox.Show("あなたはこの先を実行しますか？\nWill you run this destination?", "Flandreware");
            MessageBox.Show("FlandreScarlet:私と遊んでくれるの？\nFlandreScarlet:Will you play with me?", "Flandreware");
            DialogResult result = MessageBox.Show("[Flandre Scarlet]\n私とゲームをするの？\nAre you playing games with me?", "Flandreware",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("FlandreScarlet:遊んでくれるの？？うれしいわ\nFlandreScarlet:Will you play with me? I'm so happy.");
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("FlandreScarlet:つまらないわ\nFlandreScarlet:It's not a chore.");
                Application.Exit();
            }
        }

        private void Flandre_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
