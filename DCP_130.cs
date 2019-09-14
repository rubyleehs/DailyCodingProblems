using System;

namespace DCP_130
{
    /*
    Given an array of numbers representing the stock prices of a company in chronological order and an integer k, 
    return the maximum profit you can make from k buys and sells. You must buy the stock before you can sell it, and you must sell the stock before you can buy it again.
    For example, given k = 2 and the array [5, 2, 4, 0, 1], you should return 3.
    */

    //if k = 1 this is easy, but outside of brute forcing, i can't think if a way where it would work for k>1 despite it seeming possible.

    public class DCP_130
    {
        public static void Main()
        {
            int[] prices = new int[8] { 4, 5, 2, 4, 0, 1, 2, 3 };
            Console.WriteLine(GetMaxProfits(prices, 3) == 6);
        }

        public static int GetMaxProfits(int[] prices, int k, int currentIndex = 0, int currentProfit = 0, int? buyingPrice = null)
        {
            if (k == 0 || currentIndex >= prices.Length) return currentProfit;
            int max = currentProfit;
            if (buyingPrice.HasValue)
            {
                for (int i = currentIndex; i < prices.Length; i++)
                {
                    //selling at every price point and getting max
                    max = Math.Max(max, GetMaxProfits(prices, k - 1, i + 1, currentProfit + prices[i] - buyingPrice.Value, null));
                }
            }
            else max = Math.Max(max, GetMaxProfits(prices, k, currentIndex + 1, currentProfit, prices[currentIndex]));

            return max;
        }
    }
}