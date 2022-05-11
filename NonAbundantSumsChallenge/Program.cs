using System;
using System.Collections.Generic;
using System.Linq;

namespace NonAbundantSumsChallenge
{
    class Program
    {
        /* See https://projecteuler.net/problem=23 */
        /* Process: make a list of all abundant numbers
         * Check if all numbers <= 28123 can be made as the sum of any two numbers in this list. 
         * If not, add to a total. */

        static void Main(string[] args) {
            int answer = findSumOfAllNotAbundantSums();
            Console.WriteLine(answer);

            Console.ReadKey();
        }

        static int findSumOfAllNotAbundantSums() {
            int[] abundantNumbers = abundantNumbersUntil(28123);
            int total = 0;

            for (int i = 1; i <= 28123; i++) {
                // Check if i can be represented as a sum of two numbers in abundantNumbers, and add to the total if not.
                if (!canBeTotalFromTwoElements(i, abundantNumbers)) {
                    total += i;
                }
            }

            return total;
        }

        /* Process: for each value in an array, add it's subtractive inverse in relation to the target number to a hashset.
        *  If the value is already in the hashset or the value is half of the target (we can add it to itself), then return true and exit the function.
        *  If it never returns true, then it can not be done. */
        static bool canBeTotalFromTwoElements(int num, int[] arr) {
            HashSet<int> neededForTotal = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++) {
                if (neededForTotal.Contains(arr[i]) || 2 * arr[i] == num) {
                    return true;
                }
                else if (num - arr[i] < 0) {
                    break;
                }
                neededForTotal.Add(num - arr[i]);
            }
            return false;
        }

        static int[] abundantNumbersUntil(int untilInclusive) {
            List<int> abundantNumbersReturn = new List<int>();

            // For each number less than our until value, check for every possible factor. If any number is a factor, add it to that index's factor total.
            for (int i = 12; i <= untilInclusive; i++) {
                int total = 1;
                for (int j = 2; j <= i / 2; j++) {
                    if (i % j == 0) {
                        total += j;
                    }
                }
                // If factor total is greater than the number, it's abundant, and should be added to the list.
                if (total > i) {
                    abundantNumbersReturn.Add(i);
                }
            }

            return abundantNumbersReturn.ToArray();
        }
    }
}
