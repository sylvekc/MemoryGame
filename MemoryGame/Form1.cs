using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace MemoryGame

{
    public partial class Form1 : Form
    {
        string[] cards = { @"img\yellow.bmp",
                           @"img\grey.bmp",
                           @"img\red.bmp",
                           @"img\green.bmp",
                           @"img\purple.bmp",
                           @"img\blue.bmp",
                           @"img\yellow.bmp",
                           @"img\grey.bmp",
                           @"img\red.bmp",
                           @"img\green.bmp",
                           @"img\purple.bmp",
                           @"img\blue.bmp",
                           };

        bool odkrytaPierwszaKarta = false;
        int pierwszaKartaNumer;
        int licznik = 0;
        bool block = false;
        int ilePar = 6;



        public Form1()
        {
            InitializeComponent();
            Ostatnie3gryOdczyt();
            Rekord();
            label1.Text = "Licznik tur: " + licznik;
            var rng = new Random();
            rng.Shuffle(cards);
            pictureBox1.Image = Image.FromFile(@"img\card.bmp");
            pictureBox2.Image = Image.FromFile(@"img\card.bmp");
            pictureBox3.Image = Image.FromFile(@"img\card.bmp");
            pictureBox4.Image = Image.FromFile(@"img\card.bmp");
            pictureBox5.Image = Image.FromFile(@"img\card.bmp");
            pictureBox6.Image = Image.FromFile(@"img\card.bmp");
            pictureBox7.Image = Image.FromFile(@"img\card.bmp");
            pictureBox8.Image = Image.FromFile(@"img\card.bmp");
            pictureBox9.Image = Image.FromFile(@"img\card.bmp");
            pictureBox10.Image = Image.FromFile(@"img\card.bmp");
            pictureBox11.Image = Image.FromFile(@"img\card.bmp");
            pictureBox12.Image = Image.FromFile(@"img\card.bmp");
            BackgroundImage = Image.FromFile(@"img\BackGround.jpg");


        }
        #region Clicki obrazków
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            playRevealSound();
            revealCard(12);
        }
        #endregion 

        public void revealCard(int nr)
        {
            List<PictureBox> pictureBox = new List<PictureBox>();
            pictureBox.Add(pictureBox1);
            pictureBox.Add(pictureBox2);
            pictureBox.Add(pictureBox3);
            pictureBox.Add(pictureBox4);
            pictureBox.Add(pictureBox5);
            pictureBox.Add(pictureBox6);
            pictureBox.Add(pictureBox7);
            pictureBox.Add(pictureBox8);
            pictureBox.Add(pictureBox9);
            pictureBox.Add(pictureBox10);
            pictureBox.Add(pictureBox11);
            pictureBox.Add(pictureBox12);
            pictureBox[nr - 1].Image = Image.FromFile(cards[nr - 1]);

            if (odkrytaPierwszaKarta == false && block == false)
            {
                odkrytaPierwszaKarta = true;
                pierwszaKartaNumer = nr - 1;
                block = true;
                pictureBox[nr - 1].Enabled = false;
            }
            else
            {
                if (odkrytaPierwszaKarta == true && cards[nr - 1] == cards[pierwszaKartaNumer])
                {
                    playSuccesSound();
                    Task.Delay(700).Wait();
                    pictureBox[nr - 1].Visible = false;
                    pictureBox[pierwszaKartaNumer].Visible = false;
                    odkrytaPierwszaKarta = false;
                    licznik++;
                    label1.Text = "Licznik tur: " + licznik;
                    ilePar--;
                    block = false;
                    if (ilePar == 0)
                    {
                        playWinSound();
                        Ostatnie3gryZapis();
                        DialogResult drr1 = MessageBox.Show("Wygrałeś! Chcesz zagrać jeszcze raz?", "Wygrana po " + licznik + " turach!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (drr1 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        if (drr1 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    Task.Delay(700).Wait();
                    pictureBox[nr - 1].Image = Image.FromFile(@"img\card.bmp");
                    pictureBox[pierwszaKartaNumer].Image = Image.FromFile(@"img\card.bmp");
                    odkrytaPierwszaKarta = false;
                    licznik++;
                    label1.Text = "Licznik tur: " + licznik;
                    block = false;
                    pictureBox[pierwszaKartaNumer].Enabled = true;

                }

            }

        }
        private void playRevealSound()
        {
            SoundPlayer RevealSound = new SoundPlayer(@"snd\reveal.wav");
            RevealSound.Play();
        }
        private void playSuccesSound()
        {
            SoundPlayer SuccesSound = new SoundPlayer(@"snd\succes.wav");
            SuccesSound.Play();
        }
        private void playWinSound()
        {
            SoundPlayer WinSound = new SoundPlayer(@"snd\win.wav");
            WinSound.Play();
        }

        private void Ostatnie3gryZapis()
        {
            string path = @"Ostatnie3gry.txt";
            StreamWriter sw;
            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = new StreamWriter(path, true);

            }
            sw.WriteLine(licznik);
            sw.Close();
        }

        private void Ostatnie3gryOdczyt()
        {
            string path = @"Ostatnie3gry.txt";
            StreamReader sr = File.OpenText(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            int ostatniaGra = lines.Count();
            sr.Close();
            label3.Text = lines[ostatniaGra - 1];
            label4.Text = lines[ostatniaGra - 2];
            label5.Text = lines[ostatniaGra - 3];
        }

        private void Rekord()
        {
            string path = @"Ostatnie3gry.txt";
            StreamReader sr = File.OpenText(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            int rekord = Int32.Parse(lines.Min());
            int ostatniaGra = lines.Count();
            if (Int32.Parse(lines[ostatniaGra - 1]) < rekord)
                label6.Text = lines[ostatniaGra - 1];
            else
                label6.Text = rekord.ToString();
            sr.Close();
        }







    }



}





