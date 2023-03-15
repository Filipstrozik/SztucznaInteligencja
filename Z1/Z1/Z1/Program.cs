using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        DataLoader.LoadMerge(g);
        Console.WriteLine(g.MergedNodes.Count);
        Console.WriteLine(g.Edges.Count);
        Console.WriteLine("Graph created...");


        //string startPoint = "Broniewskiego";

        //var startingNodes = g.Nodes.Values.Where(n => n.Name == startPoint);


        //Node startNode = g.Nodes.FirstOrDefault(n => n.Value.Name == startPoint).Value;

        //Node startNode = g.Nodes[(51.1353023, 17.03633491)];
        //Node startNode = g.Nodes[(51.09365152, 17.02063499)];

        //DijkstraAlgorithm.PseudoDjikstra(g, startNode, "PL. GRUNWALDZKI", TimeSpan.Parse("07:10:00"));
        // Console.WriteLine("Shortest distances from node {0}:", "Broniewskiego");
/*
        foreach(var node in startingNodes)
        {
            var watch = Stopwatch.StartNew();
            DijkstraAlgorithm.PseudoDjikstra(g, node, "PL. GRUNWALDZKI", TimeSpan.Parse("07:10:00"));
            watch.Stop();
            Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
        }*/

        DijkstraAlgorithm.PseudoDjikstraMerged(g, "Broniewskiego", "BISKUPIN", TimeSpan.Parse("15:05:00"));


    }
}
