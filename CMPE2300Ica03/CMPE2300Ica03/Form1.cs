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
            listyBalls1.Add(new Ball((PointF)pos,rnd.NextDouble() * 10 -5), (int)rnd.Next(20-50))));
        }
        private void Canvas2_MouseLeftClick(Point pos, CDrawer dr)
        {
            
        }
    }
}
