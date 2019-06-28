using System;
using System.Data;

namespace DCP_50
{
    /*
    Suppose an arithmetic expression is given as a binary tree. Each leaf is an integer and each internal node is one of '+', '−', '∗', or '/'.
    Given the root to such a tree, write a function to evaluate it.
    For example, given the following tree:
        *
       / \
      +    +
     / \  / \
    3  2  4  5
    You should return 45, as it is (3 + 2) * (4 + 5).
    */

    public class DCP_50
    {
        public static Node tree;
        public static string[] s1 = new string[7] { "*", "+", "3", "2", "+", "4", "5" };
        public static string[] s2 = new string[7] { "3", "+", "2", "*", "4", "+", "5" };
        public static void Main()
        {
            tree = CreateBinTree(s1, s2);
            Console.WriteLine(tree.Print());
            //tree = CreateBinTree(Console.ReadLine().Split(' ').ToArray(), Console.ReadLine().Split(' ').ToArray());
            Console.WriteLine((new DataTable().Compute(tree.Print(), null)).ToString());
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
            string output = "(";
            if (left != null) output += left.Print();
            output += data;
            if (right != null) output += right.Print();
            output += ")";
            return output;
        }

    }
}