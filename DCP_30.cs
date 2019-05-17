using System;
using System.Linq;

namespace DCP_30
{
    public class DCP_30
    {
        //You are given an array of non-negative integers that represents a two-dimensional elevation map where each element is unit-width wall and the integer is the height. 
        //Suppose it will rain and all spots between two walls get filled up.
        //Compute how many units of water remain trapped on the map in O(N) time and O(1) space.

        //how in the world to do this in O(1) space? what if it is a stagged stairs? need to remember index of 1,2,3,4th....highest step which means it is not constant, if rmb left and right max wall height also not constant

        //if start at both edges and check till the highest point then it is easy, but then O(n^2) time....unless i swap if higher? thsat works. move till find higher point, move from other edge till find higher and repear

        public static void Main()
        {
            Console.WriteLine(CheckTrappedWaterAmount(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int CheckTrappedWaterAmount(int[] input)
        {
            if (input.Length < 3) return 0;

            int lh = 0;
            int rh = 0;

            int li = 0;
            int ri = input.Length - 1;

            int amount = 0;

            while (li <= ri)
            {
                if (lh < rh)
                {
                    if (input[li] >= lh) lh = input[li];
                    else amount += (lh - input[li]);
                    li++;
                }
                else
                {
                    if (input[ri] >= rh) rh = input[ri];
                    else amount += (rh - input[ri]);
                    ri--;
                }
            }
            return amount;
        }
    }
}
