using System;
using System.Collections.Generic;

namespace DCP_34
{
    /*
    Given a string, find the palindrome that can be made by inserting the fewest number of characters as possible anywhere in the word. If there is more than one palindrome of minimum length that can be made, return the lexicographically earliest one (the first one alphabetically).
    For example, given the string "race", you should return "ecarace", since we can add three letters to it (which is the smallest amount to make a palindrome). There are seven other palindromes that can be made from "race" by adding three letters, but "ecarace" comes first alphabetically.
    */

    //Whut. This is medium difficulty?
    //>is there any senario where I would add characters between the input
    //abca => abcba
    //abdca => abcdcba
    //max output.length == (input.length * 2 -1)
    //get string, reverse string, find poisiton where it can fit the most letters 
    //IDK, burte force seems like the only solution

    public class DCP_34
    {
        public static List<string> palindromes;

        public static void Main()
        {
            palindromes = new List<string>();
            BruteGetPalindromes(Console.ReadLine(), 0, 0, "");
            Console.WriteLine(GetShortestString(palindromes));
        }

        public static void BruteGetPalindromes(string s, int si, int ri, string output)
        {
            if (s == null) return;
            if (si >= s.Length && ri >= s.Length)
            {
                palindromes.Add(output);
                return;
            }
            //Console.WriteLine(si);
            if (si < s.Length && ri < s.Length && s[si] == s[s.Length - 1 - ri]) BruteGetPalindromes(s, si + 1, ri + 1, output + s[si]);
            else
            {
                if (si < s.Length) BruteGetPalindromes(s, si + 1, ri, output + s[si]);
                if (ri < s.Length) BruteGetPalindromes(s, si, ri + 1, output + s[s.Length - 1 - ri]);
            }
        }

        public static string GetShortestString(List<string> l)
        {
            if (l == null) return "";
            int minLength = 9999;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Length < minLength) minLength = l[i].Length;
            }
            List<string> p = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Length == minLength) p.Add(l[i]);
            }
            p.Sort();
            return p[0];
        }
    }
}

