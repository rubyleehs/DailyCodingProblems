using System;
using System.Collections.Generic;
using System.Linq;

public class DCP_01 {
    //Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    //For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    //Bonus: Can you do this in one pass?

    public static void Main () {
        String input = Console.ReadLine ();
        List<float> numbers = input.Split (' ').Select (float.Parse).ToList ();

        float k = int.Parse (Console.ReadLine ());

        var result = IsSumOfTwoNumbers (numbers, k);
        Console.WriteLine (result);
    }

    public static bool IsSumOfTwoNumbers (List<float> numbers, float k) {
        HashSet<float> remainder = new HashSet<float> ();

        for (int i = 0; i < numbers.Count; i++) {
            if (remainder.Contains (numbers[i])) return true;
            remainder.Add (k - numbers[i]);
        }
        return false;
    }
}