using System;
using System.Collections.Generic;

namespace DCP_132
{
    /*
    Design and implement a HitCounter class that keeps track of requests (or hits). It should support the following operations:
    •	record(timestamp): records a hit that happened at timestamp
    •	total(): returns the total number of hits recorded
    •	range(lower, upper): returns the number of hits that occurred between timestamps lower and upper (inclusive)
    Follow-up: What if our system has limited memory?
    */

    public class DCP_132
    {

    }

    public class HitCounter
    {
        public SortedList<int> hits;
        public HitCounter()
        {
            hits = new SortedList<int>();
        }

        public void Record(int timestamp)
        {
            hits.Add(timestamp);
        }

        public int Total()
        {
            return hits.Count;
        }

        public int Range(int lower, int upper)
        {
            int count = 0;
            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i] < lower) continue;
                if (hits[i] > upper) break;
                count++;
            }
            return count;
        }
    }
}
