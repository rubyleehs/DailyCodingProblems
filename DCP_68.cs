using System;
using System.Collections.Generic;

namespace DCP_68
{
    /*
    On our special chessboard, two bishops attack each other if they share the same diagonal.This includes bishops that have another bishop located between them, i.e.bishops can attack through pieces.
    You are given N bishops, represented as (row, column) tuples on a M by M chessboard. Write a function to count the number of pairs of bishops that attack each other. 
    The ordering of the pair doesn't matter: (1, 2) is considered the same as (2, 1).

    For example, given M = 5 and the list of bishops:
        •	(0, 0)
        •	(1, 2)
        •	(2, 2)
        •	(4, 0)

    The board would look like this:
        [b 0 0 0 0]
        [0 0 b 0 0]
        [0 0 b 0 0]
        [0 0 0 0 0]
        [b 0 0 0 0]

    You should return 2, since bishops 1 and 3 attack each other, as well as bishops 3 and 4.
    */

    public class DCP_68
    {
        public static void Main()
        {
            BChess bc = new BChess(new Vector2(5, 5));
            bc.PlaceBishop(new Vector2(0, 0));
            bc.PlaceBishop(new Vector2(1, 2));
            bc.PlaceBishop(new Vector2(2, 2));
            bc.PlaceBishop(new Vector2(4, 0));

            Console.WriteLine(bc.NumOfPairsOfBishopsAttackingEachOther());
        }
    }

    public class BChess
    {
        private bool[,] board;
        private Vector2 size;
        private HashSet<Vector2> bishops;

        public BChess(Vector2 size)
        {
            this.size = size;
            board = new bool[size.x, size.y];
            bishops = new HashSet<Vector2>();
        }

        public void PlaceBishop(Vector2 v)
        {
            board[v.x, v.y] = true;
            bishops.Add(v);
        }

        public void PlaceBishop(Vector2[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                board[v[i].x, v[i].y] = true;
                bishops.Add(v[i]);
            }
        }

        //Also possible to :
        //let n be (num of bishop in a single diagonal)
        //Sum (n + n-1 + n-2....+0) for all diagonals, making it so each cell on the grid is only checked twice
        //this can be further optimized by simply checking diagonals that we know have at least 1 bishops.
        //however, you would need to track which digonal you have checked to prevent checking it more times than necessary.
        public int NumOfPairsOfBishopsAttackingEachOther()
        {
            int output = 0;
            int x, y;
            foreach (Vector2 v in bishops)
            {
                x = v.x;
                y = v.y;
                while (true)
                {
                    x++;
                    y++;
                    if (x > size.x - 1 || y > size.y - 1) break;
                    if (board[x, y]) output++;
                }

                x = v.x;
                y = v.y;
                while (true)
                {
                    x--;
                    y++;
                    if (x < 0 || y > size.y - 1) break;
                    if (board[x, y]) output++;
                }
            }

            return output;
        }
    }

    public class Vector2
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