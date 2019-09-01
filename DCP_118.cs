using System;

namespace DCP_118
{
    /*
    Given a sorted list of integers, square the elements and give the output in sorted order.
    For example, given [-9, -2, 0, 2, 3], return [0, 4, 4, 9, 81].
    */

    public class DCP_118
    {
        public static void Main()
        {
            int[] arr = new int[5] { -9, -2, 0, 2, 3 };
            int[] output = SquareAndSortSortedList(arr);

            for (int ii = 0; ii < output.Length; ii++)
            {
                Console.WriteLine(output[ii]);
            }
        }

        public static int[] SquareAndSortSortedList(int[] arr)
        {
            int[] output = new int[arr.Length];
            int pIndex = -1, nIndex = -1;

            for (int ii = 0; ii < arr.Length; ii++)
            {
                if (arr[ii] >= 0)
                {
                    nIndex = ii - 1;
                    pIndex = ii;
                    break;
                }
            }

            int i = 0;
            while (nIndex >= 0 && pIndex < arr.Length)
            {
                if (arr[pIndex] + arr[nIndex] > 0)
                {
                    output[i] = (int)Math.Pow(arr[nIndex], 2);
                    nIndex--;
                }
                else
                {
                    output[i] = (int)Math.Pow(arr[pIndex], 2);
                    pIndex++;
                }
                i++;
            }

            while (pIndex < arr.Length)
            {
                output[i] = (int)Math.Pow(arr[pIndex], 2);
                pIndex++;
                i++;
            }
            while (nIndex >= 0)
            {
                output[i] = (int)Math.Pow(arr[nIndex], 2);
                nIndex--;
                i++;
            }

            return output;
        }
    }
}