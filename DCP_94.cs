namespace DCP_94
{
    /*
        Given a binary tree of integers, find the maximum path sum between two nodes. The path must go through at least one node, and does not need to go through the root.
    */

    //max path sum would be the same a min path sum in this case no? - there is only one possible route

    public class DCP_94
    {
        public static Node root;

        public static void Main()
        {
            //do stuff
        }

        public static int? MaxPathSum(Node root, Node a, Node b)
        {
            string ap = GetNodePaths(root, a);
            if (ap == null) return null;

            string bp = GetNodePaths(root, b);
            if (bp == null) return null;
            if (ap == bp) return 0;

            if (bp.Length > ap.Length)
            {
                string temp = bp;
                bp = ap;
                ap = temp;
            }

            int k = 0;
            int output = 0;
            for (; k < bp.Length; k++)
            {
                if (ap[k] != bp[k]) break;
            }

            Node travel = root;
            Node subroot = null;
            for (int i = 0; i < bp.Length; i++)
            {
                if (i == k)
                {
                    output = travel.key;
                    subroot = travel;
                }
                if (bp[i] == 'L') travel = travel.left;
                else if (bp[i] == 'R') travel = travel.right;
                if (i >= k) output += travel.key;
            }

            travel = subroot;
            for (int i = k; i < ap.Length; i++)
            {
                if (ap[i] == 'L') travel = travel.left;
                else if (ap[i] == 'R') travel = travel.right;
                if (i >= k) output += travel.key;
            }

            return output;
        }

        public static string GetNodePaths(Node root, Node node)
        {
            if (node == root) return "";
            string output = null;
            if (root.left != null)
            {
                output = GetNodePaths(root.left, node);
                if (output != null) return output += "L";
            }
            if (root.right != null)
            {
                output = GetNodePaths(root.right, node);
                if (output != null) return output += "R";
            }

            return output;
        }
    }

    public class Node
    {
        public int key;

        public Node left;
        public Node right;

        public Node(int key)
        {
            this.key = key;
            this.left = null;
            this.right = null;
        }

        public void Add(int i)
        {
            if (i < key)
            {
                if (left == null) left = new Node(i);
                else left.Add(i);
            }
            else
            {
                if (right == null) right = new Node(i);
                else right.Add(i);
            }
        }
    }
}