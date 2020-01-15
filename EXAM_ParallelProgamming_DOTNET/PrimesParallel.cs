using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAM_ParallelProgamming_DOTNET
{
    public class PrimesParallel
    {
        
       

        public long GetPrimesParallel(long first, long last)
        {
            var count = 0;
            var lockObject = new object();
            Parallel.For(first, last, (i) =>
            {
             
                if (IsPrime(i))
                {
                    lock (lockObject)
                    {
                        count++;
                    }          
                }
            });
            
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
