using System;
using System.Collections.Generic;

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
    }

    public class DCP_26
    {

        public static Node startNode;

        public static Main()
        {
            string[] input = Console.ReadLine.Split(' ').Select(int.Parse).ToArray();

            Node endNode;
            startNode = endNode;
            for (int i = 0; i < input.Length; i++)
            {
                endNode.next = new Node();
                endNode = endNode.next;
                endNode.value = input[0];               
            }
            RemoveLastKElement(startNode, (int)Console.ReadLine());
        }

        public static void RemoveLastKElement(Node node, int k)
        {
            Node endNode = node;
            for (int i = 0; i < k; i++)
            {
                if (endNode.next != null) endNode = node.next;
                else
                {
                    Console.WriteLine("Failed to remove last " + k + " element - List has less than " + k + " elements");
                    return;
                }
            }
            Node lagNode = node;
            while(endNode.next != null)
            {
                endNode = endNode.next;
                lagNode = lagNode.next;
            }

            if (lagnode.next != null)
            {
                Console.WriteLine("Removed " + lagNode.next.value);
                lagNode.next = lagNode.next.next;
            }
        }
    }
}