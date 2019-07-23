using System;
using System.Linq;

namespace DCP_69
{
    /*
    Given a list of integers, return the largest product that can be made by multiplying any three integers.
    For example, if the list is [-10, -10, 5, 2], we should return 500, since that's -10 * -10 * 5.
    You can assume the list has at least three integers.
    */


    public class DCP_69
    {
        public static void Main()
        {
            Console.WriteLine(LargestMultipleOfThreeInts(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int LargestMultipleOfThreeInts(int[] arr)
        {
            if (arr.Length < 3) return 0;
            Array.Sort(arr);

            int a = arr[0] * arr[1] * arr[arr.Length - 1];
            int b = arr[arr.Length - 1] * arr[arr.Length - 2] * arr[arr.Length - 3];

            if (a > b) return a;
            else return b;
        }
    }
}
