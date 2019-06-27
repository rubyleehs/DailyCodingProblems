using System;
using System.Security.Cryptography;


namespace DCP_45
{
    /*
    Using a function rand5() that returns an integer from 1 to 5 (inclusive) with uniform probability, implement a function rand7() that returns an integer from 1 to 7 (inclusive).
    */

    public class DCP_45
    {
        public static void Main()
        {
            int count = 0;
            int loop = 150000;

            for (int i = 0; i < loop; i++)
            {
                if (Rand7() == 1) count++;
            }
            Console.WriteLine((float)loop / count);
        }

        public static int Rand5()
        {
            return RNGCSP.RollDice(5);
        }

        public static int Rand25()
        {
            return 5 * Rand5() + Rand5() - 5;
            //so both randoms dont influence each other.
            //one sets the ones and the other sets the tens (in base 5)
        }

        public static int Rand7()
        {
            int r = Rand25();
            while (r > 21) r = Rand25();
            return (r % 7) + 1;
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
