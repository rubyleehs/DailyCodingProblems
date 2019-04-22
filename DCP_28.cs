using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_28
{
    /*
    Write an algorithm to justify text. Given a sequence of words and an integer line length k, return a list of strings which represents each line, fully justified.
    More specifically, you should have as many words as possible in each line. There should be at least one space between each word. Pad extra spaces when necessary so that each line has exactly length k. Spaces should be distributed as equally as possible, with the extra spaces, if any, distributed starting from the left.
    If you can only fit one word on a line, then you should pad the right-hand side with spaces.
    Each word is guaranteed not to be longer than k.

    For example, given the list of words ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] and k = 16, you should return the following:
    ["the  quick brown", # 1 extra space on the left
    "fox  jumps  over", # 2 extra spaces distributed evenly
    "the   lazy   dog"] # 4 extra spaces distributed evenly
	*/

    //didnt google anything, not sure if it is even supposed to be done like this.
    public class DCP_28
    {
        public void Main()
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            int k = int.Parse(Console.ReadLine());
            List<string> output = Justify(input, k);
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(">" + output[i]);
            }
        }

        public List<string> Justify(List<string> input, int k)
        {
            List<string> output = new List<string>();
            int cl = 0;
            string line = "";
            for (int i = 0; i < input.Count; i++)
            {
                if (cl + input[i].Length + i <= k) cl += input[i].Length;
                else
                {
                    if (i <= 1) output.Add(input[0]);
                    else
                    {
                        line = "";
                        int minNumOfSpace = (k - cl) / (i - 1);
                        int r = (k - (cl + i - 1)) % (i - 1);
                        for (int m = 0; m < i; m++)
                        {
                            line += input[m];
                            for (int s = 0; s < minNumOfSpace; s++) line += " ";
                            if (m < r) line += " ";
                        }
                        output.Add(line);
                    }
                    output.AddRange(Justify(input.GetRange(i, input.Count - i), k));
                    return output;
                }
            }
            for (int m = 0; m < input.Count; m++) line += input[m] + " ";
            output.Add(line);
            return output;
        }
    }
}