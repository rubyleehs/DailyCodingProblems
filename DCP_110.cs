using System;
using System.Collections.Generic;

namespace DCP_110
{
    /*
    Given a binary tree, return all paths from the root to leaves.
    For example, given the tree:
           1
          / \
         2   3
            / \
           4   5
    Return [[1, 2], [1, 3, 4], [1, 3, 5]].
    */

    //wasnt there a DCP with this exact question
    public class DCP_110
    {
        static Node root;

        public static List<List<int>> GetAllPaths(Node root)
        {
            List<List<int>> output = new List<List<int>>();
            if (root.left != null) output.AddRange(GetAllPaths(root.left));
            if (root.right != null) output.AddRange(GetAllPaths(root.right));
            else if (root.left == null) output.Add(new List<int>());

            for (int i = 0; i < output.Count; i++)
            {
                output[i].Insert(0, root.data);
            }

            return output;
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