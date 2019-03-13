using System;

namespace DCP_05
{
    /*
    cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair.For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
    Given this implementation of cons:
    def cons(a, b):
        def pair(f):
            return f(a, b)
        return pair
    Implement car and cdr.
    */

    /*
    So pair is essentially a delegate that takes (a , b);
    */

    public class Cons
    {
        public Object a = 5;
        public Object b = 10;

        public Object Pair(Func<Object, Object, Object> func)
        {
            return func(a, b);
        }
    }


    public class DCP_05
    {

        public static void Main()
        {
            Object input1 = Console.ReadLine();
            Object input2 = Console.ReadLine();

            Cons c = new Cons();
            c.a = input1;
            c.b = input2;

            Console.WriteLine(Car(c));
            Console.WriteLine(Cdr(c));
        }

        public static Object Car(Cons cons)
        {
            return cons.Pair((Object a, Object b) => a);
        }

        public static Object Cdr(Cons cons)
        {
            return cons.Pair((Object a, Object b) => b);
        }
    }
}
