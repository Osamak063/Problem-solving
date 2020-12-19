using System;
using System.Collections.Generic;
using System.Linq;

namespace Week1_Problems
{
    class Program
    {
        static int simpleArraySum(int[] ar)
        {
            /*
             * Write your code here.
             */
            int sum = 0;
            foreach (var a in ar)
            {
                sum += a;
            }
            return sum;
        }

        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int Alice = 0, Bob = 0;
            for (int i = 0; i < a.Count(); ++i)
            {
                if (a[i] > b[i])
                    ++Alice;
                else if (a[i] < b[i])
                    ++Bob;

            }

            return new List<int>() { Alice, Bob };

        }

        static long aVeryBigSum(long[] ar)
        {

            long sum = 0;
            foreach (var a in ar)
            {
                sum += a;
            }
            return sum;
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int leftDiagonalStart = 0, rightDiagonalStart = arr[0].Count - 1, row = 0;
            int sumLeft = 0, sumRight = 0;
            while (leftDiagonalStart < arr[0].Count && rightDiagonalStart >= 0)
            {
                sumLeft += arr[row][leftDiagonalStart];
                sumRight += arr[row][rightDiagonalStart];
                ++leftDiagonalStart;
                --rightDiagonalStart;
                ++row;
            }
            return Math.Abs(sumRight - sumLeft);
        }


        static void Main(string[] args)
        {
            simpleArraySum(new int[] { 1, 2, 3 });

            compareTriplets(new List<int>() { 1, 2, 3 }, new List<int>() { 1, 2, 3 });
            var matrix = new List<List<int>>();
            matrix.Add(new List<int>() { 11, 2, 4 });
            matrix.Add(new List<int>() { 4, 5, 6 });
            matrix.Add(new List<int>() { 10, 8, -12 });
            Console.WriteLine(diagonalDifference(matrix));
        }
    }
}
