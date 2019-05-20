using System;

namespace DCP_32
{
    //Good morning! Here's your coding interview problem for today.
    //This problem was asked by Jane Street.
    //Suppose you are given a table of currency exchange rates, represented as a 2D array.Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.
    //There are no transaction costs and you can trade fractional quantities

    //why is this even hard
    public class DCP_32
    {
        public static bool CheckForTradeDream(float[,] exchange)
        {
            //assuming table given in this format
            //     USD        EURO     YEN ...
            //USD   1(base)   3        10
            //EURO 0.33       1(base)  3.333
            //YEN  3          1        100(base)
            //...

            for (int y = 0; y < exchange.GetLength(0); y++)
            {
                for (int x = 0; x < exchange.GetLength(1); x++)
                {
                    if (exchange[y, y] < exchange[y, x] / exchange[x, x] * exchange[x, y]) return true;
                }
            }
            return false;
        }

        public static bool CheckForTradeDream2(float[,] exchange)
        {
            //assuming table given in this format
            //      base amount     USD        EURO     YEN ...
            //USD       1            -          3        10
            //EURO      1            1          -      3.333
            //YEN      100           1         100       -
            //...

            for (int y = 0; y < exchange.GetLength(0); y++)
            {
                for (int x = 1; x < exchange.GetLength(1); x++)
                {
                    if (exchange[0, y] < exchange[x , y] / exchange[0, x - 1] * exchange[y + 1, x - 1]) return true;
                }
            }
            return false;
        }
    }
}