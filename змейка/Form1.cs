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
            wight = pictureBox1.Width / 10;
            height = pictureBox1.Height / 10;
            snake[0].X = wight / 2;
            snake[0].Y = wight / 2;
            whiteBrush = new SolidBrush(Color.White);
            greenBrush = new SolidBrush(Color.Green);
            blackBrush = new SolidBrush(Color.Black);
            r = new Random();
            score = 0;
            maxScore = 0;
            apple.X = r.Next(0, wight-1);
            apple.Y = r.Next(0, height-1);

        }

        Point[] snake;
        Point apple;
        Random r; 
        string direction = "up";
        int len = 1;
        int wight;
        int height;
        int score, maxScore;
        SolidBrush whiteBrush;
        SolidBrush greenBrush;
        SolidBrush blackBrush;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.FillRectangle(whiteBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);

            Text = $"{score}/{maxScore}";
            if (score > maxScore) maxScore = score;

            for (int i = 0; i < len; i++)
            {
                if (snake[i].X < 0) snake[i].X += wight;
                if (snake[i].X > wight) snake[i].X -= wight;
                if (snake[i].Y < 0) snake[i].Y += height;
                if (snake[i].Y > height) snake[i].Y -= height;
                                                  

                g.FillEllipse(blackBrush, snake[i].X * 10, snake[i].Y * 10, 10, 10);

                if (apple.X == snake[i].X && apple.Y == snake[i].Y)
                {
                    len++;
                    score++;                    
                    apple.X = r.Next(0, wight-1);
                    apple.Y = r.Next(0, height-1);
                }

            }

            for (int i = 1; i < len; i++)
            {
                for (int j = i+1; j < len; j++)
                {
                    if (snake[i] == snake[j])
                    {
                        len = 3;
                        score = 0;
                        timer1.Interval = 100;
                    }
                }
            }

            g.FillEllipse(greenBrush, apple.X * 10, apple.Y * 10, 10, 10);

            if (direction == "up") snake[0].Y -= 1;
                if (direction == "down") snake[0].Y += 1;
                if (direction == "left") snake[0].X -= 1;
                if (direction == "right") snake[0].X += 1;

            if (len > 10000 - 3) len = 10000 - 3;

            for (int i = len; i >= 0; i--)
            {
                snake[i + 1].X = snake[i].X;
                snake[i + 1].Y = snake[i].Y;
            }
            if (len < 4) len++;

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(timer1.Interval>10) timer1.Interval -= 10;
        }
    }
}
