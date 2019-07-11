using System;
using System.Collections.Generic;

namespace DCP_56
{
    /*
    Given an undirected graph represented as an adjacency matrix and an integer k, 
    write a function to determine whether each vertex in the graph can be colored such that no two adjacent vertices share the same color using at most k colors.
    */
    
    public class DCP_56
    {
        public static void Main()
        {
            bool[,] matrix1 = new bool[4, 4]
            {
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
            };

            bool[,] matrix2 = new bool[4, 4]
            {
                { false, true, false, false },
                { false, false, true, false },
                { false, false, false, true },
                { true, false, false, false },
            };

            bool[,] matrix3 = new bool[4, 4]
            {
                { false, true, true, false },
                { true, false, true, false },
                { true, true, false, false },
                { false, false, false, false },
            };

            bool[,] matrix4 = new bool[4, 4]
            {
                { false, true, true, true },
                { true, false, true, true },
                { true, true, false, true },
                { true, true, true, false },
            };

            Console.WriteLine(FindMinColors(matrix1));
            Console.WriteLine(FindMinColors(matrix2));
            Console.WriteLine(FindMinColors(matrix3));
            Console.WriteLine(FindMinColors(matrix4));
            //should return 1 2 3 4
        }

        public static int FindMinColors(bool[,] matrix, int[] colors = null)
        {
            int minColors = 0;
            int numOfNodes = matrix.GetLength(0);
            if (colors == null) colors = new int[numOfNodes];

            for (int i = 0; i < numOfNodes; i++)
            {
                if (colors[i] <= 0)
                {
                    HashSet<int> positiveNumbers = new HashSet<int>();
                    for (int x = 0; x < numOfNodes; x++)
                    {
                        if (matrix[x, i]) positiveNumbers.Add(colors[x]);
                    }

                    int missingPositveInt = 1;
                    while (true)
                    {
                        if (positiveNumbers.Contains(missingPositveInt)) missingPositveInt++;
                        else break;
                    }

                    int[] nc = colors;
                    nc[i] = missingPositveInt;
                    minColors = Math.Max(missingPositveInt, minColors);
                    minColors = Math.Max(minColors, FindMinColors(matrix, nc));
                }
            }
            return minColors;
        }
    }
}