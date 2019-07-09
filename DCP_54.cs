using System;
using System.Collections.Generic;

namespace DCP_54
{
    /*
    Sudoku is a puzzle where you're given a partially-filled 9 by 9 grid with digits. The objective is to fill the grid with the constraint that every row, column, and box (3 by 3 subgrid) must contain all of the digits from 1 to 9.
    Implement an efficient sudoku solver.
 
    */

    //it's not tower of hanoi, but I guess i got what i wanted lol


    public class DCP_54
    {
        public static void Main()
        {
            SudokuSolver s = new SudokuSolver(new Vector2(4, 4), 4);
            s.DefineRegion(new HashSet<Vector2>() { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) });
            s.DefineRegion(new HashSet<Vector2>() { new Vector2(2, 0), new Vector2(3, 0), new Vector2(2, 1), new Vector2(3, 1) });
            s.DefineRegion(new HashSet<Vector2>() { new Vector2(0, 2), new Vector2(1, 2), new Vector2(0, 3), new Vector2(1, 3) });
            s.DefineRegion(new HashSet<Vector2>() { new Vector2(2, 2), new Vector2(3, 2), new Vector2(2, 3), new Vector2(3, 3) });
            s.Set(new Vector2(0, 3), 1);
            s.Set(new Vector2(1, 0), 3);
            s.Set(new Vector2(2, 1), 2);
            s.Set(new Vector2(3, 2), 4);
            s.Solve();
            s.Print();
        }
    }

    public class SudokuSolver
    {
        List<HashSet<Vector2>> regions;
        GridCell[,] grid;

        Vector2 gridSize;
        int numTypes;

        List<Vector2> checkQueue;

        public SudokuSolver(Vector2 gridSize, int numTypes)
        {
            this.gridSize = gridSize;
            this.numTypes = numTypes;
            regions = new List<HashSet<Vector2>>();
            checkQueue = new List<Vector2>();

            grid = new GridCell[gridSize.x, gridSize.y];

            for (int y = 0; y < gridSize.y; y++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    grid[x, y] = new GridCell(numTypes);
                }
            }
        }

        public void DefineRegion(HashSet<Vector2> cells)
        {
            foreach (Vector2 v in cells)
            {
                if (isWithinGrid(v)) continue;
                else
                {
                    Console.WriteLine("Invalid Region");
                    return;
                }
            }
            regions.Add(cells);
        }

        public void Set(Vector2 pos, int data)
        {
            if (isWithinGrid(pos))
            {
                grid[pos.x, pos.y].Set(data);
                checkQueue.Add(pos);
            }
        }

        private void Update(Vector2 pos)
        {
            int ans = grid[pos.x, pos.y].ans;
            if (ans < 0) return;
            else
            {
                Console.WriteLine("> " + pos.x + ',' + pos.y + " ans is: " + ans);
            }
            Vector2 v;

            //Update Horizontal
            for (int x = 0; x < gridSize.x; x++)
            {
                v = new Vector2(x, pos.y);
                if (v.Equals(pos)) continue;
                if (grid[x, pos.y].Remove(ans)) checkQueue.Add(v);
            }

            //Update Vertical
            for (int y = 0; y < gridSize.y; y++)
            {
                v = new Vector2(pos.x, y);
                if (v.Equals(pos)) continue;
                if (grid[pos.x, y].Remove(ans)) checkQueue.Add(v);
            }

            for (int i = 0; i < regions.Count; i++)
            {
                if (regions[i].Contains(pos))
                {
                    HashSet<Vector2> r = regions[i];
                    foreach (Vector2 vec in r)
                    {
                        if (vec.Equals(pos)) continue;
                        if (grid[vec.x, vec.y].Remove(ans)) checkQueue.Add(vec);
                    }
                }
            }

        }

        public void Solve()
        {
            while (checkQueue.Count > 0)
            {
                Update(checkQueue[0]);
                checkQueue.RemoveAt(0);
            }
        }

        public void Print()
        {
            string s = "";
            for (int y = gridSize.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    s += grid[x, y].ans;
                }
                s += '\n';
            }
            Console.WriteLine(s);
        }

        public bool isWithinGrid(Vector2 pos)
        {
            return !(pos.x < 0 || pos.y < 0 || pos.x >= gridSize.x || pos.y >= gridSize.y);
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

    public struct GridCell
    {
        public int ans;
        HashSet<int> p;

        public GridCell(int numTypes)
        {
            p = new HashSet<int>();
            for (int i = 0; i < numTypes; i++)
            {
                p.Add(i + 1);
            }
            ans = -1;
        }

        public bool Set(int val)
        {
            if (p.Contains(val))
            {
                p.Clear();
                ans = val;
                return true;
            }

            Console.WriteLine("Value: " + val + "is not one of the possible values");
            return false;
        }

        public bool Remove(int val)
        {
            p.Remove(val);
            if (p.Count == 1)
            {
                foreach (int i in p)
                {
                    ans = i;
                    p.Remove(i);
                    return true;
                }
            }
            return false;
        }
    }
}