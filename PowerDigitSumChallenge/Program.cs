using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerDigitSumChallenge
{
    class Program
    {
        static void Main(string[] args) {
            List<int> numberAsList = new List<int> { 1 };

            for (int i = 1; i <= 1000; i++) {
                for (int j = numberAsList.Count() - 1; j >= 0; j--) {
                    numberAsList[j] *= 2;
                }
                for (int j = numberAsList.Count() - 1; j >= 0; j--) {
                    if (numberAsList[j] >= 10) {
                        numberAsList[j] -= 10;
                        if (j > 0) {
                            numberAsList[j - 1] += 1;
                        }
                        else {
                            numberAsList.Insert(0, 1);
                        }
                    }
                }
            }

            int answer = numberAsList.Aggregate((runningTotal, next) => runningTotal + next);

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
