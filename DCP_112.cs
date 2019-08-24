using System;
using System.Collections.Generic;

namespace DCP_112
{
    /*
    Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree. Assume that each node in the tree also has a pointer to its parent.
    */

    public class DCP_112
    {
        public static Node GetLowestCommonAncestor(Node a, Node b)
        {
            List<Node> al = new List<Node>();
            Node travel = a;
            while (travel != null)
            {
                al.Add(travel);
                travel = travel.parent;
            }

            List<Node> bl = new List<Node>();
            travel = b;
            while (travel != null && bl.Count < al.Count)
            {
                bl.Add(travel);
                travel = travel.parent;
            }

            //ensures the lists have same number if elements.
            //since if on same tree, they have to intersect at final element
            //hence ending of the list will contain the same nodes, remove starting of longer list so you can check 1 to 1.
            if (al.Count > bl.Count) al.RemoveRange(0, al.Count - bl.Count);

            for (int i = 0; i < al.Count; i++)
            {
                if (al[i] == bl[i]) return al[i];
            }

            return null;
        }
    }

    public class Node
    {
        public int data;
        public Node left, right, parent;

        public Node(int d, Node parent = null)
        {
            data = d;
            this.parent = parent;
            left = right = null;
        }

        public void Add(Node node)
        {
            if (node.data < data)
            {
                if (left == null)
                {
                    left = node;
                    left.parent = this;
                }
                else left.Add(node);
            }
            else if (node.data > data)
            {
                if (right == null)
                {
                    right = node;
                    right.parent = this;
                }
                else right.Add(node);
            }
        }

        public void Add(int value)
        {
            Add(new Node(value));
        }
    }
}

