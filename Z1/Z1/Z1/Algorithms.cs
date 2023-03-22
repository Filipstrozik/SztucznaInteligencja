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

        public static void TabuSearch(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime)
        {
            var time = currentTime;
            var currPoint = startPoint;
            foreach(var point in pointsToVisit)
            {
                time = time.Add(TimeSpan.FromMinutes(AStarTime(g, currPoint, point, time)));
                currPoint = point;
            }
            time = time.Add(TimeSpan.FromMinutes(AStarTime(g, currPoint, startPoint, time)));
            Console.WriteLine($"Total time Tabu {time.TotalMinutes - currentTime.TotalMinutes}");


        }
    }
}

