using System;
using System.Linq;
using System.Collections;

namespace DCP_40
{
    /*
    Given an array of integers where every integer occurs three times except for one integer, which only occurs once, find and return the non-duplicated integer.
    For example, given [6, 1, 3, 3, 3, 6, 6], return 1. Given [13, 19, 13, 13], return 19.
    Do this in O(N) time and O(1) space.   
    */

    //I know how to do either O(N) time or O(1) space but not both at once. It shouldn't be possible? Prob possible in under O(2N) time but O(N)?
    //((sum of all unique numbers * 3) - (sum of numbers in list)) * 0.5
    //oh bitwise manipulation. guess i learn it now

    public class DCP_40
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(SingleNumber(input));
        }

        public static int SingleNumber(int[] input)
        {
            BitArray ones = new BitArray(new int[1] { 0 });
            BitArray twos = new BitArray(new int[1] { 0 });

            for (int i = 0; i < input.Length; i++)
            {
                BitArray ib = new BitArray(new int[1] { input[i] });

                for (int b = 0; b < ib.Count; b++)
                {
                    if (ib.Get(b))
                    {
                        if (!ones.Get(b)) ones.Set(b, true);
                        else if (!twos.Get(b)) twos.Set(b, true);
                        else
                        {
                            ones.Set(b, false);
                            twos.Set(b, false);
                        }
                    }
                }
            }
            int[] output = new int[1];
            ones.CopyTo(output, 0);
            return output[0];
        }
    }
}