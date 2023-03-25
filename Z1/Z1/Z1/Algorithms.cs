using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Z1
{
    public class Algorithms
    {
        public static void Dijkstra(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);

                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost;
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");

            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach(var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes < 0 ? 1440 + (currentTime.TotalMinutes - startTime.TotalMinutes) : currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time Dijkstra {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");

        }

        public static int AStarTime(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            int totalTime = (int)(currentTime.TotalMinutes - startTime.TotalMinutes < 0 ? 1440 + (currentTime.TotalMinutes - startTime.TotalMinutes) : currentTime.TotalMinutes - startTime.TotalMinutes);
            Console.WriteLine($"Total time A* time {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");

            return totalTime;
        }


        public static void AStarChanges(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.LineChangeCost(came_from[current], next);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes < 0 ? 1440 + (currentTime.TotalMinutes - startTime.TotalMinutes) : currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time A* changes {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");
        }


        public static void AStarChangesStrike(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            var lines_strikes = new Dictionary<string, int>();
            string currentLineStrike = "";
            var strikeMultiplier = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                if (came_from[current] != null)
                {
                    if (came_from[current].Line == currentLineStrike)
                    {
                        strikeMultiplier -= strikeMultiplier > 0 ? 10 : 0;
                    }
                    else
                    {
                        strikeMultiplier = 130;
                        currentLineStrike = came_from[current].Line;
                    }
                }


                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    var strikeCost = 0;
                    if(next.Line != currentLineStrike)
                    {
                        strikeCost = strikeMultiplier;
                    }
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.LineChangeCost(came_from[current], next);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode)
                            + strikeCost;
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes < 0 ? 1440 + (currentTime.TotalMinutes - startTime.TotalMinutes) : currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time A* changes + strike {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");
        }

        internal static void PathFinding(Graph g, string startPoint, string endPoint, string mode, TimeSpan currentTime)
        {
            switch (mode)
            {
                case "t":
                    AStarTime(g, startPoint, endPoint, currentTime);
                    return;
                case "p":
                    AStarChanges(g, startPoint, endPoint, currentTime);
                    return;
                default:
                    break;
            }
        }


        public static List<string> TabuSearch(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime, int tabuTenure, int maxIterations)
        {
            var time = currentTime;
            var currPoint = startPoint;
            var bestRoute = new List<string>(pointsToVisit);
            var bestTime = ComputeRouteTime(g, startPoint, pointsToVisit, currentTime);
            var tabuList = new Dictionary<string, int>();
            var iteration = 0;
            var aspirationCriteriaMet = false;

            while (iteration < maxIterations)
            {
                // Generate candidate solutions by swapping adjacent cities
                var candidates = GenerateCandidates(bestRoute);
                Console.WriteLine(candidates.Count);

                // Evaluate candidate solutions and choose the best one that is not on the Tabu list
                var bestCandidate = candidates
                    .Where(c => !tabuList.ContainsKey(string.Join("-", c)))
                    .OrderBy(c => ComputeRouteTime(g, startPoint, c, time))
                    .FirstOrDefault();


                // Update the current solution and the Tabu list
                var newTime = ComputeRouteTime(g, startPoint, bestCandidate, time);
                var newRoute = new List<string>(bestCandidate);

                if (newTime < bestTime || aspirationCriteriaMet)
                {
                    bestRoute = newRoute;
                    bestTime = newTime;

                    if (newTime < bestTime)
                    {
                        aspirationCriteriaMet = true;
                    }
                }

                foreach (var move in GetTabuMoves(bestRoute, newRoute))
                {
                    tabuList[move] = iteration + tabuTenure;
                }

                // Advance to the next iteration
                iteration++;
            }

            Console.WriteLine($"Best time Tabu {bestTime - currentTime.TotalMinutes}");

            return bestRoute;
        }

        private static List<List<string>> GenerateCandidates(List<string> route)
        {
            var candidates = new List<List<string>>();

            for (var i = 0; i < route.Count - 1; i++)
            {
                var candidate = new List<string>(route);
                var tmp = candidate[i];
                candidate[i] = candidate[i + 1];
                candidate[i + 1] = tmp;
                candidates.Add(candidate);

            }

            return candidates;
        }

        private static double ComputeRouteTime(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime)
        {
            var time = currentTime;
            var currPoint = startPoint;
            foreach (var point in pointsToVisit)
            {
                time = time.Add(TimeSpan.FromMinutes(AStarTime(g, currPoint, point, time)));
                currPoint = point;
            }
            time = time.Add(TimeSpan.FromMinutes(AStarTime(g, currPoint, startPoint, time)));
            return time.TotalMinutes;
        }

        private static IEnumerable<string> GetTabuMoves(List<string> oldRoute, List<string> newRoute)
        {
            for (var i = 0; i < oldRoute.Count; i++)
            {
                if (oldRoute[i] != newRoute[i])
                {
                    yield return $"{oldRoute[i]}-{newRoute[i]}";
                }
            }
        }
    }
}

