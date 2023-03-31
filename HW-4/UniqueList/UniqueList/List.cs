namespace UniqueList;

public class List : IList
{
    private class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? head;

    public int Size { get; set; }

    public bool IsEmpty()
        =>head == null;

    /// <inheritdoc cref="IList.AddValue"/>
    public virtual void AddValue(int value, int position)
    {
        if (position < 0 || position > Size)
        {
            throw new InvalidPositionException();
        }

        Node? previous = null;
        var current = head;

        for (var i = 0; i < position; ++i)
        {
            previous = current;
            current = current.Next;
        }

        if (previous == null)
        {
            head = new Node(value, head);
        }
        else
        {
            previous.Next = new Node(value, current);
        }
        Size++;
    }

    /// <inheritdoc cref="IList.DeleteValue"/>
    public void DeleteValue(int position)
    {
        if (position < 0 || position > Size - 1)
        {
            throw new InvalidPositionException();
        }

        Node? previous = null;
        var current = head;

        for (var i = 0; i < position; ++i)
        {
            previous = current;
            current = current.Next;
        }

        if (previous == null)
        {
            head = current.Next;
        }
        else
        {
            previous.Next = current.Next;
        }
        Size--;
    }

    /// <inheritdoc cref="IList.Contains"/>
    public bool Contains(int value)
    {
        var current = head;
        for (var i = 0; i < Size; ++i)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    /// <inheritdoc cref="IList.GetValue"/>
    public int GetValue(int position)
    {
        if (position < 0 || position > Size - 1)
        {
            throw new InvalidPositionException();
        }

        var current = head;

        for (var i = 0; i < position; ++i)
        {
            current = current.Next;
        }
        return current.Value;
    }

    /// <inheritdoc cref="IList.ChangeValue"/>
    public virtual void ChangeValue(int newValue, int position)
    {
        if (position < 0 || position > Size - 1)
        {
            throw new InvalidPositionException();
        }

        var current = head;

        for (var i = 0; i < position; ++i)
        {
            current = current.Next;
        }
        current.Value = newValue;
    }
}

