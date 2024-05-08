using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paa.NET.Common
{
    public class Evaluator
    {
        private readonly Stopwatch _stopwatch;

        public Evaluator()
        {
            _stopwatch = new Stopwatch();
        }

        public double Eval(Action action)
        {
            _stopwatch.Start();
            action.Invoke();
            _stopwatch.Stop();
            var time = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return time.TotalSeconds;
        }

        public async Task<double> Eval(Func<Task> func)
        {
            _stopwatch.Start();
            await func.Invoke();
            _stopwatch.Stop();
            var time = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return time.TotalSeconds;
        }
    }
}
