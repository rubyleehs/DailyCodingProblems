using System;
using System.Collections.Generic;

namespace DCP_38
{
    /*
    You have an N by N board. Write a function that, given N, returns the number of possible arrangements of the board where 
    N queens can be placed on the board without threatening each other, i.e. no two queens share the same row, column, or diagonal.
    */

    public class DCP_38
    {
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

        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(NumOfQueenArrangements(input, 0, input, new List<Vector2>()));
        }

        public static int NumOfQueenArrangements(int queensToPlace, int queensPlaced, int boardSize, List<Vector2> knownQPos, int dy = 0)
        {
            if (queensToPlace == queensPlaced) return 1;
            int output = 0;
            for (int y = dy; y < boardSize; y++)
            {
                for (int x = 0; x < boardSize; x++)
                {
                    if (isValidQueenPos(knownQPos, new Vector2(x, y)))
                    {
                        List<Vector2> temp = new List<Vector2>();
                        knownQPos.Clone(temp);
                        temp.Add(new Vector2(x, y));
                        output += NumOfQueenArrangements(queensToPlace, queensPlaced + 1, boardSize, temp, y + 1);
                    }
                }
            }
            return output;
        }

        public static bool isValidQueenPos(List<Vector2> knownQPos, Vector2 checkPos)
        {
            for (int i = 0; i < knownQPos.Count; i++)
            {
                if (checkPos.x == knownQPos[i].x || checkPos.y == knownQPos[i].y || (knownQPos[i].x - checkPos.x) * (knownQPos[i].x - checkPos.x) == (knownQPos[i].y - checkPos.y) * (knownQPos[i].y - checkPos.y))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public static class Extensions
    {
        public static void Clone<T>(this List<T> thing, List<T> other)
        {
            for (int i = 0; i < thing.Count; i++) { other.Add(thing[i]); }
        }
    }
}