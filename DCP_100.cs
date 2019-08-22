using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_100
{
    /*
        You are in an infinite 2D grid where you can move in any of the 8 directions:
             (x,y) to
                (x+1, y),
                (x - 1, y),
                (x, y+1),
                (x, y-1),
                (x-1, y-1),
                (x+1,y+1),
                (x-1,y+1),
                (x+1,y-1)
        You are given a sequence of points and the order in which you need to cover the points. Give the minimum number of steps in which you can achieve it. You start from the first point.
    */

    //For the 100th DCP, this is anti-climatic

    public class DCP_100
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<Vector2> va = new List<Vector2>();

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                va.Add(new Vector2(input[i], input[i + 1]));
            }
            Console.WriteLine(MinNumStepsToTransverse(va.ToArray()));
        }

        public static int MinNumStepsToTransverse(Vector2[] arr)
        {
            if (arr == null || arr.Length == 1) return 0;
            int output = 0;
            Vector2 delta;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                delta = arr[i + 1] - arr[i];
                delta.SetPositive();
                output += Math.Max(delta.x, delta.y);
            }

            return output;
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

        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);


        public void SetPositive()
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
        }
    }
}

