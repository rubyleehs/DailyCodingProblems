using System;

namespace DCP_27
{
    /*
    Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).
    For example, given the string "([])[]({})", you should return true.
    Given the string "([)]" or "((()", you should return false.

    */
    public class DCP_27
    {
        private static string bo = "({[";
        private static string be = ")}]";

        public static void Main()
        {
            Console.WriteLine(CheckBracketsBalance(Console.ReadLine()));
        }

        public static bool CheckBracketsBalance(string input)
        {
            string r = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (bo.Contains("" + input[i])) r = input[i] + r;
                else if (be.Contains("" + input[i]))
                {
                    if (r.Length > 0 && bo.IndexOf(r[0]) == be.IndexOf(input[i])) r = r.Remove(0, 1);
                    else return false;
                }
            }
            if (r.Length == 0) return true;
            else return false;
        }
    }
}

