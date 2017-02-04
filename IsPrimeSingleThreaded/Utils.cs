using System.Numerics; //reference added to System.Numerics.dll
using System.Threading;

namespace IsPrimeSingleThreaded
{
    static class Utils
    {
        #region Check if number is a prime
        public static bool isPrime(BigInteger number) {
            if (number <= 1) return false; //primes must be larger than 1
            if (number % 2 == 0) return (number == 2); //except 2, even numbers are not prime

            BigInteger ceiling = BigIntegerSqrt(number);

            for (BigInteger i = 2; i <= ceiling; ++i) {
                Thread.Sleep(5);
                if (number % i == 0) return false;
            }
            return true; 
        }
        #endregion

        #region Squareroot of BigInteger
        //Source: stackoverflow.com/questions/3432412/calculate-square-root-of-a-biginteger-system-numerics-biginteger 
        private static BigInteger BigIntegerSqrt(BigInteger x) {
            int b = 15; // this is the next bit we try 
            BigInteger r = 0; // r will contain the result
            BigInteger r2 = 0; // here we maintain r squared
            while (b >= 0) {
                BigInteger sr2 = r2;
                BigInteger sr = r;
                // compute (r+(1<<b))**2, we have r**2 already.
                r2 += (BigInteger)((r << (1 + b)) + (1 << (b + b)));
                r += (BigInteger)(1 << b);
                if (r2 > x) {
                    r = sr;
                    r2 = sr2;
                }
                b--;
            }
            return r;
        }
        #endregion
    }
}
