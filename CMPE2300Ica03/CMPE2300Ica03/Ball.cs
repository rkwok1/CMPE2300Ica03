using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;


namespace CMPE2300Ica03
{
    public class Ball
    {
        /************************Variables****************************/
        private PointF position;
        private PointF direction; //Speed is consistent between -5 so direction
        private float radius;
        private const int heightDrawer=600; //height of drawing canvas
        private const int widthDrawer=400; //width of drawing canvas
        private int equalCalls; //Counter to hold the number of times equals returned true

        /*************************Properties**************************/
         public bool highlightFlag { set; private get; }

        /*************************Constructor*************************/
        
        public Ball(PointF m_position, PointF m_direction, int m_radius)//Initializes all class members 
        {
            position = m_position;
            direction = m_direction;
            radius = m_radius;
        }

        /***************************Methods****************************/

        /************************************************************************
         * Method: GetDistance()
         * Description: Measures the distance between two balls provided using 
         *              pythagorean theorem and resturns this value as a float
         ************************************************************************/
        public static float GetDistance(Ball ballOne, Ball ballTwo) 
        {
            float distance = (float)(Math.Sqrt(Math.Pow((ballTwo.position.X - ballOne.position.X), 2) + Math.Pow((ballTwo.position.Y - ballOne.position.Y), 2)));
            return distance;
        }

        /*************************************************************************
         * Method: Move()
         * Description: Moves balls. adjusts the position by the direction.If the
         *              ball moves out of bounds of the window, returns it to the
         *              edge of bounds by flipping signs.
         **************************************************************************/
         public void Move()
        {
            //moved position is determined by  current position plus the speed(-5 t0 5) and direction(+/-)
            position.X = position.X + direction.X; 
            position.Y = position.Y + direction.Y;

            //Checking ball is within boundaries
            direction.X = position.X + radius > 400 ? -direction.X : direction.X; //If greater 400 for x position, switch sign for direction
            direction.X = position.X + radius < 0 ? direction.X : -direction.X;
            direction.Y = position.Y + radius> 600 ? -direction.Y : direction.Y;
            direction.Y = position.Y + radius < 0 ? direction.Y : -direction.Y;

            //may need a line here
        }

        /***************************************************************************
         * Method: Render()
         * Description: Accepts a CDrawer object reference and will render a ball.
         *              Wil make it yellow if highlighted. Otherwise make it dark
         *              cyan.
         ***************************************************************************/
         public void Render(CDrawer canvas)
        {
            if (highlightFlag)
            {
                canvas.AddCenteredEllipse(new Point((int)position.X, (int)position.Y), (int)radius * 2, (int)radius * 2, Color.Yellow, 1, Color.White);
                canvas.AddText(equalCalls.ToString(), 10, (int)position.X, (int)position.Y, (int)radius * 2, (int)radius * 2, Color.Black);
            }
            else
            {
                canvas.AddCenteredEllipse(new Point((int)position.X, (int)position.Y), (int)radius * 2, (int)radius * 2, Color.DarkCyan, 1, Color.White);
                canvas.AddText(equalCalls.ToString(), 10, (int)position.X, (int)position.Y, (int)radius * 2, (int)radius * 2, Color.Black);
            }
        }

        /**********************************Override*******************************/
        public override bool Equals(object obj)
        {
            //If object compared isn't a ball return false
            if (!(obj is Ball))
                return false;

            //makes a copy ball if we need to manipulate it
            Ball copyBall = (Ball)obj;

            if (GetDistance(this, copyBall) < (radius) + (copyBall.radius))
            {
                equalCalls++;
                highlightFlag = true;
                return true; //Returns true if balls overlap.

            }
            else
            {
                highlightFlag = false;
                return false;
            }
            
        }

        //Get Hash code ovveride must be present after overriding equals
        public override int GetHashCode()
        {
            return 1;
        }




    }
}
