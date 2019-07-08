using System;
using System.Security.Cryptography;

namespace DCP_51
{
    /*
    Given a function that generates perfectly random numbers between 1 and k (inclusive), where k is an input, 
    write a function that shuffles a deck of cards represented as an array using only swaps.
    It should run in O(N) time.
    Hint: Make sure each one of the 52! permutations of the deck is equally likely.
    */

    public class DCP_51
    {
        public static void Main()
        {
            int[] deck = CreateDeckOfCards(52);
            ShuffleDeck(ref deck);
            deck.Print();
        }

        static void ShuffleDeck(ref int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck.Swap(i, RNGCSP.RollDice((byte)deck.Length) - 1);
            }
        }

        static int[] CreateDeckOfCards(int numOfCards)
        {
            int[] deck = new int[numOfCards];
            for (int i = 0; i < numOfCards; i++)
            {
                deck[i] = i + 1;
            }
            return deck;
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

    public static class Extensions
    {
        public static void Swap<T>(this T[] arr, int i1, int i2)
        {
            T temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }

        public static void Print<T>(this T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}