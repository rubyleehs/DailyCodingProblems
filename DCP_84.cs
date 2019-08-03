using System;

namespace DCP_84
{
    /*
    Given a matrix of 1s and 0s, return the number of "islands" in the matrix. 
    A 1 represents land and 0 represents water, so an island is a group of 1s that are neighboring whose perimeter is surrounded by water.
    */

    //does diagonal count?
    public class DCP_84
    {
        public static void Main()
        {
            int[,] map = new int[5, 5]
            {
                {0,1,1,0,1 },
                {0,0,1,0,0 },
                {1,1,0,0,0 },
                {1,0,0,1,0 },
                {1,1,0,1,0 }
            };

            Console.WriteLine(GetIslandCount(map));
        }

        public static int GetIslandCount(int[,] map)
        {
            bool[,] check = new bool[map.GetLength(0), map.GetLength(1)];
            int output = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (FloodFill(x, y, map, check)) output++;
                }
            }
            return output;
        }

        private static bool FloodFill(int x, int y, int[,] map, bool[,] check)
        {
            if (map[x, y] == 0 || check[x, y]) return false;
            check[x, y] = true;
            if (x > 0) FloodFill(x - 1, y, map, check);
            if (x < map.GetLength(0) - 1) FloodFill(x + 1, y, map, check);
            if (y > 0) FloodFill(x, y - 1, map, check);
            if (y < map.GetLength(1) - 1) FloodFill(x, y + 1, map, check);

            return true;
        }
    }
}