using System;
using System.Drawing;
using System.Windows.Forms;

namespace kox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawKochCurve(g, 4, 200, 300, 800, 300);
        }

        private void DrawKochCurve(Graphics g, int depth, float x1, float y1, float x2, float y2)
        {
            if (depth == 0)
            {
                g.DrawLine(Pens.Black, x1, y1, x2, y2);
            }
            else
            {
                float deltaX = (x2 - x1) / 3;
                float deltaY = (y2 - y1) / 3;
                float xA = x1 + deltaX;
                float yA = y1 + deltaY;
                float xB = x2 - deltaX;
                float yB = y2 - deltaY;
                float xC = xA + deltaX * (float)Math.Cos(Math.PI / 3) - deltaY * (float)Math.Sin(Math.PI / 3);
                float yC = yA + deltaX * (float)Math.Sin(Math.PI / 3) + deltaY * (float)Math.Cos(Math.PI / 3);

                DrawKochCurve(g, depth - 1, x1, y1, xA, yA);
                DrawKochCurve(g, depth - 1, xA, yA, xC, yC);
                DrawKochCurve(g, depth - 1, xC, yC, xB, yB);
                DrawKochCurve(g, depth - 1, xB, yB, x2, y2);
            }
        }


    }
}
