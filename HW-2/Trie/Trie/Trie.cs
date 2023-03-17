namespace Trie;

/// <summary>
/// Trie class that implements Trie data structure.
/// </summary>
public class Tries : ITrie
{
    TrieNode? root;

    public int Size { get; set; }

    public void CreateTrie()
        => root = new TrieNode();

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool Word { get; set; }
        public int WordCounter { get; set; }
    }

    public bool Add(string element)
    {
        if (Contains(element))
        {
            return false;
        }
        return AddingByRecursion(root, element);
    }

    bool AddingByRecursion(TrieNode root, string str)
    {
        if (str.Length == 0)
        {
            return true;
        }

        char prefix = str[0];
        string restString = str[1..];

        if (!root.children.ContainsKey(prefix))
        {
            root.children.Add(prefix, new TrieNode());
        }
        root.children[prefix].WordCounter++;

        if (restString.Length == 0)
        {
            root.children[prefix].Word = true;
            Size++;
            return true;
        }
        else
        {
            return AddingByRecursion(root.children[prefix], restString);
        }
    }

    public bool Contains(string element)
    {
        TrieNode? temp = root;
        foreach (char symbol in element)
        {
            if (temp.children.ContainsKey(symbol))
            {
                temp = temp.children[symbol];
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public bool Remove(string element)
    {
        bool isLocated = Contains(element);

        return RemoveByRecursion(root, element, isLocated);
    }

    bool RemoveByRecursion(TrieNode root, string str, bool isLocated)
    {
        if (str.Length == 0)
        {
            return isLocated;
        }

        char prefix = str[0];
        string restString = str[1..];

        RemoveByRecursion(root.children[prefix], restString, isLocated);

        if (root.children[prefix].WordCounter > 1)
        {
            root.children[prefix].WordCounter--;
        }
        else
        {
            root.children.Remove(prefix);
        }

        return isLocated;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        TrieNode? temp = root;
        foreach (char symbol in prefix)
        {
            if (temp.children.ContainsKey(symbol))
            {
                temp = temp.children[symbol];
            }
            else
            {
                return 0;
            }
        }

        return temp.WordCounter;
    }
}