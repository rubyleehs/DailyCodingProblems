using System;

namespace DCP_73
{
    /*
    Given the head of a singly linked list, reverse it in-place.
    */

    public class DCP_73
    {
        public static void Main()
        {
            SinglyLinkedListNode l = new SinglyLinkedListNode();
            string[] s = Console.ReadLine().Split(' ');
            for (int i = 0; i < s.Length; i++)
            {
                l.Add(s[i]);
            }
            ReverseSinglyLinkedList(ref l);
            l.Print();
        }

        public static void ReverseSinglyLinkedList(ref SinglyLinkedListNode list)
        {
            SinglyLinkedListNode one = list;
            SinglyLinkedListNode two = list.next;
            one.next = null;
            while (two != null)
            {
                one = two;
                two = two.next;
                one.next = list;
                list = one;
            }
        }
    }

    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode next;
        public string data;

        public SinglyLinkedListNode(string data = null)
        {
            this.data = data;
        }

        public void Add(string data)
        {
            if (this.data == null)
            {
                this.data = data;
                return;
            }

            SinglyLinkedListNode travel = this;
            while (travel.next != null) travel = travel.next;
            travel.next = new SinglyLinkedListNode(data);
        }

        public void Print()
        {
            SinglyLinkedListNode travel = this;
            while (travel != null)
            {
                Console.WriteLine(">" + travel.data);
                travel = travel.next;
            }
        }
    }
}

