namespace ParsingTree;

public abstract class Operator : INode
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public INode? LeftChild { get; set; }

    /// /// <inheritdoc cref="INode.RightChild"/>
    public INode? RightChild { get; set; }

    /// <inheritdoc cref="INode.Calculate"/>
    public abstract int Calculate();

    ///  <inheritdoc cref="INode.Print"/>
    public virtual string Print()
        => $"{LeftChild.Print()} {RightChild.Print()}";
}
