using System;

namespace DCP_140
{
    /*
    This problem was asked by Facebook.
    Given an array of integers in which two elements appear exactly once and all other elements appear exactly twice, find the two elements that appear only once.
    For example, given the array [2, 4, 6, 8, 10, 2, 6, 10], return 4 and 8. The order does not matter.
    Follow-up: Can you do this in linear time and constant space?

    */

    //O(n) time add to hashset if its isnt and remove if it is.
    //O(n) time an O(1) space by XOR-ing all numbers while keeping track of a number only seen once and the XOR again with that. and also track 0 count

    public class DCP_140
    {
        public static void Main()
        {
            int[] input = new int[8] { 2, 4, 6, 8, 10, 2, 6, 10 };
            int[] output;

            output = GetOddAppearances(input);
            Console.WriteLine(output[0] + "," + output[1]);
        }

        //returns numbers that appear odd times. only work if 0-2 numbers appear odd times in entire array. returns 0 for if 0 appear odd times of no odd appearance numbers
        public static int[] GetOddAppearances(int[] arr)
        {
            int totXor = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                totXor = totXor ^ arr[i];
            }

            //totXor will equal to XOR of both numbers. 
            //Which means if we choose one of totXor bit set to 1, filter the entire array for only numbers which has the same bit set to 1, we get one of the numbers.

            int rightMostBit = totXor & ~(totXor - 1);
            int partialXor = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] & rightMostBit) != 0) partialXor = partialXor ^ arr[i];
            }

            return new int[2] { partialXor, totXor ^ partialXor };
        }
    }
}
