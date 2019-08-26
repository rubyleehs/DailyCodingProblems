using System;
using System.Collections.Generic;

namespace DCP_114
{
    /*
    Given a string and a set of delimiters, reverse the words in the string while maintaining the relative order of the delimiters. For example, given "hello/world:here", return "here/world:hello"
    Follow-up: Does your solution work for the following cases: "hello/world:here/", "hello//world:here"
    */

    public class DCP_114
    {
        public static void Main()
        {
            string s = "hello//world:here";
            HashSet<char> dl = new HashSet<char>();
            dl.Add('/');
            dl.Add(':');
            Console.WriteLine(ReverseStringWordsMaintainDelimiters(ref s, dl));
        }

        public static string ReverseStringWordsMaintainDelimiters(ref string s, HashSet<char> delimiters)
        {
            int left = 0;
            int right = s.Length - 1;
            int wl;
            int wr;

            while (left < right)
            {
                wl = 0;
                wr = 0;
                while (left < right)
                {
                    if (delimiters.Contains(s[left])) break;
                    else
                    {
                        left++;
                        wl++;
                    }
                }

                while (left < right)
                {
                    if (delimiters.Contains(s[right])) break;
                    else
                    {
                        right--;
                        wr++;
                    }
                }
                if (left > right) break;
                s = s.Insert(right + wr + 1, s.Substring(left - wl, wl));
                s = s.Insert(left - wl, s.Substring(right + 1, wr));
                s = s.Remove(left - wl + wr, wl);
                s = s.Remove(right - wl + wr + 1, wr);
                left = left + 1 - (wl - wr);
                right = right - 1 - (wl - wr);
            }
            return s;
        }
    }
}

