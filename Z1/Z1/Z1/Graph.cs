using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph() 
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }
        public Graph(List<Node> nodes, List<Edge> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

        public List<Edge> GetAdjacentEdges(Node node)
        {
            return Edges.Where(e => e.StartNode == node).ToList();
        }

        public List<Node> GetNeighbors(Node node)
        {
            var neighborEdges = GetAdjacentEdges(node);
            var neighbors = neighborEdges.Select(e => e.EndNode).ToList();
            return neighbors;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var edgesByStartNode = Edges.GroupBy(e => e.StartNode);

            foreach (var group in edgesByStartNode)
            {
                sb.AppendLine($"Edges starting from node {group.Key.Name}:");
                foreach (var edge in group)
                {
                    sb.AppendLine($"- {edge}");
                }
            }
            return sb.ToString();
        }
    }
}
