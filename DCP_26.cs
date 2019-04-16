using System;
using System.Linq;

namespace DCP_26
{
    /*
    Given a singly linked list and an integer k, remove the kth last element from the list.k is guaranteed to be smaller than the length of the list.
    The list is very long, so making more than one pass is prohibitively expensive.
    Do this in constant space and in one pass.
    */

    //store length of list somewhere?
    //could also have a 2nd pointer k behind the front pointer but thats stil 2 passes in a way or 2n - k reads

    //After some gooogling, somehow 2nd method is considered 1 pass. WHYY. 
    //Discord some say its considered 2 passes some say rounded down so 2n-k rounds to 1. I have no clue

    public class Node
    {
        public Object value;
        public Node next;

        public Node(Object value)
        {
            this.value = value;
        }
    }

    public class DCP_26
    {

        public static Node startNode;

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            startNode = new Node(input[0]);
            Node endNode = startNode;
            for (int i = 1; i < input.Length; i++)
            {
                endNode.next = new Node(input[i]);
                endNode = endNode.next;
            }
            RemoveLastKElement(startNode, Int32.Parse(Console.ReadLine()));
        }

        public static void RemoveLastKElement(Node node, int k)
        {
            Node endNode = node;
            for (int i = 0; i < k; i++)
            {
                if (endNode.next != null) endNode = endNode.next;
                else
                {
                    Console.WriteLine("Failed to remove last " + k + " element - List has less than " + k + " elements");
                    return;
                }
            }
            Node lagNode = node;
            while (endNode.next != null)
            {
                endNode = endNode.next;
                lagNode = lagNode.next;
            }

            if (lagNode.next != null)
            {
                Console.WriteLine("Removed " + lagNode.next.value);
                lagNode.next = lagNode.next.next;
            }
        }
    }
}