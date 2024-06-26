using paa.NET.Common;
using System.Collections.Concurrent;

namespace paa.NET.Parallel
{
    public static class ParallelBfsSolver
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

        public static async Task<bool> Solve(SudokuBoard board)
        {
            if (board.IsSolved())
            {
                return true;
            }
            
            var queue = new BlockingCollection<SudokuBoard>
            {
                board.DeepCopy()
            };

            var coreCount = Environment.ProcessorCount;
            var tasks = new List<Task>();

            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;

            object lockVar = new();

            for ( var i = 0; i < coreCount; i++)
            {
                tasks.Add(Expand(queue, board, cancellationToken, cts, lockVar));
            }

            await Task.WhenAll(tasks);
            

            if (board.IsSolved() )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static async Task Expand(BlockingCollection<SudokuBoard> queue, SudokuBoard originalSudokuBoard,
            CancellationToken solutionFoundToken, CancellationTokenSource solutionFoundSource, object lockVar)
        {
            while (queue.TryTake(out var board, 2000))
            {
                if (solutionFoundToken.IsCancellationRequested)
                {
                    return;
                }
                if (board.IsSolved())
                {
                    lock (lockVar)
                    {
                        originalSudokuBoard.From(board);
                        solutionFoundSource.Cancel();
                        return;
                    }
                }

                var broken = false;

                for (var i = 0; i < board.BoardSize; i++)
                {
                    for (var j = 0; j < board.BoardSize; j++)
                    {
                        if (board.BoardValue(i, j) == Digit.None)
                        {
                            for (var d = 1; d <= board.BoardSize; d++)
                            {
                                if (board.TryInsert(i, j, digits[d]))
                                {
                                    queue.Add(board.DeepCopy());
                                }
                                board.Delete(i, j);
                            }
                            broken = true;
                            break;
                        }
                    }
                    if (broken) break;
                }
            }


        }
    }
}
