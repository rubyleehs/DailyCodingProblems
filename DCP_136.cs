using System;

namespace DCP_136
{
    /*
    Given an N by M matrix consisting only of 1's and 0's, find the largest rectangle containing only 1's and return its area.
    For example, given the following matrix:
        [[1, 0, 0, 0],
         [1, 0, 1, 1],
         [1, 0, 1, 1],
         [0, 1, 0, 0]]
    Return 4.
    */

    public class DCP_136
    {
        public static void Main()
        {
            int[,] map = new int[4, 4] {
                { 1, 0, 0, 0 },
                { 1, 0, 1, 1 },
                { 1, 0, 1, 1 },
                { 0, 1, 0, 0 }
                };

            Console.WriteLine(GetLargestSquareSize(map));
        }

        public static int GetLargestSquareSize(int[,] map)
        {
            int[,] cMap = new int[map.GetLength(0), map.GetLength(1)];
            int c;
            for (int dy = 0; dy < map.GetLength(1); dy++)
            {
                c = 0;
                for (int dx = 0; dx < map.GetLength(0); dx++)
                {
                    if (map[dx, dy] > 0) c++;
                    else c = 0;
                    cMap[dx, dy] = c;
                }
            }
            c = 0;
            for (int dx = 0; dx < map.GetLength(0); dx++)
            {
                c = Math.Max(c, AreaHelper(cMap, dx, 0));
            }
            return c;
        }

        public static int AreaHelper(int[,] cMap, int x, int y)
        {
            int maxSize = 0;
            if (y + 1 < cMap.GetLength(1)) maxSize = Math.Max(maxSize, AreaHelper(cMap, x, y + 1));

            int min = cMap[x, y];

            for (int dy = 0; y + dy < cMap.GetLength(1); dy++)
            {
                if (cMap[x, y + dy] <= 0) return maxSize;
                min = Math.Min(min, cMap[x, y + dy]);
                maxSize = Math.Max(maxSize, min * (dy + 1));
            }
            return maxSize;
        }
    }
}
