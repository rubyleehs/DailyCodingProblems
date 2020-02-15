using System;

namespace DCP_146
{
    /*
    Given a binary tree where all nodes are either 0 or 1, prune the tree so that subtrees containing all 0s are removed.
    */
    public class DCP_146
    {
        public static void Main()
        {
            Node root = new Node(false);
            root.left = new Node(false);
            root.left.left = new Node(false);
            root.left.right = new Node(true);
            root.left.left.left = new Node(false);
            root.left.right.left = new Node(false);
            root.left.right.right = new Node(true);
            root.right = new Node(false);
            root.right.left = new Node(false);
            root.right.left.right = new Node(false);
            root.right.right = new Node(false);
            root.right.right.left = new Node(false);
            root.right.right.right = new Node(true);
            root.right.right.right.left = new Node(true);
            root.right.right.right.right = new Node(false);

            Console.WriteLine(root.Reveal());
            PruneTree(root);
            Console.WriteLine(root.Reveal());
        }

        public static bool PruneTree(Node root)
        {
            if (root == null) return true;

            bool left = PruneTree(root.left);
            bool right = PruneTree(root.right);

            if (left && right && !root.data) return true;
            if (left) root.left = null;
            if (right) root.right = null;

            return false;
        }
    }

    public class Node
    {
        public bool data;
        public Node left, right;

        public Node(bool d)
        {
            data = d;
            left = right = null;
        }

        public String Reveal()
        {
            String s = data;
            if (left == null && right == null) return s;
            s += "[";
            if (left != null) s += left.Reveal();
            if (right != null) s += right.Reveal();
            s += "]";
            return s;
        }
    }
}
