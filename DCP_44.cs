using System;
using System.Linq;

namespace DCP_44
{
    /*
    We can determine how "out of order" an array A is by counting the number of inversions it has. Two elements A[i] and A[j] form an inversion if A[i] > A[j] but i < j. That is, a smaller element appears after a larger element.
    Given an array, count the number of inversions it has. Do this faster than O(N^2) time.
    You may assume each element in the array is distinct.
    For example, a sorted list has zero inversions. The array [2, 4, 1, 3, 5] has three inversions: (2, 1), (4, 1), and (4, 3). The array [5, 4, 3, 2, 1] has ten inversions: every distinct pair forms an inversion.
    */

    //aka an optimized bubble sort?

    public class DCP_44
    {
        public static void Main()
        {
            Console.WriteLine(GetInversions(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int GetInversions(int[] arr)
        {
            int[] cal = arr;

            int inversions = 0;
            bool hasChanged;
            for (int i = 0; i < cal.Length; i++)
            {
                hasChanged = false;
                for (int ii = 0; ii < cal.Length - i - 1; ii++)
                {
                    if (cal[ii] > cal[ii + 1])
                    {
                        cal.Swap(ii, ii + 1);
                        hasChanged = true;
                        inversions++;
                    }
                }
                if (!hasChanged) break;
            }

            return inversions;
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
    }
}