using System;

namespace DCP_78
{
    /*
    Given k sorted singly linked lists, write a function to merge all the lists into one sorted singly linked list.
    */

    public class DCP_78
    {
        public static void Main()
        {
            SinglyLinkedListNode l1 = new SinglyLinkedListNode();
            int[] arr1 = new int[3] { 2, 3, 5 };
            for (int i = 0; i < arr1.Length; i++)
            {
                l1.Add(arr1[i]);
            }

            int[] arr2 = new int[4] { 0, 4, 6, 9 };
            SinglyLinkedListNode l2 = new SinglyLinkedListNode();
            for (int i = 0; i < arr2.Length; i++)
            {
                l2.Add(arr2[i]);
            }

            int[] arr3 = new int[3] { -1, 7, 8 };
            SinglyLinkedListNode l3 = new SinglyLinkedListNode();
            for (int i = 0; i < arr3.Length; i++)
            {
                l3.Add(arr3[i]);
            }
            SinglyLinkedListNode[] arr = new SinglyLinkedListNode[3] { l1, l2, l3 };
            SinglyLinkedListNode output = MergeAndSortSinglyLinkedLists(arr);
            output.Print();
        }

        public static SinglyLinkedListNode MergeAndSortSinglyLinkedLists(SinglyLinkedListNode[] list)
        {
            //Console.WriteLine(list[0].data);
            SinglyLinkedListNode first = null;
            SinglyLinkedListNode travel = null;
            int minVal = 0;
            int index = 0;
            bool isComplete = false;
            while (!isComplete)
            {
                isComplete = true;
                minVal = 99999999;
                index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == null) continue;
                    isComplete = false;
                    if (minVal > list[i].data)
                    {
                        minVal = list[i].data;
                        index = i;
                    }
                }
                if (isComplete) break;
                if (travel == null) travel = list[index];
                else
                {
                    travel.next = list[index];
                    travel = travel.next;
                }
                list[index] = list[index].next;

                if (first == null) first = travel;

            }
            return first;
        }
    }

    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode next;
        public int data;
        private bool isNew;

        public SinglyLinkedListNode(int data = 0)
        {
            this.data = data;
            isNew = true;
        }

        public void Add(int data)
        {
            if (isNew)
            {
                isNew = false;
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
}}
}