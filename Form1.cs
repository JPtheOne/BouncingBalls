using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBalls
{
    public partial class Form1 : Form
    {
        Ball b;
        Graphics g;
        Bitmap bmp;
        List<Ball> balls;
        Rectangle bounds;
        int radius = 40;
        int speedX = 5;
        int speedY = 5;
        Random random = new Random();


        Point centrum, speed;

        public Form1()
        {
            InitializeComponent();
             
         
            balls = new List<Ball>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            centrum = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            bounds = new Rectangle(new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);

            speedX = random.Next(-10, 11);
            speedY = random.Next(-10, 11);
            speed = new Point(speedX, speedY);
            b = new Ball(radius, centrum, speed);
            balls.Add(b);

            speedX = random.Next(-10, 11);
            speedY = random.Next(-10, 11);
            speed = new Point(speedX, speedY);
            centrum = new Point(pictureBox1.Width / 2 + 50, pictureBox1.Height / 2 - 15);
            b = new Ball(radius + 5, centrum, speed);
            balls.Add(b);

            speedX = random.Next(-10, 11);
            speedY = random.Next(-10, 11);
            speed = new Point(speedX, speedY);
            centrum = new Point(pictureBox1.Width / 2 - 50, pictureBox1.Height / 2 + 20);
            b = new Ball(radius + 10, centrum, speed);
            balls.Add(b);

            speedX = random.Next(-10, 11);
            speedY = random.Next(-10, 11);
            speed = new Point(speedX, speedY);
            centrum = new Point(pictureBox1.Width / 2 + 20, pictureBox1.Height / 2 - 40);
            b = new Ball(radius + 15, centrum, speed);
            balls.Add(b);

            speedX = random.Next(-10, 11);
            speedY = random.Next(-10, 11);
            speed = new Point(speedX, speedY);
            centrum = new Point(pictureBox1.Width / 2 - 70, pictureBox1.Height / 2 - 30);
            b = new Ball(radius - 5, centrum, speed);
            balls.Add(b);
        }



        public void Render()
        {
            g.Clear(Color.Black);
            for (int i = 0; i < balls.Count; i++)
            {
                g.FillEllipse(Brushes.Yellow, balls[i].centrum.X, balls[i].centrum.Y, balls[i].radius, balls[i].radius);
            }

            pictureBox1.Invalidate();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < balls.Count; i++)
                balls[i].MovePosition(bounds, balls);
            Render();
        }
    }
}
