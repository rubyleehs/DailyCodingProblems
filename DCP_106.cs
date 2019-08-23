using System;
using System.Collections.Generic;

namespace DCP_106
{
    /*
    Given an integer list where each number represents the number of hops you can make, determine whether you can reach to the last index starting at index 0.
    For example, [2, 0, 1, 0] returns True while [1, 1, 0, 1] returns False.
    */

    public class DCP_106
    {
        public static void Main()
        {
            int[] arr1 = new int[4] { 2, 0, 1, 0 };
            int[] arr2 = new int[4] { 1, 1, 0, 1 };
            int[] arr3 = new int[4] { 1, 2, 5, -3 };
            int[] arr4 = new int[4] { 1, 1, -2, 0 };

            Console.WriteLine(CanHopToEnd(arr1) == true);
            Console.WriteLine(CanHopToEnd(arr2) == false);
            Console.WriteLine(CanHopToEnd(arr3) == true);
            Console.WriteLine(CanHopToEnd(arr4) == false);
        }

        static bool CanHopToEnd(int[] map)
        {
            if (map == null || map.Length == 0) return false;
            else if (map.Length == 1) return true;
            int c = 0;

            //in case there is negative numbers
            HashSet<int> path = new HashSet<int>();
            while (c < map.Length - 1)
            {
                if (path.Contains(c)) return false;
                path.Add(c);
                c += map[c];
            }
            return (c == map.Length - 1);
        }
    }
}
