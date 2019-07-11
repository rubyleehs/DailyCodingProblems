using System;
using System.Collections.Generic;

namespace DCP_57
{
    /*
    Given a string s and an integer k, break up the string into multiple lines such that each line has a length of k or less. You must break it up so that words don't break across lines. Each line has to have the maximum possible amount of words. If there's no way to break the text up, then return null.
    You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.      
    */

    public class DCP_57
    {
        public static void Main()
        {
            while (true)
            {
                string[] bs = TextBreaker(Console.ReadLine(), 10);
                for (int i = 0; i < bs.Length; i++)
                {
                    Console.Write(bs[i] + "|");
                }
            }
        }

        public static string[] TextBreaker(string s, int k)
        {
            string[] words = s.Split(' ');
            List<string> output = new List<string>();
            string bs = "";
            int wordLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                wordLength = words[i].Length;
                if (wordLength > k) return null;
                if (bs.Length + wordLength >= k)
                {
                    output.Add(bs);
                    bs = words[i];
                }
                else bs += " " + words[i];
            }
            output.Add(bs);
            return output.ToArray();
        }
    }
}
