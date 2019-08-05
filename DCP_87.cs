using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_87
{
    /*
    A rule looks like this:
        A NE B

    This means this means point A is located northeast of point B.
        A SW C

    means that point A is southwest of C.

    Given a list of rules, check if the sum of the rules validate. 
    For example:
        A N B
        B NE C
        C N A

    does not validate, since A cannot be both north and south of C.

    A NW B
    A N B

    is considered valid.
    */


    //Not sure if my current method will work 100%, but seems to work in all cases i tried.
    public class DCP_87
    {
        static Dictionary<string, Node> map;
        public static void Main()
        {
            map = new Dictionary<string, Node>();

            while (true)
            {
                Console.WriteLine(ValidateRule(Console.ReadLine()));
            }
        }

        public static bool ValidateRule(string s)
        {
            string[] s1 = s.Split(' ');
            int x = 0;
            int y = 0;
            if (s1[1].Contains('N')) y = 1;
            else if (s1[1].Contains('S')) y = -1;
            if (s1[1].Contains('E')) x = 1;
            else if (s1[1].Contains('W')) x = -1;

            if (!map.ContainsKey(s1[2]))
            {
                if (map.Count == 0) map.Add(s1[2], new Node(0, 0, 0, 0));
                else map.Add(s1[2], new Node());
            }
            if (!map.ContainsKey(s1[0])) map.Add(s1[0], new Node());


            if (x > 0)
            {
                if (map[s1[0]].maxX <= map[s1[2]].minX) return false;
                else
                {
                    map[s1[0]].minX = Math.Max(map[s1[0]].minX, map[s1[2]].maxX);
                    if (map[s1[0]].minX > map[s1[0]].maxX)
                    {
                        map[s1[0]].minX = map[s1[0]].maxX;
                        map[s1[2]].maxX = map[s1[0]].minX;
                    }
                }
            }
            else if (x < 0)
            {
                if (map[s1[0]].minX >= map[s1[2]].maxX) return false;
                else
                {
                    map[s1[0]].maxX = Math.Min(map[s1[0]].maxX, map[s1[2]].minX);
                    if (map[s1[0]].maxX < map[s1[0]].minX)
                    {
                        map[s1[0]].maxX = map[s1[0]].minX;
                        map[s1[2]].minX = map[s1[0]].maxX;
                    }
                }
            }
            if (y > 0)
            {
                if (map[s1[0]].maxY <= map[s1[2]].minY) return false;
                else
                {
                    map[s1[0]].minY = Math.Max(map[s1[0]].minY, map[s1[2]].maxY);
                    if (map[s1[0]].minY > map[s1[0]].maxY)
                    {
                        map[s1[0]].minY = map[s1[0]].maxY;
                        map[s1[2]].maxY = map[s1[0]].minY;
                    }
                }
            }
            else if (y < 0)
            {
                if (map[s1[0]].minY >= map[s1[2]].maxY) return false;
                else
                {
                    map[s1[0]].maxY = Math.Min(map[s1[0]].maxY, map[s1[2]].minY);
                    if (map[s1[0]].maxY < map[s1[0]].minY)
                    {
                        map[s1[0]].maxY = map[s1[0]].minY;
                        map[s1[2]].minY = map[s1[0]].maxY;
                    }
                }
            }
            return true;
        }
    }

    public class Node
    {
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;
        public Node(float minX = -128, float minY = -128, float maxX = 128, float maxY = 128)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }
    }
}
