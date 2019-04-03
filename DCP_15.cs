using System;

namespace DCP_15
{
    //Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.

    //highschool conditional probablity question lol

    public class DCP_15
    {
        public static Random rand = new Random();

        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int streamArraySize = 1000;
            int[] iArray = new int[streamArraySize];
            for (int i = 0; i < streamArraySize; i++)
            {
                iArray[i] = i;
            }

            var result = randObjInStream(iArray, k);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }

        public static int[] randObjInStream(int[] stream, int numOfReturns)
        {
            int[] o = new int[numOfReturns];

            for (int i = 0; i < numOfReturns; i++)
            {
                o[i] = stream[i];
            }

            for (int i = numOfReturns; i < stream.Length; i++)
            {
                double r = GetRandNum() * ((float)i + 1);
                //Console.WriteLine(r);
                if (r <= numOfReturns)
                {
                    int index = (int)Math.Round(GetRandNum() * (numOfReturns - 1));
                    //Console.WriteLine(index);
                    o[index] = stream[i];
                }
            }

            return o;
        }

        public static double GetRandNum()
        {
            lock (rand)
            {
                return rand.NextDouble();
            }
        }
    }
}