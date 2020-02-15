using System;
using System.Collections.Generic;

namespace DCP_147
{
    /*
    Given a list, sort it using this method: reverse(lst, i, j), which reverses lst from i to j.
    */

    //Just do a selection sort? unless want min number of flips
    public class DCP_147
    {
        public static void Main()
        {
            List<int> l = new List<int>() { 2, 3, 6, 4, 8, 1, 9, 2, 5, 7, 12, 0 };

            SelectionSortByReversing(l);

            for (int k = 0; k < l.Count; k++)
            {
                Console.Write(l[k] + " ");
            }
        }

        public static void SelectionSortByReversing(List<int> l)
        {
            int minIndex = -1, min;
            for (int i = 0; i < l.Count - 1; i++)
            {
                min = Int32.MaxValue;
                for (int j = i; j < l.Count; j++)
                {
                    if (l[j] < min)
                    {
                        min = l[j];
                        minIndex = j;
                    }
                }
                l.Reverse(i, minIndex - i + 1);
            }
        }

    }
}
