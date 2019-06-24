using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_37
{
    /*
    The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
    For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
    You may also use a list or array to represent a set.
    */

    public class DCP_37
    {
        public static void Main()
        {
            List<List<int>> powerSet = CreatePowerSet(Console.ReadLine().Split(' ').Select(int.Parse).ToList());

            for (int i = 0; i < powerSet.Count; i++)
            {
                powerSet[i].Write();
            }
        }

        public static List<List<int>> CreatePowerSet(List<int> l, int cal = 0)
        {
            List<List<int>> output = new List<List<int>>();

            output.Add(l);

            for (int i = cal; i < l.Count; i++)
            {
                List<int> subset = new List<int>();
                l.Clone(subset);
                subset.RemoveAt(i);
                output.AddRange(CreatePowerSet(subset, i));
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
                Console.Write(l[i]);
            }
            Console.WriteLine("");
        }
    }
}