using System;
using System.Linq;

namespace DCP_12
{
    /*
    This problem was asked by Amazon.
    There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase.The order of the steps matters.
    For example, if N is 4, then there are 5 unique ways:
    •	1, 1, 1, 1
    •	2, 1, 1
    •	1, 2, 1
    •	1, 1, 2
    •	2, 2
    What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = { 1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
    */


    //one way is to just brute force it.

    public class DCP_12
    {
        public static void Main()
        {
            int step = int.Parse(Console.ReadLine());
            String input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(BruteNumWaysToClimbStairs(step, numbers));
        }

        public static int BruteNumWaysToClimbStairs(int stepsCount, int[] possibleSteps)
        {
            if (stepsCount < 0 || possibleSteps.Length == 0) return 0;
            else if (stepsCount == 0) return 1;

            int n = 0;
            for (int i = 0; i < possibleSteps.Length; i++)
            {
                n += BruteNumWaysToClimbStairs(stepsCount - possibleSteps[i], possibleSteps);
            }

            return n;
        }
    

        /*
        public int NumWaysToClimbStairs(int stepsCount, List<int> possibleSteps)
        {
            int n = 0;
            if (possibleSteps.Count <= 0) return 0;
            List<int> nxtPStep = possibleSteps;
            nxtPStep.RemoveAt(0);

            for (int r = stepsCount;  r > 0; r -= possibleSteps[0])
            {
                NumWaysToClimbStairs(r,)
            }
            
        }
        */
    }
}