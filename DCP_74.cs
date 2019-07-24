using System;

namespace DCP_74
{
    /*
    Suppose you have a multiplication table that is N by N. That is, a 2D array where the value at the i-th row and j-th column is (i + 1) * (j + 1) (if 0-indexed) or i * j (if 1-indexed).
    Given integers N and X, write a function that returns the number of times X appears as a value in an N by N multiplication table.
    */

    public class DCP_74
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine(GetNumApperanceInMultiTable(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            }
        }

        public static int GetNumApperanceInMultiTable(int num, int tableSize)
        {
            if (num <= 0 || tableSize <= 0) return 0;
            if (num == 1) return num;
            int output = 0;
            int half = num / 2;
            for (int i = 1; i <= half && i <= tableSize; i++)
            {
                if (num % i == 0 && num / i <= tableSize) output++;
            }
            return output;
        }
    }
}