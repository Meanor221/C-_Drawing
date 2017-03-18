using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWENG421_Lab2Part2
{
    public partial class Paint : Form
    {
        private Shape   currentShape;
        private Color   currentColor;
        private Bitmap  background;
        private Bitmap  foreground;
        private Point   firstPoint;
        private Point   secondPoint;
        private Pen     myPen;
        private Graphics g;

        public Paint()
        {
            InitializeComponent();
            foreground = new Bitmap(canvas.Width, canvas.Height);
            background = new Bitmap(canvas.Width, canvas.Height);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            currentShape = new Line();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            currentShape = new Rectangle();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            currentShape = new Ellipse();
        }

        private void createPen()
        {
            colorDisplay.BackColor = Color.FromArgb(red.Value, green.Value, blue.Value);
            myPen = new Pen(Color.FromArgb(red.Value, green.Value, blue.Value));
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                firstPoint = new Point(e.X, e.Y);
                createPen();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreground.Dispose();
                foreground = new Bitmap(background);
                g = Graphics.FromImage(foreground);
                secondPoint = new Point(e.X, e.Y);
                if (currentShape == null)
                {
                    System.Windows.Forms.MessageBox.Show("A shape was not selected.");
                    return;
                }
                currentShape.drawColoredShape(currentShape, myPen, g, firstPoint, secondPoint);
                g = canvas.CreateGraphics();
                g.Clear(canvas.BackColor);
                g.DrawImage(foreground, 0, 0);
                g.Dispose();
            }
            
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            background.Dispose();
            background = new Bitmap(foreground);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = canvas.CreateGraphics();
            g.Clear(canvas.BackColor);
            g.DrawImage(foreground, 0, 0);
            g.Dispose();
        }

        /**
         * <summary>
         * 
         * </summary>
         * 
         * <param name="e">
         * 
         * </param>
         * 
         * <
         */
        private void canvas_Resize(object sender, EventArgs e)
        {
            background.Dispose();
            background = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(background);
            g.DrawImage(foreground, 0, 0);
            foreground.Dispose();
            foreground = new Bitmap(background);
        }

        private void green_ValueChanged(object sender, EventArgs e)
        {
            createPen();
        }

        private void blue_ValueChanged(object sender, EventArgs e)
        {
            createPen();
        }

        private void red_ValueChanged(object sender, EventArgs e)
        {
            createPen();
        }
        
    }
}
