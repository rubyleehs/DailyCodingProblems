using System;
using System.Linq;

namespace DCP_02
{
    public class DCP_02
    {
        //Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
        //For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
        //Follow-up: what if you can't use division?


        public static void Main()
        {
            String input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            int[] output = MultipleOfAllButIndex(numbers);
            String s = "";
            for (int i = 0; i < output.Length; i++)
            {
                s += " " + output[i];
            }

            Console.WriteLine(s);
        }


        public static int[] MultipleOfAllButIndex(int[] input)
        {
            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = 1;
                for (int n = 0; n < input.Length; n++)
                {
                    if (i == n) continue;
                    output[i] *= input[n];
                }
            }

            return output;
        }
    }
}