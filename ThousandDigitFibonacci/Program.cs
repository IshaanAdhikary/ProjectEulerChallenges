using System;

namespace ThousandDigitFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = GetFibonacciWithDigits(1000);
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static int GetFibonacciWithDigits(int length) {
            int finalIndex;
            int a = 1;
            int aPow = 0;
            int b = 1;
            int bPow = 0;
            for (finalIndex = 3; true; finalIndex++) {
                if (a.ToString().Length > 7) {
                    aPow += a.ToString().Length - 7;
                    a = Int32.Parse(a.ToString().Substring(0, 7));
                }
                if (b.ToString().Length > 7) {
                    bPow += b.ToString().Length - 7;
                    b = Int32.Parse(b.ToString().Substring(0, 7));
                }
                int temp = b;
                b += a;
                if (b.ToString().Length + bPow >= 1000){
                    break;
                }
                a = temp;
            }
            return finalIndex;
        }
    }
}
