using System;

namespace DCP_120
{
    /*
    Implement the singleton pattern with a twist. First, instead of storing one instance, store two instances. 
    And in every even call of getInstance(), return the first instance and in every odd call of getInstance(), return the second instance.
    */

    public class DCP_120
    {
        //public static Doubleton d = new Doubleton();
        public static void Main()
        {
            Console.WriteLine(Doubleton.GetInstance);
            Console.WriteLine(Doubleton.GetInstance);
            Console.WriteLine(Doubleton.GetInstance);
            Console.WriteLine(Doubleton.GetInstance);
            Console.WriteLine(Doubleton.GetInstance);
        }
    }

    public sealed class Doubleton
    {
        private static Doubleton instance1;
        private static Doubleton instance2;
        private static bool IsOddAccess;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Doubleton()
        {
        }

        public Doubleton()
        {
            if (instance1 == null)
            {
                instance1 = this;
                instance2 = new Doubleton();
            }
            else if (instance2 == null) instance2 = this;
        }

        public static Doubleton GetInstance
        {
            get
            {
                if (instance1 == null || instance2 == null) new Doubleton();

                IsOddAccess = !IsOddAccess;
                if (IsOddAccess)
                {
                    Console.WriteLine(1);
                    return instance1;
                }
                else
                {
                    Console.WriteLine(2);
                    return instance2;
                }
            }
        }
    }
}