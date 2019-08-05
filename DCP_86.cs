using System;

namespace DCP_86
{
    /*
    Given a string of parentheses, write a function to compute the minimum number of parentheses to be removed to make the string valid (i.e. each open parenthesis is eventually closed).
    For example, given the string "()())()", you should return 1. 
    Given the string ")(", you should return 2, since we must remove all of them.
    */

    public class DCP_86
    {
        public static void Main()
        {
            Console.WriteLine(ParenthesesToRemove(Console.ReadLine()));
        }

        public static int ParenthesesToRemove(string s)
        {
            int o = 0;
            int c = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') o++;
                else if (s[i] == ')')
                {
                    if (o > 0) o--;
                    else c++;
                }
            }

            return o + c;
        }
    }
}