using System;

namespace DCP_85
{
    /*
    Given three 32-bit integers x, y, and b, return x if b is 1 and y if b is 0, using only mathematical or bit operations. You can assume b can only be 1 or 0.
    */

    public class DCP_85
    {
        public static void Main()
        {
            Console.WriteLine(F(10,20,0) == 20);
            Console.WriteLine(F(10, 20, 1) == 10);
        }

        public static int F(int x, int y, int b)
        {
            return x * b + y * Math.Abs(b - 1);
        }
    }
}