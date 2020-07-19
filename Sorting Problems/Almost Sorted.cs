using System;

namespace AlmostSorted
{
    class Program
    {
        static int[] arrayGlobal;
        static void almostSorted(int[] arr)
        {
            arrayGlobal = arr;
            if (IsSorted())
            {
                Console.WriteLine("yes");
                return;
            }
            for (int i = 0; i < arrayGlobal.Length - 1; i++)
            {
                var minIndex = min(i + 1, arrayGlobal.Length);
                if (arrayGlobal[i] > arrayGlobal[minIndex])
                {
                    Swap(i, minIndex);
                    if (IsSorted())
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"swap {i + 1} {minIndex + 1}");
                        return;
                    }
                    else
                        Swap(i, minIndex);
                }
                if (i + 1 < arrayGlobal.Length && arrayGlobal[i] > arrayGlobal[i + 1])
                {
                    var sliceEndIndex = findSliceEnd(i + 1);
                    Reverse(i, sliceEndIndex);
                    if (IsSorted())
                    {
                        Console.WriteLine("yes");
                        Console.WriteLine($"reverse  {i + 1} {sliceEndIndex + 1}");
                        return;
                    }
                    else
                        Reverse(i, sliceEndIndex);
                }
            }
            Console.WriteLine("no");

        }

        public static int findSliceEnd(int i)
        {
            for (int j = i; j < arrayGlobal.Length; j++)
            {
                if (j + 1 < arrayGlobal.Length && arrayGlobal[j] < arrayGlobal[j + 1])
                {
                    return j;
                }
            }
            return i;
        }

        public static int min(int i, int length)
        {
            int index = i;
            int min = arrayGlobal[i];
            for (int j = i; j < length; j++)
            {
                if (arrayGlobal[j] < min)
                {
                    min = arrayGlobal[j];
                    index = j;
                }
            }
            return index;
        }

        public static bool IsSorted()
        {
            for (int i = 0; i < arrayGlobal.Length; i++)
            {
                if (i + 1 < arrayGlobal.Length && arrayGlobal[i] > arrayGlobal[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Swap(int i, int r)
        {
            int temp = arrayGlobal[i];
            arrayGlobal[i] = arrayGlobal[r];
            arrayGlobal[r] = temp;
        }

        public static void Reverse(int i, int r)
        {
            while (i < r && i != r)
            {
                int temp = arrayGlobal[i];
                arrayGlobal[i] = arrayGlobal[r];
                arrayGlobal[r] = temp;
                ++i;
                --r;
            }
        }

        static void Main(string[] args)
        {
            almostSorted(new int[] { 1, 5, 4, 3, 2, 6 });
        }
    }
}
