namespace UniqueList.Test;

public class ListTests
{
    private static IEnumerable<TestCaseData> TestList
       => new TestCaseData[]
       {
            new TestCaseData(new List()),
            new TestCaseData(new UniqueList()),
       };

    [TestCaseSource(nameof(TestList))]
    public void AddValueTest(IList list)
    {
        Assert.IsTrue(list.IsEmpty());

        list.AddValue(10, 0);
        Assert.IsFalse(list.IsEmpty());

        Assert.That(list.Size != 0 && list.GetValue(0) == 10);
    }

    [TestCaseSource(nameof(TestList))]
    public void DeleteValueTest(IList list)
    {
        list.AddValue(10, 0);
        list.AddValue(20, 1);

        list.DeleteValue(1);

        Assert.That(list.Size == 1 && list.GetValue(0) == 10);
    }

    [TestCaseSource(nameof(TestList))]
    public void ChangeValueTest(IList list)
    {
        list.AddValue(10, 0);
        list.AddValue(20, 1);

        list.ChangeValue(30, 1);

        Assert.That(list.Size == 2 && list.GetValue(1) == 30);
    }

    [TestCaseSource(nameof(TestList))]
    public void ContainsTest(IList list)
    {
        list.AddValue(0, 0);
        Assert.IsTrue(list.Contains(0));
        Assert.IsFalse(list.Contains(1));
    }

    [TestCaseSource(nameof(TestList))]
    public void AddingAValueToAnInvalidPositionShouldCausAnException(IList list)
    {
        Assert.Throws<InvalidPositionException>(() => list.AddValue(0, -1));
    }

    [TestCaseSource(nameof(TestList))]
    public void DeletingAValueAtAnInvalidPositionShouldCauseAnException(IList list)
    {
        Assert.Throws<InvalidPositionException>(() => list.DeleteValue(-100));
    }

    [TestCaseSource(nameof(TestList))]
    public void GettingAValueOfAnInvalidPositionShouldCausAnExceptiont(IList list)
    {
        Assert.Throws<InvalidPositionException>(() => list.GetValue(-1));
    }

    [TestCaseSource(nameof(TestList))]
    public void ChangingAValueAtAnInvalidPositionShouldCausAnExceptiont(IList list)
    {
        Assert.Throws<InvalidPositionException>(() => list.ChangeValue(0, -10));
    }
}

