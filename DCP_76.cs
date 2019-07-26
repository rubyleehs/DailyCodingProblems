using System;

namespace DCP_76
{
    /*
    You are given an N by M 2D matrix of lowercase letters. 
    Determine the minimum number of columns that can be removed to ensure that each row is ordered from top to bottom lexicographically. 
    That is, the letter at each column is lexicographically later as you go down each row. It does not matter whether each row itself is ordered lexicographically.
    */
    public class DCP_76
    {
        public static void Main()
        {
            char[,] m = new char[3, 3]{
                {'c','b','a'  },
                {'d', 'a', 'f'},
                {'g', 'h', 'i'}
            };

            Console.WriteLine(NumColumnsToRemove(m));
        }

        public static int NumColumnsToRemove(char[,] matrix)
        {
            int output = 0;
            char prev;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                prev = matrix[0, x];
                for (int y = 1; y < matrix.GetLength(1); y++)
                {
                    if (matrix[y, x] < prev)
                    {
                        output++;
                        //Console.WriteLine(">" + x + "|" + y + '=' + matrix[x, y] );
                        break;
                    }
                    else prev = matrix[y, x];
                }
            }
            return output;
        }
    }
}