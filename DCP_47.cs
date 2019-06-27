using System;
using System.Linq;

namespace DCP_47
{
    /*
    Given a array of numbers representing the stock prices of a company in chronological order, write a function that calculates the maximum profit you could have made from buying and selling that stock once. You must buy before you can sell it.
    For example, given [9, 11, 8, 5, 7, 10], you should return 5, since you could buy the stock at 5 dollars and sell it at 10 dollars.  
    */

    public class DCP_47
    {
        public static void Main()
        {
            Console.WriteLine(GetMaxProfit(Console.ReadLine().Split(' ').Select(int.Parse).ToArray()));
        }

        public static int GetMaxProfit(int[] arr)
        {
            if (arr.Length < 2) return 0;

            int maxProfit = 0;
            int currentProfit = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                currentProfit += (arr[i + 1] - arr[i]);

                if (currentProfit > maxProfit) maxProfit = currentProfit;
                if (currentProfit < 0) currentProfit = 0;
            }

            return maxProfit;
        }
    }
}