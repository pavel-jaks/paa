using paa.NET.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paa.NET.Serial
{
    public static class CspSolver
    {
        public static bool Solve(SudokuBoard sudokuBoard, List<Domain> domains)
        {
            if (sudokuBoard.IsSolved()) return true;

            if (domains == null || domains.Count == 0)
            {
                domains = [];

                for (var row = 0; row < sudokuBoard.BoardSize; row++)
                {
                    for (var col = 0; col < sudokuBoard.BoardSize; col++)
                    {
                        if (sudokuBoard.BoardValue(row, col) == Digit.None)
                        {
                            domains.Add(new Domain(row, col, sudokuBoard));
                        }
                    }
                }
            }

            domains.Sort((c, d) => c.DomainDigits.Count() - d.DomainDigits.Count());

            if (!domains[0].DomainDigits.Any())
            {
                return false;
            }
            
            
            foreach (var digit in domains[0].DomainDigits.ToArray())
            {
                if (sudokuBoard.TryInsert(domains[0].Row, domains[0].Column, digit))
                {
                    var feasible = domains[1..].Select(dom => dom.Revise(sudokuBoard)).All(b => b);
                    if (feasible && Solve(sudokuBoard, [.. domains[1..]]))
                    {
                        return true;
                    }
                    sudokuBoard.Delete(domains[0].Row, domains[0].Column);
                    domains.ForEach(dom => dom.Revise(sudokuBoard));
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            


            return false;
        }
    }

    public class Domain
    {
        private static Digit[] _allDigits = [
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

        public int Row { get; init; }
        public int Column { get; init; }

        public List<Digit> DomainDigits { get; private set; } = [];

        public Domain(int row, int column, SudokuBoard sudokuBoard)
        {
            Row = row;
            Column = column;

            DomainDigits = _allDigits
                .Where(
                    d =>
                    !new IEnumerable<Digit>[] {
                            Enumerable.Range(0, sudokuBoard.BoardSize).Where(i => i != Row).Select(i => sudokuBoard.BoardValue(i, Column)),
                            Enumerable.Range(0, sudokuBoard.BoardSize).Where(i => i != Column).Select(i => sudokuBoard.BoardValue(Row, i)),
                            Enumerable.Range(0, sudokuBoard.BoardSize)
                                .Select(i => new Tuple<int, int>(Row / 3 * 3 + i / 3, Column / 3 * 3 + i % 3))
                                .Where(t => t.Item1 != Row && t.Item2 != Column)
                                .Select(t => sudokuBoard.BoardValue(t.Item1, t.Item2))
                    }
                    .SelectMany(col => col.Select(d => d))
                    .Distinct()
                    .Contains(d))
                .ToList();
            DomainDigits.Sort();

        }

        public bool Revise(SudokuBoard sudokuBoard)
        {
            DomainDigits = _allDigits
                .Where(
                    d =>
                    !new IEnumerable<Digit>[] {
                            Enumerable.Range(0, sudokuBoard.BoardSize).Where(i => i != Row).Select(i => sudokuBoard.BoardValue(i, Column)),
                            Enumerable.Range(0, sudokuBoard.BoardSize).Where(i => i != Column).Select(i => sudokuBoard.BoardValue(Row, i)),
                            Enumerable.Range(0, sudokuBoard.BoardSize)
                                .Select(i => new Tuple<int, int>(Row / 3 * 3 + i / 3, Column / 3 * 3 + i % 3))
                                .Where(t => t.Item1 != Row && t.Item2 != Column)
                                .Select(t => sudokuBoard.BoardValue(t.Item1, t.Item2))
                    }
                    .SelectMany(col => col.Select(d => d))
                    .Distinct()
                    .Contains(d))
                .ToList();
            DomainDigits.Sort();

            return DomainDigits.Any();
        }
    }
}
