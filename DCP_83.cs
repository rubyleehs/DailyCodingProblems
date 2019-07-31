using System;
using System.Linq;

namespace DCP_83
{
    /*
    Invert a binary tree.
    */

    public class DCP_83
    {
        public static Node tree;

        public static void Main()
        {
            CreateTree(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            tree.Invert();
            Console.WriteLine(tree.data);
            Console.WriteLine(tree.left.data + " | " + tree.right.data);
        }

        public static void CreateTree(int[] a)
        {
            if (a == null || a.Length == 0) return;
            tree = new Node(a[0]);

            for (int i = 1; i < a.Length; i++)
            {
                tree.Add(new Node(a[i]));
            }
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

        public void Invert()
        {
            Node temp = left;
            left = right;
            right = temp;
            if (left != null) left.Invert();
            if (right != null) right.Invert();
        }
    }
}