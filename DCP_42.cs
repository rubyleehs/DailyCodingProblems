using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_42
{
    /*
    Given a list of integers S and a target number k, write a function that returns a subset of S that adds up to k. If such a subset cannot be made, then return null.
    Integers can appear more than once in the list. You may assume all numbers in the list are positive.
    For example, given S = [12, 1, 61, 5, 9, 2] and k = 24, return [12, 9, 2, 1] since it sums up to 24.
    */

    public class DCP_42
    {

        public static void Main()
        {
            GetPossibleSum(Console.ReadLine().Split(' ').Select(int.Parse).ToList(), int.Parse(Console.ReadLine())).Write();
        }

        public static List<int> GetPossibleSum(List<int> l, int target)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] > target) continue;
                else if (l[i] == target)
                {
                    output.Add(l[i]);
                    return output;
                }
                else
                {
                    List<int> temp = new List<int>();
                    l.Clone(temp);
                    temp.RemoveAt(i);
                    temp = GetPossibleSum(temp, target - l[i]);
                    if (temp.Count > 0)
                    {
                        output.Add(l[i]);
                        output.AddRange(temp);
                        return output;
                    }
                }
            }
            return output;
        }
    }

    public static class Extensions
    {
        public static void Clone<T>(this List<T> thing, List<T> other)
        {
            for (int i = 0; i < thing.Count; i++) { other.Add(thing[i]); }
        }

        public static void Write<T>(this List<T> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i] + " ");
            }
            Console.WriteLine("");
        }
    }
}