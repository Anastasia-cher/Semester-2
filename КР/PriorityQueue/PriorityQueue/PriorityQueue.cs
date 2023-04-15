namespace PriorityQueue;

public class PriorityQueue<T> where T : IPriority
{
        public LinkedList<T> Entries { get; } = new LinkedList<T>();

    public bool IsEmpty()
    {
        if (Entries.Count == 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the element with the highest priority
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T? Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        if (Entries.Any())
        {
            var itemTobeRemoved = Entries.Last.Value;
            Entries.RemoveLast();
            return itemTobeRemoved;
        }

        return default(T);
    }

    /// <summary>
    /// Adds items to the queue.
    /// </summary>
    /// <param name="entry"></param>
    public void Enqueue(T entry)
    {
        var value = new LinkedListNode<T>(entry);
        if (Entries.First == null)
        {
            Entries.AddFirst(value);
        }

        else
        {
            var temp = Entries.First;
            while (temp.Next != null && temp.Value.Priority < entry.Priority)
            {
                temp = temp.Next;
            }

            if (temp.Value.Priority < entry.Priority)
            {
                Entries.AddAfter(temp, value);
            }
            else
            {
                Entries.AddBefore(temp, value);
            }
        }
    }
}
