using System;

namespace DCP_31
{
    //The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other. 
    //For example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.
    //Given two strings, compute the edit distance between them

    //How dafaq is this considered EASY difficulty?
    //How even do they evaluate difficulty lol

    //is difficulty based on how easy is it to find an algorithm online lol. Aren't these interview questions? Can we even google? Is this an algorithm that everyone just knows or something?
    //googling just makes all the problems trivial though whut
    //meanwhile A*/dijkstra was considered medium-hard difficulty .-.

    //if word longer means we definately need to add chars
    //deleting is only beneficial if not useful character < num of chars that moves into correct relative position

    //abcdefg -> aabbccffgg is 7 edits
    //breakcatapart ->breakapart is 3 edits
    //bro-ken-apa-rt-- -> brokenapaty is  5 edits

    //are we supposed to brute force this? seriously? cant see an easy method to know which is the shortest path unless brute force

    public class DCP_31
    {
        public static void Main()
        {
            Console.WriteLine(BruteEditDist(Console.ReadLine(), Console.ReadLine()));
        }

        public static int BruteEditDist(string s1, string s2)
        {
            if (s1.Length == 0) return s2.Length;
            if (s2.Length == 0) return s1.Length;

            if (s1[0] == s2[0]) return BruteEditDist(s1.Substring(1), s2.Substring(1));
            else return (1 + Math.Min(BruteEditDist(s1.Substring(1), s2), Math.Min(BruteEditDist(s1, s2.Substring(1)), BruteEditDist(s1.Substring(1), s2.Substring(1)))));
        }
    }
}