using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_04
{
    //Given an array of integers, find the first missing positive integer in linear time and constant space.In other words, find the lowest positive integer that does not exist in the array.The array can contain duplicates and negative numbers as well.
    //For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3

    public class DCP_04
    {
        public static void Main()
        {
            String input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(FirstMissingPositiveInt(numbers));
        }

        public static int FirstMissingPositiveInt(int[] intArray)
        {
            HashSet<int> positiveNumbers = new HashSet<int>();

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] > 0) positiveNumbers.Add(intArray[i]);
            }

            int missingPositveInt = 1;
            while (true)
            {
                if (positiveNumbers.Contains(missingPositveInt)) missingPositveInt++;
                else break;
            }

            return missingPositveInt;

        }

        //Why is this under Hard?
        //Not too sure if linear time and space and everyone online didnt do current method. WHY?????
    }
}
