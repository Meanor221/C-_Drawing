using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWENG421_Lab2Part2
{
    abstract class Shape
    {
        public abstract void drawColoredShape(Shape shape, Pen myPen, Graphics g, Point point1, Point point2);
    }
}
