using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_111
{
    /*
    Given a word W and a string S, find all starting indices in S which are anagrams of W.
    For example, given that W is "ab", and S is "abxaba", return 0, 3, and 4.
    */

    public class DCP_111
    {
        public static void Main()
        {
            List<int> l = FindAnagramPosition("ab", "abxaba");

            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }
        }
        public static List<int> FindAnagramPosition(string w, string s)
        {
            List<int> output = new List<int>();
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < w.Length; i++)
            {
                if (letters.ContainsKey(w[i])) letters[w[i]]++;
                else letters.Add(w[i], 1);
            }

            Dictionary<char, int> check = new Dictionary<char, int>();
            int letterCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (letters.ContainsKey(s[i]))
                {
                    letterCount++;
                    if (check.ContainsKey(s[i])) check[s[i]]++;
                    else check.Add(s[i], 1);
                }
                else
                {
                    letterCount = 0;
                    check.Clear();
                }

                while (letterCount > w.Length)
                {
                    check[s[i - letterCount + 1]]--;
                    letterCount--;
                }

                if (letterCount == w.Length)
                {
                    if (check.Keys.All(k => letters.ContainsKey(k) && object.Equals(check[k], letters[k])))
                    {
                        output.Add(i - letterCount + 1);
                    }
                }
            }
            return output;
        }
    }
}