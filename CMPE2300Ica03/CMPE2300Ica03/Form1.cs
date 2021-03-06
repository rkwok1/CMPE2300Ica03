﻿using System;
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
    
    public partial class MyFirstEquals : Form
    {
        /*********************Variables******************************/
        private static CDrawer canvas1 = new CDrawer(400, 600, false);
        private static CDrawer canvas2 = new CDrawer(400, 600, false);
        private static Random rnd = new Random();
        private List<Ball> listyBalls1 = new List<Ball>();
        private List<Ball> listyBalls2 = new List<Ball>();

        public MyFirstEquals()
        {
            InitializeComponent();
            canvas1.Position = new Point(800, 300);
            canvas2.Position = new Point(1210, 300);
            canvas1.MouseLeftClick += Canvas1_MouseLeftClick;
            canvas2.MouseLeftClick += Canvas2_MouseLeftClick;
        }

        /**********************MouseClickSubscriptions***************************/
        private void Canvas1_MouseLeftClick(Point pos, CDrawer dr)
        {
            PointF holder = new PointF((float)(rnd.NextDouble() * 10 - 5), (float)(rnd.NextDouble() * 10 - 5));
            listyBalls1.Add(new Ball(pos, holder, rnd.Next(10,26)));

        }
        private void Canvas2_MouseLeftClick(Point pos, CDrawer dr)
        {
            PointF holder = new PointF((float)(rnd.NextDouble() * 10 - 5), (float)(rnd.NextDouble() * 10 - 5));
            listyBalls2.Add(new Ball(pos, holder, rnd.Next(10,26)));//diameter not radius wanted
        }

        private void UI_timer_Tick(object sender, EventArgs e)
        {
            List<Ball> listyMiddle = new List<Ball>();
            //Move function for left drawer
            lock (listyBalls1)
            {
                foreach (Ball ball in listyBalls1)
                {
                    ball.Move();
                }
                //Compares all balls in a list in left window
                foreach (Ball A in listyBalls1)
                {
                    foreach (Ball B in listyBalls1)
                    {
                        if (!(Ball.ReferenceEquals(A, B))) //Do NOT Compare to self
                        {
                            if (A.Equals(B)) //If the balls overlap then add to a temporary list 
                            {
                                listyMiddle.Add(A);
                            }
                        }
                    }
                }
            }
            lock (listyMiddle)
            {
                foreach (Ball item in listyMiddle)
                {
                    listyBalls1.Remove(item); //remove balls that have touched
                }
                foreach (Ball item in listyMiddle)
                {
                    listyBalls2.Add(item);
                }
            }
            //Clear lef drawer and move the balls and render the left drawer
            canvas1.Clear();
            lock (listyBalls1)
            {
                foreach (Ball ball in listyBalls1)
                {
                    ball.Render(canvas1);
                }
            }
            canvas1.AddText("Left Count: " + listyBalls1.Count, 15, 75, 550, 200, 30, Color.LawnGreen);
            canvas1.Render();

            //Move the right list
            lock (listyBalls2)
            {
                foreach (Ball item in listyBalls2)
                {
                    item.Move();
                    item.highlightFlag = false;
                    foreach (Ball b1 in listyBalls2)
                    {
                        foreach (Ball b2 in listyBalls2)
                        {
                            if (!(Ball.ReferenceEquals(b1, b2)))
                            {
                                if (b1.Equals(b2))
                                {
                                    b1.highlightFlag = true;
                                }
                            }
                        }
                    }
                }

                canvas2.Clear();
                foreach (Ball ball in listyBalls2)
                {
                    ball.Render(canvas2);
                }
            }
            canvas2.AddText("Right Count: " + listyBalls2.Count, 15, 75, 550, 200, 30, Color.LawnGreen);
            canvas2.Render();
        }

    }
}
