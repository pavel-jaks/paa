using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paa.NET.Common
{
    public static class BoardGenerator
    {
        public static Digit[][] Hard
        { 
            get
            {
                var board = new Digit[9][];
                for (int i = 0; i < board.Length; i++)
                {
                    board[i] = new Digit[9];
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        board[i][j] = Digit.None;
                    }
                }
                board[0][0] = Digit.Digit8;
                board[2][0] = Digit.Digit2;
                board[3][0] = Digit.Digit3;
                board[8][0] = Digit.Digit9;

                board[3][1] = Digit.Digit8;
                board[5][1] = Digit.Digit7;

                board[2][2] = Digit.Digit9;
                board[4][2] = Digit.Digit5;

                board[2][3] = Digit.Digit1;
                board[6][3] = Digit.Digit8;
                board[7][3] = Digit.Digit4;

                board[1][4] = Digit.Digit3;

                board[3][5] = Digit.Digit9;
                board[5][5] = Digit.Digit3;
                board[6][5] = Digit.Digit6;
                board[8][5] = Digit.Digit5;

                board[1][6] = Digit.Digit4;
                board[6][6] = Digit.Digit5;

                board[0][7] = Digit.Digit9;
                board[4][7] = Digit.Digit8;
                board[5][7] = Digit.Digit1;
                board[7][7] = Digit.Digit6;

                board[2][8] = Digit.Digit7;
                board[3][8] = Digit.Digit4;
                board[5][8] = Digit.Digit5;
                board[7][8] = Digit.Digit2;

                return board;
            } 
        }

        public static Digit[][] Empty
        {
            get
            {
                var board = new Digit[9][];
                for (int i = 0; i < board.Length; i++)
                {
                    board[i] = new Digit[9];
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        board[i][j] = Digit.None;
                    }
                }

                return board;
            }
        }

        public static Digit[][] Deep
        {
            get
            {
                var board = new Digit[9][];
                for (int i = 0; i < board.Length; i++)
                {
                    board[i] = new Digit[9];
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        board[i][j] = Digit.None;
                    }
                }

                board[2][8] = Digit.Digit7;
                board[3][8] = Digit.Digit4;
                board[5][8] = Digit.Digit5;
                board[7][8] = Digit.Digit2;

                return board;
            }
        }

        public static Digit[][] DFSBreaker
        {
            get
            {
                var board = new Digit[9][];
                for (int i = 0; i < board.Length; i++)
                {
                    board[i] = new Digit[9];
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        board[i][j] = Digit.None;
                    }
                }
                board[6][0] = Digit.Digit5;
                
                board[5][1] = Digit.Digit9;

                board[2][2] = Digit.Digit1;
                board[4][2] = Digit.Digit4;
                board[7][2] = Digit.Digit2;

                board[3][3] = Digit.Digit5;


                board[2][4] = Digit.Digit2;
                board[7][4] = Digit.Digit1;
                board[8][4] = Digit.Digit4;

                board[1][5] = Digit.Digit3;
                board[3][5] = Digit.Digit7;

                board[4][6] = Digit.Digit1;

                board[1][7] = Digit.Digit8;
                board[6][7] = Digit.Digit7;
                
                board[1][8] = Digit.Digit5;
                board[6][8] = Digit.Digit3;
                board[8][8] = Digit.Digit9;

                return board;
            }
        }
    }
}
