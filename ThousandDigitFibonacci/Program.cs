using System;
using System.Numerics;

namespace ThousandDigitFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = GetFibonacciIndexWithDigits(1000);
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static int GetFibonacciIndexWithDigits(int length) {
            int finalIndex = 2;
            BigInteger a = 1;
            BigInteger b = 1;
            while (b.ToString().Length < length) {
                BigInteger temp = b;
                b += a;
                a = temp;
                finalIndex++;
            }
            return finalIndex;
        }
    }
}
