using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_96
{
    /*
    Given a number in the form of a list of digits, return all possible permutations.
    For example, given [1,2,3], return [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]].
   */

    public class DCP_96
    {
        public static void Main()
        {
            List<List<int>> permutations = GetAllPermutations(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            for (int i = 0; i < permutations.Count; i++)
            {
                permutations[i].Write();
            }
        }

        public static List<List<int>> GetAllPermutations(List<int> l)
        {
            if (l == null) return null;
            if (l.Count == 1) return new List<List<int>>() { l };

            List<List<int>> output = new List<List<int>>();
            List<List<int>> k;
            for (int i = 0; i < l.Count; i++)
            {
                k = GetAllPermutations(l.CopyAllButOne(i));
                for (int ii = 0; ii < k.Count; ii++)
                {
                    k[ii].Add(l[i]);
                }
                output.AddRange(k);
            }
            return output;
        }
    }

    public static class Extensions
    {
        public static List<T> CopyAllButOne<T>(this List<T> l0, int except)
        {
            List<T> l1 = new List<T>();
            for (int i = 0; i < l0.Count; i++)
            {
                if (i == except) continue;
                l1.Add(l0[i]);
            }
            return l1;
        }

        public static void Write(this List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i]);
            }
            Console.WriteLine(' ');
        }
    }
}