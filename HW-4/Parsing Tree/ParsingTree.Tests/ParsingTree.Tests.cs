namespace ParsingTree.Tests;

public class Tests
{
    [Test]
    public void TreeShouldBeAbleToCalculateArithmeticExpressions()
    {
        var testTree = new Tree();
        string arithmeticExpression = "(* (+ 1 1) 2)";
        Assert.That(testTree.CalculateArithmeticExpression(arithmeticExpression) == 4 
            && testTree.PrintParsingTree(arithmeticExpression) == "( * ( + 1 1 ) 2 )");
    }

    [Test]
    public void ExpressionInWhichBothOperandsAreTreesShouldBeCalculated()
    {
        var testTree = new Tree();
        string arithmeticExpression = "/ (+ 1 2) (/ 9 3)";
        Assert.That(testTree.CalculateArithmeticExpression(arithmeticExpression), Is.EqualTo(1));
    }

    [Test]
    public void MultiplyingByZeroShouldGiveZero()
    {
        var testTree = new Tree();
        string arithmeticExpression = "(* 1 0)";
        Assert.That(testTree.CalculateArithmeticExpression(arithmeticExpression), Is.EqualTo(0));
    }

    [Test]
    public void EnteringIncorrectCharactersShouldCauseAnException()
    {
        var testTree = new Tree();
        string arithmeticExpression = "/ c h";
        Assert.Throws<FormatException>(() => testTree.CalculateArithmeticExpression(arithmeticExpression));
    }
}