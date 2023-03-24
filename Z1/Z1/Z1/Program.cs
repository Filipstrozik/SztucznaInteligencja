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
        Graph g = new Graph();
        DataLoader.LoadMerge(g);

        //Run(g, "Perzowa", "Jaworowa", TimeSpan.Parse("12:30:00"));
        //Run(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        //Run(g, "Obornicka (Obwodnica)", "Jaworowa", TimeSpan.Parse("06:07:00"));
        //Run(g, "Wielka", "ZOO", TimeSpan.Parse("16:19:00"));
        //Run(g, "Słonimskiego", "PL. GRUNWALDZKI", TimeSpan.Parse("08:30:00"));
        //Run(g, "LEŚNICA", "KSIĘŻE MAŁE", TimeSpan.Parse("07:26:00"));



        //Run(g, "DWORZEC GŁÓWNY", "Górnickiego", TimeSpan.Parse("10:00:00"));


        //Run(g, "Perzowa", "Jaworowa", TimeSpan.Parse("23:34:00"));
        //Run(g, "Magellana", "Rogowska", TimeSpan.Parse("12:34:00"));
        //Run(g, "Jordanowska", "Nowy Dom", TimeSpan.Parse("13:35:00"));
        Run(g, "Broniewskiego", "Wawrzyniaka", TimeSpan.Parse("07:19:00"));
        //Run(g, "Wyszyńskiego", "Wielka", TimeSpan.Parse("08:18:00"));
        //Run(g, "DWORZEC NADODRZE", "DWORZEC GŁÓWNY", TimeSpan.Parse("19:00:00"));
        //Run(g, "Smolec - Dębowa (sklep)", "Długołęka - Parkowa/skrzy.", TimeSpan.Parse("07:30:00"));
        /*        List<string> points = new List<string> { "PL. GRUNWALDZKI", "Wielka", "Wawrzyniaka", "Jaworowa" };
                var result = Algorithms.TabuSearch(g, "Broniewskiego", points, TimeSpan.Parse("07:30:00"), 2, 4);
                foreach (var point in result)
                {
                    Console.WriteLine(point.ToString());
                }*/

    }

    public static void Run(Graph g, String startName, String endName, TimeSpan currentTime)
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
}
