using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicographicPermutationsChallenge
{
    class Program
    {
        /* See https://projecteuler.net/problem=24 */

        static void Main(string[] args) {
            // Digits are in permutation order.
            string[] digits = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            // Get the 1 millionth permutation of these digits.
            string answer = getPermutationAtNumber(digits, 1000000);
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        // Format as a string vs stringbuilder for the recursive function. Function checks that nth permutation actually exists, otherwise will throw exception.
        static string getPermutationAtNumber(string[] digits, int number) {
            // Make a list of factorials that can be used later in the Recursive function, rather than recalculating.
            int[] factorials = fillFactorials(digits.Length);

            if (number > factorials.Last() || number <= 0) {
                throw new ArgumentException("Cannot get permutation greater than possible permutations or less than one.", nameof(number));
            }

            StringBuilder permutation = getPermutationAtNumberRecursive(digits.ToList(), number, new StringBuilder(digits.Length), factorials);
            return permutation.ToString();
        }

        /* Breakdown of how permutations can be made into a recursive function: 
         * Find the amount of permutations if you had one less digit (factorial of digits count minus 1)
         * Find the amount of times that factorial can fit in the remaining number, maximum.
         * Each time this number is repeated will be a full cycle of the permutations one less digit, so we can subtract this amount, remove that digit, and concatenate to our answer.
         * Call function again with new remaining number, digit string, and ongoing answer.
         * Exit once the remaining number is 1, this is our answer.*/
        static StringBuilder getPermutationAtNumberRecursive(List<string> remainingDigits, int remainingNumber, StringBuilder currentString, int[] factorialsReference) {
            if (remainingNumber == 1) {
                currentString.Append(remainingDigits[0]);
                return currentString;
            }

            int factorialNumber = factorialsReference[remainingDigits.Count() - 1];
            // Integer division truncates automatically.
            int amountFactorialFits = (remainingNumber - 1) / factorialNumber;

            remainingNumber -= factorialNumber * amountFactorialFits;
            currentString.Append(remainingDigits[amountFactorialFits]);
            remainingDigits.RemoveAt(amountFactorialFits);
            return getPermutationAtNumberRecursive(remainingDigits, remainingNumber, currentString, factorialsReference);
        }

        static int[] fillFactorials(int untilInclusive) {
            int[] factorials = new int[untilInclusive + 1];
            factorials[0] = 0;
            factorials[1] = 1;

            for (int i = 2; i <= untilInclusive; i++) {
                factorials[i] = factorials[i - 1] * i;
            }

            return factorials;
        }
    }
}
