using System;
using System.Collections.Generic;

namespace DCP_126
{
    /*
    Write a function that rotates a list by k elements. For example, [1, 2, 3, 4, 5, 6] rotated by two becomes [3, 4, 5, 6, 1, 2]. 
    Try solving this without creating a copy of the list. How many swap or move operations do you need?
    */

    //This is trivial if it's a C# List

    public class DCP_126
    {
        public static void RotateList(List<T> l, int k)
        {
            l.AddRange(l.GetRange(0, k));
            l.RemoveRange(0, k);
        }
    }
}
