using System;

namespace DCP_121
{
    /*
    Given a string which we can delete at most k, return whether you can make a palindrome.
    For example, given 'waterrfetawx' and a k of 2, you could delete f and x to get 'waterretaw'.
    */

    public class DCP_121
    {
        public static void Main()
        {
            Console.WriteLine(MakePalindrome(2, "waterrfetawx"));
        }

        public static bool MakePalindrome(int k, string s)
        {
            if (IsPalindrome(s)) return true;
            else if (k <= 0) return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == s[s.Length - 1 - i]) continue;
                else if (MakePalindrome(k - 1, s.Remove(i, 1))) return true;
            }
            return false;
        }

        public static bool IsPalindrome(string s)
        {
            int c = (s.Length + 1) / 2;
            for (int i = 0; i < c; i++)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }
            return true;
        }
    }
}
