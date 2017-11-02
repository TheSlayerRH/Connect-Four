using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInALine
{
    class Computer
    {
        private int[][] board = { new int[7], new int[7], new int[7], new int[7], new int[7], new int[7] };

        public Computer(int[][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    this.board[row][column] = board[row][column];
                }
            }
        }

        public int[] play()
        {
            int[] location = {-1, -1};

            //Three of the same color:
            //Check for 3 separated in a row:
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length - 3; column++)
                {
                    if (board[row][column] != 0 && (board[row][column] == board[row][column + 1] || board[row][column] == board[row][column + 2]) && board[row][column] == board[row][column + 3])
                    {
                        if (/*board[row][column] == board[row][column + 1] && */isAvailable(row, column + 2)) 
                        {
                            location[0] = row;
                            location[1] = column + 2;
                        }
                        else if (/*board[row][column] == board[row][column + 2] && */isAvailable(row, column + 1))
                        {
                            location[0] = row;
                            location[1] = column + 1;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 separated in a left to right diagonal:
            for (int row = 0; row < board.Length - 3; row++)
            {
                for (int column = 0; column < board[row].Length - 3; column++)
                {
                    if (board[row][column] != 0 && (board[row][column] == board[row + 1][column + 1] || board[row][column] == board[row + 2][column + 2]) && board[row][column] == board[row + 3][column + 3])
                    {
                        if (/*board[row][column] == board[row + 1][column + 1] && */isAvailable(row + 2, column + 2))
                        {
                            location[0] = row + 2;
                            location[1] = column + 2;
                        }
                        else if (/*board[row][column] == board[row + 2][column + 2] && */isAvailable(row + 1, column + 1))
                        {
                            location[0] = row + 1;
                            location[1] = column + 1;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 separated in a right to left diagonal:
            for (int row = 0; row < board.Length - 3; row++)
            {
                for (int column = 3; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && (board[row][column] == board[row + 1][column - 1] || board[row][column] == board[row + 2][column - 2]) && board[row][column] == board[row + 3][column - 3])
                    {
                        if (/*board[row][column] == board[row + 1][column - 1] && */isAvailable(row + 2, column - 2))
                        {
                            location[0] = row + 2;
                            location[1] = column - 2;
                        }
                        else if (/*board[row][column] == board[row + 2][column - 2] && */isAvailable(row + 1, column - 1))
                        {
                            location[0] = row + 1;
                            location[1] = column - 1;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 in a row:
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length-2; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row][column + 1] && board[row][column + 1] == board[row][column + 2])
                    {
                        if (isAvailable(row, column - 1))
                        {
                            location[0] = row;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row, column + 3))
                        {
                            location[0] = row;
                            location[1] = column + 3;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 in a column:
            for (int row = 0; row < board.Length-2; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column] && board[row + 1][column] == board[row + 2][column]) 
                    {
                        if (isAvailable(row - 1, column))
                        {
                            location[0] = row - 1;
                            location[1] = column;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 in a diagonal right to left:
            for (int row = 0; row < board.Length - 2; row++)
            {
                for (int column = 0; column < board[row].Length - 2; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column + 1] && board[row + 1][column + 1] == board[row + 2][column + 2])
                    {
                        if (isAvailable(row - 1, column - 1))
                        {
                            location[0] = row - 1;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row + 3, column + 3))
                        {
                            location[0] = row + 3;
                            location[1] = column + 3;
                        }
                        else
                        {
                            continue;
                        }
                        
                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }

            //Check for 3 in a diagonal left to right:
            for (int row = 0; row < board.Length - 2; row++)
            {
                for (int column = 2; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column - 1] && board[row + 1][column - 1] == board[row + 2][column - 2])
                    {
                        if (isAvailable(row - 1, column + 1))
                        {
                            location[0] = row - 1;
                            location[1] = column + 1;
                        }
                        else if (isAvailable(row + 3, column - 3))
                        {
                            location[0] = row + 3;
                            location[1] = column - 3;
                        }
                        else
                        {
                            continue;
                        }

                        if (board[row][column] == 2)
                            return location;
                    }
                }
            }


            //Found something to block:
            if (location[0] != -1 && location[1] != -1)
            {
                return location;
            }


            //Two of the same color:
            //Check for 2 in a row:
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length - 1; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row][column + 1])
                    {
                        if (isAvailable(row, column - 1) && isGoodMove(row, column - 1))
                        {
                            location[0] = row;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row, column + 2) && isGoodMove(row, column + 2))
                        {
                            location[0] = row;
                            location[1] = column + 2;
                        }
                    }
                }
            }

            //Check for 2 in a column:
            for (int row = 0; row < board.Length - 1; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column]) 
                    {
                        if (isAvailable(row - 1, column) && isGoodMove(row - 1, column))
                        {
                            location[0] = row - 1;
                            location[1] = column;
                        }
                    }
                }
            }

            //Check for 2 in a diagonal left to right:
            for (int row = 0; row < board.Length - 1; row++)
            {
                for (int column = 0; column < board[row].Length - 1; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column + 1]) 
                    {
                        if (isAvailable(row - 1, column - 1) && isGoodMove(row - 1, column - 1))
                        {
                            location[0] = row - 1;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row + 2, column + 2) && isGoodMove(row + 2, column + 2))
                        {
                            location[0] = row + 2;
                            location[1] = column + 2;
                        }
                    }
                }
            }

            //Check for 2 in a diagonal right to left:
            for (int row = 0; row < board.Length - 1; row++)
            {
                for (int column = 1; column < board[row].Length; column++)
                {
                    if (board[row][column] != 0 && board[row][column] == board[row + 1][column - 1] && board[row + 1][column - 1] == board[row + 1][column - 1])
                    {
                        if (isAvailable(row - 1, column + 1) && isGoodMove(row - 1, column + 1))
                        {
                            location[0] = row - 1;
                            location[1] = column + 1;
                        }
                        else if (isAvailable(row + 2, column - 2) && isGoodMove(row + 2, column - 2)) 
                        {
                            location[0] = row + 2;
                            location[1] = column - 2;
                        }
                    }
                }
            }


            //Found something to block or continue:
            if (location[0] != -1 && location[1] != -1)
            {
                return location;
            }


            //One red:
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] == 2)
                    {
                        if (isAvailable(row - 1, column - 1) && isGoodMove(row - 1, column - 1))
                        {
                            location[0] = row - 1;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row + 1, column + 1) && isGoodMove(row + 1, column + 1))
                        {
                            location[0] = row + 1;
                            location[1] = column + 1;
                        }
                        else if (isAvailable(row - 1, column + 1) && isGoodMove(row - 1, column + 1))
                        {
                            location[0] = row - 1;
                            location[1] = column + 1;
                        }
                        else if (isAvailable(row + 1, column - 1) && isGoodMove(row + 1, column - 1))
                        {
                            location[0] = row + 1;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row, column + 1) && isGoodMove(row, column + 1))
                        {
                            location[0] = row;
                            location[1] = column + 1;
                        }
                        else if (isAvailable(row, column - 1) && isGoodMove(row, column - 1))
                        {
                            location[0] = row;
                            location[1] = column - 1;
                        }
                        else if (isAvailable(row - 1, column) && isGoodMove(row - 1, column))
                        {
                            location[0] = row - 1;
                            location[1] = column;
                        }
                    }
                }
            }

            //Found something to continue:
            if (location[0] != -1 && location[1] != -1)
            {
                return location;
            }

            //If none of the above - Random column:
            List<int> availableColumns = new List<int>();
            
            for (int column = 0; column < 7; column++)
            {
                if (board[0][column] == 0)
                {
                    availableColumns.Add(column);
                }
            }
            
            if (availableColumns.Count == 0)
            {
                return location;
            }

            bool haveGood = false;

            for (int i = 0; i < availableColumns.Count; i++ )
            {
                for (int row = board.Length - 1; row >= 0; row--)
                {
                    if (board[row][availableColumns.ElementAt(i)] == 0)
                    {
                        location[0] = row;
                        break;
                    }
                }

                if (isGoodMove(location[0], availableColumns.ElementAt(i)))
                {
                    haveGood = true;
                }
            }

            Random random = new Random();
            do{
                int randomColumn = random.Next(availableColumns.Count);

                location[1] = availableColumns.ElementAt(randomColumn);

                for (int row = board.Length - 1; row >= 0; row--)
                {
                    if (board[row][location[1]] == 0)
                    {
                        location[0] = row;
                        break;
                    }
                }
            }while(haveGood && availableColumns.Count != 1 && !isGoodMove(location[0], location[1]));

            return location;
        }

        private bool isAvailable(int row, int column)
        {
            if (row < 0 || row >= 6 || column < 0 || column >= 7 || board[row][column] != 0) 
                return false;

            if (row == 5)
                return true;

            if (board[row+1][column] == 0)
            {
                return false;
            }

            return true;
        }

        private bool isGoodMove(int row, int column)
        {
            if (row == 0)
                return true;

            //Row:
            if (column < 4 && board[row - 1][column + 1] == 1 && board[row - 1][column + 1] == board[row - 1][column + 2] &&
                board[row - 1][column + 2] == board[row - 1][column + 3])
                return false;

            if (column > 2 && board[row - 1][column - 1] == 1 && board[row - 1][column - 1] == board[row - 1][column - 2] &&
                board[row - 1][column - 2] == board[row - 1][column - 3])
                return false;

            if (column > 0 && column < 5 && board[row - 1][column - 1] == 1 && board[row - 1][column - 1] == board[row - 1][column + 1] &&
                board[row - 1][column + 1] == board[row - 1][column + 2])
                return false;

            if (column > 1 && column < 6 && board[row - 1][column - 2] == 1 && board[row - 1][column - 2] == board[row - 1][column - 1] &&
                board[row - 1][column - 1] == board[row - 1][column + 1])
                return false;


            //Left to right diagonal:
            if (row < 4 && column < 4 && board[row][column + 1] == 1 && board[row][column + 1] == board[row + 1][column + 2] &&
                board[row + 1][column + 2] == board[row + 2][column + 3])
                return false;

            if (row > 3 && column > 2 && board[row - 2][column - 1] == 1 && board[row - 2][column - 1] == board[row - 3][column - 2] &&
                board[row - 3][column - 2] == board[row - 4][column - 3])
                return false;

            if (row > 1 && row < 5 && column > 0 && column < 5 && board[row - 2][column - 1] == 1 && board[row - 2][column - 1] == board[row][column + 1] &&
                board[row][column + 1] == board[row + 1][column + 2])
                return false;

            if (row > 2 && column > 1 && column < 6 && board[row - 3][column - 2] == 1 && board[row - 3][column - 2] == board[row - 2][column - 1] &&
                board[row - 2][column - 1] == board[row][column + 1])
                return false;


            //Right to left diagonal:
            if (row < 4 && column > 2 && board[row][column - 1] == 1 && board[row][column - 1] == board[row + 1][column - 2] &&
                board[row + 1][column - 2] == board[row + 2][column - 3])
                return false;

            if (row > 3 && column < 4 && board[row - 2][column + 1] == 1 && board[row - 2][column + 1] == board[row - 3][column + 2] &&
                board[row - 3][column + 2] == board[row - 4][column + 3])
                return false;

            if (row > 1 && row < 5 && column > 1 && column < 6 && board[row - 2][column + 1] == 1 && board[row - 2][column + 1] == board[row][column - 1] &&
                board[row][column - 1] == board[row + 1][column - 2])
                return false;

            if (row > 2 && column > 0 && column < 5 && board[row - 3][column + 2] == 1 && board[row - 3][column + 2] == board[row - 2][column + 1] &&
                board[row - 2][column + 1] == board[row][column - 1])
                return false;

            return true;
        }
    }
}
