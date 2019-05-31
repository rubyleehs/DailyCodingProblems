using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_33
{
    //Compute the running median of a sequence of numbers.That is, given a stream of numbers, print out the median of the list so far on each new element.
    //Recall that the median of an even-numbered list is the average of the two middle numbers.

    public static class ListExtensions
    {
        public static void SortedAdd(this List<float> l, float f)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (f >= l[i])
                {
                    l.Insert(i, f);
                    return;
                }
            }
            l.Add(f);
        }
    }

    public class DCP_33
    {
        public static void Main()
        {
            GetRunningMedian(Console.ReadLine().Split(' ').Select(float.Parse).ToArray());
        }

        public static void GetRunningMedian(float[] f)
        {
            List<float> bigBucket = new List<float>();
            List<float> smallBucket = new List<float>();
            float median = 0;

            for (int i = 0; i < f.Length; i++)
            {
                int bc = bigBucket.Count;
                int sc = smallBucket.Count;

                if (f[i] >= median)
                {
                    bigBucket.SortedAdd(f[i]);
                    if ((bc + sc) % 2 == 0)
                    {
                        median = bigBucket[bc];
                    }
                    else
                    {
                        median = (bigBucket[bc] + bigBucket[bc - 1]) * 0.5f;
                        smallBucket.Insert(0, bigBucket[bc]);
                        bigBucket.RemoveAt(bc);
                    }
                }
                else
                {
                    smallBucket.SortedAdd(f[i]);
                    if ((bc + sc) % 2 == 0)
                    {
                        median = smallBucket[0];
                        bigBucket.Add(smallBucket[0]);
                        smallBucket.RemoveAt(0);
                    }
                    else
                    {
                        median = (smallBucket[0] + bigBucket[bc - 1]) * 0.5f;
                    }
                }
                Console.WriteLine(median);
            }
        }
    }
}

