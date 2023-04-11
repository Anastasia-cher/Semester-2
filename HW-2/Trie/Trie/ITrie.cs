namespace Trie;

/// <summary>
/// An interface that implements the Trie class.
/// </summary>
interface ITrie
{
    /// <summary>
    /// The method that adds an element to the trie.
    /// </summary>
    /// <param name="element"></param>
    bool Add(string element);

    /// <summary>
    /// The method that checks whether a given element is in the trie.
    /// </summary>
    /// <param name="element"></param>
    bool Contains(string element);

    /// <summary>
    /// The method that removes an element from the trie.
    /// </summary>
    /// <param name="element"></param>
    bool Remove(string element);

    /// <summary>
    /// The method that returns amount of words starting with the given prefix.
    /// </summary>
    /// <param name="prefix"></param>
    int HowManyStartsWithPrefix(String prefix);
}
