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

        }

        Point[] snake;
        string direction = "up";
        int len = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);

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
