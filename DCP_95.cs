using System;
using System.Linq;

namespace DCP_95
{
    /*
    Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic ordering. 
    If there is not greater permutation possible, return the permutation with the lowest value/ordering.
    For example, the list [1,2,3] should return [1,3,2]. The list [1,3,2] should return [2,1,3]. The list [3,2,1] should return [1,2,3].

    Can you perform the operation without allocating extra memory (disregarding the input memory)?
    */

    //dont think it's possible since you would already need memory to rmb the index/point in loops?
    //O(1) you mean? 


    public class DCP_95
    {
        public static void Main()
        {
            int[] input;
            while (true)
            {
                input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                GetGreaterPermutation(input).Write();
            }
        }

        public static int[] GetGreaterPermutation(int[] arr)
        {
            if (arr == null || arr.Length < 2) return arr;

            int k = arr.Length - 1;
            int smallest = k;
            for (; k > 1; k--)
            {
                if (arr[k - 1] < arr[k]) break;
                if (arr[k] < arr[smallest]) smallest = k;
            }

            if (k == 1)
            {
                Array.Reverse(arr);
                return arr;
            }
            else if (k == arr.Length - 1)
            {
                arr.Swap(k, k - 1);
                return arr;
            }
            else
            {
                arr.Swap(k - 1, smallest);
                Array.Sort(arr, k, arr.Length - k);
                return arr;
            }
        }
    }

    public static class Extensions
    {
        public static void Swap<T>(this T[] arr, int indexA, int indexB)
        {
            T temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }

        public static void Write(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine('\n');
        }
    }
}