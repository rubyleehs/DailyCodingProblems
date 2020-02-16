using System;
using System.Collections.Generic;

namespace DCP_150
{
    /*
    Given a list of points, a central point, and an integer k, find the nearest k points from the central point.
    For example, given the list of points [(0, 0), (5, 4), (3, 1)], the central point (1, 2), and k = 2, return [(0, 0), (3, 1)].
    */

    //no heap in .NET, just gonna just sort for this problem but can be better than O(nlog(n)) time complexity.
    public class DCP_150
    {
        public static void Main()
        {
            Vector2[] points = new Vector2[5] { new Vector2(0, 0), new Vector2(3, 3), new Vector2(-1, -1), new Vector2(2, 2), new Vector2(4, 4) };

            Vector2[] arr = GetClosestPoints(points, new Vector2(-3, -3), 3);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].x + "," + arr[i].y + " ");
            }
        }

        public static Vector2[] GetClosestPoints(Vector2[] points, Vector2 origin, int n)
        {
            List<double> delta = new List<double>();
            List<Vector2> output = new List<Vector2>();
            double d;
            int k;
            for (int i = 0; i < points.Length; i++)
            {
                d = Vector2.SqrDistance(points[i], origin);

                k = 0;
                while (k < delta.Count && d < delta[k]) k++;
                if (k >= delta.Count)
                {
                    delta.Add(d);
                    output.Add(points[i]);
                }
                else
                {
                    delta.Insert(k, d);
                    output.Insert(k, points[i]);
                }

                while (delta.Count > n)
                {
                    delta.RemoveAt(0);
                    output.RemoveAt(0);
                }
            }
            return output.ToArray();
        }

    }

    public class Vector2
    {
        public double x, y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static double SqrDistance(Vector2 a, Vector2 b)
        {
            return (Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }
    }
}
