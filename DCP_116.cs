using System;

namespace DCP_116
{
    /*
    Generate a finite, but an arbitrarily large binary tree quickly in O(1).
    That is, generate() should return a tree whose size is unbounded but finite.
    */

    //Dafaq is this even possible?
    //You could technically generate a seed for a tree, making it O(1) and generate clild nodes when needed. which is still O(n) but delayed.

    public class DCP_116
    {
        public static BinTree tree;
        public static Random random;

        public static void Main()
        {
            random = new Random();
            tree = new BinTree(random.Next());

            Node travel = tree.root;
            while (true)
            {
                Console.ReadLine();
                Console.Write(travel.data);
                travel = travel.left.Value;
            }
        }
    }

    public class BinTree
    {
        public Random random;
        public Node root;

        public BinTree(int seed)
        {
            random = new Random(seed);
            root = new Node(random.Next(), random);
        }
    }

    public class Node
    {
        public int data;
        public Lazy<Node> left;
        public Lazy<Node> right;

        public Node(int data, Random random)
        {
            this.data = data;
            if (random.Next(0, 10) < 5) left = new Lazy<Node>(() => new Node(random.Next(), random));
            else left = null;

            if (random.Next(0, 10) < 5) right = new Lazy<Node>(() => new Node(random.Next(), random));
            else right = null;
        }
    }
}