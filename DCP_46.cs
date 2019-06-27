using System;

namespace DCP_46
{
    /*
    Given a string, find the longest palindromic contiguous substring. If there are more than one with the maximum length, return any one.
    For example, the longest palindromic substring of "aabcdcb" is "bcdcb". The longest palindromic substring of "bananas" is "anana".  
    */

    public class DCP_46
    {
        public static void Main()
        {
            Console.WriteLine(LongestPalindromicSubstring(Console.ReadLine()));
        }

        public static string LongestPalindromicSubstring(string s)
        {
            if (s.Length == 0) return "";

            int d = 0;
            int maxL = 0;
            int startIndex = -1;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (maxL >= s.Length) return s.Substring(startIndex, maxL);
                d = 0;

                while (i + d + 1 < s.Length && i - d >= 0 && s[i - d] == s[i + d + 1]) d++;
                if (d > 0 && 2 * d > maxL)
                {
                    maxL = 2 * d;
                    startIndex = i - d + 1;
                }
            }

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (maxL >= s.Length) return s.Substring(startIndex, maxL);
                d = 1;

                while (i + d < s.Length && i - d >= 0 && s[i - d] == s[i + d]) d++;
                if (d > 1 && 2 * d - 1 > maxL)
                {
                    maxL = 2 * d - 1;
                    startIndex = i - d + 1;
                }
            }
            return s.Substring(startIndex,maxL);
        }

        //https://www.geeksforgeeks.org/longest-palindrome-substring-set-1/
        //...this isnt much better than my solution. nvm. Faster in best case but O(n^2) space compared to my constant.
    }
}