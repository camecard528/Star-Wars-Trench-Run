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
/// Star Wars Trench Run 
/// Program showing the plans on how to destroy the death star
/// Cameron Cardiff November 2016    

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
            // getting graphics ready for the program, also sound resources. 
            // also starts the theme
            Graphics g = this.CreateGraphics(); 
            SolidBrush textBrush = new SolidBrush(Color.Yellow);
            Font scrollFont = new Font("Arial", 12, FontStyle.Bold);
            Font numFont = new Font("Arial", 18, FontStyle.Bold);
            Pen starPen = new Pen(Color.White);
            SoundPlayer theme = new SoundPlayer(Properties.Resources.starwars);
            SoundPlayer imperial = new SoundPlayer(Properties.Resources.imperial);
            SoundPlayer explosion = new SoundPlayer(Properties.Resources.explosion);
            theme.Play();
            label1.Visible = false;
            //for loop that makes the opening text scroll up
            for (int y = 400; y >= -240; y = y - 2)
            {
                g.DrawString("Rebel spies managed to steal secret plans to the Empire's ultimate", scrollFont, textBrush, 35, y);
                g.DrawString("weapon, the Death Star an armored space station with enough", scrollFont, textBrush, 35, y + 15);
                g.DrawString("power to destroy an entire planet.", scrollFont, textBrush, 35, y + 30);

                g.DrawString("These plans that the brave rebels have stole are going are ", scrollFont, textBrush, 35, y + 60);
                g.DrawString("to be relayed to your location in", scrollFont, textBrush, 35, y + 75);
                g.DrawString("5", numFont, textBrush, 295, y + 105);
                g.DrawString("4", numFont, textBrush, 295, y + 135);
                g.DrawString("3", numFont, textBrush, 295, y + 165);
                g.DrawString("2", numFont, textBrush, 295, y + 195);
                g.DrawString("1", numFont, textBrush, 295, y + 225);
                Thread.Sleep(15);
                g.Clear(Color.Black);
            }
            // draws creates a brush for the x-wing and stops the theme
            theme.Stop();
            g.Clear(Color.Black);
            Thread.Sleep(500);
            SolidBrush shipBrush = new SolidBrush(Color.White);

            // for loop drawing the starting angle of the x-wing + death star
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
            //creates a bomb variable and a size, and s variable
            int bomb = 40;
            int s = 1;
            int size = randgen.Next(25, 50);
            SolidBrush explosionBrush = new SolidBrush(Color.Red);

            //for loop that draws the xwing flying away from the death star and 
            //dropping a bomb to the reactor core. 
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
                //if statment when the xwing crosses point 290 stays between 150 
                // it drops the bomb
                if (x <= 290 && x >= 150) 
                {
                    explosion.Play();
                    bomb++;
                    g.FillEllipse(shipBrush, 290, bomb, 7, 7);
                }
                //this if statment starts the reactor exploading and creates 
                //the drawing for it and explosion 
                if(x == 150)
                {
                    explosion.Play();
                }
                if (x < 149)
                {
                    s = s + 4;
                    g.FillEllipse(explosionBrush, 290 - s/2, 150 -s/2, size + s, size + s);
                }
                Thread.Sleep(10);
            }
            //clears the screen and plays the imperial march
            g.Clear(Color.Black);
            imperial.Play();
            g.DrawString("Now that you've seen the plans get ready for the real thing pilot", scrollFont, textBrush, 35, 50);



        }

    }
}
