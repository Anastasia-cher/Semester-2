namespace StackCalculator;
public class StackList : IStack
{
    private StackElement? top;

    /// Stack element, contains value and reference to next element
    private class StackElement
    {
        public int Value { get; set; }
        public StackElement Next { get; set; }


        /// Initializes a new instance of the class StackElement
        /// param is value of element
        /// param is reference to next element
        public StackElement(int value, StackElement next)
        {
            Value = value;
            Next = next;
        }
    }

    /// Checks for emptiness
    /// returns true if the stack is empty
    public bool IsEmpty()
        => top == null;


    /// Adds element to a top of the stack
    /// param is element to add
    public void Push(int value)
    {
        top = new StackElement(value, top);
    }


    /// Gets element from a top of the stack and removes it
    /// returns element that was on the top
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        int value = top.Value;
        top = top.Next;
        return value;
    }


    /// Removes all elements from the stack.
    public void Clear()
    {
        top = null;
    }
}

