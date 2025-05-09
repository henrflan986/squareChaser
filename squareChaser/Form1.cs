using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace squareChaser
{
    public partial class Form1 : Form
    {

        Random randGen = new Random();
        SoundPlayer speedBoost = new SoundPlayer(Properties.Resources.speedSound);
        SoundPlayer winner = new SoundPlayer(Properties.Resources.winnerSound);


        int xValue;
        Rectangle player1 = new Rectangle(200, 200, 15, 15);
        Rectangle player2 = new Rectangle(250, 200, 15, 15);
        Rectangle ball = new Rectangle(295, 195, 15, 15);
        Rectangle speedball = new Rectangle(400, 195, 15, 15);
        Rectangle freezeBall = new Rectangle( 200, 300, 10, 10);
        Rectangle border = new Rectangle(100, 100, 400, 400);
        Rectangle filler = new Rectangle(125, 125, 350, 350);
       

        int player1Score = 0;
        int player2Score = 0;

       // int playerSpeed = 3;
        int player1Speed = 3;
        int player2Speed = 3;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool aLeft = false;
        bool dRight = false;
        bool leftArrow = false;
        bool rightArrow = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aLeft = true;
                    break;
                case Keys.D:
                    dRight = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    leftArrow = true;
                    break;
                case Keys.Left:
                    rightArrow = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aLeft = false;
                    break;
                case Keys.D:
                    dRight = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    leftArrow = false;
                    break;
                case Keys.Left:
                    rightArrow = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blackBrush, border);
            e.Graphics.FillRectangle(whiteBrush, filler);
            e.Graphics.FillRectangle(redBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(greenBrush, ball);
            e.Graphics.FillRectangle(blackBrush, speedball);
            e.Graphics.FillEllipse(purpleBrush, freezeBall);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        

            //move player 1
            if (wDown == true && player1.Y > 125)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < 475 - player1.Width)
            {
                player1.Y += player1Speed;
            }
            if (aLeft == true && player1.X > 125)
            {
                player1.X -= player1Speed;
            }

            if (dRight == true && player1.X < 475 - player1.Width)
            {
                player1.X += player1Speed;
            }
            //move player 2
            if (upArrowDown == true && player2.Y > 125)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < 475 - player2.Height)
            {
                player2.Y += player2Speed;
            }
            if (rightArrow == true && player2.X > 125)
            {
                player2.X -= player2Speed;
            }

            if (leftArrow == true && player2.X < 475 - player2.Width)
            {
                player2.X += player2Speed;
            }

            //check if ball hits top wall or the bottom wall
          
            //check if ball hits either player.
            //If it does change the direction
            //and place the ball in front of the player hit
            if (player1.IntersectsWith(ball))
            {
                ball.X = randGen.Next(125, 475);
                ball.Y = randGen.Next(125, 475);
                player1Score++;
                winner.Play();
            }
            else if (player2.IntersectsWith(ball))
            {
                ball.X = randGen.Next(125, 475);
                ball.Y = randGen.Next(125, 475);
                player2Score++;
                winner.Play();
            }
            if (player1.IntersectsWith(speedball))
            {
                speedball.X = randGen.Next(125, 475);
                speedball.Y = randGen.Next(125, 475);
                player1Speed += 2;
                speedBoost.Play();
            }
            else if (player2.IntersectsWith(speedball))
            {
                speedball.X = randGen.Next(125, 475);
                speedball.Y = randGen.Next(125, 475);
                player2Speed++;
                player2Speed++;
                speedBoost.Play();
            }
            if (player1.IntersectsWith(freezeBall))
            {
                freezeBall.X = randGen.Next(125, 475);
                freezeBall.Y = randGen.Next(125, 475);

                player2Speed = 0;
                freezeTimer.Enabled = true;




            }
            else if (player2.IntersectsWith(freezeBall))
            {
                freezeBall.X = randGen.Next(125, 475);
                freezeBall.Y = randGen.Next(125, 475);

                player1Speed = 0;
               freezeTimer.Enabled = true;

            }

            //if (player1.IntersectsWith(bombBall))
            //{
            //    bombBall.X = randGen.Next(125, 475);
            //    bombBall.Y = randGen.Next(125, 475);

            //    player2Speed = 0;
            //    freezeTimer.Enabled = true;




            //}
            //else if (player2.IntersectsWith(bombBall))
            //{
            //    bombBall.X = randGen.Next(125, 475);
            //    bombBall.Y = randGen.Next(125, 475);

            //    player1Speed = 0;
            //    freezeTimer.Enabled = true;

                //check if game is over
                if (player1Score == 5)
            {
                winLabel.Visible = true;
                winLabel.Text = "Player 1 wins!!";
                gameEngine.Enabled = false;
            }
            else if (player2Score == 5)
            {
                gameEngine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 wins!!";
            }

            Refresh(); // runs the Paint method
        }

        private void freezeTimer_Tick(object sender, EventArgs e)
        {
            freezeTimer.Enabled = false;
            player2Speed = 3;
            player1Speed = 3;
        }
    }
}


