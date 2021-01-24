using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace змейка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            snake = new Point[10000];
            int wight = pictureBox1.Width / 10;
            int height = pictureBox1.Height / 10;
            snake[0].X = wight / 2;
            snake[0].Y = wight / 2;
            b = new SolidBrush(Color.White);
            greenBrush = new SolidBrush(Color.Green);

        }

        Point[] snake;
        string direction = "up";
        int len = 1;
        SolidBrush b;
        SolidBrush greenBrush;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.FillRectangle(b, 0, 0, pictureBox1.Width, pictureBox1.Height);

            for (int i = 0; i < len; i++)
            {
                g.FillEllipse(greenBrush, snake[i].X*10, snake[i].Y*10,10,10);
                if (direction == "up") snake[i].Y -= 1;
                if (direction == "down") snake[i].Y += 1;
                if (direction == "left") snake[i].X -= 1;
                if (direction == "right") snake[i].X += 1;
            }

            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                direction = "up";
            }

            if (e.KeyCode == Keys.Down)
            {
                direction = "down";
            }

            if (e.KeyCode == Keys.Left)
            {
                direction = "left";
            }

            if (e.KeyCode == Keys.Right)
            {
                direction = "right";
            }
                       
        }
    }
}
