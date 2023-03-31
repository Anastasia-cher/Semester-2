namespace UniqueList;

public interface IList
{
    /// <summary>
    /// Number of elements.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Checks for emptiness.
    /// </summary>
    public bool IsEmpty();

    /// <summary>
    /// Adds an element by position to the list.
    /// </summary>
    /// <param name="value">A value you'd like to add</param>
    /// <param name="position">A position where a new element shoud be added</param>
    public void AddValue(int value, int position);

    /// <summary>
    /// Determines whether an element is in the list.
    /// </summary>
    /// <param name="value">Value to locate in the list</param>
    /// <returns>True if value is found in the list; otherwise, false</returns>
    public bool Contains(int value);

    /// <summary>
    /// Deletes an element by position from the list.
    /// </summary>
    /// <param name="position">A position you'd like to delete a value of.</param>
    public void DeleteValue(int position);

    /// <summary>
    /// Returns the value of element by position.
    /// </summary>
    /// <param name="position">A position of an element you want to get a value of.</param>
    public int GetValue(int position);

    /// <summary>
    /// Sets the value of element by position.
    /// </summary>
    /// <param name="newValue">A new value you'd like to add.</param>
    /// <param name="position">A position in which you want to change a value.</param>
    public void ChangeValue(int newValue, int position);
}