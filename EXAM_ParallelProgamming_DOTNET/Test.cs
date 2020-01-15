using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EXAM_ParallelProgamming_DOTNET
{
    public class Test
    {
        public int PrimesWithPlinq(int min, int max)
        {
            return    Enumerable.Range(min, max).AsParallel()
                     .Where(x => IsPrime(x))
                     .Count();
         

        }

        public long PrimesWithThreads(long start, long end)
        {
            long result = 0;
            const long chunkSize = 25_000;
            var completed = 0;
            var allDone = new ManualResetEvent(initialState: false);

            var chunks = (end - start) / chunkSize;
            for (long i = 0; i < chunks; i++)
            {
                var chunkStart = (start) + i * chunkSize;
                var chunkEnd = i == (chunks - 1) ? end : chunkStart + chunkSize;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    for (var number = chunkStart; number < chunkEnd; number++)
                    {
                        if (IsPrime(number))
                        {
                            Interlocked.Increment(ref result);
                        }
                    }

                    if (Interlocked.Increment(ref completed) == chunks)
                    {
                        allDone.Set();
                    }
                });

            }
            allDone.WaitOne();
            return result;
        }

        private bool IsPrime(long n)
        {
            if (n == 1) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0) return false;
            int limit = (int)(Math.Sqrt(n) + 0.5);
            for (int i = 3; i <= limit; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }


    }
}
