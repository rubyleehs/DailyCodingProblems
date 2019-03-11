using System;

namespace DCP_03
{
    /*
    Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
    For example, given the following Node class
    class Node:
        def __init__(self, val, left=None, right=None):
            self.val = val
            self.left = left
            self.right = right
    The following test should pass:
    node = Node('root', Node('left', Node('left.left')), Node('right'))
    assert deserialize(serialize(node)).left.left.val == 'left.left'

    */

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

    public class DCP_03
    {
        public static char seperationChar = '-';

        public static string Serialize(Node node)
        {
            if (node == null) return seperationChar + "";


            string s = node.val + seperationChar;

            s += Serialize(node.left);
            s += Serialize(node.right);

            return s;
        }

        public static Node Deserialise(ref string s)
        {
            if (s.Length == 0 || s[0] == seperationChar)
            {
                return null;
            }
            string val = s.Split(seperationChar)[0];

            s = s.Substring(s.IndexOf(seperationChar) + 1);
            Node left = Deserialise(ref s);

            s = s.Substring(s.IndexOf(seperationChar) + 1);
            Node right = Deserialise(ref s);

            return new Node(val, left, right);
        }

        public static void Main()
        {
            Node node = new Node("root", new Node("L1", new Node("L2"), new Node("R2")), new Node("R1"));

            string path = Serialize(node);
            Console.WriteLine(path);
            Console.WriteLine(Serialize(Deserialise(ref path)));
        }

    }
}