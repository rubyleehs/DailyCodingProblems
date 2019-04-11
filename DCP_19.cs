using System;
using System.Linq;

namespace DCP_19
{
    /*
        A builder is looking to build a row of N houses that can be of K different colors. He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
        Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.
    */

    public class DCP_19
    {
        public static float[][] housePricing;

        public static void Main()
        {
            //I know this is not a matix but bleh
            housePricing = new float[5][]
            {
                new float[5] {0,2,2,3,-1},
                new float[5] {2,3,1,2,4},
                new float[5] {0,4,-3,3,2},
                new float[5] {0,2,1,2,3},
                new float[5] {0,3,1,4,2}
            };

            Console.WriteLine(BruteMinCostToBuildRow(0, -1));
        }


        public static float BruteMinCostToBuildRow(int n, int prevIndex)
        {
            if (n >= housePricing.Length) return 0;
            float[] a = new float[housePricing[n].Length];

            for (int i = 0; i < housePricing[n].Length; i++)
            {
                if (i == prevIndex)
                {
                    a[i] = 9999999999;
                    continue;
                };

                a[i] = housePricing[n][i] + BruteMinCostToBuildRow(n + 1, i);
            }
            float min = a.Min();
            return min;
        }

    }
}
