using System;
using System.Linq;

namespace DCP_58
{
    /*
    An sorted array of integers was rotated an unknown number of times.
    Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.
    For example, given the array [13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).
    You can assume all the integers in the array are unique.
    */

    public class DCP_58
    {
        public static void Main()
        {
            Console.WriteLine(TryFindInSortedArray(Console.ReadLine().Split(' ').Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));
        }

        public static int? TryFindInSortedArray(int[] arr, int k)
        {
            if (arr.Length == 0) return null;
            if (k >= arr[0])
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == k) return i;
                    else if (arr[i] > k) return null;
                }
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] == k) return i;
                    else if (arr[i] < k) return null;
                }
            }
            return null;
        }
    }
}
