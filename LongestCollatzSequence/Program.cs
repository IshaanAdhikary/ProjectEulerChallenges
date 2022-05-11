using System;

namespace LongestCollatzSequence
{
    class Program
    {
        static void Main(string[] args) {
            uint answer = 0;
            uint maxCount = 0;
            for (uint i = 1; i < 1000000; i++) {
                if (i % 50000 == 0) {
                    Console.WriteLine("{0} of 20", i / 50000);
                }

                uint[] currentCount = CollatzSteps(i);
                if (currentCount[0] > maxCount) {
                    maxCount = currentCount[0];
                    answer = currentCount[1];
                }
            }

            Console.WriteLine("{1}: {0}", maxCount, answer);
            Console.ReadKey();
        }

        static uint[] CollatzSteps(uint n) {
            uint count = 0;
            uint num = n;

            while (true) {
                count++;
                if (num == 1) {
                    return new uint[2] { count, n };
                }
                else if (num % 2 == 0) {
                    num = num / 2;
                }
                else {
                    num = 3 * num + 1;
                }
            }
        }
    }
}
