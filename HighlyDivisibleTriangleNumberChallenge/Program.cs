using System;
using System.Collections.Generic;
using System.Linq;

namespace HighlyDivisibleTriangleNumberChallenge
{
    class Program
    {
        /* See https://projecteuler.net/problem=12 */

        static void Main(string[] args) {
            long answer = 0;

            // Keep testing triangle numbers of index i until one of them has more than 500 factors.
            for (int i = 1; answer == 0; i++) {
                long triangleNum = GetTriangleNumber(i);

                if (GetFactorAmount(triangleNum) > 500) {
                    answer = triangleNum;
                }
            }

            Console.WriteLine(answer);
            Console.ReadKey();
        }

        // Uses prime-factorization to get every unique combination of prime factors (which, when multiplied, is every factor)
        static int GetFactorAmount(long num) {
            List<int> primeFactorPowers = new List<int>();

            for (int b = 2; num > 1; b++) {
                // Initialize power counter with 1 for the always-present value of b^0 = 1.
                int powerCounter = 1;
                while (num % b == 0) {
                    num /= b;
                    powerCounter++;
                }
                primeFactorPowers.Add(powerCounter);
            }

            // Return the product of every single prime factor products (AKA All combinations they can be combined in, including 1)
            return primeFactorPowers.Aggregate(1, (runningTotal, next) => runningTotal * next);
        }

        static long GetTriangleNumber(int num) {
            long total = 0;
            for (int i = num; i > 0; i--) {
                total += i;
            }
            return total;
        }
    }
}
