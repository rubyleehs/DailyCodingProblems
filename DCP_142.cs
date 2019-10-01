using System;

namespace DCP_142
{
    /*
    You're given a string consisting solely of (, ), and *. * can represent either a (, ), or an empty string. Determine whether the parentheses are balanced.
    For example, (()* and (*) are balanced. )*( is not balanced.
    */

    public class DCP_142
    {
        public static void Main()
        {
            Console.WriteLine(isBalance("(()*"));
            Console.WriteLine(isBalance("(*)"));
            Console.WriteLine(isBalance(")*(") == false);

        }

        public static bool isBalance(string s, int numOpen = 0)
        {
            int o = numOpen;

            for (int i = 0; i < s.Length; i++)
            {
                if (o < 0) return false;
                if (s[i] == '(') o++;
                else if (s[i] == ')') o--;
                else if (s[i] == '*')
                {
                    if (i == s.Length - 1) return (o == 1);
                    else if (isBalance(s.Substring(i + 1), o + 1)) return true;
                    else if (isBalance(s.Substring(i + 1), o - 1)) return true;
                }
            }

            return (o == 0);
        }
    }
}
