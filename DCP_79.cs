using System;
using System.Linq;

namespace DCP_79
{
    /*
    Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
    For example, given the array [10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
    Given the array [10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.
    */

    public class DCP_79
    {
        public static void Main()
        {
            Console.WriteLine(CanBeNonDecreasingArray(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static bool CanBeNonDecreasingArray(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return true;

            bool counter = false;
            int largestValue = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] >= largestValue)
                {
                    largestValue = arr[i];
                    continue;
                }
                if (counter) return false;
                counter = true;
                if (i == 1) largestValue = arr[1];
                else if (arr[i] < arr[i - 2]) continue;
                else largestValue = arr[i];
            }
            return true;
        }
    }
}
