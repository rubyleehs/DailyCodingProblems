using System;
using System.Collections.Generic;

namespace DCP_129
{
    /*
    Given a real number n, find the square root of n. For example, given n = 9, return 3.
    */

    public class DCP_129
    {
        public static void Main()
        {
            Console.WriteLine(SquareRoot(9));
        }

        public static float SquareRoot(int number)
        {
            float precision = 0.0001f;
            float min = 0;
            float max = number;
            float result = 0;
            while (max - min > precision)
            {
                result = (min + max) / 2;
                if ((result * result) >= number)
                {
                    max = result;
                }
                else
                {
                    min = result;
                }
            }
            return result;
        }


    }
}
