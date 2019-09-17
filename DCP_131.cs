using System;
using System.Collections.Generic;

namespace DCP_131
{
    /*
    Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.
    */

    public class DCP_131
    {
        public static Node copy;
        public static void Main()
        {
            Node a = new Node(1);
            Node b = new Node(2);
            Node c = new Node(3);
            Node d = new Node(4);
            Node e = new Node(5);

            a.random = e;
            b.random = b;
            c.random = c;
            d.random = a;
            e.random = a;

            a.Add(b);
            b.Add(c);
            c.Add(d);
            d.Add(e);

            copy = DeepClone(a);

            Node travel = a;
            Node last = copy;
            while (travel != null)
            {
                Console.WriteLine(last.random.data + " == " + travel.random.data);
                travel = travel.next;
                last = last.next;
            }
        }

        public static Node DeepClone(Node head)
        {
            Dictionary<Node, Node> nodeDict = new Dictionary<Node, Node>();
            Node output = new Node(head.data);
            Node travel = head, last = output;
            nodeDict.Add(travel, last);
            while (travel.next != null)
            {
                travel = travel.next;
                last.Add(new Node(travel.data));
                last = last.next;
                nodeDict.Add(travel, last);
            }

            travel = head;
            last = output;
            while (last != null)
            {
                if (travel.random != null) last.random = nodeDict[travel.random];
                last = last.next;
                travel = travel.next;
            }

            return output;
        }
    }

    public class Node
    {
        public Node next;
        public Node random;
        public int data;

        public Node(int data, Node random = null)
        {
            next = null;
            this.random = random;
            this.data = data;
        }

        public void Add(Node node)
        {
            if (next == null) next = node;
            else next.Add(node);
        }
    }

    class NodeEqualityComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            return (x.data == y.data && x.random == y.random && x.next == y.next);
        }

        public int GetHashCode(Node obj)
        {
            string combined = "" + obj.data;
            if (obj.random != null)
            {
                combined += obj.random.data;
                if (obj.random.random != null) combined += obj.random.random.data;
            }
            if (obj.next != null)
            {
                combined += obj.next.data;
                if (obj.next.next != null) combined += obj;
            }
            return (combined.GetHashCode());
        }
    }
}
