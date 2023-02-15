using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Ball //Creating ball class with attributes
    {
        public int radius;
        public Point centrum;
        public Point speed;
 


        public Ball(int radius, Point centrum, Point speed)
        {
            this.radius = radius;
            this.centrum = centrum;
            this.speed = speed;
        }


        public void MovePosition(Rectangle bounds, List <Ball> balls) //Move the ball to new point
        {
            this.centrum.Offset(this.speed); //Translates the old point centrum to the new point speed

            if (this.centrum.X <= bounds.Left || this.radius<= bounds.Right)
            {
                this.speed.X = -this.speed.X; //If the centrum of the ball
            }

            if (this.centrum.Y <= bounds.Top || this.centrum.Y + this.radius >= bounds.Bottom)

            {
                this.speed.Y = -this.speed.Y;
            }

            //Check if ball collide with another one
            foreach (var other in balls)
                if (other != this && CheckCollision(this, other))
                    ResolveCollision(this, other);
        }

        private static bool CheckCollision(Ball a, Ball b)
        {
            int dx = a.centrum.X - b.centrum.X;
            int dy = a.centrum.Y- b.centrum.Y;
            int distance = a.radius/2 + b.radius/2;
            return (dx * dx + dy * dy) < (distance * distance);

        }

        private static void ResolveCollision(Ball a, Ball b)
        {
            int dx = b.centrum.X - a.centrum.X;
            int dy = b.centrum.Y - a.centrum.Y;
            int distance = a.radius / 2 + b.radius / 2;
            int overlap = distance - (int)Math.Sqrt(dx * dx + dy * dy);

            //Balls are translated if they collide with each other
            a.centrum.Offset(-overlap * dx / distance, -overlap * dy / distance);
            b.centrum.Offset(overlap * dx / distance, overlap * dy / distance);

            // These formulas of new velocities were obviously seen in class
            int totalMass = a.radius / 2 + b.radius / 2;
            int aSpeed = (a.speed.X * dx + a.speed.Y * dy) / totalMass;
            int bSpeed = (b.speed.X * dx + b.speed.Y * dy) / totalMass;
            a.speed.Offset((bSpeed - aSpeed) * dx / distance, (bSpeed - aSpeed) * dy / distance);
            b.speed.Offset((aSpeed - bSpeed) * dx / distance, (aSpeed - bSpeed) * dy / distance);
        }

        

    }

    

   
}
