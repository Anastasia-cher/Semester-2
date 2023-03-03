using System;

namespace Sorting
{
    class Program
    {
        static void PrintArray(int[] array, int length)
        {

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{array[i], 3}");
            }
        }

        static void SortByBubble(int[] array, int length)
        {

            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static bool CheckSortedArray(int[] array, int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool TestOfSortByBubble()
        {
            int length = 6;
            int[] array = { 5, 6, 3, 4, 8, 0 };
            SortByBubble(array, length);
            if (CheckSortedArray(array, length))
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            if (TestOfSortByBubble())
            {
                Console.Write("Enter length of array: ");
                int length = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[length];
                Random rand = new Random();
                for (int i = 0; i < length; i++)
                {
                    array[i] = rand.Next(1, 99);
                }
                Console.WriteLine("Array: ");
                PrintArray(array, length);
                Console.Write("\n");
                Console.WriteLine("Sorted array: ");
                SortByBubble(array, length);
                PrintArray(array, length);
            }
        }
    }
}