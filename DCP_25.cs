using System;

namespace DCP_25
{
    /*
    Implement regular expression matching with the following special characters:
        •	. (period) which matches any single character
        •	* (asterisk) which matches zero or more of the preceding element
    That is, implement a function that takes in a string and a valid regular expression and returns whether or not the string matches the regular expression.
    */

    //intresting, never coded anything similar. 

    //TIL Dynamic programming. intresting. its like recursive but in 2d.
    //also just realized i did it in the game human resource machine without realizing what it was
    //and also never really applied it in RL.

    public class DCP_25
    {
        public static void Main()
        {
            string i1 = Console.ReadLine();
            string i2 = Console.ReadLine();
            Console.WriteLine(CompareRegex(i1, i2));
        }

        public static bool CompareRegex(string re, string s)
        {
            bool[,] ba = new bool[re.Length + 1, s.Length + 1];

            for (int si = 0; si <= s.Length; si++)
            {
                for (int ri = 0; ri <= re.Length; ri++)
                {
                    //make table edge
                    if (ri * si == 0)
                    {
                        ba[ri, si] = (ri == si);
                        continue;
                    }
                    //if *
                    //if no occurance, same as as though ?* isnt there so ba[ri-2,si]
                    //if 1 occurance, same as though * isnt there so ba[ri-1,si]
                    //if 2nd occurance, same as though it has 1 occurance so it will be the same as ba[ri-1,si] would also get same result if there was one less letter so ba[ri, si - 1]
                    if (re[ri - 1] == '*')
                    {
                        if (CompareRegexChar(re[ri - 2], s[si - 1])) ba[ri, si] = (ba[ri - 1, si] || ba[ri, si - 1]);
                        else ba[ri, si] = ba[ri - 2, si];
                    }
                    else if (CompareRegexChar(re[ri - 1], s[si - 1])) ba[ri, si] = ba[ri - 1, si - 1];
                    else ba[ri, si] = false;

                    if (ba[ri, si]) Console.Write("1 ");
                    else Console.Write("0 ");
                }
                Console.WriteLine("");
            }
            return ba[re.Length - 1, s.Length - 1];
        }

        public static bool CompareRegexChar(char re, char c)
        {
            if (re == '.') return true;
            else return (re == c);
        }

        /*
        //change re into smaller sections and compare?
        //or just go through each char
        //This seem so hackey
        public static bool CompareRegex(string s, string re)
        {
            int si = 0;
            int ri = 0;
            for (si = s.Length -1, ri = re.Length -1; si >= 0 && ri >= 0; si--, ri--)
            {
                Console.WriteLine("> " + s[si] + " , " + re[ri]);
                if (re[ri] == '*')
                {
                    char prev = re[ri - 1];
                    while (true)
                    {
                        if (ri > 0 && CheckChar(s[si], re[ri - 1]))
                        {
                            Console.WriteLine(">>> " + s[si] + " , " + re[ri - 1]);
                            if (CompareRegex(s.Substring(0,se.Length - si), re.Substring(0, re.Length - ri - 1))) return true;
                        }

                        if (si < s.Length && CheckChar(s[si], prev))
                        {
                            Console.WriteLine(">> " + s[si] + " , " + prev);
                            si--;
                        }
                        else break;
                    }
                    ri--;
                }
                else if (!CheckChar(s[si], re[ri])) return false;
            }
            Console.WriteLine("> " + si + " , " + ri);
            if (ri == 0 && si == 0) return true;
            else return false;
        }

        public static bool CheckChar(char c, char re)
        {
            if (re == '.') return true;
            else return (re == c);
        }
        */
    }
}
