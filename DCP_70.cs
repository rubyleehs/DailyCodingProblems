using System;
using System.Linq;

namespace DCP_70
{
    /*
    A number is considered perfect if its digits sum up to exactly 10.
    Given a positive integer n, return the n-th perfect number.
    For example, given 1, you should return 19. Given 2, you should return 28.

     1 ,2 ,3 ,4 ...9, 10 ,11 ,12 ...19 ,20...27 ,28 ,29 ,30
    19,28,37,46...91,109,118,127...190,208...271,280,307,316
    */

    //(9(n) +10) works till n = 9
    //from then become 9(n+1) + 10 works till n = 19
    //n+2 works till n = 28
    //n+3 works till n = 37
    //...
    //n+9 works till n = 91
    //n+10 works till n = 109

    //https://www.geeksforgeeks.org/n-th-number-whose-sum-of-digits-is-ten/
    //Dafaq, this site is completely wrong



    public class DCP_70
    {
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(BruteGetNthPerfectNumber(i));
            }
            
            //Console.WriteLine(GetNthPerfectNumber(int.Parse(Console.ReadLine())));
        }

        //works till n = 43? idk how to do this other than brute force
        public static int GetNthPerfectNumber(int n)
        {
            if (n <= 9)
            {
                return 9 * n + 10;
            }
            else
            {
                int displacement = 1;
                int i = 1;

                while (n < GetNthPerfectNumber(i)) i++;

                displacement += (i - 1);
                return 9 * (n + displacement) + 10;
            }
        }


        public static int BruteGetNthPerfectNumber(int n)
        {
            int counter = 0;
            int n = 0;
            while (true)
            {
                if (GetSumOfDigits(9 * n + 10) == 10)
                {
                    counter++;
                    if (counter == n) return 9 * n + 10;
                }
                n++;
            }
        }

        public static int GetSumOfDigits(int i)
        {
            int sum = 0;
            while (i != 0)
            {
                sum += n % 10;
                i /= 10;
            }
            return sum;
        }
    }
}