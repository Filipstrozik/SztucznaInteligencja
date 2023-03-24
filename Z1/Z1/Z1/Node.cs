using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Node
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Edge> Edges { get; set; }

        public PriorityQueue<Edge, double> PriorityQueue { get; set; }

        public Node(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Edges = new List<Edge>();
            PriorityQueue = new PriorityQueue<Edge, double>();
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
            PriorityQueue.Enqueue(edge, edge.DepartureTime.TotalMinutes);
        }

        public override string ToString()
        {
            return $"Node(Name={Name}, Latitude={Latitude}, Longitude={Longitude})";
        }
    }

}
