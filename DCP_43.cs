using System;
using System.Collections.Generic;

namespace DCP_43
{
    /*
    Implement a stack that has the following methods:
        •	push(val), which pushes an element onto the stack
        •	pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
        •	max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
    Each method should run in constant time.
    */

    //https://www.geeksforgeeks.org/find-maximum-in-a-stack-in-o1-time-and-o1-extra-space/
    //genius way to do it :O Such beauty!

    public class DCP_43
    {
        public static void Main()
        {
            MyStack s = new MyStack();
            s.Push(3);
            s.Push(5);
            s.Max();
            s.Push(7);
            s.Push(19);
            s.Max();
            s.Pop();
            s.Max();
            s.Pop();
            s.Peek();
        }
    }

    public class MyStack
    {
        public Stack<int> data;
        public int max;

        public MyStack()
        {
            data = new Stack<int>();
        }

        public int Peek()
        {
            if (data.Count > 0)
            {
                int top = data.Peek();
                if (top > max)
                {
                    Console.WriteLine(max);
                    return max;
                }
                else
                {
                    Console.WriteLine(top);
                    return top;
                }
            }
            throw new System.ArgumentException("Stack is empty");
        }

        public void Push(int a)
        {
            if (data.Count == 0)
            {
                max = a;
                data.Push(a);
            }
            else if (a > max)
            {
                data.Push(2 * a - max);
                max = a;
            }
            else data.Push(a);
        }

        public int Pop()
        {
            if (data.Count > 0)
            {
                int top = data.Pop();

                if (top > max)
                {
                    int temp = max;
                    max = 2 * max - top;
                    Console.WriteLine(temp);
                    return temp;
                }
                else return top;
            }
            throw new System.ArgumentException("Stack is empty");
        }

        public int Max()
        {
            if (data.Count <= 0) throw new System.ArgumentException("Stack is empty");
            else
            {
                Console.WriteLine(max);
                return max;
            }
        }
    }
}