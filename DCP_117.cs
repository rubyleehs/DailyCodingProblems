using System;
using System.Collections.Generic;

namespace DCP_117
{
    /*
    Given a binary tree, return the level of the tree with minimum sum.
    */

    //My god why is half the questions about binary trees.
    //why not GOAP, or path finding stuff with a turn radius


    public class DCP_117
    {
        public static Node root;
        public static void Main()
        {
            root = new Node(10);
            root.Add(4);
            root.Add(12);
            root.Add(-11);
            root.Add(5);
            root.Add(11);
            root.Add(12);

            Console.WriteLine(LevelWithMinSum(root) == 2);

            root.Add(1);
            Console.WriteLine(LevelWithMinSum(root) == 3);
        }

        public static int LevelWithMinSum(Node root)
        {
            if (root == null) return -1;

            int smallestSum = root.data;
            int sum;
            int currentLv = -1;
            int smallestLv = 0;
            int curLevelCount = 1;
            int nextLevelCount;
            Queue<Node> queue = new Queue<Node>();
            Node current;

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                currentLv++;
                sum = 0;
                nextLevelCount = 0;
                for (int i = 0; i < curLevelCount; i++)
                {
                    current = queue.Dequeue();
                    sum += current.data;
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                        nextLevelCount++;
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                        nextLevelCount++;
                    }
                }
                if (sum < smallestSum)
                {
                    smallestSum = sum;
                    smallestLv = currentLv;
                }

                curLevelCount = nextLevelCount;
            }
            return smallestLv;
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
