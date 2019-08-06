
using System;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace DCP_90
{
    /*
        Given an integer n and a list of integers l, write a function that randomly generates a number from 0 to n-1 that isn't in l (uniform).
    */
    //What??
    //Why the list?
    //oh isn't in the list.

    public class DCP_90
    {

        public static int ExcludedRandom(int n, List<int> l)
        {
            int output = RNGCSP.RollDice((byte)n);
            while (l.Contains(output))
            {
                output = RNGCSP.RollDice((byte)n);
            }

            return output;
        }
    }

    class RNGCSP
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public static byte RollDice(byte numberSides)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");
            byte[] randomNumber = new byte[1];
            do
            {
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));
            return (byte)((randomNumber[0] % numberSides) + 1);
        }

        private static bool IsFairRoll(byte roll, byte numSides)
        {
            int fullSetsOfValues = Byte.MaxValue / numSides;
            return roll < numSides * fullSetsOfValues;
        }
    }
}
