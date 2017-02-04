using System;
using System.Diagnostics;

namespace IsPrimeSingleThreaded
{
    class Program
    {
        private Stopwatch stopwatch = new Stopwatch();
        bool goOn = true;

        static void Main(string[] args) {
            Program program = new IsPrimeSingleThreaded.Program();
            program.Run();
        }

        public void Run() {
            do {
                long input = GetUserValue();
                string output;
                if (input == 0) {
                    goOn = false;
                }
                else {
                    try {
                        stopwatch.Start();
                        long result = Utils.isPrime(input);
                        if (result == 0) {
                            output = "is prime!";
                        }
                        else {
                            output = "is NOT prime, contains factor " + result;
                        }
                        Console.WriteLine($"{input} " + output);
                        stopwatch.Stop();
                        Console.WriteLine("Time (ms) : " + stopwatch.Elapsed);
                        stopwatch.Reset();
                    }
                    catch (ArgumentOutOfRangeException e) {
                        Console.WriteLine("Nonvalid parameter! " + e.ToString());
                    }
                }
            } while (goOn);
        }

        private long GetUserValue() {
            Console.Write("Enter a positive integer value to test whether it is prime (enter 0 to exit) : ");
            return long.Parse(Console.ReadLine());
        }
    }
}
