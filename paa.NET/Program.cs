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
            
            var times = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                var board = new SudokuBoard(BoardGenerator.Deep);

                var time = evaluator.Eval(() => CspSolver.Solve(board, []));
                Console.WriteLine($"Sequential {i+1} run: {time}");
                times.Add(time);
            }
            
            
            var parallelTimes = new List<double>();

            for (int i = 0;i < 10;i++)
            {
                var board = new SudokuBoard(BoardGenerator.Deep);

                var time = evaluator.Eval(() => ParallelCspSolver.Solve(board, []));
                Console.WriteLine($"Parallel {i + 1} run: {time}");
                parallelTimes.Add(time);
            }

            
            Console.WriteLine($"Csp time: {times.Average()}");
            Console.WriteLine($"ParallelCsp time: {parallelTimes.Average()}");
            //Console.WriteLine(board);
        }
    }
}
