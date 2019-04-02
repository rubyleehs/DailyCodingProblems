using System;

namespace DCP_14
{
    /*
    The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
    Hint: The basic equation of a circle is x2 + y2 = r2.
    */

    //ez pz

    public class DCP_14
    {
        public static Random rand = new Random();
        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());

            var result = ApproxPI(k, 2);
            Console.WriteLine(result);
        }

        public static double ApproxPI(int sampleCount, int dp)
        {
            int c = 0;
            double x, y;
            for (int i = 0; i < sampleCount; i++)
            {
                x = GetRandNum();
                y = GetRandNum();

                if (x * x + y * y <= 1) c++;
            }
            return Math.Round(c / (double)sampleCount * 4, dp, MidpointRounding.AwayFromZero);
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
