using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_39
{
    /*
    Conway's Game of Life takes place on an infinite two-dimensional board of square cells. Each cell is either dead or alive, and at each tick, the following rules apply:
        •	Any live cell with less than two live neighbours dies.
        •	Any live cell with two or three live neighbours remains living.
        •	Any live cell with more than three live neighbours dies.
        •	Any dead cell with exactly three live neighbours becomes a live cell.
    A cell neighbours another cell if it is horizontally, vertically, or diagonally adjacent.
    Implement Conway's Game of Life. It should be able to be initialized with a starting list of live cell coordinates and the number of steps it should run for. 
    Once initialized, it should print out the board state at each step. Since it's an infinite board, print out only the relevant coordinates, 
    i.e. from the top-leftmost live cell to bottom-rightmost live cell.
    You can represent a live cell with an asterisk (*) and a dead cell with a dot (.).     
    */

    //infinite whut
    //store map or store live cells?
    //pros of map: easeir to visualize/print
    //cons of map: map size will keep changing
    //pros of store cells: figure out corners faster?
    //cons of stored cells: somehow need to know adj cells state

    public class DCP_39
    {
        public static HashSet<Vector2> liveCells;

        public static void Main()
        {
            liveCells = new HashSet<Vector2>();
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < input.Length - 1; i += 2)
            {
                liveCells.Add(new Vector2(input[i], input[i + 1]));
            }
            PrintBoard();
            while (true)
            {
                string text = Console.ReadLine();
                Console.WriteLine(text);

                liveCells = Step();
                PrintBoard();
            }
        }

        public static void PrintBoard()
        {
            List<Vector2> a = liveCells.ToList<Vector2>();
            if (a.Count == 0) return;

            int minX = a[0].x, maxX = a[0].x, minY = a[0].y, maxY = a[0].y;
            for (int i = 1; i < a.Count; i++)
            {
                if (a[i].x > maxX) maxX = a[i].x;
                else if (a[i].x < minX) minX = a[i].x;

                if (a[i].y > maxY) maxY = a[i].y;
                else if (a[i].y < minY) minY = a[i].y;
            }

            string map = "";
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (liveCells.Contains(new Vector2(x, y))) map += "*";
                    else map += ".";
                }
                map += '\n';
            }

            Console.WriteLine(map);
        }


        public static HashSet<Vector2> Step()
        {
            HashSet<Vector2> check = new HashSet<Vector2>();
            List<Vector2> a = liveCells.ToList<Vector2>();

            for (int i = 0; i < a.Count; i++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        Vector2 p = new Vector2(a[i].x + dx, a[i].y + dy);
                        if (GetStatus(p, liveCells.Contains(p))) check.Add(p);
                    }
                }
            }
            return check;
        }

        public static bool GetStatus(Vector2 o, bool isLive)
        {
            int adjLiveCells = 0;

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dy == 0 && dx == 0) continue;
                    if (liveCells.Contains(new Vector2(o.x + dx, o.y + dy))) adjLiveCells++;
                }
            }
            if (isLive)
            {
                if (adjLiveCells < 2 || adjLiveCells > 3) return false;
                else return true;
            }
            else
            {
                if (adjLiveCells == 3) return true;
                else return false;
            }
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