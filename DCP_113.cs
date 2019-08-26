using System;

namespace DCP_113
{
    /*
    Given a string of words delimited by spaces, reverse the words in string. For example, given "hello world here", return "here world hello"
    Follow-up: given a mutable string representation, can you perform this operation in-place?
    */

    public class DCP_113
    {
        public static void Main()
        {
            string s = "hello world here this is me one two three";
            Console.WriteLine(ReverseStringWords(ref s));
        }

        public static string ReverseStringWords(ref string s)
        {
            int counter = 0;
            int wcount = 0;
            for (int i = 0; i + wcount < s.Length; i++)
            {
                if (s[counter] == ' ')
                {
                    s = s.Insert(s.Length - (i - counter + wcount), ' ' + s.Substring(0, counter));
                    s = s.Remove(0, counter + 1);
                    counter = 0;
                    wcount++;
                }
                counter++;
            }
            return s;
        }
    }
}
