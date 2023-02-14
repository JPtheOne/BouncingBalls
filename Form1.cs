
using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;


namespace WindowsApplication1
{
	public partial class Form1
	{
		public Form1()
		{
			InitializeComponent();
		
		}
		
#region Default Instance
		
		private static Form1 defaultInstance;
		
		public static Form1 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form1();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		
		private int ball_Size = 8;  
		private int move_Size = 4;  
		private Bitmap bmp;
		private int ball_PositionX;
		private int ball_PositionY;
		private int ball_RadiusX;
		private int ball_RadiusY;
		private int ball_MoveX;
		private int ball_MoveY;
		private int ball_BitmapWidth;
		private int ball_BitmapHeight;
		private int bitmap_WidthMargin;
		private int bitmap_HeightMargin;
		
		
		public void Form1_Load(System.Object sender, System.EventArgs e)
		{
			Timer1.Start();
		}
		
		public void Timer1_Tick(System.Object sender, System.EventArgs e) //Ball bouncing with timer
        {
			
 			Graphics g = CreateGraphics();
			//Draw Ball
			g.DrawImage(bmp, (int) (ball_PositionX - ball_BitmapWidth / 2), (int) (ball_PositionY - ball_BitmapHeight / 2), ball_BitmapWidth, ball_BitmapHeight);
			
			g.Dispose();
			
 			// Increment the position in x and y
			ball_PositionX += ball_MoveX;
			ball_PositionY += ball_MoveY;

            //Move to the other direction whenever boundaries are hit in x
            if (ball_PositionX + ball_RadiusX >= ClientSize.Width | ball_PositionX - ball_RadiusX <= 0)
			{
				ball_MoveX = System.Convert.ToInt32(- ball_MoveX);
 			}
            //Move to the other direction whenever boundaries are hit in y
            if (ball_PositionY + ball_RadiusY >= ClientSize.Height | ball_PositionY - ball_RadiusY <= 90)
			{
				ball_MoveY = System.Convert.ToInt32(- ball_MoveY);
 			}
		} 
		
		protected override void OnResize(EventArgs ev_arg)
		{
			
			
			Graphics g = CreateGraphics();
 			g.Clear(BackColor);
			
			
			// Declare the radius of the ball and it's set to a fraction of width and height
			double dbl_Radius = Math.Min(ClientSize.Width / g.DpiX, ClientSize.Height / g.DpiY) / ball_Size;
			
			
			//calculate height and weight
			ball_RadiusX = (int) (dbl_Radius * g.DpiX);
			ball_RadiusY = (int) (dbl_Radius * g.DpiY);
			
			g.Dispose();
 			
			
			ball_MoveX = (int) (Math.Max(1, ball_RadiusX / move_Size));
			ball_MoveY = (int) (Math.Max(1, ball_RadiusY / move_Size));
 			
			bitmap_WidthMargin = ball_MoveX;
			bitmap_HeightMargin = ball_MoveY;
			
 			ball_BitmapWidth = 2 * (ball_RadiusX + bitmap_WidthMargin);
			ball_BitmapHeight = 2 * (ball_RadiusY + bitmap_HeightMargin);
			
 			bmp = new Bitmap(ball_BitmapWidth, ball_BitmapHeight);
 			g = Graphics.FromImage(bmp);

 			g.Clear(BackColor);
			g.FillEllipse(Brushes.Green, new Rectangle(ball_MoveX, ball_MoveY, System.Convert.ToInt32(2 * ball_RadiusX), System.Convert.ToInt32(2 * ball_RadiusY)));
			g.Dispose();
			
			//send to the center
 			ball_PositionX = (int) (ClientSize.Width / 2);
			ball_PositionY = (int) (ClientSize.Height/2);
			
			
		}

        public void timer2_Tick(System.Object sender, System.EventArgs e) //Ball bouncing with timer
        {

            Graphics g = CreateGraphics();
            //Draw Ball
            g.DrawImage(bmp, (int)(ball_PositionX - ball_BitmapWidth / 2), (int)(ball_PositionY - ball_BitmapHeight / 2), ball_BitmapWidth, ball_BitmapHeight);

            g.Dispose();

            // Increment the position in x and y
            ball_PositionX += ball_MoveX;
            ball_PositionY += ball_MoveY;

            //Move to the other direction whenever boundaries are hit in x
            if (ball_PositionX + ball_RadiusX >= ClientSize.Width | ball_PositionX - ball_RadiusX <= 0)
            {
                ball_MoveX = System.Convert.ToInt32(-ball_MoveX);
            }
            //Move to the other direction whenever boundaries are hit in y
            if (ball_PositionY + ball_RadiusY >= ClientSize.Height | ball_PositionY - ball_RadiusY <= 90)
            {
                ball_MoveY = System.Convert.ToInt32(-ball_MoveY);
            }
        }




    }
	
}
