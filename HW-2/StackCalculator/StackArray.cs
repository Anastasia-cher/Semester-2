namespace StackCalculator;

internal class StackArray : IStack
{
    private int[] stackElements;
    private int counter;


    /// Initializes a new instance of the class StackArray
    public StackArray()
    {
        stackElements = new int[10];
    }


    /// Checks for emptiness
    /// returns true if the stack is empty
    public bool IsEmpty()
        => counter == 0;

    /// Adds element to a top of the stack
    /// param is element to add
    public void Push(int value)
    {
        if (counter == stackElements.Length)
        {
            Resize();
        }

        stackElements[counter] = value;
        counter++;
    }

    private void Resize()
    {
        Array.Resize(ref stackElements, stackElements.Length * 2);
    }

    /// Gets element from a top of the stack and removes it
    /// returns element that was on the top
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        counter--;
        var value = stackElements[counter];
        stackElements[counter] = 0;
        return value;
    }

    /// Removes all elements from the stack
    public void Clear()
    {
        stackElements = new int[10];
        counter = 0;
    }
}

