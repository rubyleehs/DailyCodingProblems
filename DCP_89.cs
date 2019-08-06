namespace DCP_89
{
    /*
        Determine whether a tree is a valid binary search tree.
        A binary search tree is a tree with two children, left and right, 
        and satisfies the constraint that the key in the left child must be less than or equal to the root and the key in the right child must be greater than or equal to the root
    */

    //Easier variant of a previous question

    public class DCP_89
    {
        public static Node root;
        public static void Main()
        {
            //do stuff
        }
    }

    public class Node
    {
        int key;
        Node left;
        Node right;

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

        public bool Validate()
        {
            if (left != null)
            {
                if (left.key >= key) return false;
                if (!left.Validate()) return false;
            }
            if (right != null)
            {
                if (right.key < key) return false;
                if (!right.Validate()) return false;
            }
            return true;
        }
    }
}