using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SWENG421_Lab2Part2
{
    class Line : Shape
    {
        public override void drawColoredShape(Shape shape, Pen myPen, Graphics g, Point point1, Point point2)
        {
            g.DrawLine(myPen, (int)point1.X, (int)point1.Y, (int)point2.X, (int)point2.Y);
            g.Dispose();
        }
    }
}
