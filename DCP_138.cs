using System;

namespace DCP_138
{
    /*
    Find the minimum number of coins required to make n cents.
    You can use standard American denominations, that is, 1¢, 5¢, 10¢, and 25¢.
    For example, given n = 16, return 3 since we can make it with a 10¢, a 5¢, and a 1¢.
    */

    public class DCP_138
    {
        public static readonly int[] denom = new int[4] { 25, 10, 5, 1 };
        public static int MinNumOfCoins(int n)
        {
            if (n <= 0) return 0;
            int remainder = n;
            int d = 0;
            int count = 0;
            while (remainder > 0)
            {
                while (remainder - denom[d] < 0) d++;
                count++;
                remainder -= denom[d];
            }
            return count;
        }
    }
}
