using System;
using System.Threading;

namespace IsPrimeSingleThreaded
{
    static class Utils
    {

        #region Check if number is a prime
        //returns 0 if number is prime, orherwise the first factor of number
        public static long isPrime(long number) {
            int delayTime = 5;
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
                long i = 3; //we have tested for <= 1 and 2
                while ((i <= ceiling) && (number % i != 0)) {
                    Thread.Sleep(delayTime);//simulate hard calculation
                    i = i + 2; // only check uneven factors, we have testet even 
                }
                if (number % i == 0) {
                    result = i; // i is a factor
                } else {
                    result = 0; // number is prime
                }
            }
            return result;
        }
        #endregion
    }
}
