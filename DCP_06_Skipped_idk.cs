using System;
namespace DCP_06
{
    //An XOR linked list is a more memory efficient doubly linked list.Instead of each node holding next and prev fields, 
    //it holds a field named both, which is an XOR of the next node and the previous node.Implement an XOR linked list; 
    //it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    //If using a language that has no pointers(such as Python),
    //assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.


    //Well, not really relevant to C#/JS/Phython/Ruby ^^;
    //Is it? I think pointers exist for C# in unsafe context. 
    //Never used them, here goes nothing.

    unsafe struct XorListItem
    {
        int* ptr;
        int value;
    }

    //OK I HAVE NO CLUE.

    public class XORList
    {
        private XorListItem startItem;

     
        public unsafe static XorListItem Get(int index)
        {
            int* a = null;
            int* b = &startItem;
            XorListItem* c;
            for (int i = 0; i < index; i++)
            {
                c = a ^ b;
                a = b;
                b = *c;
            }

        }

    }
}
