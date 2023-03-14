using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Graph
    {
        public Dictionary<(double, double), Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph() 
        {
            Nodes = new Dictionary<(double,double),Node>();
            Edges = new List<Edge>();
        }
        public Graph(Dictionary<(double, double), Node> nodes, List<Edge> edges)
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



        public void AddNode(Node node)
        {
            if(!Nodes.ContainsKey((node.Longitude, node.Latitude)))
            {
                Nodes[(node.Longitude, node.Latitude)] = node;
            }
        }

        public void AddEdge(Edge edge)
        {
            Node? foundStartNode = Nodes[(edge.StartNode.Longitude, edge.StartNode.Latitude)];
            Node? foundEndNode = Nodes[(edge.EndNode.Longitude, edge.EndNode.Latitude)];

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
/*            if(ConvertTimeAndCompare(edge.DepartureTime, currentTime))
            {
                //Console.WriteLine($"{startNode} - {edge} - {currentTime}");
                //Console.WriteLine(edge.ArrivalTime.TotalSeconds - currentTime.TotalSeconds);
                return (int)(edge.ArrivalTime.TotalSeconds - currentTime.TotalSeconds);
            }*/

            return (int) (edge.ArrivalTime.TotalMinutes - edge.DepartureTime.TotalMinutes);
        }

        private bool ConvertTimeAndCompare(TimeSpan currentTime, TimeSpan departureTime)
        {
            return TimeSpan.Compare(currentTime, departureTime) == 0;
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

        public List<Edge> NeighbourEdges(Node startNode)
        {
            List<Edge> neighoursEdge = new List<Edge>();
            foreach (Edge edge in Edges)
            {
                if (edge.StartNode == startNode)
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
    }
}
