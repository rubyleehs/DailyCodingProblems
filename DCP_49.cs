using System;
using System.Linq;

namespace DCP_49
{
    /*
    Given an array of numbers, find the maximum sum of any contiguous subarray of the array.
    For example, given the array [34, -50, 42, 14, -5, 86], the maximum sum would be 137, since we would take elements 42, 14, -5, and 86.
    Given the array [-5, -1, -8, -9], the maximum sum would be 0, since we would not take any elements.
    Do this in O(N) time.
    */

    //Lol. exactly the same as DCP_47


    public class DCP_49
    {
        public static void Main()
        {
            Console.WriteLine(GetMaxContiguousSum(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int GetMaxContiguousSum(int[] arr)
        {
            if (arr.Length <= 0) return 0;

            int maxVal = 0;
            int currentVal = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentVal += arr[i];

                if (currentVal > maxVal) maxVal = currentVal;
                if (currentVal < 0) currentVal = 0;
            }

            return maxVal;
        }
    }
}