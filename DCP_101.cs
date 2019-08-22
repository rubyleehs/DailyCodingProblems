using System;

namespace DCP_101
{
    /*
    Given an even number (greater than 2), return two prime numbers whose sum will be equal to the given number.

    If there are more than one solution possible, return the lexicographically smaller solution.
    */

    public class DCP_101
    {
        public static void Main()
        {
            Vector2 output = GetChildPrimes(int.Parse(Console.ReadLine()));
            Console.WriteLine(output.x + " + " + output.y);
        }

        public static Vector2 GetChildPrimes(int n)
        {
            if (n <= 2 || n % 2 == 1) return new Vector2(0, 0);
            if (IsPrime(n - 2)) return new Vector2(2, n - 2);

            for (int i = 3; i < n * 0.5; i += 2)
            {
                if (IsPrime(i) && IsPrime(n - i)) return new Vector2(i, n - i);
            }
            return new Vector2(0, 0);
        }

        public static bool IsPrime(int n)
        {
            if (n <= 3) return (n > 1);
            else if (n % 2 == 0 || n % 3 == 0) return false;
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
                i += 6;
            }
            return true;
        }
    }

    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}



