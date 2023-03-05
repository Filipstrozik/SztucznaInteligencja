using System;
using System.Collections.Generic;
using Z1;

public class Program
{
    public static void Main()
    {
        Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

        // Add nodes and edges to the graph
        graph[1] = new Dictionary<int, int>();
        graph[1][2] = 1;
        graph[1][3] = 4;

        graph[2] = new Dictionary<int, int>();
        graph[2][4] = 6;

        graph[3] = new Dictionary<int, int>();
        graph[3][4] = 2;
        graph[3][5] = 5;

        graph[4] = new Dictionary<int, int>();
        graph[4][5] = 3;

        graph[5] = new Dictionary<int, int>();

        int startNode = 1;
        Dictionary<int, int> shortestDistances = DijkstraAlgorithm.FindShortestPaths(graph, startNode);

        Console.WriteLine("Shortest distances from node {0}:", startNode);

        foreach (var pair in shortestDistances)
        {
            Console.WriteLine("Node {0}: {1}", pair.Key, pair.Value);
        }
    }
}
