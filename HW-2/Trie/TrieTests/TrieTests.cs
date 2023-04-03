namespace Trie;

public class Tests
{
    static IEnumerable<Tries> Tries
    {
        get
        {
            yield return new Tries();
        }
    }

    [TestCaseSource(nameof(Tries))]
    public void TireShouldAddWordsAndCalculateTheSizeCorrectly(Tries trie)
    {
        trie.CreateTrie();
        trie.Add("a");
        trie.Add("b");
        trie.Add("c");
        Assert.That(trie.Size, Is.EqualTo(3));
    }

    [TestCaseSource(nameof(Tries))]
    public void TrieShouldCountAllWordsStartingWithTheSamePrefix(Tries trie)
    {
        trie.CreateTrie();
        trie.Add("a");
        trie.Add("ad");
        trie.Add("caa");
        trie.Add("nd");
        Assert.That(trie.HowManyStartsWithPrefix("a"), Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Tries))]
    public void TrieShouldContainAWordThatIsAPrefixOfAnotherWord(Tries trie)
    {
        trie.CreateTrie();
        trie.Add("dog");
        trie.Add("do");
        Assert.IsTrue(trie.Contains("do"));
    }

    [TestCaseSource(nameof(Tries))]
    public void TrieShouldRemoveAWordThatIsAPrefixOfAnotherWord(Tries trie)
    {
        trie.CreateTrie();
        trie.Add("dog");
        trie.Add("do");
        trie.Remove("do");
        Assert.IsFalse(trie.Contains("do"));
    }
}