using System;
using System.Linq;

namespace DCP_36
{
    /*
    Given the root to a binary search tree, find the second largest node in the tree.
    */

    //Wasn't there a previous question about binary trees already?

    public class DCP_36
    {
        public static Node tree;

        public static void Main()
        {
            CreateTree(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Console.WriteLine(Find2ndLargestNode(tree).data);
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

        public static Node Find2ndLargestNode(Node n)
        {
            Node noi = n;
            Node travel = n;
            while (travel.right != null)
            {
                noi = travel;
                travel = travel.right;
            }

            if (noi.left != null) return noi.left;
            else return noi;
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
    }
}
