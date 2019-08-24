using System;

namespace DCP_108
{
    /*
    Given two strings A and B, return whether or not A can be shifted some number of times to get B.
    For example, if A is abcde and B is cdeab, return true. If A is abc and B is acb, return false.
    */
    public class DCP_108
    {
        public static void Main()
        {
            Console.WriteLine(AreShiftedStrings("abcde", "cdeab") == true);
            Console.WriteLine(AreShiftedStrings("abc", "acb") == false);
        }


        public static bool AreShiftedStrings(string a, string b)
        {
            if (a == b) return true;
            if (a.Length != b.Length) return false;

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == a[0])
                {
                    if (b.Substring(i) == a.Substring(0, b.Length - i) && b.Substring(0, i) == a.Substring(b.Length - i, i)) return true;
                }
            }
            return false;
        }
    }
}
