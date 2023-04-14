namespace MapFilterFold;

/// <summary>
/// Map, Filter and Fold functions for List.
/// </summary>
public class Functions
{
    /// <summary>
    /// Applies the passed function to each element of the list.
    /// </summary>
    /// <param name="list">Input list</param>
    /// <param name="func">Function that transforms a list element</param>
    /// <returns>List of transformed elements</returns>
    public static List<int> Map(List<int> list, Func<int, int> func)
    {
        List<int> newList = new();
        foreach (var element in list)
        {
            newList.Add(func(element));
        }
        return newList;
    }

    /// <summary>
    /// Creates a list of elements for which the passed function returned true.
    /// </summary>
    /// <param name="list">Input list</param>
    /// <param name="func">Function that returns a boolean value for a list element</param>
    /// <returns>Filtered list</returns>
    public static List<int> Filter(List<int> list, Func<int, bool> func)
    {
        List<int> newList = new();
        foreach (var element in list)
        {
            if (func(element))
            {
                newList.Add(element);
            }
        }
        return newList;
    }

    /// <summary>
    /// Accumulates the value when viewing the list.
    /// </summary>
    /// <param name="list">Input list</param>
    /// <param name="initial">Initial value</param>
    /// <param name="func">Function that returns the next accumulated value for the current value and element</param>
    /// <returns>Accumulated value</returns>
    public static int Fold(List<int> list, int initial, Func<int, int, int> func)
    {
        var accumulated = initial;
        foreach (var element in list)
        {
            accumulated = func(accumulated, element);
        }
        return accumulated;
    }
}