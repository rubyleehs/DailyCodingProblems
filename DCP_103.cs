using System;
using System.Collections.Generic;

namespace DCP_103
{
    /*
    Given a string and a set of characters, return the shortest substring containing all the characters in the set.
    For example, given the string "figehaeci" and the set of characters {a, e, i}, you should return "aeci".
    If there is no substring containing all the characters in the set, return null.
    */

    public class DCP_103
    {
        public static void Main()
        {
            Console.WriteLine(GetShortestSubstringWithAllChars(Console.ReadLine(), Console.ReadLine()));
        }

        public static string GetShortestSubstringWithAllChars(string s, string c)
        {
            if (c.Length == 0 || s.Length == 0 || c.Length > s.Length) return "";
            string output = "";
            HashSet<char> characters = new HashSet<char>();
            for (int i = 0; i < c.Length; i++)
            {
                characters.Add(c[i]);
            }

            //These should be queues + hashset for it to be faster but eh
            List<CharIndex> l0 = new List<CharIndex>();
            HashSet<char> h0 = new HashSet<char>();
            List<CharIndex> l1 = new List<CharIndex>();

            for (int i = 0; i < s.Length; i++)
            {
                if (characters.Contains(s[i]))
                {
                    if (l0.Count == 0 || !h0.Contains(s[i]))
                    {
                        h0.Add(s[i]);
                        l0.Add(new CharIndex(s[i], i));
                    }
                    else if (l0[0] == s[i])
                    {
                        l0.RemoveAt(0);
                        l0.Add(new CharIndex(s[i], i));
                        while (l1.Count > 0 && l1[0] == l0[0])
                        {
                            l0.RemoveAt(0);
                            l0.Add(l1[0]);
                            l1.RemoveAt(0);
                        }
                    }
                    else l1.Add(new CharIndex(s[i], i));

                    if (l0.Count == characters.Count)
                    {
                        if (output.Length == 0 || output.Length > l0[l0.Count - 1].index - l0[0].index + 1) output = s.Substring(l0[0].index, l0[l0.Count - 1].index - l0[0].index + 1);
                    }
                    else if (l0.Count > characters.Count) Console.WriteLine("What?");
                }
                Console.WriteLine('>' + output);
            }
            return output;
        }
    }

    public struct CharIndex
    {
        public char c;
        public int index;

        public CharIndex(char c, int index)
        {
            this.c = c;
            this.index = index;
        }

        public static bool operator ==(CharIndex v1, CharIndex v2)
        {
            return v1.c == v2.c;
        }
        public static bool operator ==(CharIndex v1, char v2)
        {
            return v1.c == v2;
        }

        public static bool operator !=(CharIndex v1, CharIndex v2)
        {
            return v1.c != v2.c;
        }
        public static bool operator !=(CharIndex v1, char v2)
        {
            return v1.c != v2;
        }
    }
}