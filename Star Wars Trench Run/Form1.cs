using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Star_Wars_Trench_Run
{
    public partial class Form1 : Form
    {  Random randgen = new Random();
        Random randgen2 = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush textBrush = new SolidBrush(Color.Yellow);
            Font textFont = new Font("Arial", 12, FontStyle.Bold);
            Font textFont2 = new Font("Arial", 18, FontStyle.Bold);
            Pen starPen = new Pen(Color.White);
            SoundPlayer theme = new SoundPlayer(Properties.Resources.starwars);
            SoundPlayer imperial = new SoundPlayer(Properties.Resources.imperial);

            for (int y = 400; y < this.Height && y >= -240; y = y - 2)
            {
                label1.Visible = false;
                theme.Play();
                g.DrawString("Rebel spies managed to steal secret plans to the Empire's ultimate", textFont, textBrush, 35, y);
                g.DrawString("weapon, the Death Star an armored space station with enough", textFont, textBrush, 35, y + 15);
                g.DrawString("power to destroy an entire planet.", textFont, textBrush, 35, y + 30);

                g.DrawString("These plans that the brave rebels have stole are going are ", textFont, textBrush, 35, y + 60);
                g.DrawString("to be relayed to your location in", textFont, textBrush, 35, y + 75);
                g.DrawString("5", textFont2, textBrush, 295, y + 105);
                g.DrawString("4", textFont2, textBrush, 295, y + 135);
                g.DrawString("3", textFont2, textBrush, 295, y + 165);
                g.DrawString("2", textFont2, textBrush, 295, y + 195);
                g.DrawString("1", textFont2, textBrush, 295, y + 225);
                Thread.Sleep(15);
                g.Clear(Color.Black);
            }
            g.Clear(Color.Black);
            Thread.Sleep(500);
            g.DrawEllipse(starPen, 165, 50, 250, 250);
            g.DrawEllipse(starPen, 222, 115, 30, 30);
            g.DrawEllipse(starPen, 232, 127, 7, 7);
            g.DrawLine(starPen, 165, 180, 415, 180);
            g.DrawLine(starPen, 290, 50, 290, 180);
            g.DrawRectangle(starPen, 282, 180, 20, 20);
            SolidBrush shipBrush = new SolidBrush(Color.White);


            for (int i = 0; i < 40; i++)
            {
                g.DrawEllipse(starPen, 165, 50, 250, 250);
                g.DrawEllipse(starPen, 222, 115, 30, 30);
                g.DrawEllipse(starPen, 232, 127, 7, 7);
                g.DrawLine(starPen, 165, 180, 415, 180);
                g.DrawLine(starPen, 290, 50, 290, 180);
                g.DrawRectangle(starPen, 282, 180, 20, 20);
                g.FillRectangle(shipBrush, 407 - i, 0 + i, 20, 10);
                Thread.Sleep(10);
                g.Clear(Color.Black);


            }
            int bomb = 40;
            int s = 1;
            int size = randgen.Next(25, 50);
            SolidBrush starBrush2 = new SolidBrush(Color.Red);

            //randgen2.Next(50 - 165);


            for (int x = 367; x > 0; x--)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(starPen, 165, 50, 250, 250);
                g.DrawEllipse(starPen, 222, 115, 30, 30);
                g.DrawEllipse(starPen, 232, 127, 7, 7);
                g.DrawLine(starPen, 165, 180, 415, 180);
                g.DrawLine(starPen, 290, 50, 290, 180);
                g.DrawRectangle(starPen, 282, 180, 20, 20);
                g.DrawLine(starPen, 300, 300, 300, 300);
                g.FillRectangle(shipBrush, x, 40, 20, 10);

                if (x <= 290 && x >= 150) 
                {
                    bomb++;
                    g.FillEllipse(shipBrush, 290, bomb, 7, 7);
                }
                if (x < 150)
                {
                    s = s + 4;
                    g.FillEllipse(starBrush2, 290 - s/2, 150 -s/2, size + s, size + s);
                }

                Thread.Sleep(10);

            }
            g.Clear(Color.Black);
            imperial.Play();
            g.DrawString("Now that you've seen the plans get ready for the real thing pilot", textFont, textBrush, 35, 50);



        }

    }
}
