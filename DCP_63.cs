using System;
using System.Security.Cryptography;

namespace DCP_63
{
    /*
    Assume you have access to a function toss_biased() which returns 0 or 1 with a probability that's not 50-50 (but also not 0-100 or 100-0). You do not know the bias of the coin.
    Write a function to simulate an unbiased coin toss.
    */

    public class DCP_63
    {
        public static void Main()
        {
            int times = Int32.Parse(Console.ReadLine());
            int headCount = 0;
            for (int i = 0; i < times; i++)
            {
                if (TossUnbiased()) headCount++;
            }
            Console.WriteLine((float)headCount / times);
        }


        public static bool TossBiased()
        {
            int i = RNGCSP.RollDice(100);
            //Console.WriteLine(i);
            if (i > 65) return true;
            else return false;
        }

        public static bool TossUnbiased()
        {
            bool a = false;
            bool b = false;
            while (a == b)
            {
                a = TossBiased();
                b = TossBiased();
            }
            //Console.WriteLine(a + "|" + b);
            return a;
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