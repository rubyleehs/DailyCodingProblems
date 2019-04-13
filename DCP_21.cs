using System;
using System.Linq;

namespace DCP_21
{
    /*
    Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
    For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
    */

    //One way is to just loop through time. which is O(large number * n)
    //other way is to check the start/end and see if its inside another time period, which is O(n^2)

    public struct Lecture
    {
        public float start;
        public float end;
    }

    public class DCP_21
    {
        public static void Main()
        {
            String input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
            Lecture[] lec = new Lecture[(int)Math.Floor(numbers.Length * 0.5)];
            for (int i = 0; i < lec.Length; i++)
            {
                lec[i].start = numbers[2 * i];
                lec[i].end = numbers[2 * i + 1];
            }

            Console.WriteLine(MinNumOfRoomsRequired(lec));
        }


        public static int MinNumOfRoomsRequired(Lecture[] lec)
        {
            int minNumOfRooms = 0;

            for (int x = 0; x < lec.Length; x++)
            {
                int ks = 1;
                int ke = 1;
                for (int y = 0; y < lec.Length; y++)
                {
                    if (x == y) continue;
                    if (lec[x].start >= lec[y].start && lec[x].start < lec[y].end) ks++;
                    if (lec[x].end > lec[y].start && lec[x].end < lec[y].end) ke++;
                }
                if (ke > minNumOfRooms) minNumOfRooms = ke;
                if (ks > minNumOfRooms) minNumOfRooms = ks;
            }

            return minNumOfRooms;
        }
    }
}
