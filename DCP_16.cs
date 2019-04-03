using System;
using System.Collections.Generic;

namespace DCP_16
{
    /*
    You run an e-commerce website and want to record the last N order ids in a log.Implement a data structure to accomplish this, with the following API:
    •	record(order_id): adds the order_id to the log
    •  	get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
    You should be as efficient with time and space as possible.
    */

    //....Just a normal List????
    //but with a constant N, perhaps an array would be better. 
    //however, would shifting each element forward 1 be more costly in an array?

    public class DCP_16
    {
        public static List<string> lastOrders = new List<string>();
        public static int N = 10;

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                Record(input[i]);
            }

            int k = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(Get_Last(k));
        }

        public static void Record(string order_id)
        {
            lastOrders.Add(order_id);

            if (lastOrders.Count > N) lastOrders.RemoveAt(0);
        }

        public static string Get_Last(int i)
        {
            if (i <= 0)
            {
                Console.WriteLine(i + " is an invalid input");
                return null;
            }
            else if (i > lastOrders.Count)
            {
                Console.WriteLine("There are only " + lastOrders.Count + "orders saved, last " + i + " order is out of range");
                return null;
            }
            else
            {
                return lastOrders[lastOrders.Count - i];
            }
        }
    }
}