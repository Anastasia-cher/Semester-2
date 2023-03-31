namespace UniqueList;

/// <summary>
/// The exception that is thrown when trying to add an element that already exists in the list.
/// </summary>
[Serializable]
public class AddingExistingElementException : Exception
{
    public AddingExistingElementException() { }
}