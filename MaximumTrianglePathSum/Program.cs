using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MaximumTrianglePathSum
{
    class Program
    {
        /* See https://projecteuler.net/problem=18 and https://projecteuler.net/problem=67 */

        static void Main(string[] args) {
            int[][] triangleArray = InitializeTriangle();
            int[][] solvedTriangle = getBestSum(triangleArray);

            // The answer will be the only element of the top row of sums.
            int answer = solvedTriangle[0][0];
            Console.WriteLine("Best Sum: {0}", answer);
            Console.ReadKey();
        }

        static int[][] getBestSum(int[][] triangle) {
            /* Using dynamic programming tabulation, make a triangle array the same size as the input for the table. Since the bottom starts adding from
             zero, we can fill in the last row with the same last row as the input triangle.*/
            int[][] solvedTriangle = new int[triangle.Length][];
            solvedTriangle[solvedTriangle.Length - 1] = triangle[triangle.Length - 1];

            // For each row of the triangle except the last, make an array of the best sum using previous sums and return that to the respective row of the triangle.
            for (int row = triangle.Length - 2; row >= 0; row--) {
                // Each row had the same amount of items as it's row number, and we need to add one because we start at index 0
                int[] rowContents = new int[row + 1];
                for (int i = 0; i < rowContents.Length; i++) {
                    /* For each row element, find the bigger of the two possible best sums it can use. This element should be that number plus this
                     * element on the original triangle. The path will always go down, either to the left (same index) or to the right (+1 index) */
                    rowContents[i] = Math.Max(solvedTriangle[row + 1][i], solvedTriangle[row + 1][i + 1]) + triangle[row][i];
                }
                solvedTriangle[row] = rowContents;
            }

            return solvedTriangle;
        }

        static int[][] InitializeTriangle() {
            // Get Operating Directory
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            // Get Triangle based off of file; rename this line to either triangle1 or triangle2 depending on which to use, or another file.
            string[] rawTriangleText = File.ReadAllLines(Path.Combine(projectPath, @"Source\triangle2.txt"));
            int[][] result = new int[rawTriangleText.Length][];

            string[][] rawTriangleTextArray = new string[rawTriangleText.Length][];

            for (int i = 0; i < rawTriangleText.Length; i++) {
                rawTriangleTextArray[i] = rawTriangleText[i].Split(' ');
                result[i] = new int[rawTriangleTextArray[i].Length];
                for (int j = 0; j < rawTriangleTextArray[i].Length; j++) {
                    result[i][j] = Int32.Parse(rawTriangleTextArray[i][j]);
                }
            }

            return result;
        }
    }
}
