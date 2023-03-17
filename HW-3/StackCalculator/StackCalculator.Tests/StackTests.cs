namespace StackCalculator;

[TestFixture]
public class StackTest
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
    public void PopFromEmptyStackTest(IStack stack)
    {
        Assert.Throws(typeof(InvalidOperationException), () => stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackSouldTakeTheValueAfterPushTest(IStack stack)
    {
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldOutputTheValueAfterPopTest(IStack stack)
    {
        stack.Push(2);
        Assert.That(stack.Pop(), Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldBeIsEmptyAfterClearTest(IStack stack)
    {
        stack.Push(5);
        stack.Clear();
        Assert.IsTrue(stack.IsEmpty());
    }

    [Test]
    public void ResizeTest()
    {
        var stack = new StackArray();
        for (var i = 0; i < 1000; ++i)
        {
            stack.Push(i);
        }
        Assert.That(stack.Pop(), Is.EqualTo(999));
    }
}
