using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_97
{
    /*
    Write a map implementation with a get function that lets you retrieve the value of a key at a particular time.
    It should contain the following methods:
        •	set(key, value, time): sets key to value for t = time.
        •	get(key, time): gets the key at t = time.
    The map should work like this. If we set a key at a particular time, it will maintain that value forever or until it gets set at a later time. In other words, when we get a key at a time, it should return the value that was set for that key set at the most recent time.
   */

    //oops. misread.
    //close enough. just make a List of timelines.

    public class DCP_97
    {
        public static Timeline t = new Timeline();
        public static void Main()
        {
            //t.Print(5);
            t.Set(1, 1, 0);
            t.Set(3, 3, 0);
            t.Print(0f);
            t.Print(1f);
            t.Print(2f);
            t.Print(3f);
            t.Print(4f);
            t.Set(1.5f, 2f, 1);
            t.Print(1.6f);
            t.Print(2.6f);
            t.Print(3.6f);
        }
    }

    public class Timeline
    {
        private SortedDictionary<float, float> timeline;

        public Timeline()
        {
            timeline = new SortedDictionary<float, float>();
        }

        public void Set(float time, float value)
        {
            if (timeline.ContainsKey(time)) timeline[time] = value;
            else timeline.Add(time, value);
        }

        public void Set(float time, float value, float duration)
        {
            Set(time + duration, Get(time + duration));
            Set(time, value);
            if (duration > 0)
            {
                foreach (KeyValuePair<float, float> t in timeline)
                {
                    if (t.Key >= time + duration) break;
                    if (t.Key > time) timeline.Remove(t.Key);
                }
            }
        }

        public float Get(float time)
        {
            if (timeline.Count == 0) return 0;
            if (timeline.ContainsKey(time)) return timeline[time];
            if (time < timeline.First().Key) return 0;


            KeyValuePair<float, float> prev = timeline.First();
            foreach (KeyValuePair<float, float> t in timeline)
            {
                if (time < t.Key) return prev.Value;
                prev = t;
            }
            return prev.Value;
        }

        public void Print(float time)
        {
            Console.WriteLine(Get(time));
        }
        public void PrintAll()
        {
            foreach (KeyValuePair<float, float> t in timeline)
            {
                Console.WriteLine(t.Key + " | " + t.Value);
            };
        }
    }
}