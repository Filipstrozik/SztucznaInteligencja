using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class DijkstraAlgorithm
    {
        private static string? GetMinDistance(Dictionary<string, int> distances, HashSet<string> unvisited)
        {
            int minDistance = int.MaxValue;
            string? minNode = null;

            foreach (var pair in distances)
            {
                string node = pair.Key;
                int distance = pair.Value;

                if (unvisited.Contains(node) && distance < minDistance)
                {
                    minDistance = distance;
                    minNode = node;
                }
            }

            return minNode;
        }

        public static Dictionary<string, int> FindShortestPaths(Dictionary<string, Dictionary<string, int>> graph, string startNode)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            HashSet<string> unvisited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
                unvisited.Add(node);
            }

            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                string? currentNode = GetMinDistance(distances, unvisited);

                if(currentNode == null)
                {
                    Console.WriteLine("Graph is not complete!");
                    unvisited.Clear();
                }
                else
                {
                    unvisited.Remove(currentNode);

                    if (graph.ContainsKey(currentNode))
                    {
                        foreach (var neighbor in graph[currentNode])
                        {
                            int distanceToNeighbor = neighbor.Value;
                            int distanceFromStart = distances[currentNode] + distanceToNeighbor;

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
