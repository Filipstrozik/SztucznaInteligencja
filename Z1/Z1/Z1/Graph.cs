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

            Edge newEdge = new Edge(
                edge.Id,
                edge.Company,
                edge.Line,
                foundStartNode,
                foundEndNode,
                edge.ArrivalTime,
                edge.DepartureTime);

            Edges.Add(newEdge);// do i need this

            foundStartNode.AddEdge(newEdge);
        }

        public int CalculateCost(Node startNode, Edge edge, TimeSpan currentTime)
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
            /*            List<Edge> neighoursEdge = new List<Edge>();
                        foreach (Edge edge in startNode.Edges)
                        {
                            if (ConvertTimeAndCompare(currentTime, edge.DepartureTime))
                            {
                                neighoursEdge.Add(edge);
                            }
                        }
                        return neighoursEdge;*/
            //return startNode.Edges;

             //TODO
             //1 iterate through pirorytyqueue starting from current time and scan maximaly 20 minutes in forward...
             //1a make a copy of piroryty queue
             //1b 


            //PriorityQueue<Edge, double> copyPriorityQueue = new PriorityQueue<Edge, double>((IEnumerable<(Edge Element, double Priority)>)startNode.PriorityQueue);
            //copyPriorityQueue.Ele
            var edges = startNode.Edges.Where(e => ConvertTimeAndCompare(currentTime, e.DepartureTime)
            && ConvertTimeAndCompare(e.DepartureTime, currentTime.Add(TimeSpan.FromMinutes(30)))).ToList();
            //Console.WriteLine(edges.Count);

            //edges = startNode.Edges.Where(e => ConvertTimeAndCompare(currentTime, e.DepartureTime)).ToList();
            //Console.WriteLine(edges.Count);

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
