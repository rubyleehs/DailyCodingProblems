using System;
using System.Collections.Generic;

namespace DCP_77
{
    /*
    Given a list of possibly overlapping intervals, return a new list of intervals where all overlapping intervals have been merged.
    The input list is not necessarily ordered in any way.
    For example, given [(1, 3), (5, 8), (4, 10), (20, 25)], you should return [(1, 3), (4, 10), (20, 25)].
    */

    public class DCP_77
    {
        public static void Main()
        {
            List<Vector2> li = new List<Vector2>()
            {
               new Vector2(1,3),
               new Vector2(5,8),
               new Vector2(4,10),
               new Vector2(20,25)
            };
            List<Vector2> l1 = MergeIntervals(li);
            for (int i = 0; i < l1.Count; i++)
            {
                l1[i].Print();
            }
        }

        //Can also use stacks
        public static List<Vector2> MergeIntervals(List<Vector2> li)
        {
            if (li == null || li.Count == 0) return null;
            if (li.Count == 1) return li;

            List<Vector2> output = new List<Vector2>();

            li.Sort();
            output.Add(li[0]);
            Vector2 temp;
            for (int i = 1; i < li.Count; i++)
            {
                temp = output[output.Count - 1];
                if (li[i].x <= temp.y)
                {
                    output[output.Count - 1] = new Vector2(temp.x, Math.Max(li[i].y, temp.y));
                }
                else output.Add(li[i]);
            }
            return output;
        }
    }

    public struct Vector2 : IComparable
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Object other)
        {
            if (this.x > ((Vector2)other).x) return 1;
            else return -1;
        }

        public void Print()
        {
            Console.WriteLine("( " + x + " , " + y + " )");
        }
    }
}