using System;
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
                        foreach (var neighborEdge in graph.NeighbourEdges(currentNode))
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
    }
}
