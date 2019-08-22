using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_99
{
    /*
    This problem was asked by Microsoft.
    Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
    For example, given [100, 4, 200, 1, 3, 2], the longest consecutive element sequence is [1, 2, 3, 4]. Return its length: 4.
    Your algorithm should run in O(n) complexity.
    */

    public class DCP_99
    {
        public static void Main()
        {
            Console.WriteLine(LongestConseutiveSequence(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int LongestConseutiveSequence(int[] arr)
        {
            HashSet<int> seq = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                seq.Add(arr[i]);
            }

            int max = 0;
            int val;
            int check;
            for (int i = 0; i < arr.Length; i++)
            {
                val = 1;
                check = arr[i];
                while (seq.Contains(check - 1)) check--;
                while (seq.Contains(check + 1))
                {
                    val++;
                    check++;
                }
                max = Math.Max(max, val);
            }
            return max;
        }
    }
}

