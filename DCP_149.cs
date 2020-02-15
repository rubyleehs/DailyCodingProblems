using System;

namespace DCP_149
{
    /*
    Given a list of numbers L, implement a method sum(i, j) which returns the sum from the sublist L[i:j] (including i, excluding j).
    For example, given L = [1, 2, 3, 4, 5], sum(1, 3) should return sum([2, 3]), which is 5.
    You can assume that you can do some pre-processing. sum() should be optimized over the pre-processing step.
    */

    public class DCP_149
    {
        public static void Main()
        {
            int[] arr = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
            int[] arr1 = PreprocessArrForRangeSum(arr);
            Console.WriteLine(SumProcessedArray(arr1, 2, 6));
        }

        public static int[] PreprocessArrForRangeSum(int[] arr)
        {
            int[] output = new int[arr.Length];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                output[i] = sum;
            }
            return output;
        }

        public static int SumProcessedArray(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex < 0 || startIndex > arr.Length - 1) throw new ArgumentOutOfRangeException("startIndex");
            if (endIndex < 0 || endIndex > arr.Length - 1) throw new ArgumentOutOfRangeException("endIndex");
            if (startIndex == 0) return arr[endIndex];
            return arr[endIndex] - arr[startIndex - 1];
        }
    }
}
