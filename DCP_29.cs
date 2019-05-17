using System;

namespace DCP_29
{
    //Implement run-length encoding and decoding. You can assume the string to be encoded have no digits and consists solely of alphabetic characters. You can assume the string to be decoded is valid

    public class DCP_29
    {
        public static void Main()
        {
            Console.WriteLine(RunLengthEncoding(Console.ReadLine()));
        }

        public static string RunLengthEncoding(string input)
        {
            char c = input[0];
            string output = "";
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != c)
                {
                    output += counter;
                    output += c;
                    counter = 1;
                    c = input[i];
                }
                else counter++;
            }
            output += counter;
            output += c;
            return output;
        }
    }
}

