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

        Run(g, "Perzowa", "Jaworowa", TimeSpan.Parse("12:30:00"));
        Run(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        Run(g, "Obornicka (Obwodnica)", "Jaworowa", TimeSpan.Parse("06:07:00"));

        //Run(g, "DWORZEC GŁÓWNY", "Górnickiego", TimeSpan.Parse("10:00:00"));


        //DijkstraAlgorithm.PseudoDjikstraMerged(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        //Run(g, "Magellana", "Rogowska", TimeSpan.Parse("12:34:00"));
        //Run(g, "Jordanowska", "Nowy Dom", TimeSpan.Parse("13:35:00"));
        //Run(g, "Broniewskiego", "Wawrzyniaka", TimeSpan.Parse("07:00:00"));
    }

    public static void Run(Graph g, String startName, String endName, TimeSpan currentTime)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        DijkstraAlgorithm.PseudoDjikstraMerged(g, startName, endName, currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch = System.Diagnostics.Stopwatch.StartNew();
        DijkstraAlgorithm.PathFinding(g, startName, endName, "t", currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        watch = System.Diagnostics.Stopwatch.StartNew();
        DijkstraAlgorithm.PathFinding(g, startName, endName, "p", currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
}
