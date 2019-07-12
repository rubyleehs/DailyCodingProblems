using System;
using System.Linq;
using System.Security.Cryptography;

namespace DCP_59
{
    /*
    Implement a file syncing algorithm for two computers over a low-bandwidth network. What if we know the files in the two computers are mostly the same?
    */

    //Never heard of anyone doing ths in c# lol.
    //https://medium.com/coinmonks/merkle-root-of-a-bitcoin-block-calculated-in-c-8c659a3b3290

        /*

    public class DCP_59
    {
        private SHA256 Sha256 = SHA256.Create();

        public static void Main()
        {
            Console.WriteLine(TryFindInSortedArray(Console.ReadLine().Split(' ').Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));
        }

        private MerkleNode CreateMerkleTree(string[] filenames, int startIndex = 0, int endIndex = -1)
        {
            Console.WriteLine("endIndex : " + endIndex);
            if (endIndex < 0) endIndex = filenames.Length - 1;
            if (startIndex == endIndex) return filenames[startIndex];
            else
            {
                int h = startIndex + Convert.ToInt32(Math.Floor((endIndex - startIndex + 1) / 2));
                MerkleNode left = CreateMerkleTree(filenames, startIndex, h - 1);
            }
        }

        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }

            //if no file found, just use the file name. Makes it easeir to test.
            return Sha256.ComputeHash(Encoding.UTF8.GetBytes(filename));           
        }
    }

    public class MerkleNode
    {
        public MerkleNode parent;

        public string name;
        //public byte[] hash;

        public MerkleNode(string name, MerkleNode parent = null)
        {
            this.name = name;
            this.parnet = parent;
        }
    }

    public class MerkleFile
    {
        public MerkleNode node;

        public string data;
    }
    */
}
