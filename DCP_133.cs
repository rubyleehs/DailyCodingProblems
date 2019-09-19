using System;
using System.Collections.Generic;

namespace DCP_133
{
    /*
    Given a node in a binary search tree, return the next bigger element, also known as the inorder successor.
    For example, the inorder successor of 22 is 30.
           10
          /  \
         5    30
             /  \
           22    35
    You can assume each node has a parent pointer.

    */

    public class DCP_133
    {
        public static Node GetInorderSuccessor(Node n)
        {
            Node travel;
            if (n.right == null)
            {
                travel = n.parent;
                while (travel != null)
                {
                    if (travel.data > n.data) break;
                    travel = travel.parent;
                }
            }
            else
            {
                travel = n.right;
                while (travel.left != null) travel = travel.left;
            }
            return travel;
        }
    }

    public class Node
    {
        public Node parent;
        public Node left;
        public Node right;
        public int data;

        public Node(int data, Node parent = null)
        {
            left = null;
            right = null;

            this.data = data;
            this.parent = parent;
        }

        public void Add(Node node)
        {
            if (node.data <= data)
            {
                if (left != null) left.Add(node);
                else
                {
                    node.parent = this;
                    left = node;
                }
            }
            else
            {
                if (right != null) right.Add(node);
                else
                {
                    node.parent = this;
                    right = node;
                }
            }
        }
    }
}

