using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSundaysChallenge
{
    /* See https://projecteuler.net/problem=19 */

    class Program
    {
        // April, June, September, and November Numerical Orders
        static readonly int[] shortMonths = new int[4] { 4, 6, 9, 11 };
        // Unneccesary, but useful for understanding: static readonly int[] longMonths = new int[7] { 1, 3, 5, 7, 8, 10, 12};

        static void Main(string[] args) {
            int[] daysIndexFromStart = getFirstOfMonths();
            int answer = getAmountOfSundays(daysIndexFromStart);

            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static int getAmountOfSundays(int[] days) {
            int total = 0;

            for (int i = 0; i < days.Length; i++) {
                // Jan. 1, 1901 was a Tuesday, so Mondays are on every multiple, and Sundays are one less then every multiple, or a remainder of 6.
                if (days[i] % 7 == 6) {
                    total++;
                }
            }

            return total;
        }

        // Get the amount of days since the start of the region as a number for the first of every month.
        static int[] getFirstOfMonths() {
            List<int> days = new List<int>();
            int currentDaySinceStart = 1;

            for (int year = 1901; year <= 2000; year++) {
                for (int month = 1; month <= 12; month++) {
                    days.Add(currentDaySinceStart);

                    // Feburary is always a special case
                    if (month == 2) {
                        // On leap years
                        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
                            currentDaySinceStart += 29;
                        }
                        else {
                            currentDaySinceStart += 28;
                        }
                    }
                    else if (shortMonths.Contains(month)) {
                        currentDaySinceStart += 30;
                    }
                    else /* (Month is a long month) */ {
                        currentDaySinceStart += 31;
                    }
                }
            }

            return days.ToArray();
        }
    }
}
