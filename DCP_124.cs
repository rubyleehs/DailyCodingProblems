using System;

namespace DCP_124
{
    /*
    You have n fair coins and you flip them all at the same time. Any that come up tails you set aside. The ones that come up heads you flip again. How many rounds do you expect to play before only one coin remains?
    Write a function that, given n, returns the number of rounds you'd expect to play until one coin remains.
    */

    //so closest power of 2?

    public class DCP_124
    {
        public static void Main()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + " | " + NumberOfRound(i));
            }
        }

        public static int NumberOfRound(int coinCount)
        {
            if (coinCount <= 1) return 0;
            return (int)Math.Round((Math.Log(coinCount, 2)));
        }
    }
}
