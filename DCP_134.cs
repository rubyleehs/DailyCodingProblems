using System;
using System.Collections.Generic;

namespace DCP_134
{
    /*
    You have a large array with most of the elements as zero.
    Use a more space-efficient data structure, SparseArray, that implements the same interface:
        •	init(arr, size): initialize with the original large array and size.
        •	set(i, val): updates index at i with val.
        •	get(i): gets the value at index i.
    */

    public class DCP_134
    {
    }

    public class SparseArray
    {
        public int len;
        public Dictionary<int, int> d;

        public SparseArray(int len, int[] arr = null)
        {
            this.len = len;
            d = new Dictionary<int, int>();

            if(arr != null)
            {
                for (int i = 0; i < arr.Length && i < len; i++)
                {
                    if (arr[i] != 0) d.Add(i, arr[i]);
                }
            }
        }

        public void Set(int index, int value)
        {
            if (index > len - 1) throw new System.ArgumentException("Index out of range!");
            else
            {
                if (d.ContainsKey(index)) d[index] = value;
                else d.Add(index, value);
            }
        }

        public int Get(int index)
        {
            if (d.ContainsKey(index)) return d[index];
            else return 0;
        }
    }
}
