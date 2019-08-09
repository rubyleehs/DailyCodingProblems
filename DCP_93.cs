using System;
using System.Collections.Generic;

namespace DCP_93
{
    /*
        Given a tree, find the largest tree/subtree that is a BST.
        Given a tree, return the size of the largest tree/subtree that is a BST.
    */

        //Havent tested but should work
    public class DCP_93
    {
        public static int FindLargestBSTSubtreeSize(Node root, ref bool rootIsBST)
        {
            if (root.childs.Count == 0)
            {
                rootIsBST = true;
                return 1;
            }
            if (root.childs.Count > 2) rootIsBST = false;
            else rootIsBST = true;

            bool isBST = true;
            int size;
            int largestSize = 0;
            for (int i = 0; i < root.childs.Count; i++)
            {
                size = FindLargestBSTSubtreeSize(root.childs[i], ref isBST);
                if (rootIsBST && isBST) largestSize += size;
                else
                {
                    largestSize = Math.Max(largestSize, size);
                    if (!isBST) rootIsBST = false;
                }
            }
            if (rootIsBST) largestSize++;

            return largestSize;
        }

        //Exactly the same as above but also stores said subroot
        public static int LargestBSTSubtree(Node root, out Node subroot, ref bool rootIsBST)
        {
            if (root.childs.Count == 0)
            {
                rootIsBST = true;
                subroot = root;
                return 1;
            }
            if (root.childs.Count > 2) rootIsBST = false;
            else rootIsBST = true;

            bool isBST = true;
            int size;
            int largestSize = 0;
            Node node = null;
            subroot = null;
            for (int i = 0; i < root.childs.Count; i++)
            {
                size = LargestBSTSubtree(root.childs[i], out node, ref isBST);
                if (rootIsBST && isBST) largestSize += size;
                else
                {
                    if (size > largestSize)
                    {
                        largestSize = size;
                        subroot = node;
                    }
                    if (!isBST) rootIsBST = false;
                }
            }
            if (rootIsBST)
            {
                largestSize++;
                subroot = root;
            }

            return largestSize;
        }
    }

    public class Node
    {
        public List<Node> childs;

        public Node(List<Node> childs = null)
        {
            if (childs == null) childs = new List<Node>();
            else this.childs = childs;
        }
    }
}