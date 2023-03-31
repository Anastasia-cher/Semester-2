namespace ParsingTree;

public interface INode
{
    /// <summary>
    /// Left child node.
    /// </summary>
    public abstract INode? LeftChild { get; set; }

    /// <summary>
    /// Right child node.
    /// </summary>
    public abstract INode? RightChild { get; set; }

    /// <summary>
    /// Prints node and subtree.
    /// </summary>
    public abstract string Print();

    /// <summary>
    /// Calculates subtree.
    /// </summary>
    /// <returns>Result</returns>
    public abstract int Calculate();
}