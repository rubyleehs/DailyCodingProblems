using System;
using System.Collections.Generic;

namespace DCP_13
{
    /*
     * Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
     * For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
    */

    //Whatttt how lol.
    //pick k chars, convert them into the same char and the count longest string?
    //so unelegant though

    //if same char is seperated by some unique char, if unique char included in k can merge seperation
    //or we can just brute force it once again and go unique char by char

    public class DCP_13
    {
        public static void Main()
        {
            String input = Console.ReadLine();

            int k = int.Parse(Console.ReadLine());

            var result = BruteLongestSubstringWithDistinctCharacters(input, k);
            Console.WriteLine(result);
        }


        public static string BruteLongestSubstringWithDistinctCharacters(string s, int k)
        {
            int sIndex = 0;
            int longestLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> h = new HashSet<char>();
                for (int n = 0; i + n < s.Length; n++)
                {
                    h.Add(s[i + n]);
                    if (n > longestLength)
                    {
                        longestLength = n;
                        sIndex = i;
                    }
                    if (h.Count > k)
                    {
                        break;
                    }
                }
            }

            return s.Substring(sIndex, longestLength);
        }
    }
}
