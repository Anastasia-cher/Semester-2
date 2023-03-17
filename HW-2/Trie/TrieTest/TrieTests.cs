using static Trie.Tries;

namespace Trie;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var trie1 = new Tries();
        trie1.CreateTrie();
        trie1.Add("a");
        trie1.Add("b");
        trie1.Add("c");
        Assert.That(trie1.Size, Is.EqualTo(3));
    }

    [Test]
    public void Test2()
    {
        var trie2 = new Tries();
        trie2.CreateTrie();
        trie2.Add("a");
        trie2.Add("ad");
        trie2.Add("caa");
        trie2.Add("nd");
        Assert.That(trie2.HowManyStartsWithPrefix("a"), Is.EqualTo(2));
    }

    [Test]
    public void Test3()
    {
        var trie3 = new Tries();
        trie3.CreateTrie();
        trie3.Add("dog");
        trie3.Add("do");
        Assert.IsTrue(trie3.Contains("do"));
    }

    [Test]
    public void Test4()
    {
        var trie4 = new Tries();
        trie4.CreateTrie();
        trie4.Add("dog");
        trie4.Add("do");
        trie4.Remove("do");
        Assert.IsFalse(trie4.Contains("do"));
    }
}