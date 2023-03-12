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
        Console.WriteLine(g);

        //Dictionary<(double, double), int> shortestDistances = DijkstraAlgorithm.FindShortestPaths(g, "Broniewskiego", "Biskupin");

        //Console.WriteLine("Shortest distances from node {0}:", "Broniewskiego");

        //foreach (var pair in shortestDistances)
        //{
        //    Console.WriteLine("Node {0}: {1}", pair.Key, pair.Value);
        //}

    }
}
