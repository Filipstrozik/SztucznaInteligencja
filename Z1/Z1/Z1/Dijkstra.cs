using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class DijkstraAlgorithm
    {
        private static int GetMinDistance(Dictionary<int, int> distances, HashSet<int> unvisited)
        {
            int minDistance = int.MaxValue;
            int minNode = 0;

            foreach (var pair in distances)
            {
                int node = pair.Key;
                int distance = pair.Value;

                if (unvisited.Contains(node) && distance < minDistance)
                {
                    minDistance = distance;
                    minNode = node;
                }
            }

            return minNode;
        }

        public static Dictionary<int, int> FindShortestPaths(Dictionary<int, Dictionary<int, int>> graph, int startNode)
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();
            HashSet<int> unvisited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
                unvisited.Add(node);
            }

            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                int currentNode = GetMinDistance(distances, unvisited);
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

            return distances;
        }
    }
}
