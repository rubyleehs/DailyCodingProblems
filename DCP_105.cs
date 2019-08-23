using System;
using System.Threading;

namespace DCP_105
{
    /*
    Given a function f, and N return a debounced f of N milliseconds.
    That is, as long as the debounced f continues to be invoked, f itself will not be called for N milliseconds.
    */

    //https://stackoverflow.com/questions/28472205/c-sharp-event-debounce

    public class DCP_105
    {
        public static void Main()
        {
            Action<int> a = (arg) =>
            {
                // This was successfully debounced...
                Console.WriteLine(arg);
            };
            var debouncedWrapper = a.Debounce<int>();

            while (true)
            {
                var rndVal = rnd.Next(400);
                Thread.Sleep(rndVal);
                debouncedWrapper(rndVal);
            }
        }

        public static Action<T> Debounce<T>(this Action<T> func, int millisecs = 300)
        {
            int last = 0;
            return arg =>
            {
                //stores copy of last in current
                var current = Interlocked.Increment(ref last);

                //wait for milliseconds
                Task.Delay(milliseconds).ContinueWith(task =>
                {
                    //if after wait current still same as last, means this is latest "call"
                    if (current == last) func(arg);
                    //otherwise, this is not latest call.
                    task.Dispose();
                });
            };
        }
    }


}
