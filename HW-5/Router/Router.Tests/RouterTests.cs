namespace Router.Tests;

public class Tests
{ 
    private static IEnumerable<TestCaseData> Prima
      => new TestCaseData[]
      {
            new TestCaseData(new Router())
      };

    [TestCaseSource(nameof(Prima))]
    public void AlgorithmShouldWork(Router prim)
    {
        prim.Build("Test1.txt");
        Assert.That(prim.Tree[0].Bandwidth + prim.Tree[1].Bandwidth, Is.EqualTo(15));
    }
}