namespace UniqueList;

/// <inheritdoc cref="IList"/>
/// /// <summary>
/// The List that doesn't contain duplicate values.
/// </summary>
public class UniqueList : List
{
    /// <summary>
    /// Adds an element that isn't in the list.
    /// </summary>
    /// <param name="value">Value to add</param>
    /// <param name="position">The position of the element to add</param>
    public override void AddValue(int value, int position)
    {
        if (Contains(value))
        {
            throw new AddingExistingElementException();
        }

        base.AddValue(value, position);
    }

    /// <summary>
    /// Changes the value of element by position.
    /// </summary>
    /// <param name="value">New value that isn't in the list</param>
    /// <param name="position">The position of the element to set value</param>
    public override void ChangeValue(int newValue, int position)
    {
        DeleteValue(position);

        if (Contains(newValue))
        {
            throw new AddingExistingElementException();
        }

        base.AddValue(newValue, position);
    }
}
