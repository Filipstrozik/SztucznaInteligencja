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

        public Dictionary<string, Node> MergedNodes { get; set; }

        public Graph() 
        {
            MergedNodes = new Dictionary<string, Node>();
        }

        public void AddNodeMerged(Node node)
        {
            if (!MergedNodes.ContainsKey(node.Name))
            {
                MergedNodes[node.Name] = node;
            }
        }

        public void AddEdgeMerged(Edge edge)
        {
            Node? foundStartNode = MergedNodes[edge.StartNode.Name];
            Node? foundEndNode = MergedNodes[edge.EndNode.Name];

            Edge newEdge = new(
                edge.Id,
                edge.Company,
                edge.Line,
                foundStartNode,
                foundEndNode,
                edge.ArrivalTime,
                edge.DepartureTime);

            foundStartNode.AddEdge(newEdge);
        }

        public int CalculateCost(Edge edge, TimeSpan currentTime)
        {
            int result = (int)(edge.ArrivalTime.TotalMinutes - currentTime.TotalMinutes);
            if((int)(edge.DepartureTime.TotalMinutes - currentTime.TotalMinutes) < 0) 
            {
                result = (int)(edge.ArrivalTime.TotalMinutes) + (int)(1440 - currentTime.TotalMinutes);
            }
            return result;
        }

        public bool ConvertTimeAndCompare(TimeSpan currentTime, TimeSpan departureTime) 
        {
            return TimeSpan.Compare(currentTime, departureTime) <= 0;
        }


        internal List<Edge> NeighbourEdgesForStartNodeMergedAll(Node startNode, TimeSpan currentTime)
        {
            var edges = startNode.Edges.Where(e => ConvertTimeAndCompare(currentTime, e.DepartureTime)
            && ConvertTimeAndCompare(e.DepartureTime, currentTime.Add(TimeSpan.FromMinutes(30)))).ToList();

            return edges;
        }

        public static int ManhattanHeuristic(Node a, Node b)
        {
            return (int)((Math.Abs(a.Latitude - b.Latitude) + Math.Abs(a.Longitude - b.Longitude)) * 1000);
        }

        public static int EuklidesHeuristic(Node a, Node b)
        {
            return (int)(Math.Sqrt((Math.Pow(a.Latitude - b.Latitude, 2) + Math.Pow(a.Longitude - b.Longitude, 2))) * 1000);
        }

        internal static int LineChangeCost(Edge edge, Edge next)
        {
            int cost = 0;
            if (edge != null && edge.Line != next.Line)
            {
                cost = 100;
            }
            return cost;
        }
    }
}
