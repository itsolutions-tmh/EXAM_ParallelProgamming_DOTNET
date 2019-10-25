using System;
using System.Collections.Generic;
using System.Text;

namespace EXAM_ParallelProgamming_DOTNET
{
    public class PrimesSequential
    {

        public long GetPrimesSequential(long first, long last)
        {
            var count = 0;
            for (long i = first; i < last; i++)
            {
                if (IsPrime(i)) count++;
            }
            return count;
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
