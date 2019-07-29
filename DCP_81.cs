using System;
using System.Collections.Generic;

namespace DCP_81
{
    /*
    Given a mapping of digits to letters (as in a phone number), 
    and a digit string, return all possible letters the number could represent. You can assume each valid number in the mapping is a single digit.
    For example if {“2”: [“a”, “b”, “c”], 3: [“d”, “e”, “f”], …} then “23” should return [“ad”, “ae”, “af”, “bd”, “be”, “bf”, “cd”, “ce”, “cf"].
    */

    public class DCP_81
    {
        public static Dictionary<int, List<char>> map = new Dictionary<int, List<char>>();

        public static void Main()
        {
            map.Add(2, new List<char>() { 'a', 'b', 'c' });
            map.Add(3, new List<char>() { 'd', 'e', 'f' });
            GetAllPossibleMapping(new List<int>() { 2, 3 }).Write();
        }

        public static List<string> GetAllPossibleMapping(List<int> input)
        {
            List<string> output = new List<string>();
            if (input == null || input.Count == 0) return output;

            List<int> arr = new List<int>();
            input.Clone(arr, 1, input.Count);
            List<string> arr2 = GetAllPossibleMapping(arr);
            for (int i = 0; i < map[input[0]].Count; i++)
            {
                if (arr2 == null || arr2.Count == 0) output.Add(map[input[0]][i] + "");
                else
                {
                    for (int ii = 0; ii < arr2.Count; ii++)
                    {
                        output.Add(map[input[0]][i] + arr2[ii]);
                    }
                }
            }

            //output.Write();
            return output;
        }
    }

    public static class Extensions
    {
        public static void Clone<T>(this List<T> thing, List<T> other, int start, int end)
        {
            for (int i = start; i < end; i++) { other.Add(thing[i]); }
        }

        public static void Write<T>(this List<T> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(" " + l[i]);
            }
            Console.WriteLine("-");
        }
    }
}
