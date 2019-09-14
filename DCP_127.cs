using System;
using System.Collections.Generic;

namespace DCP_127
{
    /*
    Let's represent an integer in a linked list format by having each node represent a digit in the number. The nodes make up the number in reversed order.
    For example, the following linked list:
        1 -> 2 -> 3 -> 4 -> 5
    is the number 54321.
    Given two linked lists in this format, return their sum in the same linked list format.

    */

    public class DCP_127
    {
        public static LinkedList<int> SumTwoLinkedList(LinkedList<int> l1, LinkedList<int> l2)
        {
            int carry = 0;
            int sum;
            LinkedListNode<int> t1 = l1.First;
            LinkedListNode<int> t2 = l2.First;

            LinkedList<int> output = new LinkedList<int>();
            while (t1 != null && t2 != null)
            {
                sum = carry;
                carry = 0;
                if (t1 != null)
                {
                    sum += t1.Value;
                    t1 = t1.Next;
                }
                if (t2 != null)
                {
                    sum += t2.Value;
                    t2 = t2.Next;
                }
                carry = (int)Math.Floor(sum * 0.1);
                sum = sum % 10;
                output.AddLast(sum);
            }
            return output;
        }
    }
}