using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class DijkstraAlgorithm
    {
        private static (double,double)? GetMinDistance(Dictionary<(double, double), int> distances, HashSet<(double, double)> unvisited)
        {
            int minDistance = int.MaxValue;
            (double, double)? minNode = null;

            foreach (var node in unvisited)
            {
                if (distances[node] < minDistance)
                {
                    minDistance = distances[node];
                    minNode = node;
                }
            }

            return minNode;
        }

        public static Dictionary<(double, double), int> FindShortestPaths(Graph graph, string startPoint, string endPoint)
        {
            (double, double) startNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == startPoint).Key;
            (double, double) endNode = graph.Nodes.FirstOrDefault(n => n.Value.Name == endPoint).Key;
            Dictionary<(double, double), int> distances = new Dictionary<(double, double), int>();
            HashSet<(double, double)> unvisited = new HashSet<(double, double)>();

            //TODO gotta have a piroryty queue

            foreach (var node in graph.Nodes.Keys)
            {
                distances[node] = int.MaxValue;
                unvisited.Add(node);
            }

            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                (double, double)? currentNode = GetMinDistance(distances, unvisited);

                if(currentNode == null)
                {
                    Console.WriteLine("Graph is not complete!");
                    unvisited.Clear();
                }
                else
                {
                    unvisited.Remove(currentNode.Value);

                    if (graph.Nodes.ContainsKey(currentNode.Value))
                    {
                        foreach (var neighbor in graph.Nodes)
                        {
                            int distanceToNeighbor = 1;
                            int distanceFromStart = distances[currentNode.Value] + distanceToNeighbor;

                            if (distanceFromStart < distances[neighbor.Key])
                            {
                                distances[neighbor.Key] = distanceFromStart;
                            }
                        }
                    }
                }

            }

            return distances;
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
