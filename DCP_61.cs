using System;

namespace DCP_61
{
    /*
    Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
    Do this faster than the naive method of repeated multiplication.
    For example, pow(2, 10) should return 1024.
    */

    public class DCP_61
    {
        public static void Main()
        {
            Console.WriteLine(Pow(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine())));
        }


        public static float Pow(int x, int exponent)
        {
            if (exponent < 0) return (1 / Pow(x, -exponent));
            if (exponent == 0) return 1;
            if (exponent == 1) return x;
            if (exponent % 2 == 0) return Pow(x * x, exponent / 2);
            else return (Pow(x * x, (exponent - 1) / 2) * x);
        }
    }
}