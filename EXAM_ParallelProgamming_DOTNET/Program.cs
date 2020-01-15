using System;
using System.Diagnostics;

namespace EXAM_ParallelProgamming_DOTNET
{
    class Program
    {
        static int min = 0;
       // static int min = 10_000_000;
        static int max = 2_000_000;
        static Program program = new Program();

        private PrimesSequential _primesSequential = new PrimesSequential();
        private PrimesParallel _primesParallel = new PrimesParallel();
        private Test test = new Test();
        static void Main(string[] args)
        {

          //  RunSequential();
            RunParallel();
            Test();

            Console.WriteLine();

        }

        public static void RunSequential()
        {
            Console.Write("Time for Sequential approach: ");
            var n = program.Watch(() => program._primesSequential.GetPrimesSequential(min, max));
            Console.WriteLine("\n" + n + " primes between " + min + " and " + max);
        }

        public static void RunParallel()
        {
            Console.Write("Time for Parallel approach: ");
            var n = program.Watch(() => program._primesParallel.GetPrimesParallel(min, max));
            Console.WriteLine("\n" + n + " primes between " + min + " and " + max);
        }

        public static void Test ()
        {
            Console.Write("Time for Test approach: ");
            var n = program.Watch(() => program.test.PrimesWithPlinq(min, max));
            Console.WriteLine("\n" + n + " primes between " + min + " and " + max);
        }


        public T Watch<T>(Func<T> action)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = action.Invoke();
            sw.Stop();
            Console.Write($"{sw.ElapsedMilliseconds / 1000d:F5} sek");
            return result;
        }
    }
}
