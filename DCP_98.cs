using System;

namespace DCP_98
{
    /*
    Given a 2D board of characters and a word, find if the word exists in the grid.
    The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.
    For example, given the following board:
        [
          ['A','B','C','E'],
          ['S','F','C','S'],
          ['A','D','E','E']
        ]
    exists(board, "ABCCED") returns true, exists(board, "SEE") returns true, exists(board, "ABCB") returns false.
    */

    public class DCP_98
    {
        public static void Main()
        {
            char[,] board = new char[3, 4]
            {
                  { 'A', 'B', 'C', 'E' },
                  { 'S', 'F', 'C', 'S' },
                  { 'A', 'D', 'E', 'E' },
            };

            Console.WriteLine(WordExist(board, Console.ReadLine()));
        }

        public static bool WordExist(char[,] board, string word)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (CanFormWord(board, word, x, y)) return true;
                }
            }
            return false;
        }

        public static bool CanFormWord(char[,] board, string word, int x, int y, int w = 0, bool[,] tMap = null)
        {
            if (x < 0 || y < 0 || x >= board.GetLength(0) || y >= board.GetLength(1)) return false;
            if (tMap == null) tMap = new bool[board.GetLength(0), board.GetLength(1)];
            if (tMap[x, y]) return false;
            if (board[x, y] == word[w])
            {
                if (w >= word.Length - 1) return true;
                tMap[x, y] = true;
                if (CanFormWord(board, word, x + 1, y, w + 1, tMap)) return true;
                if (CanFormWord(board, word, x - 1, y, w + 1, tMap)) return true;
                if (CanFormWord(board, word, x, y + 1, w + 1, tMap)) return true;
                if (CanFormWord(board, word, x, y - 1, w + 1, tMap)) return true;

                tMap[x, y] = false;
                return false;
            }
            else return false;
        }
    }
}


