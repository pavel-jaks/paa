using System.Data.Common;
using System.Diagnostics;
using paa.NET.Common;
using paa.NET.Serial;
using paa.NET.Parallel;

namespace paa.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            var evaluator = new Evaluator();
            var board = new ParallelSudokuBoard(BoardGenerator.DFSBreaker);
            
            var time = evaluator.Eval(() => ParallelCspSolver.Solve(board, []));
            Console.WriteLine($"Parallel board {time}");
            Console.WriteLine(board);
        }
    }
}
