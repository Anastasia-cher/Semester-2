using System.Collections.Generic;
using System.Text;

namespace Router;

public class Router
{
    /// <summary>
    /// A list containing the edges whose sum of bandwidths is maximal.
    /// </summary>
    public List<Edges> Tree { get; private set; } = new List<Edges>();
    private List<Edges> NotUsedEdges { get; set; } = new List<Edges>();
    private List<Edges> EdgesWithUsedVertices { get; set; } = new List<Edges>();
    private List<int> NotUsedVertices { get; set; } = new List<int>();
    public bool Connected { get; set; }

    /// <summary>
    /// A method that sorts the edges.
    /// </summary>
    /// <param name="list"></param>
    private void SortEdges(List<Edges> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                if (list[j].Bandwidth > list[i].Bandwidth)
                {
                    Edges temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }

    /// <summary>
    /// A method that gets the edges from the file.
    /// </summary>
    /// <param name="FilePath"></param>
    private void GetEdges(string FilePath)
    {
        var file = new StreamReader(FilePath);
        string? connectionString;
        while ((connectionString = file.ReadLine()) != null)
        {
            int startVertex = Convert.ToInt32(connectionString[0].ToString());
            connectionString = connectionString.Remove(0, 3);
            string[] toVertexAndBendwidth = connectionString.Split(',');
            foreach (string symbol in toVertexAndBendwidth)
            {
                var toVertex = new StringBuilder();
                int i = 0;
                while (symbol[i] != '(')
                {
                    if (symbol[i] == ' ')
                    {
                        i++;
                        continue;
                    }
                    toVertex.Append(symbol[i]);
                    i++;
                }
                int endVertex = Convert.ToInt32(toVertex.ToString());
                var bandwidth = new StringBuilder();
                int j = i + 1;
                while (symbol[j] != ')')
                {
                    if (symbol[j] == ' ')
                    {
                        j++;
                        continue;
                    }
                    bandwidth.Append(symbol[j]);
                    j++;
                }
                int bandwidthInt = Convert.ToInt32(bandwidth.ToString());
                NotUsedEdges.Add(new Edges(startVertex, endVertex, bandwidthInt));
            }
        }
    }

    /// <summary>
    /// A method that adds vertices to the tree.
    /// </summary>
    /// <param name="FronVertex"></param>
    /// <param name="ToVertex"></param>
    private void AddVertex(int FronVertex, int ToVertex)
    {
        if (!NotUsedVertices.Contains(FronVertex))
        {
            NotUsedVertices.Add(FronVertex);
        }
        if (!NotUsedVertices.Contains(ToVertex))
        {
            NotUsedVertices.Add(ToVertex);
        }
    }

    /// <summary>
    /// A method that adds edges to the tree.
    /// </summary>
    /// <param name="remainingEdge"></param>
    private void AddEdges(Edges remainingEdge)
    {
        if (NotUsedVertices.Contains(remainingEdge.ToVertex) ^ NotUsedVertices.Contains(remainingEdge.FromVertex))
        {
            if (!NotUsedVertices.Contains(remainingEdge.ToVertex) || !NotUsedVertices.Contains(remainingEdge.FromVertex))
            {
                EdgesWithUsedVertices.Add(remainingEdge);
            }
        }
    }

    /// <summary>
    /// A method that uses the Prim algorithm to build a tree.
    /// </summary>
    /// <param name="FilePath"></param>
    public void Build(string FilePath)
    {
        GetEdges(FilePath);
        SortEdges(NotUsedEdges);
        BuildTree(NotUsedEdges[0]);
    }

    private void BuildTree(Edges edge)
    {
        Tree.Add(edge);
        AddVertex(edge.FromVertex, edge.ToVertex);
        NotUsedEdges.Remove(edge);
        EdgesWithUsedVertices.Remove(edge); 
        foreach (Edges edges in NotUsedEdges)
        {
            AddEdges(edges);
        }
        SortEdges(EdgesWithUsedVertices);
        if (EdgesWithUsedVertices.Count == 0)
        {
            return;
        }
        else
        {
            BuildTree(EdgesWithUsedVertices[0]);
            return;
        }
    }

    /// <summary>
    /// A method that determines tree connectivity.
    /// </summary>
    public void Connectivity()
    {
        foreach (Edges edge in NotUsedEdges)
        {
            if (!NotUsedVertices.Contains(edge.FromVertex) || !NotUsedVertices.Contains(edge.ToVertex))
            {
                return;
            }
        }
        Connected = true;
    }
}