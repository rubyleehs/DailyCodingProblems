using System;
using System.Collections.Generic;

namespace DCP_135
{
    /*
    Given a binary tree, find a minimum path sum from root to a leaf.
    For example, the minimum path in this tree is [10, 5, 1, -1], which has sum 15.
      10
     /  \
    5    5
     \     \
       2    1
           /
         -1

        */

    public class DCP_135
    {
    }

    public class Node
    {
        Node left;
        Node right;
        int data;

        public Node(int data)
        {
            this.data = data;
        }

        public int CalMinPathSumToLeaf()
        {
            if (left != null)
            {
                if (right != null) return data + Math.Max(right.CalMinPathSumToLeaf(), left.CalMinPathSumToLeaf);
                return data + left.CalMinPathSumToLeaf(); 
            }
            else if(right != null) return data + right.CalMinPathSumToLeaf();
            return data;
        }
    }
}
