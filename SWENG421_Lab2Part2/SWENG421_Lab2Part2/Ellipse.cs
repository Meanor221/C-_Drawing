using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SWENG421_Lab2Part2
{
    class Ellipse : Shape
    {
        public override void drawColoredShape(Shape shape, Pen myPen, Graphics g, Point point1, Point point2)
        {
            int startx, starty;

            if (point1.X <= point2.X)
                startx = point1.X;
            else
                startx = point2.X;

            if (point1.Y <= point2.Y)
                starty = point1.Y;
            else
                starty = point2.Y;

            g.DrawEllipse(myPen, startx, starty, Math.Abs((int)point2.X - (int)point1.X), Math.Abs((int)point2.Y - (int)point1.Y));
            g.Dispose();
        }
    }
}
