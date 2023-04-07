namespace Router;

/// <summary>
/// A class representing edges in an undirected graph.
/// </summary>
public class Edges
{
    public int FromVertex { get; set; }
    public int ToVertex { get; set; }

    /// <summary>
    /// The bandwidth between the start and end vertices.
    /// </summary>
    public int Bandwidth { get; set; }

    internal Edges(int fromVertex, int toVertex, int bandwidth)
    {
        FromVertex = fromVertex;
        ToVertex = toVertex;
        Bandwidth = bandwidth;
    }
}