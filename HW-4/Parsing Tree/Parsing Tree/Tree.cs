namespace ParsingTree;

public class Tree
{
    private INode? root;
    private bool IsTree { get; set; } = false;

    /// <summary>
    /// Creating a new parsing tree.
    /// </summary>
    public void ParsingTree(string arithmeticExpression)
    {
        int position = 0;
        var charSeparators = new char[] { ' ', '(', ')' };
        string[] elements = arithmeticExpression.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        root = BuildParsingTree(elements, ref position);
    }

    private INode BuildParsingTree(string[] arithmeticExpression, ref int position)
    {
        INode? temp;

        switch (arithmeticExpression[position])
        {
            case "+":
                temp = new Addition();
                position++;
                temp.LeftChild = BuildParsingTree(arithmeticExpression, ref position);
                temp.RightChild = BuildParsingTree(arithmeticExpression, ref position);
                break;
            case "-":
                temp = new Subtraction();
                position++;
                temp.LeftChild = BuildParsingTree(arithmeticExpression, ref position);
                temp.RightChild = BuildParsingTree(arithmeticExpression, ref position);
                break;
            case "*":
                temp = new Multiplication();
                position++;
                temp.LeftChild = BuildParsingTree(arithmeticExpression, ref position);
                temp.RightChild = BuildParsingTree(arithmeticExpression, ref position);
                break;
            case "/":
                temp = new Division();
                position++;
                temp.LeftChild = BuildParsingTree(arithmeticExpression, ref position);
                temp.RightChild = BuildParsingTree(arithmeticExpression, ref position);
                break;
            default:
                position++;
                temp = new Operand() { Value = int.Parse(arithmeticExpression[position - 1]) };
                break;
        }

        return temp;
    }

    /// <summary>
    /// Prints tree.
    /// </summary>
    public string PrintParsingTree(string arithmeticExpression)
    {
        if (!IsTree)
        {
            ParsingTree(arithmeticExpression);
            IsTree = true;
        }

        if (root == null)
        {
            throw new InvalidExpressionException("Empty expression.");
        }

        return root.Print();
    }


    /// <summary>
    /// Calculates the value of an expression by tree.
    /// </summary>
    /// <returns>Result</returns
    public int CalculateArithmeticExpression(string arithmeticExpression)
    {
        if (!IsTree)
        {
            ParsingTree(arithmeticExpression);
            IsTree = true;
        }

        if (root == null)
        {
            throw new InvalidExpressionException("Empty expression.");
        }

        return root.Calculate();
    }
}