using System;
using System.Collections.Generic;

namespace DCP_144
{
    /*
    Given an array of numbers and an index i, return the index of the nearest larger number of the number at index i, where distance is measured in array indices.
    For example, given [4, 1, 3, 5, 6] and index 0, you should return 3.
    If two distances to larger numbers are the equal, then return any one of them. If the array at i doesn't have a nearest larger integer, then return null.
    Follow-up: If you can preprocess the array, can you do this in constant time?
    */

    public class DCP_144
    {
        public static void Main()
        {
            int[] arr = new int[5] { 4, 1, 3, 5, 6 };

            CustomIntArray cArr = new CustomIntArray(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(cArr.GetClosestLargestNumIndex(i));
            }
        }
    }

    public class CustomIntArray
    {
        public int[] arr;
        public int?[] processedArr;

        public CustomIntArray(int[] arr)
        {
            UpdateIntArr(arr);
        }

        public void UpdateIntArr(int[] arr)
        {
            this.arr = arr;
            processedArr = new int?[arr.Length];
        }

        public int GetClosestLargestNumIndex(int index)
        {
            if (processedArr[index].HasValue) return processedArr[index].Value;

            int num = arr[index];
            int d = 0;
            int output = -1;
            for (int i = index + 1; i < arr.Length; i++)
            {
                if (arr[i] <= num) continue;
                d = i - index;
                output = i;
                break;
            }
            for (int i = index - 1; i >= 0; i--)
            {
                if (arr[i] <= num) continue;
                if (d > index - i) output = i;
                return output;
            }
            processedArr[index] = output;
            return output;
        }
    }
}
