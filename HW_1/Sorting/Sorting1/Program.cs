static void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i],3}");
    }
}

static void SortByBubble(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = array.Length - 1; j > i; j--)
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

static bool CheckSortedArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
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
    int[] array = { 5, 6, 3, 4, 8, 0 };
    SortByBubble(array);
    if (CheckSortedArray(array))
    {
        return true;
    }
    return false;
}

if (TestOfSortByBubble())
{
    Console.Write("Enter length of array: ");
    int length = Convert.ToInt32(Console.ReadLine());
    var array = new int[length];
    Random rand = new();
    for (int i = 0; i < length; i++)
    {
        array[i] = rand.Next(1, 99);
    }
    Console.WriteLine("Array: ");
    PrintArray(array);
    Console.Write("\n");
    Console.WriteLine("Sorted array: ");
    SortByBubble(array);
    PrintArray(array);
}