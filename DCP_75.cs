using System;
using System.Linq;

namespace DCP_75
{
    /*
    Given an array of numbers, find the length of the longest increasing subsequence in the array. The subsequence does not necessarily have to be contiguous.
    For example, given the array [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15], the longest increasing subsequence has length 6: it is 0, 2, 6, 9, 11, 15.
    */
    public class DCP_75
    {
        public static void Main()
        {
            Console.WriteLine(GetLongestIncreasingSubsequenceLength(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int GetLongestIncreasingSubsequenceLength(int[] arr)
        {
            if (arr.Length <= 1) return arr.Length;

            int[] counter = new int[arr.Length];
            int max;

            for (int i = 0; i < arr.Length; i++)
            {
                max = -999999;
                for (int ii = i - 1; ii >= 0; ii--)
                {
                    if (arr[ii] <= max) break;
                    if (arr[ii] > arr[i]) continue;
                    max = arr[ii];
                    if (counter[i] <= counter[ii])
                    {
                        counter[i] = counter[ii] + 1;
                    }
                }
            }

            max = 0;
            for (int i = 0; i < counter.Length; i++)
            {
                max = Math.Max(counter[i], max);
            }

            return max + 1;
        }
    }
}