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

        var watch = System.Diagnostics.Stopwatch.StartNew();
        DijkstraAlgorithm.PseudoDjikstraMerged(g, "Perzowa", "Jaworowa", TimeSpan.Parse("12:30:00"));
        DijkstraAlgorithm.PseudoDjikstraMerged(g, "DWORZEC GŁÓWNY", "Górnickiego", TimeSpan.Parse("10:12:00"));
        DijkstraAlgorithm.PseudoDjikstraMerged(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        DijkstraAlgorithm.PseudoDjikstraMerged(g, "Magellana", "Rogowska", TimeSpan.Parse("12:34:00"));
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
}
