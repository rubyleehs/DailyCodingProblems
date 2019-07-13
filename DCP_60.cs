using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_60
{
    /*
    Given a multiset of integers, return whether it can be partitioned into two subsets whose sums are the same.
    For example, given the multiset {15, 5, 20, 10, 35, 15, 10}, it would return true, since we can split it up into {15, 5, 10, 15, 10} and {20, 35}, which both add up to 55.
    Given the multiset {15, 5, 20, 10, 35}, it would return false, since we can't split it up into two subsets that add up to the same sum.
    */

    public class DCP_60
    {
        public static void Main()
        {
            Console.WriteLine(CanSplitTo2EqualSumSets(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static bool CanSplitTo2EqualSumSets(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum % 2 == 1) return false;

            int goal = sum / 2;

            return TryMakeEqual(arr.ToList());
        }

        private static bool TryMakeEqual(List<int> a, List<int> b = null, int skip = 0)
        {
            if (a == null) return false;
            if (b == null) b = new List<int>();
            if (a.Sum() == b.Sum()) return true;
            if (skip > a.Count - 1) return false;
            else
            {
                List<int> a1 = new List<int>(), b1 = new List<int>();
                for (int i = skip; i < a.Count; i++)
                {
                    a1.Copy(a);
                    b1.Copy(b);
                    a1.RemoveAt(i);
                    b1.Add(a[i]);

                    if (TryMakeEqual(a1, b1, skip)) return true;
                    if (TryMakeEqual(a, b, skip + 1)) return true;
                }
                return false;
            }
        }
    }

    public static class Extensions
    {
        public static int Sum(this List<int> l)
        {
            if (l == null) return 0;

            int sum = 0;
            for (int i = 0; i < l.Count; i++)
            {
                sum += l[i];
            }
            return sum;
        }

        public static void Copy(this List<int> l, List<int> toCopy)
        {
            l.Clear();
            for (int i = 0; i < toCopy.Count; i++)
            {
                l.Add(toCopy[i]);
            }
        }
    }
}
