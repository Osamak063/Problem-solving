using System;
using System.Collections.Generic;
using System.Text;

namespace Sherlock_and_Anagrams
{
    class Program
    {
        static int n;
        static char[] charArray;
        static bool[] v;
        static List<string> allSubsequences;
        static int sherlockAndAnagrams(string s)
        {
            int count = 0;
            charArray = s.ToCharArray();
            n = charArray.Length;
            v = new bool[charArray.Length];
            allSubsequences = new List<string>();
            //generate all subsequences of s
            generateSubsequences(0);

            for (int i = 0; i < allSubsequences.Count; i++)
            {
                for (int j = i + 1; j < allSubsequences.Count; j++)
                {
                    if (allSubsequences[i].Length == allSubsequences[j].Length &&
                        checkAnagrammaticPairs(allSubsequences[i].ToCharArray(), allSubsequences[j].ToCharArray()))
                        ++count;
                }
            }
            return count;
        }

        private static bool checkAnagrammaticPairs(char[] c1, char[] c2)
        {
            const int MAX_CHARS = 26;
            int[] count = new int[MAX_CHARS];
            for (int i = 0; i < c1.Length && i < c2.Length; i++)
            {
                ++count[c1[i] >= 97 ? c1[i] - 96 : c1[i] - 64];
                --count[c2[i] >= 97 ? c2[i] - 96 : c2[i] - 64];
            }
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                    return false;
            }
            return true;
        }

        public static void generateSubsequences(int i)
        {
            if (i == n)
            {
                StringBuilder subSeq = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (v[j])
                        subSeq.Append(charArray[j]);
                }
                if (subSeq.Length > 0 && subSeq.Length != charArray.Length )
                    //&& (subSeq.Length == 1 || !allSubsequences.Contains(subSeq.ToString())))
                    allSubsequences.Add(subSeq.ToString());
            }
            else
            {
                // Each element of the original set may be or not in the subsets
                // Since each element has two options the total number subsets is:
                // 2 * 2 * 2 * ... * 2 = 2^n
                // -------------------------
                // 1   2   3   ...   n

                v[i] = true;      // This element will be in the subset
                generateSubsequences(i + 1);
                v[i] = false;     // This element won't be in the subset
                generateSubsequences(i + 1);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine(sherlockAndAnagrams("kkkk"));
        }
    }
}
