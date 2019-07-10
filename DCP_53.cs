using System;
using System.Collections;

namespace DCP_53
{
    /*
    Implement a queue using two stacks. 
    Recall that a queue is a FIFO (first-in, first-out) data structure with the following methods: enqueue, which inserts an element into the queue, and dequeue, which removes it. 
    */

    //basically a baby-difficulty Tower of Hanoi?
    //Now i feel like coding a solver for Tower of Hanoi puzzles

    public class DCP_53
    {
        public static void Main()
        {
            Queue q = new Queue();
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input.Length <= 0) Console.WriteLine(q.Dequeue());
                else q.Enqueue(input);
            }
        }
    }

    public class Queue
    {
        private Stack inStack;
        private Stack outStack;

        public Queue()
        {
            inStack = new Stack();
            outStack = new Stack();
        }

        public void Enqueue(object item)
        {
            inStack.Push(item);
        }

        public object Dequeue()
        {
            if (outStack.Count <= 0)
            {
                while (inStack.Count > 0)
                {
                    outStack.Push(inStack.Pop());
                }
            }

            return outStack.Pop();
        }
    }
}
