using System;
using System.Linq;

namespace DCP_102
{
    /*
    Given a list of integers and a number K, return which contiguous elements of the list sum to K.
    For example, if the list is [1, 2, 3, 4, 5] and K is 9, then it should return [2, 3, 4], since 2 + 3 + 4 = 9.
    */

    public class DCP_102
    {
        public static void Main()
        {
            int[] arr2 = GetContiguousSumEqualK(Console.ReadLine().Split(' ').Select(int.Parse).ToArray(), int.Parse(Console.ReadLine()));
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
        }

        //assuming all positives, otherwise prob need recursive?
        public static int[] GetContiguousSumEqualK(int[] arr, int k)
        {
            int cSum = 0;
            int startIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                cSum += arr[i];

                while (cSum > k)
                {
                    cSum -= arr[startIndex];
                    startIndex++;
                }
                if (cSum == k)
                {
                    int[] output = new int[i - startIndex + 1];
                    Array.Copy(arr, startIndex, output, 0, i - startIndex + 1);
                    return output;
                }
            }
            return null;
        }
    }
}