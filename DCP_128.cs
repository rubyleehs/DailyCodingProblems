using System;
using System.Collections.Generic;

namespace DCP_128
{
    /*
    The Tower of Hanoi is a puzzle game with three rods and n disks, each a different size.
    All the disks start off on the first rod in a stack. They are ordered by size, with the largest disk on the bottom and the smallest one at the top.
    The goal of this puzzle is to move all the disks from the first rod to the last rod while following these rules:
        •	You can only move one disk at a time.
        •	A move consists of taking the uppermost disk from one of the stacks and placing it on top of another stack.
        •	You cannot place a larger disk on top of a smaller disk.
    Write a function that prints out all the steps necessary to complete the Tower of Hanoi. You should assume that the rods are numbered, with the first rod being 1, the second (auxiliary) rod being 2, and the last (goal) rod being 3.
    */

    //something fun finally!
    //https://en.wikipedia.org/wiki/Tower_of_Hanoi

    public class DCP_128
    {
        public static void Main()
        {
            TowerOfHanoiSolver2(3);
            Console.WriteLine("=======");
            TowerOfHanoiSolver2(3);
        }

        //Recursive method
        public static void TowerOfHanoiSolver1(int diskNum)
        {
            Stack<int>[] towers = new Stack<int>[3];
            towers[0] = new Stack<int>();
            towers[1] = new Stack<int>();
            towers[2] = new Stack<int>();

            for (int i = 0; i < diskNum; i++)
            {
                towers[0].Push(diskNum - i);
            }

            Move(diskNum, ref towers, 0, 2, 1);
        }
        private static void Move(int n, ref Stack<int>[] towers, int from, int to, int mid)
        {
            if (n > 0)
            {
                Move(n - 1, ref towers, from, mid, to);
                MoveTowerDisk(ref towers, from, to);
                Move(n - 1, ref towers, mid, to, from);
            }
        }

        //Formula/Non recursive method
        public static void TowerOfHanoiSolver2(int diskNum)
        {
            Stack<int>[] towers = new Stack<int>[3];
            towers[0] = new Stack<int>();
            towers[1] = new Stack<int>();
            towers[2] = new Stack<int>();

            for (int i = 0; i < diskNum; i++)
            {
                towers[0].Push(diskNum - i);
            }

            int lastTowerPlaced;
            if (diskNum % 2 == 0) lastTowerPlaced = MoveTowerDisk(ref towers, 0, 1);
            else lastTowerPlaced = MoveTowerDisk(ref towers, 0, 2);

            int toTower;

            while (towers[2].Count < diskNum)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == lastTowerPlaced) continue;
                    if (towers[i].Count == 0) continue;

                    toTower = -1;
                    for (int ii = 0; ii < 3; ii++)
                    {
                        if (ii == i) continue;
                        if (towers[ii].Count == 0)
                        {
                            if (toTower < 0) toTower = ii;
                        }
                        else if (towers[i].Peek() < towers[ii].Peek() && (towers[i].Peek() + towers[ii].Peek()) % 2 == 1)
                        {
                            toTower = ii;
                            break;
                        }
                    }

                    if (toTower >= 0)
                    {
                        lastTowerPlaced = MoveTowerDisk(ref towers, i, toTower);
                        break;
                    }
                }
            }
        }

        private static int MoveTowerDisk(ref Stack<int>[] towers, int fromTower, int toTower)
        {
            Console.WriteLine("Moved Disk #" + towers[fromTower].Peek() + " from Tower " + fromTower + " to Tower" + toTower);
            towers[toTower].Push(towers[fromTower].Pop());
            return toTower;
        }
    }
}
