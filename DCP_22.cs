using System;
using System.Collections.Generic;

namespace DCP_22
{
    /*
    Given a dictionary of words and a string made up of those words (no spaces), return the original sentence in a list. If there is more than one possible reconstruction, return any of them. If there is no possible reconstruction, then return null.
    For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox", you should return ['the', 'quick', 'brown', 'fox'].
    Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond", return either ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].
    */

    public class DCP_22
    {
        public static HashSet<string> dict;

        public static void Main()
        {
            dict = new HashSet<string>(Console.ReadLine().Split(' '));
            Console.WriteLine(dict.Count);
            List<string> output = new List<string>();
            WordBreak(Console.ReadLine(), dict, 10, out output);

            Console.Write("> ");
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }
        }


        public static bool WordBreak(string words, HashSet<string> dict, int maxLengthWordToCheck, out List<string> output)
        {
            if (words.Length == 0)
            {
                Console.WriteLine("end");
                output = new List<string>();
                return true;
            }
            int ml = Math.Min(maxLengthWordToCheck, words.Length);
            string w = "";

            for (int i = 0; i < ml; i++)
            {
                w = words.Substring(0, i + 1);
                if (dict.Contains(w))
                {
                    if (WordBreak(words.Substring(i + 1), dict, maxLengthWordToCheck, out output))
                    {
                        output.Insert(0, w);
                        return true;
                    }
                }
            }
            output = new List<string>(); ;
            return false;
        }
    }
}