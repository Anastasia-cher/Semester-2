namespace StackCalculator;

[TestFixture]
public class StackCalculateTests
{
    static IEnumerable<IStack> Stacks
    {
        get
        {
            yield return new StackList();
            yield return new StackArray();
        }
    }

    [TestCaseSource(nameof(Stacks))]
    public void WithInvalidSymbolsTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("1 3 * a -", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void EmptyStringTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void DivideByZeroTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("9 0 / 5 3 +", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void OperationBeforeOperandTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("+ 4 7", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void OneOperandBeforeOperationTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("6 - 3", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void NotEnoughOperationTest(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("1 2 + 3 4 *", stack), Is.EqualTo((false, 0)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldBeEmpty1Test(IStack stack)
    {
        StackCalculate.Calculate("7 0 / 1", stack);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldBeEmpty2Test(IStack stack)
    {
        StackCalculate.Calculate("5 a", stack);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldBeEmpty3Test(IStack stack)
    {
        StackCalculate.Calculate("3 8", stack);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateCorrectExpression1Test(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("96 6 - 17 13 + /", stack), Is.EqualTo((true, 3)));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateCorrectExpression2Test(IStack stack)
    {
        Assert.That(StackCalculate.Calculate("20 45 2 * +", stack), Is.EqualTo((true, 110)));
    }
}
