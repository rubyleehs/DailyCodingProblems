using System;
using System.Collections.Generic;

namespace DCP_35
{
    /*
    Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.
    Do this in linear time and in-place.
    For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'].
    */

    //some sort of sorting algorithm prob.
    //30 mins to figure out on my own. 1153hrs now.

    //linear time basically means during the actual sort i need to get it right immediately.
    //first time count num of RGB. 2nd time just go through it and done?
    //Oh need to know where the element you want to change is too


    //1243 hrs now. 50 mins. kinda iffy algorithm. Spent like 30 mins trying to figure out a bug and it was me forgetinng to increment gii :/
    //takes O(2n) time;

    public class DCP_35
    {
        static char[] chars;
        public static void Main()
        {
            chars = Console.ReadLine().ToCharArray();
            RGBSortV2(chars);
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
            }
        }
        //1st attempt
        public static void RGBSort(char[] a)
        {
            List<int> rc = new List<int>(), gc = new List<int>();
            int ri = 0, gi = 0, gii = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 'R') rc.Add(i);
                else if (a[i] == 'G') gc.Add(i);
            }
            while (rc[ri] < rc.Count - 1) ri++;

            for (int i = 0; i < a.Length; i++)
            {
                if (i < rc.Count)
                {
                    if (a[i] != 'R')
                    {
                        if (a[i] == 'G')
                        {
                            gc[gi] = rc[ri];
                            gi++;
                        }
                        a.Swap(i, rc[ri]);
                        ri++;
                    }
                }
                else if (i < rc.Count + gc.Count && a[i] != 'G')
                {
                    while (gc[gii] < i) gii++;
                    a.Swap(i, gc[gii]);
                    gii++;
                }
            }
        }

        //Ah been so long since I did DCPs and algorithms I forgot about just moving Bs to the end instead.
        //guess i do it again.
        //2nd attempt
        public static void RGBSortV2(char[] a)
        {
            int li = 0, ri = a.Length - 1;

            while (true)
            {
                while (a[li] == 'R' && li < ri) li++;
                while (a[ri] != 'R' && li < ri) ri--;
                if (li >= ri) break;

                a.Swap(li, ri);
            }
            ri = a.Length - 1;
            while (true)
            {
                while (a[li] != 'B' && li < ri) li++;
                while (a[ri] == 'B' && li < ri) ri--;
                if (li >= ri) break;

                a.Swap(li, ri);
            }
        }
    }

    public static class Extensions
    {
        public static void Swap<T>(this T[] array, int a, int b)
        {
            if (a == b) return;
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}



