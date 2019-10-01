using System;
using System.Collections.Generic;

namespace DCP_141
{
    /*
    Implement 3 stacks using a single list:
        class Stack:
            def __init__(self):
                self.list = []

            def pop(self, stack_number):
                pass

            def push(self, item, stack_number):
                pass


    */

    public class DCP_141
    {

    }

    public class CustomStack<T>
    {
        List<T> l;
        int[] len;

        public CustomStack()
        {
            l = new List<T>();
            len = new int[3];
        }

        public void Push(T item, int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > len.Length) throw new System.ArgumentException("Stack Index Out Of Range");
            int index = 0;
            for (int i = 0; i <= stackIndex; i++)
            {
                index += len[i];
            }
            l.Insert(index, item);
            len[stackIndex]++;
        }

        public T Peek(int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > len.Length) throw new System.ArgumentException("Stack Index Out Of Range");
            if (len[stackIndex] <= 0) throw new System.ArgumentException("Stack is empty");
            int index = 0;
            for (int i = 0; i <= stackIndex; i++)
            {
                index += len[i];
            }
            return l[index - 1];
        }

        public T Pop(int stackIndex)
        {
            if(stackIndex < 0 || stackIndex > len.Length) throw new System.ArgumentException("Stack Index Out Of Range");
            if (len[stackIndex] <= 0) throw new System.ArgumentException("Stack is empty"); 

            int index = 0;
            for (int i = 0; i <= stackIndex; i++)
            {
                index += len[i];
            }
            T output = l[index - 1];
            l.RemoveAt(index - 1);
            len[stackIndex]--;
            return output;
        }
    }
}
