using System;
using System.Diagnostics;

namespace PrimeNumbers_Sync
{
    class PrimeNumbers
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(CountPrimeNumbers(1, 1000000));
            Console.WriteLine(sw.Elapsed);
        }

        private static int CountPrimeNumbers(int from, int to)
        {
            int count = 0;

            for(int i = from; i <= to; i++)
            {
                bool isPrime = true;

                for(int div = 2; div <= Math.Sqrt(i); div++)
                {
                    if(i % div == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
