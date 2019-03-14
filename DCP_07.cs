using System;

namespace DCP_07
{
    //Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
    //For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
    //You can assume that the messages are decodable.For example, '001' is not allowed.

    //essentially a permutation and combination question.
    //how many ways can you add lengths of the string such that it adds up to the combined length. + some conditions
    //how many permuations of 1 and 2 where 1s and 2s are NOT unique


    public class DCP_07
    {
        public static char[] charArray = new char[] {
         'A', 'B', 'c', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        public static void Main()
        {
            String input = Console.ReadLine();
            Console.WriteLine(NumOfPossibleMessages(input));
            Console.WriteLine(NumOfPossibleMessages2((int)Convert.ToInt64(input)));
        }

        public static int NumOfPossibleMessages(string eMsg)//loop variant, front to back;
        {
            int t = (charArray.Length).ToString().Length;
            if (t == 1) return 1;

            int[] pastCombinations = new int[t];
            for (int i = 0; i < pastCombinations.Length; i++)
            {
                pastCombinations[i] = 1;
            }

            int num;
            int currentC;
            int[] d = new int[t];

            for (int i = 0; i < eMsg.Length - (t - 1); i++)
            {
                currentC = 0;
                num = Convert.ToInt32(eMsg.Substring(i, t));

                for (int p = 0; p < t; p++)
                {
                    if ((num * Math.Pow(0.1, p)) % 10 >= 1) d[p] = 1;
                    else d[p] = 0;
                }
                if (num > charArray.Length) d[d.Length - 1] = 0;

                for (int p = 0; p < t; p++)
                {
                    currentC += pastCombinations[p] * d[p];
                }

                for (int p = 1; p < t; p++)
                {
                    pastCombinations[p] = pastCombinations[p - 1];
                }
                pastCombinations[0] = currentC;
                //Console.WriteLine(currentC + " | " + d[0] + " | " +  d[1] + " | " + d[2]);
            }
            return pastCombinations[0];
        }

        public static int NumOfPossibleMessages2(int eMsg)//Recursive variant, back to front;
        {
            int t = (charArray.Length).ToString().Length;
            int[] d = new int[t];
            for (int p = 0; p < t; p++) d[p] = 1;
            if (eMsg >= Math.Pow(10, t))
            {
                for (int p = 0; p < t; p++)
                {
                    d[p] = NumOfPossibleMessages2((int)Math.Floor(eMsg * Math.Pow(0.1, p + 1)));
                }
            }

            int tot = 0;
            for (int p = 0; p < t - 1; p++)
            {
                if (eMsg % Math.Pow(10, p + 1) >= Math.Pow(10, p)) tot += d[p];
            }
            if (eMsg % Math.Pow(10, t) >= Math.Pow(10, t - 1) && eMsg % Math.Pow(10, t) <= charArray.Length) tot += d[t - 1];
            //Console.WriteLine(d[0]);
            return tot;
        }
    }
}
