using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInALine
{
    public partial class Form1 : Form
    {
        Point cursorLocation = new Point(0, 0);
        bool[] visibles = new bool[7];

        int[] locations = { 206, 303, 400, 498, 598, 696, 794}; //y=15
        int[] yLocations = { 112, 205, 299, 393, 486, 579};

        int limit = 579;

        PictureBox[] topCircles = new PictureBox[7];
        bool greenTurn = true;

        PictureBox circle;

        int[][] board = new int[6][];

        bool moving = false;

        int winner = 0;

        int[] computerPlayLocation = new int[2];

        int usedGreenDiscsCount = 0;

        int winCount = 0;
        int loseCount = 0;
        int drawCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cursorLocation.X = Cursor.Position.X - this.Left - 15;
            cursorLocation.Y = Cursor.Position.Y - this.Top - 35;

            int[] line0 = { 0, 0, 0, 0, 0, 0, 0 };
            board[0] = line0;
            int[] line1 = { 0, 0, 0, 0, 0, 0, 0 };
            board[1] = line1;
            int[] line2 = { 0, 0, 0, 0, 0, 0, 0 };
            board[2] = line2;
            int[] line3 = { 0, 0, 0, 0, 0, 0, 0 };
            board[3] = line3;
            int[] line4 = { 0, 0, 0, 0, 0, 0, 0 };
            board[4] = line4;
            int[] line5 = { 0, 0, 0, 0, 0, 0, 0 };
            board[5] = line5;
        }

        private PictureBox createCircle(bool isGreen, Point location)
        {
            PictureBox circle1 = new PictureBox();
            circle1.Size = new Size(87, 82);

            if (isGreen)
            {
                circle1.Image = Properties.Resources.green;
            }
            else
            {
                circle1.Image = Properties.Resources.red;
            }

            circle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            circle1.BackColor = Color.Transparent;
            circle1.Location = location;
            this.Controls.Add(circle1);

            return circle1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursorLocation.X = Cursor.Position.X - this.Left - 15;
            cursorLocation.Y = Cursor.Position.Y - this.Top - 35;

            
            for (int i = 0; i < topCircles.Length; i++)
            {
                if (topCircles[i] != null)
                {
                    topCircles[i].Visible = false;
                }
            }
            
            
            if (winner == 0 && !moving && greenTurn && cursorLocation.Y < 94 && cursorLocation.Y > 0 && cursorLocation.X >= locations[0] && cursorLocation.X <= locations[6] + 92)
            {
                int topLocationNumber = getNumberOfTopLocation();

                if (topCircles[topLocationNumber] == null)
                    topCircles[topLocationNumber] = createCircle(true, new Point(locations[topLocationNumber], 16));
                else
                    topCircles[topLocationNumber].Visible = true;

                topCircles[topLocationNumber].MouseClick += Top_MouseClick;
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            cursorLocation.X = Cursor.Position.X - this.Left - 15;
            cursorLocation.Y = Cursor.Position.Y - this.Top - 35;
        }



        private void Top_MouseClick(object sender, MouseEventArgs e)
        {
            if (greenTurn && cursorLocation.Y < 94 && cursorLocation.Y > 0 && cursorLocation.X >= locations[0] && cursorLocation.X <= locations[6] + 92)
            {
                if (!moving && winner == 0)
                {
                    for (int i = 0; i < topCircles.Length; i++)
                    {
                        if (topCircles[i] != null)
                        {
                            topCircles[i].Visible = false;
                        }
                    }

                    int topLocationNumber = getNumberOfTopLocation();

                    putCircle(topLocationNumber, true);
                }
            }
        }

        private int getNumberOfTopLocation()
        {
            if (cursorLocation.X >= locations[0] && cursorLocation.X < locations[1])
            {
                return 0;
            }
            else if (cursorLocation.X >= locations[1] && cursorLocation.X < locations[2])
            {
                return 1;
            }
            else if (cursorLocation.X >= locations[2] && cursorLocation.X < locations[3])
            {
                return 2;
            }
            else if (cursorLocation.X >= locations[3] && cursorLocation.X < locations[4])
            {
                return 3;
            }
            else if (cursorLocation.X >= locations[4] && cursorLocation.X < locations[5])
            {
                return 4;
            }
            else if (cursorLocation.X >= locations[5] && cursorLocation.X < locations[6])
            {
                return 5;
            }
            else if (cursorLocation.X >= locations[6] && cursorLocation.X <= locations[6] + 92)
            {
                return 6;
            }

            return -1;
        }

        private void timerMoveDown_Tick(object sender, EventArgs e)
        {
            Point newLocation = new Point(circle.Location.X, circle.Location.Y + 10);
            circle.Location = newLocation;

            if (circle.Location.Y >= limit)
            {
                newLocation = new Point(circle.Location.X, limit);
                circle.Location = newLocation;

                timerMoveDown.Enabled = false;
                moving = false;

                Computer computer = new Computer(board);
                computerPlayLocation = computer.play();

                int[] winnerCheck = checkForWinner();
                winner = winnerCheck[2];
                if (winner == 1)
                {
                    winCount++;
                    drawWinnerLine(winnerCheck);
                    MessageBox.Show("Congratulations, you won!!!", "Game Over");
                    labelGamesPlayed.Text = "Games played: " + (winCount + loseCount + drawCount);
                    labelWinsLoses.Text = "Wins/Loses: " + winCount + "/" + loseCount;
                    labelWLRatio.Text = String.Format("W/L ratio: {0:0.00}", getWinLoseRatio());
                }

                if (computerPlayLocation[0] != -1 && winner == 0)
                {
                    putCircle(computerPlayLocation[1], false);
                }
            }
        }

        private int getYNeeded()
        {
            int column = getNumberOfTopLocation();

            for (int row = board.Length-1; row >= 0; row-- )
            {
                if (board[row][column] == 0)
                {
                    return row;
                }
            }

            return -1;
        }

        private void putCircle(int location, bool isGreen)
        {
            int sideLocationNumber;
            if (isGreen)
            {
                sideLocationNumber = getYNeeded();
            }
            else
            {
                sideLocationNumber = computerPlayLocation[0];
            }

            if (sideLocationNumber != -1)
            {
                circle = createCircle(isGreen, new Point(locations[location], 16));
                moving = true;
                limit = yLocations[sideLocationNumber];

                if (isGreen)
                {
                    usedGreenDiscsCount++;
                    board[sideLocationNumber][location] = 1;
                    timerMoveDown.Enabled = true;
                }
                else
                {
                    board[sideLocationNumber][location] = 2;
                    timerMoveDownComputer.Enabled = true;
                }

                labelDiscsLeft.Text = "Discs left: " + (21 - usedGreenDiscsCount);
            }
        }

        private void timerMoveDownComputer_Tick(object sender, EventArgs e)
        {
            Point newLocation = new Point(circle.Location.X, circle.Location.Y + 10);
            circle.Location = newLocation;

            if (circle.Location.Y >= limit)
            {
                newLocation = new Point(circle.Location.X, limit);
                circle.Location = newLocation;

                timerMoveDownComputer.Enabled = false;
                moving = false;

                int[] winnerCheck = checkForWinner();
                winner = winnerCheck[2];
                if (winner == 2)
                {
                    loseCount++;
                    drawWinnerLine(winnerCheck);
                    MessageBox.Show("You lost!", "Game Over");
                    labelGamesPlayed.Text = "Games played: " + (winCount + loseCount + drawCount);
                    labelWinsLoses.Text = "Wins/Loses: " + winCount + "/" + loseCount;
                    labelWLRatio.Text = String.Format("W/L ratio: {0:0.00}", getWinLoseRatio());
                }
                else if (usedGreenDiscsCount == 21)
                {
                    drawCount++;
                    MessageBox.Show("It's a tie!", "Game Over");
                    labelGamesPlayed.Text = "Games played: " + (winCount + loseCount + drawCount);
                    labelDraws.Text = "Draws: " + drawCount;
                    winner = -1;
                }
            }
        }

        private int[] checkForWinner()
        {
            int[] result = new int[3];

            //4 in a row:
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length - 3; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row][column + 1] && board[row][column + 1] == board[row][column + 2] && board[row][column + 2] == board[row][column + 3])
                    {
                        result[0] = row;
                        result[1] = column;
                        result[2] = board[row][column];
                        return result;
                    }
                }
            }

            //4 in a column:
            for (int row = 0; row < board.Length - 3; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column] && board[row + 1][column] == board[row + 2][column] && board[row + 2][column] == board[row + 3][column]) 
                    {
                        result[0] = row;
                        result[1] = column;
                        result[2] = board[row][column];
                        return result;
                    }
                }
            }

            //4 in a left to right diagonal:
            for (int row = 0; row < board.Length - 3; row++)
            {
                for (int column = 0; column < board[row].Length - 3; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column + 1] && board[row + 1][column + 1] == board[row + 2][column + 2] && board[row + 2][column + 2] == board[row + 3][column + 3])
                    {
                        result[0] = row;
                        result[1] = column;
                        result[2] = board[row][column];
                        return result;
                    }
                }
            }

            //4 in a right to left diagonal:
            for (int row = 0; row < board.Length - 3; row++)
            {
                for (int column = 3; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column - 1] && board[row + 1][column - 1] == board[row + 2][column - 2] && board[row + 2][column - 2] == board[row + 3][column - 3])
                    {
                        result[0] = row;
                        result[1] = column;
                        result[2] = board[row][column];
                        return result;
                    }
                }
            }

            result[0] = -1;
            result[1] = -1;
            result[2] = 0;
            return result;
        }

        private double getWinLoseRatio()
        {
            if (loseCount == 0)
            {
                return (double)winCount;
            }

            return (double)winCount / (double)loseCount;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    board[row][column] = 0;
                }
            }

            foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
            {
                pb.Visible = false;
            }

            usedGreenDiscsCount = 0;
            labelDiscsLeft.Text = "Discs left: " + (21 - usedGreenDiscsCount);

            timerMoveDown.Enabled = false;
            timerMoveDownComputer.Enabled = false;

            greenTurn = true;
            moving = false;
            winner = 0;
        }

        private void drawWinnerLine(int[] winner)
        {
            PictureBox[] winningFour = new PictureBox[4];

            Image newPicture;
            if(board[winner[0]][winner[1]] == 1)
                newPicture = Properties.Resources.winGreen;
            else
                newPicture = Properties.Resources.winRed;

            if (winner[1] < 4 && board[winner[0]][winner[1]] == board[winner[0]][winner[1] + 1] && board[winner[0]][winner[1]] == board[winner[0]][winner[1] + 2] &&
                board[winner[0]][winner[1]] == board[winner[0]][winner[1] + 3]) //Row
            {
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[0] = pb;
                    else if (pb.Location.X == locations[winner[1] + 1] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[1] = pb;
                    else if (pb.Location.X == locations[winner[1] + 2] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[2] = pb;
                    else if (pb.Location.X == locations[winner[1] + 3] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[3] = pb;
                }
            }
            else if (winner[0] < 3 && board[winner[0]][winner[1]] == board[winner[0] + 1][winner[1]] && board[winner[0]][winner[1]] == board[winner[0] + 2][winner[1]] &&
                board[winner[0]][winner[1]] == board[winner[0] + 3][winner[1]])//Column
            {
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[0] = pb;
                    else if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0] + 1])
                        winningFour[1] = pb;
                    else if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0] + 2])
                        winningFour[2] = pb;
                    else if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0] + 3])
                        winningFour[3] = pb;
                }
            }
            else if (winner[0] < 3 && winner[1] < 4 && board[winner[0]][winner[1]] == board[winner[0] + 1][winner[1] + 1] &&
                board[winner[0]][winner[1]] == board[winner[0] + 2][winner[1] + 2] &&
                board[winner[0]][winner[1]] == board[winner[0] + 3][winner[1] + 3])//Left to right diagonal
            {
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[0] = pb;
                    else if (pb.Location.X == locations[winner[1] + 1] && pb.Location.Y == yLocations[winner[0] + 1])
                        winningFour[1] = pb;
                    else if (pb.Location.X == locations[winner[1] + 2] && pb.Location.Y == yLocations[winner[0] + 2])
                        winningFour[2] = pb;
                    else if (pb.Location.X == locations[winner[1] + 3] && pb.Location.Y == yLocations[winner[0] + 3])
                        winningFour[3] = pb;
                }
            }
            else if (winner[0] < 3 && winner[1] > 2 && board[winner[0]][winner[1]] == board[winner[0] + 1][winner[1] - 1] && board[winner[0]][winner[1]] == board[winner[0] + 2][winner[1] - 2] &&
            board[winner[0]][winner[1]] == board[winner[0] + 3][winner[1] - 3])//Right to left diagonal
            {
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    if (pb.Location.X == locations[winner[1]] && pb.Location.Y == yLocations[winner[0]])
                        winningFour[0] = pb;
                    else if (pb.Location.X == locations[winner[1] - 1] && pb.Location.Y == yLocations[winner[0] + 1])
                        winningFour[1] = pb;
                    else if (pb.Location.X == locations[winner[1] - 2] && pb.Location.Y == yLocations[winner[0] + 2])
                        winningFour[2] = pb;
                    else if (pb.Location.X == locations[winner[1] - 3] && pb.Location.Y == yLocations[winner[0] + 3])
                        winningFour[3] = pb;
                }
            }

            for (int i = 0; i < winningFour.Length; i++)
            {
                try
                {
                    winningFour[i].Image = newPicture;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("" + i);
                }
            }
        }
    }
}
