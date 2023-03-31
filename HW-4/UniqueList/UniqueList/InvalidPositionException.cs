namespace UniqueList;

/// <summary>
/// The exception that is thrown when the position of an element in the list is invalid.
/// </summary>
[Serializable]
public class InvalidPositionException : Exception
{
    public InvalidPositionException() { }
}