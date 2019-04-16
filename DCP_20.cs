using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_20
{
    /*
    Given two singly linked lists that intersect at some point, find the intersecting node.The lists are non-cyclical.
    For example, given A = 3 -> 7 -> 8 -> 10 and B = 99-> 1 -> 8 -> 10, return the node with value 8.
    In this example, assume nodes with the same value are the exact same node objects.
    Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
    */

    public class DCP_20
    {
        public static void Main()
        {
            //These are double linked but they work the same for this example anyway
            LinkedList<int> l1 = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            LinkedList<int> l2 = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            Console.WriteLine("> " + ReturnIntersectingNodeValue(l1, l2));
        }

        public static int? ReturnIntersectingNodeValue(LinkedList<int> l1, LinkedList<int> l2)
        {
            int l1c = l1.Count;
            int l2c = l2.Count;
            int dl = l1c - l2c;
            int? output = null;

            if (dl >= 0)
            {
                for (int i = 0; i < l1c - dl; i++)
                {
                    output = l1.ElementAt(i + dl);
                    if (output == l2.ElementAt(i)) return output;
                }
            }
            else
            {
                for (int i = 0; i < l2c + dl; i++)
                {
                    output = l2.ElementAt(i - dl);
                    if (output == l1.ElementAt(i)) return output;
                }
            }

            return null;
        }
    }
}