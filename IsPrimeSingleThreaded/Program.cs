using System;
using System.Diagnostics;
using System.Numerics; //reference added to System.Numerics.dll

namespace IsPrimeSingleThreaded
{
    class Program
    {
        private Stopwatch stopwatch = new Stopwatch();
        private long threshold = 0;
        bool goOn = true;

        static void Main(string[] args) {
            Program program = new IsPrimeSingleThreaded.Program();
            program.Run();
        }

        public void Run() {
            do {
                long input = GetUserValue();

                if (input != 0) {
                    stopwatch.Start();
                    BigInteger value = threshold + input;
                    
                    Console.WriteLine($"{value} is a prime number: " + Utils.isPrime(value).ToString().ToUpper());
                    stopwatch.Stop();
                    Console.WriteLine("Time (ms) : " + stopwatch.Elapsed);
                    stopwatch.Reset();
                }
                else {
                    goOn = false;
                }
            } while (goOn);
        }

        private long GetUserValue() {
            Console.Write($"We will calculate the value of ({threshold} + x), where x is your input (enter 0 to exit): ");
            String s = Console.ReadLine();
            return long.Parse(s);
        }
    }
}
