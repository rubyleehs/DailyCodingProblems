using System;
using System.Collections.Generic;

namespace DCP_107
{
    /*
    Print the nodes in a binary tree level-wise. For example, the following should print 1, 2, 3, 4, 5.
          1
         / \
        2   3
           / \
          4   5
    */

    public class DCP_107
    {
        public static Node root;
        public static void Main()
        {
            root = new Node(10);
            root.Add(5);
            root.Add(15);
            root.Add(2);
            root.Add(3);
            root.Add(9);
            root.Add(12);
            root.Add(17);
            root.Add(16);

            Console.WriteLine(PrintTreeByLevel(root) == "10 5 15 2 9 12 17 3 16 ");
        }


        public static string PrintTreeByLevel(Node root)
        {
            if (root == null) return "";

            string output = "";
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            Node current;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                output += current.data + " ";

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            Console.WriteLine(output);
            return output;
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