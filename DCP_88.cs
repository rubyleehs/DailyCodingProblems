using System;

namespace DCP_88
{
    /*
        Implement division of two positive integers without using the division, multiplication, or modulus operators. Return the quotient as an integer, ignoring the remainder.
    */

    //There is the obvious solution of just minus till you cant i guess
    //also bit munipulation. 

    public class DCP_88
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine(BruteDivide(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            }
        }
        public static int BruteDivide(int dividend, int divisor)
        {
            int output = 0;
            while (dividend > divisor)
            {
                dividend -= divisor;
                output++;
            }
            return output;
        }
    }
}