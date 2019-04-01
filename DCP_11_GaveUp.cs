using System;
using System.Linq;
using System.Collections.Generic;

namespace DCP_11
{
    //Implement an autocomplete system.That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
    //For example, given the query string de and the set of strings[dog, deer, deal], return [deer, deal].
    //Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.


    public struct CharNode
    {
        public CharNode(char val)
        {
            this.val = val;
            charSets = new Dict<char, CharNode>();
        }

        public char val;
        public Dict<char, CharNode> charSets;
    }

    public class DCP_11
    {
        public static CharNode wordList;

        public static void Main()
        {
            wordList = new CharNode('-');
            String input = Console.ReadLine();
            DeserializeWordList(input.Split(' ').ToList());

            Console.WriteLine(wordList.charSets[0].val);
            Console.WriteLine(wordList.charSets[0].charSets[0].val);
            Console.WriteLine(wordList.charSets[0].charSets[0].charSets[0].val);
        }

        public static void DeserializeWordList(List<string> words)
        {
            for (int w = 0; w < words.Count; w++)
            {
                DeserialiseWord(words[w], wordList);
            }
        }
        public static void DeserialiseWord(ref string word, ref CharNode curNode)
        {
            if (word == null || word.Length == 0) return null;

            char letter = word[0];
            word = word.Substring(1, word.Length - 1);
            if (curNode.charSets.ContainsKey(letter)) DeserialiseWord(word, curNode.charSets[letter]);
            else
            {
                curNode.charSets.Add(letter, new CharNode(letter));
                DeserialiseWord(word, ref curNode.charSets[curNode.charSets.Count - 1]);
            }
        }
    }


}
