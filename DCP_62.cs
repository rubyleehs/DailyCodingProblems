using System;

namespace DCP_62
{
    /*
    There is an N by M matrix of zeroes. Given N and M, write a function to count the number of ways of starting at the top-left corner and getting to the bottom-right corner. You can only move right or down.
    For example, given a 2 by 2 matrix, you should return 2, since there are two ways to get to the bottom-right:
    •	Right, then down
    •	Down, then right
    Given a 5 by 5 matrix, there are 70 ways to get to the bottom-right.

    */

    public class DCP_62
    {
        public static void Main()
        {
            Console.WriteLine(NumWaysToGetToOppositeCorner(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine())));
        }


        public static int NumWaysToGetToOppositeCorner(int x, int y)
        {
            if (x <= 0 || y <= 0) return 0;
            int[,] grid = new int[x, y];
            for (int iy = 0; iy < y; iy++)
            {
                for (int ix = 0; ix < x; ix++)
                {
                    if (ix * iy == 0) grid[ix, iy] = 1;
                    else
                    {
                        grid[ix, iy] = grid[ix - 1, iy] + grid[ix, iy - 1];
                    }
                }
            }
            return grid[x - 1, y - 1];
        }
    }
}