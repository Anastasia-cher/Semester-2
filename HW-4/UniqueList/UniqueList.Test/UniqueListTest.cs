namespace UniqueList.Test;

public class UniqueListTests
{
    private static IEnumerable<TestCaseData> TestList
        => new TestCaseData[]
        {
            new TestCaseData(new UniqueList()),
        };

    [TestCaseSource(nameof(TestList))]
    public void AddingAnExistentValueShouldThrowAnException(IList list)
    {
        list.AddValue(0, 0);
        list.AddValue(1, 1);
        Assert.Throws<AddingExistingElementException>(() => list.AddValue(1, 1));
    }
}