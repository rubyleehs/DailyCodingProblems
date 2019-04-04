using System;
using System.Collections.Generic;
using System.Linq;

namespace DCP_17
{
    /*  The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
            dir
                subdir1
                subdir2
                    file.ext
        The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
        The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
            dir
                subdir1
                    file1.ext
                    subsubdir1
                subdir2
                    subsubdir2
                        file2.ext
        The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
        We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
        Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system. If there is no file in the system, return 0.
     */

    //Prob can do it by recursive but this is the first method that occured to me so yeah.

    public class DCP_17
    {
        public static void Main()
        {
            String input = Console.ReadLine();

            Console.WriteLine(LongestDirectFilePathLength(input));
        }

        public static int LongestDirectFilePathLength(string s0)
        {
            List<string> paths = new List<string>();
            int cDepth = 0;
            string c = "";
            string[] s1 = s0.Split(new[] { "\\n" }, StringSplitOptions.None);
            for (int i = 0; i < s1.Length; i++)
            {
                string[] s2 = s1[i].Split(new[] { "\\t" }, StringSplitOptions.None);

                if (s2.Length == cDepth + 1)
                {
                    if (i != 0) c += '\\';
                    c += s2[s2.Length - 1];
                    if (c.Contains('.')) paths.Add(c);
                    cDepth++;
                }
                else if (s2.Length <= cDepth)
                {
                    string[] st = c.Split('\\');
                    c = "";
                    for (int n = 0; n < s2.Length - 1; n++)
                    {
                        if (n != 0) c += '\\';
                        c += st[n];
                    }
                    c += '\\' + s2[s2.Length - 1];
                    cDepth = s2.Length;
                }
                Console.WriteLine(c);
            }

            string o = "";
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine("> " + paths[i]);
                if (paths[i].Length > o.Length) o = paths[i];
            }
            Console.WriteLine(">> " + o);
            return o.Length;
        }
    }
}