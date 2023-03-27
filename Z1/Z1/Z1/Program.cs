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
        Graph g = new();
        DataLoader.LoadMerge(g);

        //Zadanie 1

        //RunAlgorithmsBenchmark(g, "Perzowa", "Jaworowa", TimeSpan.Parse("12:30:00"));
        //RunAlgorithmsBenchmark(g, "Jaworowa", "BISKUPIN", TimeSpan.Parse("12:30:00"));
        //RunAlgorithmsBenchmark(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        //RunAlgorithmsBenchmark(g, "Obornicka (Obwodnica)", "Jaworowa", TimeSpan.Parse("06:07:00"));
        //RunAlgorithmsBenchmark(g, "Wielka", "ZOO", TimeSpan.Parse("16:19:00"));
        //RunAlgorithmsBenchmark(g, "Słonimskiego", "PL. GRUNWALDZKI", TimeSpan.Parse("08:30:00"));
        //RunAlgorithmsBenchmark(g, "LEŚNICA", "KSIĘŻE MAŁE", TimeSpan.Parse("07:28:00"));
        //RunAlgorithmsBenchmark(g, "DWORZEC GŁÓWNY", "Górnickiego", TimeSpan.Parse("10:00:00"));
        //RunAlgorithmsBenchmark(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        //RunAlgorithmsBenchmark(g, "Magellana", "Rogowska", TimeSpan.Parse("12:34:00"));
        //RunAlgorithmsBenchmark(g, "Rogowska", "Magellana", TimeSpan.Parse("12:34:00"));
        //RunAlgorithmsBenchmark(g, "PL. GRUNWALDZKI", "DWORZEC GŁÓWNY", TimeSpan.Parse("13:21:00"));
        //RunAlgorithmsBenchmark(g, "Broniewskiego", "PL. GRUNWALDZKI", TimeSpan.Parse("07:19:00"));
        RunAlgorithmsBenchmark(g, "Wyszyńskiego", "Wielka", TimeSpan.Parse("08:18:00"));
        //RunAlgorithmsBenchmark(g, "DWORZEC NADODRZE", "DWORZEC GŁÓWNY", TimeSpan.Parse("19:00:00"));
        //RunAlgorithmsBenchmark(g, "Smolec - Dębowa (sklep)", "Długołęka - Parkowa/skrzy.", TimeSpan.Parse("07:30:00"));

        //Zadanie 2
        List<string> points = new() { "PL. GRUNWALDZKI", "Hutmen", "Dmowskiego", "Broniewskiego", "Jaworowa" };

        //List<string> points = new List<string> { "PL. GRUNWALDZKI", "Hutmen", "Dmowskiego", "Broniewskiego"};


        Random random = new();
        List<string> randomizedList = points.OrderBy(x => random.Next()).ToList();

        RunTabuSearch(g, "Wita Stwosza", randomizedList, TimeSpan.Parse("10:00:00"), 20);


        //for (int i = 0; i < 2; i++)
        //{
        //    randomizedList = points.OrderBy(x => random.Next()).ToList();
        //    Console.WriteLine("\n-----------------\n");
        //    RunTabuSearch(g, "Wita Stwosza", randomizedList, TimeSpan.Parse("10:00:00"), 20);
        //}
    }

    public static void RunAlgorithmsBenchmark(Graph g, String startName, String endName, TimeSpan currentTime)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Algorithms.Dijkstra(g, startName, endName, currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch = System.Diagnostics.Stopwatch.StartNew();
        Algorithms.PathFinding(g, startName, endName, "t", currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        watch = System.Diagnostics.Stopwatch.StartNew();
        Algorithms.PathFinding(g, startName, endName, "p", currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch = System.Diagnostics.Stopwatch.StartNew();
        Algorithms.AStarChangesStrike(g, startName, endName, currentTime);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    public static void RunTabuSearch(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime, int maxIterations)
    {
        var result = new List<string>();
        result = Algorithms.TabuSearch(g, startPoint, pointsToVisit, currentTime, maxIterations, true);
        Algorithms.ComputeRouteTimePrint(g, startPoint, result, currentTime, true);


        result = Algorithms.TabuSearch(g, startPoint, pointsToVisit, currentTime, maxIterations, false);
        Algorithms.ComputeRouteTimePrint(g, startPoint, result, currentTime, false);
    }
    
}

/*
 Made by Filip Strózik 2022
*/
