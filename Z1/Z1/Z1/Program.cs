using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using Z1;

public class Program
{
    public static void Main()
    {


        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";
        Graph g = new Graph();
        DataLoader.Load(g);
        Console.WriteLine(g.Nodes.Count);
        Console.WriteLine(g.Edges.Count);
        Console.WriteLine("Graph created...");
        //Console.ReadKey();
        //Console.WriteLine(g);

        //Dictionary<Node, int> shortestDistances = DijkstraAlgorithm.FindShortestPaths(g, "Broniewskiego", "PL. GRUNWALDZKI", TimeSpan.Parse("08:28:00"));

        string startPoint = "Broniewskiego";

        var startingNodes = g.Nodes.Values.Where(n => n.Name == startPoint);


        //Node startNode = g.Nodes.FirstOrDefault(n => n.Value.Name == startPoint).Value;

        //Node startNode = g.Nodes[(51.1353023, 17.03633491)];
        //Node startNode = g.Nodes[(51.09365152, 17.02063499)];

        //DijkstraAlgorithm.PseudoDjikstra(g, startNode, "PL. GRUNWALDZKI", TimeSpan.Parse("07:10:00"));
        // Console.WriteLine("Shortest distances from node {0}:", "Broniewskiego");

        foreach(var node in startingNodes)
        {
            DijkstraAlgorithm.PseudoDjikstra(g, node, "PL. GRUNWALDZKI", TimeSpan.Parse("07:10:00"));
        }


        /*       foreach (var pair in shortestDistances)
               {
                   Console.WriteLine("Node {0}: {1}", pair.Key.Name, pair.Value);
               }*/

    }
}
