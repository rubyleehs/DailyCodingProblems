using System;
using System.Collections.Generic;

namespace DCP_115
{
    /*
    Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.
    A subtree of s is a tree consists of a node in s and all of this node's descendants. 
    The tree s could also be considered as a subtree of itself.
    */


    //identical value-vise/deep-copies of each other
    public class DCP_115
    {
        public static Node root;
        public static void Main()
        {
            root = new Node(10);
            root.Add(5);
            root.Add(6);
            root.Add(17);
            root.Add(15);

            Node temp = new Node(11);
            temp.Add(2);
            temp.Add(7);
            temp.Add(13);
            temp.Add(12);

            root.Add(temp);

            Console.WriteLine(IsSubtree(root, temp) == true);
            Console.WriteLine(IsSubtree(temp, root) == false);
        }

        //Non-Recursive, prob better is it was recursive, but wanted to try something diffrent.
        public static bool IsSubtree(Node s, Node t)
        {
            Queue<Node> nodesToCheck = new Queue<Node>();
            nodesToCheck.Enqueue(s);

            Node check;
            while(nodesToCheck.Count > 0)
            {
                check = nodesToCheck.Dequeue();
                if (check.data == t.data)
                {
                    if (IsIdenticalTree(check, t)) return true;
                }

                if (check.left != null) nodesToCheck.Enqueue(check.left);
                if (check.right != null) nodesToCheck.Enqueue(check.right);            
            }
            return false;
        }   

        //Recursive
        public static bool IsIdenticalTree(Node s, Node t)
        {
            if (s == null ^ t == null) return false;
            else if(s == null && t == null) return true;

            if (s.data != t.data) return false;
            else
            {
                if (!IsIdenticalTree(s.left, t.left)) return false;
                if (!IsIdenticalTree(s.right, t.right)) return false;
                else return true;
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

        public void Add(int value)
        {
            Add(new Node(value));
        }
    }
}
