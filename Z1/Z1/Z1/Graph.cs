using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Graph
    {
        public Dictionary<(double, double), Node> Nodes { get; set; }

        public Dictionary<string, Node> MergedNodes { get; set; }
        public List<Edge> Edges { get; set; } //we can do it in priorityQueue also to keep them in order... binary search...

        public Graph() 
        {
            Nodes = new Dictionary<(double,double),Node>();
            Edges = new List<Edge>();
            MergedNodes = new Dictionary<string, Node>();
        }
        public Graph(Dictionary<(double, double), Node> nodes, List<Edge> edges, Dictionary<string, Node> merged)
        {
            Nodes = nodes;
            Edges = edges;
            MergedNodes=merged;
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


        public void AddNode(Node node)
        {
            if(!Nodes.ContainsKey((node.Latitude, node.Longitude)))
            {
                Nodes[(node.Latitude, node.Longitude)] = node;
            }
        }

        public void AddNodeMerged(Node node)
        {
            if (!MergedNodes.ContainsKey(node.Name))
            {
                MergedNodes[node.Name] = node;
            }
        }

        public void AddEdge(Edge edge)
        {
            Node? foundStartNode = Nodes[(edge.StartNode.Latitude, edge.StartNode.Longitude)];
            Node? foundEndNode = Nodes[(edge.EndNode.Latitude, edge.EndNode.Longitude)];

            Edge newEdge = new Edge(
                edge.Id, 
                edge.Company, 
                edge.Line,
                foundStartNode,
                foundEndNode, 
                edge.ArrivalTime, 
                edge.DepartureTime);

            Edges.Add(newEdge);

            foundStartNode.Edges.Add(newEdge);

        }

        public void AddEdgeMerged(Edge edge)
        {
            Node? foundStartNode = MergedNodes[edge.StartNode.Name];
            Node? foundEndNode = MergedNodes[edge.EndNode.Name];

            Edge newEdge = new Edge(
                edge.Id,
                edge.Company,
                edge.Line,
                foundStartNode,
                foundEndNode,
                edge.ArrivalTime,
                edge.DepartureTime);

            Edges.Add(newEdge);

            foundStartNode.Edges.Add(newEdge);
        }

        public int CalculateCost(Node startNode, Edge edge, TimeSpan currentTime)
        {
            return (int) ((edge.ArrivalTime.TotalMinutes -  currentTime.TotalMinutes));
        }

        private bool ConvertTimeAndCompare(TimeSpan currentTime, TimeSpan departureTime) 
        {
            return TimeSpan.Compare(currentTime, departureTime) <= 0;
        }

        public List<Node> Neighbours(Node startNode)
        {
            List<Node> neighours = new List<Node>();
            foreach(Edge edge in Edges) 
            {
                if(edge.StartNode == startNode)
                {
                    neighours.Add(edge.EndNode);
                }
            }
            return neighours;
        }

        public List<Edge> NeighbourEdges(Node startNode, TimeSpan currentTime)
        {
            List<Edge> neighoursEdge = new List<Edge>();
            foreach (Edge edge in Edges)
            {
                if (edge.StartNode == startNode && ConvertTimeAndCompare(currentTime, edge.DepartureTime))
                {
                    neighoursEdge.Add(edge);
                }
            }
            return neighoursEdge;
        }

        public List<Edge> NeighbourEdgesMerged(Node startNode, TimeSpan currentTime)
        {
            List<Edge> neighoursEdge = new List<Edge>();
            foreach (Edge edge in startNode.Edges)
            {
                if (edge.StartNode == startNode && ConvertTimeAndCompare(currentTime, edge.DepartureTime))
                {
                    neighoursEdge.Add(edge);
                }
            }
            return neighoursEdge;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var nodes = Nodes;

            foreach (var node in nodes)
            {
                if(node.Value.Edges.Count > 1)
                {
                    sb.AppendLine($"Edges starting from node {node}:");
                    foreach (var edge in node.Value.Edges)
                    {
                        sb.AppendLine($"- {edge}");
                    }
                }
            }
            return sb.ToString();
        }

        internal List<Edge> NeighbourEdgesForStartNode(Node startNode, TimeSpan currentTime)
        {
            List<Edge> neighoursEdge = new List<Edge>();
            foreach (Edge edge in Edges)
            {
                if (edge.StartNode == startNode && ConvertTimeAndCompare(currentTime, edge.DepartureTime))
                {
                    neighoursEdge.Add(edge);
                }
            }
            return neighoursEdge;
        }

        internal List<Edge> NeighbourEdgesForStartNodeMerged(Node startNode, TimeSpan currentTime)
        {
            List<Edge> neighoursEdge = new List<Edge>();
            foreach (Edge edge in startNode.Edges)
            {
                if (edge.StartNode == startNode && ConvertTimeAndCompare(currentTime, edge.DepartureTime))
                {
                    neighoursEdge.Add(edge);
                    //maybe set only 1 represetation of each line?
                }
            }
            return neighoursEdge;
        }

        public static int ManhattanHeuristic(Node a, Node b)
        {
            return (int)((Math.Abs(a.Latitude - b.Latitude) + Math.Abs(a.Longitude - b.Longitude)) * 1000);
        }
        public static int EuklidesHeuristic(Node a, Node b)
        {
            return (int)(Math.Pow(a.Latitude - b.Latitude, 2) + Math.Pow(a.Longitude - b.Longitude, 2));
        }

        internal static int LineChangeCost(Edge edge, Edge next)
        {
            int cost = 0;
            if (edge != null && edge.Line != next.Line)
            {
                cost = 3000;
            }
            return cost;
        }
    }
}
