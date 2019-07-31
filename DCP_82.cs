using System;

namespace DCP_82
{
    /*
    Using a read7() method that returns 7 characters from a file, implement readN(n) which reads n characters.
    For example, given a file with the content “Hello world”, three read7() returns “Hello w”, “orld” and then “”.
    */

    public class DCP_82
    {
        public static void Main()
        {
            ProxyFile f = new ProxyFile("0123456789012345678901234567890");
            while (true) Console.WriteLine(f.ReadN(int.Parse(Console.ReadLine())));
        }
    }

    public class ProxyFile
    {
        string content;
        private int k;
        string storage;

        public ProxyFile(string s)
        {
            this.content = s;
            this.storage = "";
            this.k = 0;
        }

        public string Read7()
        {
            if (k >= content.Length) return "";
            string output = content.Substring(k, Math.Min(content.Length - 1, 7));
            k += 7;
            return output;
        }

        public string ReadN(int n)
        {
            while (storage.Length < n) storage += Read7();

            String output = storage;
            storage = storage.Substring(n, storage.Length - n);
            Console.WriteLine(storage);
            return output.Substring(0, n);
        }
    }
}