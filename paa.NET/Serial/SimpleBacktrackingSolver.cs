using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using paa.NET.Common;

namespace paa.NET.Serial
{
    public static class SimpleBacktrackingSolver
    {
        private static readonly Digit[] digits = [
            Digit.None,
            Digit.Digit1,
            Digit.Digit2,
            Digit.Digit3,
            Digit.Digit4,
            Digit.Digit5,
            Digit.Digit6,
            Digit.Digit7,
            Digit.Digit8,
            Digit.Digit9
        ];

        public static bool Solve(this SudokuBoard sudokuBoard)
        {
            if (sudokuBoard.IsSolved()) return true;
            for (int i = 0; i < sudokuBoard.BoardSize; i++)
            {
                for (int j = 0; j < sudokuBoard.BoardSize; j++)
                {
                    if (sudokuBoard.BoardValue(i, j) == Digit.None)
                    {
                        for (int d = 1; d < sudokuBoard.BoardSize + 1; d++)
                        {
                            if (sudokuBoard.TryInsert(i, j, digits[d]))
                            {
                                if (Solve(sudokuBoard)) return true;
                            }
                            sudokuBoard.Delete(i, j);
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
