namespace MapFilterFold.Tests;

public class Tests
{
    Functions func = new();

    [Test]
    public void TheMapFunctionShouldWorkCorrectly()
    {
        var list = new List<int>() { 1, 2, 3 };
        Assert.That(Functions.Map(list, (elem) => elem * 2), Is.EqualTo(new List<int>() { 2, 4, 6 }));
        Assert.That(Functions.Map(list, (elem) => 10 + elem), Is.EqualTo(new List<int>() { 11, 12, 13 }));
        Assert.That(Functions.Map(list, (elem) => 6 / elem), Is.EqualTo(new List<int>() { 6, 3, 2 }));
    }

    [Test]
    public void TheFilterFunctionShouldWorkCorrectly()
    {
        var list = new List<int>() { -1, 2, 3, 4 };
        Assert.That(Functions.Filter(list, (elem) => elem % 2 == 0), Is.EqualTo(new List<int>() { 2, 4 }));
        Assert.That(Functions.Filter(list, (elem) => elem < 0), Is.EqualTo(new List<int>() { -1 }));
    }

    [Test]
    public void TheFoldFunctionShouldWorkCorrectly()
    {
        var list = new List<int>() { 1, 2, 3 };
        Assert.That(Functions.Fold(list, 1, (acc, elem) => acc * elem), Is.EqualTo(6));
        Assert.That(Functions.Fold(list, -6, (acc, elem) => acc + elem), Is.EqualTo(0));
        Assert.That(Functions.Fold(list, 6, (acc, elem) => acc / elem), Is.EqualTo(1));
    }
}