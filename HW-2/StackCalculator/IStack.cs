namespace StackCalculator;
internal interface IStack
{
    public interface IStack
    {
        /// Checks for emptiness
        /// returns true if the stack is empty
        bool IsEmpty();


        /// Adds element to a top of the stack
        /// param is element to add
        void Push(int value);


        /// Gets element from a top of the stack and removes it
        /// returns element that was on the top
        int Pop();


        /// Removes all elements from the stack
        void Clear();
    }
}
