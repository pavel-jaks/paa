using System;
using System.Text;
using paa.NET.Common;

namespace paa.NET.Parallel
{
    public class ParallelSudokuBoard
    {
        protected readonly Digit[][] _rows;
        public int BoardSize => 9;

        protected readonly int[][] boxCoords = [
            [0, 0, 0, 1, 1, 1, 2, 2, 2],
            [0, 0, 0, 1, 1, 1, 2, 2, 2],
            [0, 0, 0, 1, 1, 1, 2, 2, 2],
            [3, 3, 3, 4, 4, 4, 5, 5, 5],
            [3, 3, 3, 4, 4, 4, 5, 5, 5],
            [3, 3, 3, 4, 4, 4, 5, 5, 5],
            [6, 6, 6, 7, 7, 7, 8, 8, 8],
            [6, 6, 6, 7, 7, 7, 8, 8, 8],
            [6, 6, 6, 7, 7, 7, 8, 8, 8]
        ];

        public ParallelSudokuBoard(Digit[][] rows)
        {
            try
            {
                _rows = new Digit[BoardSize][];
                for (var i = 0; i < BoardSize; i++)
                {
                    _rows[i] = new Digit[BoardSize];
                    for (var j = 0; j < BoardSize; j++)
                    {
                        _rows[i][j] = rows[i][j];
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Given rows not valid");
            }
        }

        public Digit BoardValue(int row, int column) => _rows[row][column];

        public virtual bool Delete(int row, int col)
        {
            if (_rows[row][col] == Digit.None) return false;
            _rows[row][col] = Digit.None;
            return true;
        }

        public virtual bool TryInsert(int row, int col, Digit val)
        {
            if (_rows[row].Contains(val)) return false;
            if (Column(col).Contains(val)) return false;
            if (Box(GetBoxCoord(row, col)).Contains(val)) return false;

            _rows[row][col] = val;
            return true;
        }

        public int GetBoxCoord(int row, int col)
        {
            return boxCoords[row][col];
        }

        protected IEnumerable<Digit> Row(int row) => _rows[row];

        protected IEnumerable<Digit> Column(int col)
        {
            for (var i = 0; i < BoardSize; i++)
            {
                yield return _rows[i][col];
            }
        }

        protected IEnumerable<Digit> Box(int box)
        {
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    if (GetBoxCoord(i, j) == box) yield return _rows[i][j];
                }
            }
        }

        public bool IsSolved()
        {
            if (_rows.SelectMany(x => x).Contains(Digit.None)) return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in _rows)
            {
                sb.AppendLine(string.Join(',', row));
            }
            return sb.ToString();
        }
    }
}
