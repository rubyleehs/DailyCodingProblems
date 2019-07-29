using System;
using System.Linq;

namespace DCP_80
{
    /*
    Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
    For example, given the array [10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
    Given the array [10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.
    */

    public class DCP_80
    {
        public static Node tree;

        public static void Main()
        {
            CreateTree(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Node output = null;
            GetDeepestNode(tree, out output);
            Console.WriteLine(output.data);
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

        public static int GetDeepestNode(Node root, out Node output)
        {
            if (root == null)
            {
                output = null;
                return -1;
            }
            else if (root.left == null && root.right == null)
            {
                output = root;
                return 0;
            }
            Console.WriteLine(">" + root.data);
            Node dl, dr;
            int l = GetDeepestNode(root.left, out dl);
            int r = GetDeepestNode(root.right, out dr);
            if (l > r)
            {
                output = dl;
                return l + 1;
            }
            else
            {
                output = dr;
                return r + 1;
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
    }
}