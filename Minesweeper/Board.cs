using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Board
    {
        enum SquareValue
        {
            Zero = 0,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Bomb
        };

        SquareValue[,] board;
        public Board(int rows, int columns)
        {
            board = new SquareValue[rows, columns];
        }

        public bool InitialiseBoard(List<string>boardList)
        {
            int row = 0;
            foreach (string line in boardList)
            {
                int column = 0;
                foreach (char character in line)
                {
                    if (character == '*')
                        board[row, column] = SquareValue.Bomb;
                    else if (character == '.')
                        board[row, column] = SquareValue.Zero;
                    else
                        return false;
                    column++;
                }
                row++;
            }
            return true;
        }

        public void GenerateBoardValues()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] == SquareValue.Bomb)
                        IncrementAdjacentSquares(i, j);
                }
            }
        }

        void IncrementAdjacentSquares(int rowIndex, int columnIndex)
        {
            //Attempt to Increment Each Adjacent Square
            IncrementSquare(rowIndex - 1, columnIndex - 1); //Top Left
            IncrementSquare(rowIndex - 1, columnIndex);     //Top Middle
            IncrementSquare(rowIndex - 1, columnIndex + 1); //Top Right

            IncrementSquare(rowIndex, columnIndex - 1);     //Middle Left
            IncrementSquare(rowIndex, columnIndex + 1);     //Middle Right

            IncrementSquare(rowIndex + 1, columnIndex - 1); //Bottom Left
            IncrementSquare(rowIndex + 1, columnIndex);     //Bottom Middle
            IncrementSquare(rowIndex + 1, columnIndex + 1); //Bottom Right
        }

        void IncrementSquare(int rowIndex, int columnIndex)
        {
            if (IndexInBounds(rowIndex, columnIndex))
            {
                if (board[rowIndex, columnIndex] == SquareValue.Bomb)
                    return;

                board[rowIndex, columnIndex]++;
            }
        }

        public override string ToString()
        {
            StringBuilder levelOutput = new StringBuilder();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    levelOutput.Append(SquareValueToChar(i, j));
                }
            }
            return levelOutput.ToString();
        }

        char SquareValueToChar(int row, int column)
        {
            if (board[row, column] == SquareValue.Bomb)
            {
                return '*';
            }
            else
            {
                int value = (int)board[row, column];
                return value.ToString()[0];
            }
        }

        public bool IndexInBounds(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 &&
                columnIndex >= 0 &&
                rowIndex < board.GetLength(0) &&
                columnIndex < board.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
