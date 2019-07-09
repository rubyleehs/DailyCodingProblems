using System;
using System.Collections.Generic;

namespace DCP_52
{
    /*
    Implement an LRU (Least Recently Used) cache. It should be able to be initialized with a cache size n, and contain the following methods:
    •	set(key, value): sets key to value. If there are already n items in the cache and we are adding a new item, then it should also remove the least recently used item.
    •	get(key): gets the value at key. If no such key exists, return null.

    Each operation should run in O(1) time.
    */

    public class DCP_52
    {
        public static void Main()
        {
            LRUCache<string> d = new LRUCache<string>(3);
            d.Set(0, "zero");
            d.Set(1, "one");
            d.Set(2, "two");
            d.Set(3, "three");
            Console.WriteLine("> " + d.Get(0));
            Console.WriteLine("> " + d.Get(1));
            d.Set(4, "four");
            Console.WriteLine("> " + d.Get(2));
            Console.WriteLine("> " + d.Get(1));

            /*
			should return
			>
			> one
			>
			> one
			*/
        }
    }

    public class LRUCache<T>
    {
        private List<T> data;

        private List<int> keys;
        private HashSet<int> map;

        private int cacheSize;

        //Its possible for Keys be a V2 struct so dont need to move elements in Data when Getting/Setting value that is already in data, but i'm rushing and it's not much diffrent.
        public LRUCache(int cacheSize)
        {
            data = new List<T>();
            keys = new List<int>();
            map = new HashSet<int>();
            this.cacheSize = cacheSize;
        }

        public T Get(int key)
        {
            if (map.Contains(key))
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i] == key)
                    {
                        T output = data[i];
                        data.RemoveAt(i);
                        keys.RemoveAt(i);
                        data.Add(output);
                        keys.Add(key);
                        return output;
                    }
                }
            }
            return default(T);
        }

        public void Set(int key, T value)
        {
            if (map.Contains(key))
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i] == key)
                    {
                        T temp = data[i];
                        data.RemoveAt(i);
                        keys.RemoveAt(i);
                        data.Add(value);
                        keys.Add(key);
                    }
                }
            }
            else
            {
                while (keys.Count >= cacheSize)
                {
                    map.Remove(keys[0]);
                    keys.RemoveAt(0);
                    data.RemoveAt(0);
                }

                data.Add(value);
                keys.Add(key);
                map.Add(key);
            }
        }
    }
}