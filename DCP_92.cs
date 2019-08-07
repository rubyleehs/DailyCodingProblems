using System;
using System.Collections.Generic;

namespace DCP_92
{
    /*
    We're given a hashmap associating each courseId key with a list of courseIds values, which represents that the prerequisites of courseId are courseIds. 
    Return a sorted ordering of courses such that we can finish all courses.
    Return null if there is no such ordering.
    For example, given {'CSC300': ['CSC100', 'CSC200'], 'CSC200': ['CSC100'], 'CSC100': []}, should return ['CSC100', 'CSC200', 'CSCS300'].

    */

    //Lol. Basically simplified GOAP?

    public class DCP_92
    {
        public static Dictionary<string, string[]> courses = new Dictionary<string, string[]>();
        public static void Main()
        {
            string c0 = " ";
            string c1;
            while (c0.Length > 0)
            {
                c0 = Console.ReadLine();
                if (c0.Length == 0) break;
                c1 = Console.ReadLine();
                if (c1.Length <= 0) AddCourses(c0, null);
                else AddCourses(c0, c1.Split(' '));
            }

            string[] c2 = TryFinishAllCourses(courses);
            if (c2 != null) c2.Print();
        }

        public static void AddCourses(string course, string[] requirements)
        {
            if (courses.ContainsKey(course)) Console.WriteLine("Course Already Exist");
            else courses.Add(course, requirements);
        }

        public static string[] TryFinishAllCourses(Dictionary<string, string[]> courses)
        {
            List<string> output = new List<string>();
            HashSet<string> qualifications = new HashSet<string>();

            bool isDone = false;
            bool canTakeCourse;
            while (!isDone)
            {
                isDone = true;
                foreach (KeyValuePair<string, string[]> c in courses)
                {
                    canTakeCourse = true;
                    if (qualifications.Contains(c.Key)) continue;
                    if (c.Value != null && c.Value.Length > 0)
                    {
                        for (int i = 0; i < c.Value.Length; i++)
                        {
                            if (!qualifications.Contains(c.Value[i]))
                            {
                                canTakeCourse = false;
                                break;
                            }
                        }
                    }

                    if (canTakeCourse)
                    {
                        isDone = false;
                        output.Add(c.Key);
                        qualifications.Add(c.Key);
                    }
                }
            }

            if (output.Count == courses.Count) return output.ToArray();
            else return null;
        }
    }

    public static class Extensions
    {
        public static void Print<T>(this T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
