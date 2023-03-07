using System;
using System.Collections.Generic;
using Z1;

public class Program
{
    public static void Main()
    {
        DataLoader.Load();

        var nodes = new List<Node>
        {
            new Node(61477, "Niedzwiedzia", 51.12148282, 16.99341779),
            new Node(61478, "Malopanewska", 51.12389408, 16.98746677),
            new Node(61479, "Kwiska", 51.1254882, 16.98320659),
            new Node(61480, "DH Astra", 51.12813822, 16.97605757),
            new Node(61481, "Park Zachodni", 51.12932557, 16.97212112),
            new Node(61482, "Bajana", 51.13072762, 16.96717919),
            new Node(61483, "Metalowców", 51.13277352, 16.95744959),
            new Node(61484, "PILCZYCE", 51.13609341, 16.95045065)
        };

        var edges = new List<Edge>
        {
            new Edge(1, "MPK Tramwaje", "10", nodes[0], nodes[1], TimeSpan.Parse("16:15:00"), TimeSpan.Parse("16:16:00")),
            new Edge(2, "MPK Tramwaje", "10", nodes[1], nodes[2], TimeSpan.Parse("16:16:00"), TimeSpan.Parse("16:18:00")),
            new Edge(3, "MPK Tramwaje", "10", nodes[2], nodes[3], TimeSpan.Parse("16:18:00"), TimeSpan.Parse("16:20:00")),
            new Edge(4, "MPK Tramwaje", "10", nodes[3], nodes[4], TimeSpan.Parse("16:20:00"), TimeSpan.Parse("16:21:00")),
            new Edge(5, "MPK Tramwaje", "10", nodes[4], nodes[5], TimeSpan.Parse("16:21:00"), TimeSpan.Parse("16:22:00")),
            new Edge(6, "MPK Tramwaje", "10", nodes[5], nodes[6], TimeSpan.Parse("16:22:00"), TimeSpan.Parse("16:23:00")),
            new Edge(7, "MPK Tramwaje", "10", nodes[6], nodes[7], TimeSpan.Parse("16:23:00"), TimeSpan.Parse("16:25:00")),
            new Edge(8, "MPK Tramwaje", "10", nodes[7], nodes[6], TimeSpan.Parse("16:25:00"), TimeSpan.Parse("16:26:00")),
            new Edge(9, "MPK Tramwaje", "10", nodes[6], nodes[5], TimeSpan.Parse("16:27:00"), TimeSpan.Parse("16:28:00")),
            new Edge(10, "MPK Tramwaje", "10", nodes[5], nodes[4], TimeSpan.Parse("16:28:00"), TimeSpan.Parse("16:29:00")),
            new Edge(11, "MPK Tramwaje", "10", nodes[4], nodes[3], TimeSpan.Parse("16:29:00"), TimeSpan.Parse("16:30:00")),
            new Edge(12, "MPK Tramwaje", "10", nodes[3], nodes[2], TimeSpan.Parse("16:30:00"), TimeSpan.Parse("16:31:00")),
            new Edge(13, "MPK Tramwaje", "10", nodes[2], nodes[1], TimeSpan.Parse("16:31:00"), TimeSpan.Parse("16:32:00")),
            new Edge(14, "MPK Tramwaje", "10", nodes[1], nodes[0], TimeSpan.Parse("16:32:00"), TimeSpan.Parse("16:33:00"))

        };

        Graph g = new Graph(nodes, edges);
        Console.WriteLine(g.ToString());

 /*       Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

        // Add nodes and edges to the graph
        graph["A"] = new Dictionary<string, int>();
        graph["A"]["B"] = 1;
        graph["A"]["C"] = 4;

        graph["B"] = new Dictionary<string, int>();
        graph["B"]["A"] = 1;
        graph["B"]["D"] = 6;

        graph["C"] = new Dictionary<string, int>();
        graph["C"]["D"] = 2;
        graph["C"]["E"] = 5;
        graph["C"]["B"] = 2;


        graph["D"] = new Dictionary<string, int>();
        graph["D"]["E"] = 4;

        graph["E"] = new Dictionary<string, int>();
        graph["E"]["C"] = 5;

        string startNode = "B";
        Dictionary<string, int> shortestDistances = DijkstraAlgorithm.FindShortestPaths(graph, startNode);

        Console.WriteLine("Shortest distances from node {0}:", startNode);

        foreach (var pair in shortestDistances)
        {
            Console.WriteLine("Node {0}: {1}", pair.Key, pair.Value);
        }*/

    }
}
