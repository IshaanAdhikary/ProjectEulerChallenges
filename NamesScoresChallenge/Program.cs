using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NamesScoresChallenge
{
    class Program
    {
        static void Main(string[] args) {
            List<string> namesList = getNamesInAlphabeticalOrder();
            int[] nameValue = new int[namesList.Count];

            for (int i = 0; i < namesList.Count(); i++) {
                int wordScore = 0;
                char[] name = namesList.ElementAt(i).ToCharArray();
                foreach (char letter in name) {
                    wordScore += (int) letter - 64;
                }
                nameValue[i] = wordScore * (i + 1);
            }

            int answer = nameValue.Aggregate(0, (runningTotal, next) => runningTotal + next);
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static List<string> getNamesInAlphabeticalOrder() {
            // Get Operating Directory
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            // Get name score file.
            string namesRaw = File.ReadAllText(Path.Combine(projectPath, @"names.txt")).ToUpper();
            namesRaw = namesRaw.Replace("\"", String.Empty);
            string[] namesList = namesRaw.Split(',');

            return (from name in namesList orderby name select name).ToList();
        }
    }
}