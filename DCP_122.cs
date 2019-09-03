using System;

namespace DCP_122
{
    /*
    You are given a 2-d matrix where each cell represents number of coins in that cell. 
    Assuming we start at matrix[0][0], and can only move right or down, 
    find the maximum number of coins you can collect by the bottom right corner.
    */

    //Quite alot of practically duplicated questions

    public class DCP_122
    {
        public static int MaxCoins(int[,] coinMap)
        {
            int[,] sumMap = coinMap;

            //3 loops instead of having ifs. faster that way
            for (int y = 1; y < coinMap.GetLength(1); y++)
            {
                sumMap[0, y] += sumMap[0, y - 1];
            }
            for (int x = 1; x < coinMap.GetLength(0); x++)
            {
                sumMap[x, 0] += sumMap[x - 1, 0];
            }
            for (int y = 1; y < coinMap.GetLength(1); y++)
            {
                for (int x = 1; x < coinMap.GetLength(0); x++)
                {
                    sumMap[x, y] += Math.Max(sumMap[x - 1, y], sumMap[x, y - 1]);
                }
            }

            return sumMap[coinMap.GetLength(0), coinMap.GetLength(1)];
        }
    }
}
