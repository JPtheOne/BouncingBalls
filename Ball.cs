using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CollidingBalls
{
    public class Ball
    {
        //Ball attributes
        public int size, speed, direction, x, y;
        private Color color;
        
        //Constructor of each ball
        public Ball(int size, int speed, int direction, int x, int y, Color color)
        {
            this.size = size;
            this.speed = speed;
            this.direction = direction;
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public void MoveBall(int Width, int Height)
        {
            double radians = direction * Math.PI / 180;
            int deltaX = (int)(speed * Math.Cos(radians));
            int deltaY = (int)(speed * Math.Sin(radians));
            int newX = x + deltaX;
            int newY = y + deltaY;

            if (newX < 0 || newX > Width - size)
            {
                //If the ball hits a horizontal wall, reverse its x direction.
                direction = 180 - direction;
                newX = x - deltaX;
            }

            if (newY < 0 || newY > Height - size)
            {
                //If the ball hits a vertical wall, reverse its y direction.
                direction = -direction;
                newY = y - deltaY;
            }

            x = newX;
            y = newY;
        }

        public void DrawBall(Graphics g)//Draws the ball
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, size, size);
        }

        public Rectangle Bounds//bounds for collision
        {
            get { return new Rectangle(x, y, size, size); }
        }



    }
}
