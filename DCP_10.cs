using System;
using System.Threading;

namespace DCP_10
{
    //Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.

    public class DCP_10
    {
        public static void Main()
        {
            int delay = 800;
            RunParallel(() => DelayFunction(() => WriteY(), delay));

            for (int i = 0; i < 100; i++)
            {
                Console.Write("x");
                Thread.Sleep(1);
            }
        }

        static void RunParallel(Func<bool> f)
        {
            Thread t = new Thread(() => f());
            t.Start();
        }

        static bool DelayFunction(Func<bool> f, int d)
        {
            Thread.Sleep(d);
            f();
            return true;
        }

        static bool WriteY()
        {
            Console.Write("y");
            Thread.Sleep(1);
            return true;
        }
    }
}
