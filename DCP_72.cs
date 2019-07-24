using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_72
{
    /*
    In a directed graph, each node is assigned an uppercase letter. We define a path's value as the number of most frequently-occurring letter along that path. For example, if a path in the graph goes through "ABACA", the value of the path is 3, since there are 3 occurrences of 'A' on the path.
    Given a graph with n nodes and m directed edges, return the largest value path of the graph. If the largest value is infinite, then return null.
    The graph is represented with a string and an edge list. The i-th character represents the uppercase letter of the i-th node. Each tuple in the edge list (i, j) means there is a directed edge from the i-th node to the j-th node. Self-edges are possible, as well as multi-edges.
    
    For example, the following input graph:
        ABACA
        [(0, 1),
         (0, 2),
         (2, 3),
         (3, 4)]
    Would have maximum value 3 using the path of vertices [0, 2, 3, 4], (A, A, C, A).

    The following input graph:
        A
        [(0, 0)]
    Should return null, since we have an infinite loop.
    */

    //https://www.cnblogs.com/lz87/p/10354361.html

    public class DCP_72
    {
        public static void Main()
        {
            string s = Console.ReadLine();
            int[] num = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<Vector2> c = new List<Vector2>();
            for (int i = 0; i < num.Length - 1; i += 2)
            {
                c.Add(new Vector2(num[i], num[i + 1]));
            }

            Console.WriteLine(GetLargestValuePath(s, c.ToArray()));
        }

        public static int? GetLargestValuePath(string s, Vector2[] connections)
        {
            Dictionary<int, HashSet<int>> map = ConstructMap(s, connections);
            int[] states = new int[s.Length];
            int[,] maxPaths = new int[s.Length, 26];

            for (int node = 0; node < s.Length; node++)
            {
                if (states[node] == 0)
                {
                    if (dfs(s, map, states, maxPaths, node))
                    {
                        return null;
                    }
                }
            }

            int maxPathValue = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    maxPathValue = Math.Max(maxPaths[i, j], maxPathValue);
                }
            }
            return maxPathValue;

        }

        public static Dictionary<int, HashSet<int>> ConstructMap(string s, Vector2[] connections)
        {
            Dictionary<int, HashSet<int>> output = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                output.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < connections.Length; i++)
            {
                output[connections[i].x].Add(connections[i].y);
            }
            return output;
        }

        public static bool dfs(string s, Dictionary<int, HashSet<int>> map, int[] states, int[,] maxPaths, int node)
        {
            if (states[node] == 2) return false;
            if (states[node] == 1) return true;
            states[node] = 1;

            foreach (int i in map[node])
            {
                dfs(s, map, states, maxPaths, i);
            }

            foreach (int i in map[node])
            {
                for (int letter = 0; letter < 26; letter++)
                {
                    maxPaths[node, letter] = Math.Max(maxPaths[node, letter], maxPaths[i, letter]);
                }
            }

            maxPaths[node, s[node] - 'A']++;
            states[node] = 2;
            return false;
        }
    }

    public struct Vector2
    {
        public int x;
        public int y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}