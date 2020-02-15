using System;
using System.Collections.Generic;

namespace DCP_143
{
    /*
    Given a pivot x, and a list lst, partition the list into three parts.
        •	The first part contains all elements in lst that are less than x
        •	The second part contains all elements in lst that are equal to x
        •	The third part contains all elements in lst that are larger than x
    Ordering within a part can be arbitrary.
    For example, given x = 10 and lst = [9, 12, 3, 5, 14, 10, 10], one partition may be [9, 3, 5, 10, 10, 12, 14].
    */

    public class DCP_143
    {
        public static void Main()
        {
            List<int> l = new List<int> { 9, 12, 3, 5, 14, 10, 10 };
            PivotList(l, 10);
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i] + " ");
            }
        }

        public static void PivotList(List<int> l, int p)
        {
            int end = l.Count;
            for (int i = 0; i < end; i++)
            {
                if (l[i] > p)
                {
                    l.Add(l[i]);
                    l.RemoveAt(i);
                    end--;
                }
                else if (l[i] < p)
                {
                    l.Insert(0, l[i]);
                    l.RemoveAt(i + 1);
                }
            }
        }
    }
}
