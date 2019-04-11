using System;

namespace DCP_09
{
    //Given a list of integers, write a function that returns the largest sum of non-adjacent numbers.Numbers can be 0 or negative.
    //For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
    //Follow-up: Can you do this in O(N) time and constant space?

    public class DCP_09
    {
        public static void Main()
        {
            String input = Console.ReadLine();
            float result = LargestSumOfNonAdjacentNum(input.Split(' ').Select(float.Parse).ToArray());

            Console.WriteLine(result);
        }

        public static float LargestSumOfNonAdjacentNum(float[] nums)
        {
            if (nums.Length <= 0) return 0;
            if (nums.Length == 1) return nums[0];

            float sum0 = 0;
            float sum1 = 0;

            for (int i = 0; i < nums.Length; i += 2)
            {
                sum1 = Math.Max(sum0, sum1);
                if (nums[i] > 0) sum0 += nums[i];

                if (i != nums.Length - 1)
                {
                    if (nums[i + 1] > 0) sum1 += nums[i + 1];
                }
            }

            return Math.Max(sum0, sum1);
        }

    }
}