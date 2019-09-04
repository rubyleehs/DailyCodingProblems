using System;

namespace DCP_123
{
    /*
    Given a string, return whether it represents a number. Here are the different kinds of numbers:
        •	"10", a positive integer
        •	"-10", a negative integer
        •	"10.1", a positive real number
        •	"-10.1", a negative real number
        •	"1e5", a number in scientific notation

    And here are examples of non-numbers:
        •	"a"
        •	"x 1"
        •	"a -2"
        •	"-"
    */

    public class DCP_123
    {
        private static readonly char[] numChar = "0123456789-.e".ToCharArray(); //Also has numbers so it don't need another check

        public static void Main()
        {
            Console.WriteLine(IsNumber("10"));
            Console.WriteLine(IsNumber("-10"));
            Console.WriteLine(IsNumber("10.1"));
            Console.WriteLine(IsNumber("-10.1"));
            Console.WriteLine(IsNumber("1e5"));
            Console.WriteLine(IsNumber("a"));
            Console.WriteLine(IsNumber("x 1"));
            Console.WriteLine(IsNumber("a -2"));
            Console.WriteLine(IsNumber("-"));
        }

        public static bool IsNumber(string s)
        {
            if (s.Length == 0) return false;
            if (s.Length == 1) return (Char.IsDigit(s[0]));
            //Console.WriteLine(s.IndexOfAny(numChar));
            if (s.IndexOfAny(numChar) > 0) return false;

            string s1 = s;
            //removes initial negatives
            if (s1[0] == '-') s1 = s1.Substring(1, s1.Length - 1);

            bool decimalHasAppeared = false;
            for (int i = 0; i < s1.Length; i++)
            {
                //Console.WriteLine(s1[i]);
                if (Char.IsDigit(s1[i])) continue;
                else if (s1[i] == 'e') return IsNumber(s1.Substring(i + 1, s1.Length - 1 - i));
                else if (s1[i] == '-') return false;
                else
                {
                    if (decimalHasAppeared) return false;
                    decimalHasAppeared = true;
                    //if decimal, prev and next number have to be too
                    if (i > 0 && i < s1.Length - 1 && Char.IsDigit(s1[i - 1]) && Char.IsDigit(s1[i + 1])) continue;
                    else return false;
                }
            }
            return true;
        }
    }
}