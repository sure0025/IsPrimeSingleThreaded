using System;
using System.Diagnostics;
using System.Threading;

namespace IsPrimeSingleThreaded
{
    class PrimeChecker
    {
        private long number;
        private Stopwatch stopwatch = new Stopwatch();

        public PrimeChecker(long input) {
            this.number = input;
        }

        public void Check() {
            string output;
            stopwatch.Start();
            try {
                long result = IsPrime();

                if (result == 0) {
                    output = "is prime!";
                }
                else {
                    output = "is NOT prime, contains factor " + result;
                }
                Console.WriteLine($"{number} " + output);
                Console.WriteLine("Time (ms) : " + stopwatch.Elapsed);
                stopwatch.Reset();
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine("Invalid parameter! " + e.Message);
            }
        }

        #region Check if number is a prime
        //returns 0 if number is prime, orherwise the first factor of number
        public long IsPrime() {
            int delayTime = 25;
            if (number <= 1) throw new ArgumentOutOfRangeException(); //primes must be larger than 1
            long result;
            if (number % 2 == 0) {//number is even
                if (number == 2) {
                    result = 0; //2 is the only even prime
                }
                else {
                    result = 2; //other even numbers are not prime as 2 is a factor
                }
            }
            else {
                long ceiling = (long)Math.Sqrt(number);
                long i = 3;
                while ((i <= ceiling) && (number % i != 0)) {
                    Thread.Sleep(delayTime);//simulate hard calculation
                    i = i + 2; // only check uneven factors, we have testet even 
                }
                if ((number % i == 0) && (number != i)) {
                    result = i; // i is a factor
                }
                else {
                    result = 0; // number is prime
                }
            }
            stopwatch.Stop();
            return result;
        }
        #endregion
    }
}
