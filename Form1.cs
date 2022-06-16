using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace npa_music_player
{
    public partial class Venetify : Form
    {
        List<Glasba> glasbe;

        public int igrazdaj;
        public Venetify()
        {
            InitializeComponent();
            //glasbe.Add(new Glasba("Dancin", "Dancin.wav"));
            //glasbe.Add(new Glasba("Black Catcher", "BlackCatcher.wav"));
            //glasbe.Add(new Glasba("MTC S3RL", "MTCS3RL.wav"));
            //glasbe.Add(new Glasba("Yu-Gi-Oh", "Yu-Gi-Oh.wav"));
            //glasbe.Add(new Glasba("Trap Anthem","Animethighs.wav" ));
            //glasbe.Add(new Glasba("Rhinestone Eyes", "RhinestoneEyes.wav"));
            //glasbe.Add(new Glasba("Mother Mother", "MotherMother.wav"));
            //glasbe.Add(new Glasba("The Living Tombstone", "TheLivingTombstone.wav"));
            glasbe = ImportAll();
            music1.Text = glasbe[0].Naslov;
            music2.Text = glasbe[1].Naslov;
            button1.Text = glasbe[2].Naslov;
            button2.Text = glasbe[3].Naslov;
            button3.Text = glasbe[4].Naslov;
            button4.Text = glasbe[5].Naslov;
            button5.Text = glasbe[6].Naslov;
            button6.Text = glasbe[7].Naslov;
        }

        //void ExportAll(List<Glasba> glasbe)
        //{
        //    StreamWriter sw = new StreamWriter("data.csv");
        //    for (int i = 0; i < glasbe.Count; i++)
        //    {
        //        sw.Write(glasbe[i].Naslov);
        //        sw.Write(";");
        //        sw.Write(glasbe[i].Datoteka);
        //        sw.Write(";");
        //        sw.Write(Environment.NewLine);
        //    }
        //    sw.Close();
        //}

        List<Glasba> ImportAll()
        {
            List<Glasba> glasbe = new List<Glasba>();
            using (StreamReader sr = new StreamReader("data.csv"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] lines = line.Split(';');
                    glasbe.Add(new Glasba(lines[0], lines[1]));
                }
            }
            return glasbe;
        }

        public bool play = true;
        private void play_pause_Click(object sender, EventArgs e)
        {
            if (play)
            {
                Player.Play();
                play_pause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                play = false;
            } else
            {
                Player.Pause();
                play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                play = true;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private bool mousedown;
        private Point lastlocation;
        private void Bom_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            lastlocation = e.Location;
        }

        private void Bom_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Location = new Point((this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Bom_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        

        MediaPlayer Player = new MediaPlayer();
        private void prevBtn_Click(object sender, EventArgs e)
        {
            Player.Stop();
            if (igrazdaj > 0)
            {
                igrazdaj -= 1;
                title.Text = glasbe[igrazdaj].Naslov;
            }
            else
            {
                igrazdaj = 7;
                title.Text = glasbe[igrazdaj].Naslov;
            }
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
            Player.Play();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            Player.Stop();
            if (igrazdaj < 7)
            { 
                igrazdaj += 1;
                title.Text = glasbe[igrazdaj].Naslov;
            } else
            {
                igrazdaj = 0;
                title.Text = glasbe[igrazdaj].Naslov;
            }
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
            Player.Play();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void music1_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 0;
            title.Text = glasbe[0].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void music2_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 1;
            title.Text = glasbe[1].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 2;
            title.Text = glasbe[2].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 3;
            title.Text = glasbe[3].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 4;
            title.Text = glasbe[4].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 5;
            title.Text = glasbe[5].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 6;
            title.Text = glasbe[6].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Player.Stop();
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            play = true;
            igrazdaj = 7;
            title.Text = glasbe[7].Naslov;
            Player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + glasbe[igrazdaj].Datoteka));
        }

        public void SetVolume(int volume)
        {
            Player.Volume = volume / 100.0;
        }

        private void volumeBar_ValueChanged(object sender, EventArgs e)
        {
            SetVolume(volumeBar.Value * 10);
        }
    }
}
