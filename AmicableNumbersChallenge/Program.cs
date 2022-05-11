using System;

namespace AmicableNumbersChallenge
{
    class Program
    {
        /* See https://projecteuler.net/problem=21 */

        public static void Main(string[] args) {
            // Makes a list of the sum of the divisors of every number under 10,000, except for itself. This let's us check the index of an index easily.
            int[] divisorSums = getDivisorSums(10000);
            int answer = 0;

            /* For every number, get the sum of it's divsors. If this number is in the array and not equal to itself (a perfect number, not an amicable one),
             * then check if that index is equal to the original number. If so, that number is amicable. Our output is their total, so add that number to the answer value.*/
            for (int num = 1; num < divisorSums.Length; num++) {
                int sumAtIndex = divisorSums[num];
                if (sumAtIndex < divisorSums.Length && sumAtIndex != num) {
                    if (divisorSums[sumAtIndex] == num) {
                        answer += num;
                    }
                }
            }

            Console.WriteLine("Answer: {0}", answer);
            Console.ReadKey();
        }

        static int[] getDivisorSums(int until) {
            int[] sums = new int[until];

            // Zero has no factors
            sums[0] = 0;

            // For each number less than our until value, check for every possible factor. If any number is a factor, add it to that index's factor total.
            for (int i = 1; i < until; i++) {
                int total = 1;
                for (int j = 2; j <= i / 2; j++) {
                    if (i % j == 0) {
                        total += j;
                    }
                }
                sums[i] = total;
            }
            return sums;
        }
    }
}
