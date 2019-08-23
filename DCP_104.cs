using System;
using System.Collections;

namespace DCP_104
{
    /*
    Determine whether a doubly linked list is a palindrome. What if it’s singly linked?
    For example, 1 -> 4 -> 3 -> 4 -> 1 returns True while 1 -> 4 returns False.

    */

    public class DCP_104
    {
        public static bool IsPalindrome(SLinkedList li)
        {
            Stack stack = new Stack();
            stack.Push(li.head);
            SLinkedListNode travel = li.head;
            while (travel.next != null)
            {
                travel = travel.next;
                stack.Push(travel);
            }

            int len = (stack.Count + 1) / 2;
            travel = li.head;
            for (int i = 0; i < len; i++)
            {
                if (stack.Pop() != travel) return false;
                travel = travel.next;
            }
            return true;
        }

        public static bool IsPalindrome(DLinkedList li)
        {
            DLinkedListNode travel0 = li.head;
            DLinkedListNode travel1 = li.head;
            int len = 0;
            while (travel1.next != null)
            {
                travel1 = travel1.next;
                len++;
            }
            len = (len + 1) / 2;
            for (int i = 0; i < len; i++)
            {
                if (travel0.data != travel1.data) return false;

                travel0 = travel0.next;
                travel1 = travel1.prev;
            }
            return true;
        }
    }

    public class SLinkedList
    {
        internal SLinkedListNode head;

        public void Add(int data)
        {
            SLinkedListNode travel = head;
            while (travel.next != null) travel = travel.next;
            travel.next = new SLinkedListNode(data);
        }
    }

    public class DLinkedList
    {
        internal DLinkedListNode head;

        public void Add(int data)
        {
            DLinkedListNode travel = head;
            while (travel.next != null) travel = travel.next;
            travel.next = new DLinkedListNode(data);
        }
    }

    internal class SLinkedListNode
    {
        internal SLinkedListNode next;
        internal int data;

        public SLinkedListNode(int data)
        {
            next = null;
            this.data = data;
        }
    }

    internal class DLinkedListNode
    {
        internal DLinkedListNode next;
        internal DLinkedListNode prev;
        internal int data;

        public DLinkedListNode(int data)
        {
            next = null;
            prev = null;
            this.data = data;
        }
    }
}