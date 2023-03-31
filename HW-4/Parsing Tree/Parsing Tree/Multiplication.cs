namespace ParsingTree;

public class Multiplication : Operator
{
    ///<inheritdoc cref = "INode.Print" />
    public override string Print()
        => $"( * {base.Print()} )";

    ///<inheritdoc cref = "INode.Calculate" />
    public override int Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();
}