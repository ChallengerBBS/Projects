using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nakov.TurtleGraphics;

namespace TurtleDraw
{
    public partial class FormDrawTurtle : Form
    {

        public FormDrawTurtle()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.Rotate(30);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(-30);
            Turtle.PenUp();
            Turtle.Backward(50);
            Turtle.PenDown();
            Turtle.Backward(100);
            Turtle.PenUp();
            Turtle.Forward(150);
            Turtle.Rotate(30);
            Turtle.PenDown();

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
        }

        private void buttonShowHideTurtle_Click(object sender, EventArgs e)
        {
            if (Turtle.ShowTurtle)
            {
                Turtle.ShowTurtle = false;
                this.buttonShowHideTurtle.Text = "Show turtle";
            }
            else
            {
                Turtle.ShowTurtle = true;
                this.buttonShowHideTurtle.Text = "Hide turtle";
            }
        }

        private void buttonDrawHexagon_Click(object sender, EventArgs e)
        {
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
        }

        private void buttonDrawStar_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Green;
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
        }

        private void buttonDrawSpiral_Click(object sender, EventArgs e)
        {
            int lenght = 20;
            for (int i = 1; i <= 20; i++)
            {
                
                Turtle.Forward(lenght);
                Turtle.Rotate(60);
                lenght += 5;
            }
        }

        private void buttonDrawSun_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <=36; i++)
            {
                Turtle.Rotate(5);
                Turtle.Forward(100);
                Turtle.Rotate(170);
                Turtle.Forward(150);
                Turtle.Rotate(-170);
            }
        }

        private void buttonDrawTriangle_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Red;
            int lenght = 20;
            for (int i = 1; i < 22; i++)
            {
                Turtle.Forward(lenght);
                Turtle.Rotate(120);
                
                lenght += 10;
            }
            Turtle.Rotate(120);
        }
    }
}
