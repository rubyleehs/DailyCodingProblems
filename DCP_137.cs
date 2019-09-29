using System;

namespace DCP_137
{
    /*
    Implement a bit array.
    A bit array is a space efficient array that holds a value of 1 or 0 at each index.
        •	init(size): initialize the array with size
        •	set(i, val): updates index at i with val where val is either 1 or 0.
        •	get(i): gets the value at index i.
    */


    public class DCP_137
	{

	}

    public class BitArray
    {
        int size;
        UInt16[] data;

        public BitArray(int size)
        {
            this.size = size;
            data = new UInt16(Math.Ceiling(size / 16));
        }

        public void SetValue(int index, bool value)
        {
            if(index >= size) throw new System.ArgumentException("Index Out Of Range");
            int i0 = index / 16;
            int ir = index % 16;

            if (value) data[i0] |= 1 << ir;
            else data[i0] &= ~(1 << ir);
        }

        public bool GetValue(int index)
        {
            if (index >= size) throw new System.ArgumentException("Index Out Of Range");
            if (b & (1 << index - 1) != 0) return true;
            else return false;
        }
    }
}
