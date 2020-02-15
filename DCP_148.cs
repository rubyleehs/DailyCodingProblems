using System;
using System.Collections;

namespace DCP_148
{
    /*
    Given a number of bits n, generate a possible gray code for it.
    For example, for n = 2, one gray code would be [00, 01, 11, 10].
    */

    public class DCP_148
    {
        public static void Main()
        {
            BitArray[] arr = GenerateGrayCode(4);

            for (int i = 0; i < arr.Length; i++)
            {
                PrintValues(arr[i], 8);
            }
        }

        public static BitArray[] GenerateGrayCode(int numOfBits)
        {
            BitArray[] output = new BitArray[(int)Math.Pow(2, numOfBits)];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new BitArray(numOfBits, true);
            }
            int count, interval;
            for (int j = 0; j < numOfBits; j++)
            {
                count = (int)Math.Pow(2, j);
                interval = count * 2;
                for (int i = 0; i < output.Length; i++)
                {
                    output[i][j] = false;
                    count++;
                    if (count >= interval)
                    {
                        i += interval;
                        count = 0;
                    }
                }
            }
            return output;
        }

		public static void PrintValues( IEnumerable myList, int myWidth )  {
      	int i = myWidth;
		  foreach ( Object obj in myList ) {
			 if ( i <= 0 )  {
				i = myWidth;
				Console.WriteLine();
			 }
			 i--;
			 Console.Write( "{0,8}", obj );
		  }
		  Console.WriteLine();
	   }
    }
}
