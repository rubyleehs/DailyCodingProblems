using System;
using System.Collections.Generic;

namespace DCP_125
{
    /*
    Given the root of a binary search tree, and a target K, return two nodes in the tree whose sum equals K.
    For example, given the following tree and K of 20
    */

    public class DCP_125
    {
        public static Node root;

        public static void Main()
        {
            root = new Node(10);
            root.Add(4);
            root.Add(12);
            root.Add(-11);
            root.Add(5);
            root.Add(11);
            root.Add(12);

            Node[] output = FindNodesSumEqualK(root, 9);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i].data);
            }
        }

        public static Node[] FindNodesSumEqualK(Node root, int k)
        {
            Dictionary<int, Node> dic = new Dictionary<int, Node>();
            Queue<Node> queue = new Queue<Node>();
            Node current;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if (dic.ContainsKey(k - current.data)) return new Node[2] { current, dic[k - current.data] };
                else if (!dic.ContainsKey(current.data)) dic.Add(current.data, current);

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }

            return null;
        }
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }

        public void Add(Node node)
        {
            if (node.data < data)
            {
                if (left == null) left = node;
                else left.Add(node);
            }
            else if (node.data > data)
            {
                if (right == null) right = node;
                else right.Add(node);
            }
        }

        public void Add(int value)
        {
            Add(new Node(value));
        }
    }
}

