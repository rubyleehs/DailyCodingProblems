using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_41
{
    /*
    Given an unordered list of flights taken by someone, each represented as (origin, destination) pairs, and a starting airport,  
    compute the person's itinerary. If no such itinerary exists, return null. If there are multiple possible itineraries, 
    return the lexicographically smallest one. All flights must be used in the itinerary.

    example, given the list of flights [('SFO', 'HKO'), ('YYZ', 'SFO'), ('YUL', 'YYZ'), ('HKO', 'ORD')] and starting airport 'YUL',
    you should return the list ['YUL', 'YYZ', 'SFO', 'HKO', 'ORD'].

    Given the list of flights [('SFO', 'COM'), ('COM', 'YYZ')] and starting airport 'COM', 
    you should return null.

    Given the list of flights [('A', 'B'), ('A', 'C'), ('B', 'C'), ('C', 'A')] and starting airport 'A', 
    you should return the list ['A', 'B', 'C', 'A', 'C'] even though ['A', 'C', 'A', 'B', 'C'] is also a valid itinerary. 
    However, the first one is lexicographically smaller.
   
    */


    public class DCP_41
    {
        public static void Main()
        {
            List<Flights> f = new List<Flights>();
            string[] input = Console.ReadLine().Split(' ').ToArray();
            for (int i = 0; i < input.Length - 1; i += 2)
            {
                f.Add(new Flights(input[i], input[i + 1]));
            }

            GetItineraries(f, input[0]).Write();
        }

        public static List<string> GetItineraries(List<Flights> flights, string start)
        {
            if (flights.Count == 0) return new List<string>() { start };

            List<List<string>> p = new List<List<string>>();
            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].origin == start)
                {
                    p.Add(new List<string>() { start });
                    List<Flights> temp = new List<Flights>();
                    flights.Clone(temp);
                    temp.RemoveAt(i);
                    p[p.Count - 1].AddRange(GetItineraries(temp, flights[i].destination));
                }
            }

            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].Count < flights.Count)
                {
                    p.RemoveAt(i);
                    i--;
                }
            }
            if (p.Count > 1) p = p.OrderBy(x => x[1]).ToList();

            if (p.Count > 0) return p[0];
            else return new List<string>();
        }

        public struct Flights
        {
            public string origin;
            public string destination;

            public Flights(string origin, string destination)
            {
                this.origin = origin;
                this.destination = destination;
            }
        }
    }

    public static class Extensions
    {
        public static void Sort(this List<List<string>> l)
        {
            List<string> ls = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                string s = "";
                for (int ii = 0; ii < l[i].Count; ii++)
                {
                    s += l[i][ii];
                }
                ls.Add(s);
            }
        }

        public static void Clone<T>(this List<T> thing, List<T> other)
        {
            for (int i = 0; i < thing.Count; i++) { other.Add(thing[i]); }
        }

        public static void Write<T>(this List<T> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i]);
            }
            Console.WriteLine("");
        }
    }
}
