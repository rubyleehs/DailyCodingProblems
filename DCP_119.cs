using System;
using System.Collections.Generic;

namespace DCP_119
{
    /*
    Given a set of closed intervals, find the smallest set of numbers that covers all the intervals. If there are multiple smallest sets, return any of them.
    For example, given the intervals [0, 3], [2, 6], [3, 4], [6, 9], one set of numbers that covers all these intervals is {3, 6}.
    */

    //[0, [2, 3], [3  

    public class DCP_119
    {
        public static void Main()
        {
            List<Interval> intervals = new List<Interval>();
            intervals.Add(new Interval(0, 3));
            intervals.Add(new Interval(2, 6));
            intervals.Add(new Interval(3, 4));
            intervals.Add(new Interval(6, 9));

            List<int> output = FindSmallestStabSet(intervals);

            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine("> " + output[i]);
            }
        }

        public static List<int> FindSmallestStabSet(List<Interval> intervals)
        {
            List<int> output = new List<int>();
            List<IntervalEle> l = new List<IntervalEle>();

            for (int i = 0; i < intervals.Count; i++)
            {
                l.Add(intervals[i].start);
                l.Add(intervals[i].end);
            }

            l.Sort((x, y) =>
            {
                int result = x.value.CompareTo(y.value);
                if (result == 0)
                {
                    if (x.isStart) return -1;
                    else if (y.isStart) return 1;
                }
                return result;
            });

            bool prevWasStart = false;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].isStart) prevWasStart = true;
                else
                {
                    if (prevWasStart) output.Add(l[i].value);
                    prevWasStart = false;
                }
            }
            return output;
        }
    }

    public struct Interval
    {
        public IntervalEle start;
        public IntervalEle end;

        public Interval(int start, int end)
        {
            this.start = new IntervalEle(start, true);
            this.end = new IntervalEle(end, false);
        }
    }

    public struct IntervalEle
    {
        public int value;
        public bool isStart;

        public IntervalEle(int value, bool isStart)
        {
            this.value = value;
            this.isStart = isStart;
        }
    }
}