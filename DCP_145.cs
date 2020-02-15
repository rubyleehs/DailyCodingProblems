using System;
using System.Collections.Generic;

namespace DCP_145
{
    /*
    Given the head of a singly linked list, swap every two nodes and return its head.
    For example, given 1 -> 2 -> 3 -> 4, return 2 -> 1 -> 4 -> 3.
    */
    public class DCP_145
    {
        public static void Main()
        {
            LinkedList<int> head = new LinkedList<int>();
            head.AddLast(0);
            head.AddLast(1);
            head.AddLast(2);
            head.AddLast(3);
            head.AddLast(4);
            SwapListElements(head.First);

            LinkedListNode<int> travel = head.First;
            while (travel != null)
            {
                Console.WriteLine(travel.Value);
                travel = travel.Next;
            }
        }

        public static void SwapListElements(LinkedListNode<int> head)
        {
            if (head == null) return;
            if (head.Next != null)
            {
                int tdata = head.Value;
                head.Value = head.Next.Value;
                head.Next.Value = tdata;

                SwapListElements(head.Next.Next);
            }
        }
    }
}
