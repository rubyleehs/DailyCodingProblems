using System;
using System.Linq;

namespace DCP_48
{
    /*
    Given pre-order and in-order traversals of a binary tree, write a function to reconstruct the tree.
    For example, given the following preorder traversal:
    [a, b, d, e, c, f, g]
    And the following inorder traversal:
    [d, b, e, a, f, c, g]
    You should return the following tree:
        a
       / \
      b   c
     / \ / \
    d  e f  g
    */

    public class DCP_48
    {
        public static Node tree;
        public static string[] s1 = new string[7] { "a", "b", "d", "e", "c", "f", "g" };
        public static string[] s2 = new string[7] { "d", "b", "e", "a", "f", "c", "g" };
        public static void Main()
        {
            tree = CreateBinTree(s1, s2);
            Console.WriteLine(tree.Print());
            tree = CreateBinTree(Console.ReadLine().Split(' ').ToArray(), Console.ReadLine().Split(' ').ToArray());
            Console.WriteLine(tree.Print());
        }

        public static Node CreateBinTree(string[] preorder, string[] inorder, int check = 0, int start = 0, int end = -1)
        {
            if (end < 0) end = preorder.Length - 1;
            if (check < 0 || check > preorder.Length - 1) return null;
            if (start == end) return new Node(preorder[check]);

            int index = -1;
            for (int i = start; i <= end; i++)
            {
                if (inorder[i] == preorder[check])
                {
                    index = i;
                    break;
                }
            }

            if (index < 0) return null;

            Node output = new Node(preorder[check]);
            output.left = CreateBinTree(preorder, inorder, check + 1, start, index - 1);
            output.right = CreateBinTree(preorder, inorder, check + index + 1 - start, index + 1, end);
            return output;
        }
    }

    public class Node
    {
        public string data;
        public Node left;
        public Node right;

        public Node(string data)
        {
            this.data = data;
        }

        public string Print()
        {
            string output = "(" + data + " ";
            if (left != null) output += left.Print();
            if (right != null) output += right.Print();
            output += ")";
            return output;
        }
    }
}