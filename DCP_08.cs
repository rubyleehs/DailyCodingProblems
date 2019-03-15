using System;

namespace DCP_08
{
    //A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
    //Given the root to a binary tree, count the number of unival subtrees

    public class Node
    {
        public string val;
        public Node left;
        public Node right;

        public Node(string val, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class DCP_08
    {
        public static void Main()
        {
            Node node = new Node("a", new Node("b", new Node("b"), new Node("b")), new Node("a"));

            Console.Write(NumofUnivalSubtrees(node));
        }


        public static int NumofUnivalSubtrees(Node root)
        {
            if (root.left == null && root.right == null) return 1;
            int l = 0;
            int r = 0;
            if (root.left != null) l += NumofUnivalSubtrees(root.left);
            if (root.right != null) r += NumofUnivalSubtrees(root.right);

            if ((root.val == root.left.val || root.left == null) && (root.val == root.right.val || root.right == null)) return l + r + 1;
            else return l + r;
        }
    }
}