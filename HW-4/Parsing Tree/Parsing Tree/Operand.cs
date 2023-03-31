namespace ParsingTree;

internal class Operand : INode
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public INode? LeftChild { get; set; }

    /// <inheritdoc cref="INode.RightChild"/>
    public INode? RightChild { get; set; }

    /// <summary>
    /// The value contained in the operand.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Calculates operand.
    /// </summary>
    /// <returns>Operand value</returns>
    /// <inheritdoc cref="INode.Calculate"/>
    public int Calculate() 
        => Value;

    /// <summary>
    /// Prints the operand value.
    /// </summary>
    /// <inheritdoc cref="INode.Print"/>
    public string Print()
    {
        Console.Write($"{Value} ");
        return Value.ToString();
    }
}
