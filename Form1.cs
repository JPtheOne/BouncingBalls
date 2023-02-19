using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollidingBalls
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Ball b1;

        Timer timer;
        List<Ball> balls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;


            timer1 = new Timer();
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            timer1.Start();


            //Ball1 random parameters
            var rSize = new Random();//random size
            var sz1 = rSize.Next(0,130);

            var rSpeed = new Random();// random speed
            var sp1 = rSpeed.Next(0, 10);

            var rDirection = new Random();// random direction
            var d1 = rDirection.Next(0, 360);

            balls.Add(new Ball(sz1, sp1, d1, 100, 10, Color.Red));

            //Ball2 random parameters
            var r2Size = new Random();//random size
            var sz2 = rSize.Next(0, 130);

            var r2Speed = new Random();// random speed
            var sp2 = rSpeed.Next(0, 10);

            var r2Direction = new Random();// random direction
            var d2 = rDirection.Next(0, 360);

            balls.Add(new Ball(sz2, sp2, d2, 10, 10, Color.Yellow));

            //Ball3 random parameters
            var r3Size = new Random();//random size
            var sz3 = rSize.Next(0, 130);

            var r3Speed = new Random();// random speed
            var sp3 = rSpeed.Next(0, 10);

            var r3Direction = new Random();// random direction
            var d3 = rDirection.Next(0, 360);

            balls.Add(new Ball(sz3, sp3, d3, 200, 10, Color.Green));


            //Ball4 random parameters
            var r4Size = new Random();//random size
            var sz4 = rSize.Next(0, 130);

            var r4Speed = new Random();// random speed
            var sp4 = rSpeed.Next(0, 10);

            var r4Direction = new Random();// random direction
            var d4 = rDirection.Next(0, 360);

            balls.Add(new Ball(sz4, sp4, d4, 250, 10, Color.Blue));


            //Ball5 random parameters
            var r5Size = new Random();//random size
            var sz5 = rSize.Next(0, 130);

            var r5Speed = new Random();// random speed
            var sp5 = rSpeed.Next(0, 10);

            var r5Direction = new Random();// random direction
            var d5 = rDirection.Next(0, 360);

            balls.Add(new Ball(sz5, sp5, d5, 300, 10, Color.Orange));


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            var rDirec = new Random();
            var lowerBound = 0;
            var upperBound = 360;
            var rD = rDirec.Next(lowerBound, upperBound);


            for (int i = 0; i < balls.Count; i++)// ball is drawn and moves based on the number of elements in the list
            {

                balls[i].DrawBall(g);
                balls[i].MoveBall(pictureBox1.Width, pictureBox1.Height);

                for (int j = i + 1; j < balls.Count; j++)//Start of collision
                {

                    if (balls[i].Bounds.IntersectsWith(balls[j].Bounds))
                    {
                        double distance = Math.Sqrt(Math.Pow(balls[i].Bounds.X - balls[j].Bounds.X, 2) + Math.Pow(balls[i].Bounds.Y - balls[j].Bounds.Y, 2));

                        if (distance <= balls[i].Bounds.Width / 2 + balls[j].Bounds.Width / 2)
                        {

                            //collision is ocurring
                            balls[i].direction = rD - balls[i].direction;
                            balls[j].direction = rD - balls[j].direction;
                        }


                    }


                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }
    }
}
