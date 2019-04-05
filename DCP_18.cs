using System;
using System.Linq;

namespace DCP_18
{
    /*
    Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.
    For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:
    •	10 = max(10, 5, 2)
    •	7 = max(5, 2, 7)
    •	8 = max(2, 7, 8)
    •	8 = max(7, 8, 7)
    Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
    */

    //is this O(k) space? It is creating a new array each time. hmmm.
    
    public class DCP_18
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            LargestValueAround(input, k);
        }

        public static void LargestValueAround(int[] array, int k)
        {
            if (k <= 0) return;
            for (int i = 0; i <= array.Length - k; i++)
            {
                int max = SubArray(array, i, k).Max();
                Console.WriteLine(max);
            }
        }

        public static T[] SubArray<T>(T[] data, int startIndex, int length)
        {
            T[] o = new T[length];
            Array.Copy(data, startIndex, o, 0, length);
            return o;
        }
    }
}