using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Z1
{
    public class DijkstraAlgorithm
    {
        private static Node GetMinDistance(Dictionary<Node, int> distances, HashSet<Node> unvisited)
        {
            int minDistance = int.MaxValue;
            Node? minNode = null;

            foreach (var node in unvisited)
            {
                if (distances[node] < minDistance)
                {
                    minDistance = distances[node];
                    minNode = node;
                }
            }

            return minNode!;
        }

        public static Dictionary<Node, int> FindShortestPaths(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == startPoint).Value;
            Node endNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == endPoint).Value;
            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            HashSet<Node> unvisited = new HashSet<Node>();


            Dictionary<Node, int> timeNodeVisited = new Dictionary<Node, int>();
            timeNodeVisited[startNode] = 0;

            //gotta have two dijskras 
            //TODO gotta have a piroryty queues
            Console.WriteLine("startting nodes:");
            foreach (Node node in graph.Nodes.Values.Where(n => n.Name == startPoint))
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("end nodes:");

            foreach (Node node in graph.Nodes.Values.Where(n => n.Name == endPoint))
            {
                Console.WriteLine(node);
            }


            foreach (var node in graph.Nodes.Values)
            {
                distances[node] = int.MaxValue;
                unvisited.Add(node);
            }

            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                Node currentNode = GetMinDistance(distances, unvisited);
                Console.WriteLine(currentNode);
                if (currentNode.Name == endPoint)
                {
                    Console.WriteLine(currentNode);
                    break;
                }

                int currentNodeTime = timeNodeVisited[currentNode];

                if(currentNode == null)
                {
                    Console.WriteLine("Graph is not complete!");
                    unvisited.Clear();
                }
                else
                {
                    unvisited.Remove(currentNode);

                    if (graph.Nodes.ContainsValue(currentNode))
                    {
                        foreach (var neighborEdge in graph.NeighbourEdges(currentNode, startTime))
                        {
                            
                            int distanceToNeighbor = graph.CalculateCost(currentNode, neighborEdge, startTime);
                            int distanceFromStart = distances[currentNode] + distanceToNeighbor;

                            if (distanceFromStart < distances[neighborEdge.EndNode])
                            {
                                timeNodeVisited[neighborEdge.EndNode] = distanceToNeighbor;
                                distances[neighborEdge.EndNode] = distanceFromStart;
                            }
                        }
                    }
                }

            }

            return timeNodeVisited;
        }

        public static string Print(Dictionary<string, Dictionary<string, int>> graph)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var node in graph)
            {
                sb.AppendFormat("Node {0}:\n", node.Key);

                foreach (var neighbor in node.Value)
                {
                    sb.AppendFormat("\t-> Node {0} (distance: {1})\n", neighbor.Key, neighbor.Value);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static void PseudoDjikstra(Graph graph, Node startNode, string endPoint, TimeSpan startTime)
        {
            //Node startNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == startPoint).Value;
            Node endNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == endPoint).Value;

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


                foreach (var next in 
                    current == startNode ? graph.NeighbourEdgesForStartNode(current, currentTime) :
                    graph.NeighbourEdges(current, currentTime)
                    
                    )//optimize getiing edges
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost + Graph.EuklidesHeuristic(endNode, next.EndNode) + Graph.LineChangeCost(came_from[current], next);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                if (frontier.Count == 0)
                {
                    Console.WriteLine("No possible solution!");
                    break;
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;

            }
            
            Console.WriteLine(howMany);
            var final_list = new List<Edge>();

            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            final_list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total time {currentTime.TotalMinutes - startTime.TotalMinutes}");
        }

        public static void PseudoDjikstraMerged(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
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

                foreach (var next in graph.NeighbourEdgesForStartNodeMerged(current, currentTime))
                {
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.ManhattanHeuristic(endNode, next.EndNode);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        howMany++;
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost + Graph.LineChangeCost(came_from[current], next);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                if (frontier.Count == 0)
                {
                    Console.WriteLine("No possible solution!");
                    break;
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            Console.WriteLine(howMany);
            var final_list = new List<Edge>();

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
            Console.WriteLine($"Total time {currentTime.TotalMinutes - startTime.TotalMinutes}");
        }
    }



}
