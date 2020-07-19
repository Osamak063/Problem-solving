using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Anagrams
{
    class Program
    {
        static int anagram(string s)
        {
            char[] charArray1 = s.Substring(s.Length / 2, s.Length / 2).ToCharArray();
            char[] charArray2 = s.Substring(0, s.Length / 2).ToCharArray();
            Dictionary<char, int> dictOne = new Dictionary<char, int>();
            Dictionary<char, int> dictTwo = new Dictionary<char, int>();
            for (int i = 0; i < charArray1.Length; i++)
            {
                if (dictOne.ContainsKey(charArray1[i]))
                {
                    int count = 0;
                    dictOne.TryGetValue(charArray1[i], out count);
                    dictOne[charArray1[i]] = ++count;
                }
                else
                    dictOne.Add(charArray1[i], 1);
            }
            for (int i = 0; i < charArray2.Length; i++)
            {
                if (dictTwo.ContainsKey(charArray2[i]))
                {
                    int count = 0;
                    dictTwo.TryGetValue(charArray2[i], out count);
                    dictTwo[charArray2[i]] = ++count;
                }
                else
                    dictTwo.Add(charArray2[i], 1);
            }
            int diffCount = 0;
            foreach (var key in dictOne.Keys)
            {
                if (dictTwo.ContainsKey(key))
                {
                    int twoCount = 0, oneCount = 0;
                    dictTwo.TryGetValue(key, out twoCount);
                    dictOne.TryGetValue(key, out oneCount);
                    if (oneCount - twoCount >= 0)
                        diffCount += oneCount - twoCount;
                }
                else
                {
                    int count = 0;
                    dictOne.TryGetValue(key, out count);
                    diffCount += count;
                }

            }
            return diffCount;
        }
        static void Main(string[] args)
        {
            // Returns steps to make first sub string anagram of other.
            Console.WriteLine(anagram("mvdalvkiopaufl"));
        }
    }
}
