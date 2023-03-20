using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class Edge
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Line { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public Edge(int id, string company, string line, Node startNode, Node endNode, TimeSpan arrivalTime, TimeSpan departureTime)
        {
            Id = id;
            Company = company;
            Line = line;
            StartNode = startNode;
            EndNode = endNode;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public override string? ToString()
        {
            return $"{Line.Substring(0, Math.Min(3, Line.Length)).PadRight(3)}\t{DepartureTime}\t{StartNode.Name.Substring(0, Math.Min(26, StartNode.Name.Length)).PadRight(26)}\t{ArrivalTime}\t{EndNode.Name.Substring(0, Math.Min(26, EndNode.Name.Length)).PadRight(26)}";

        }
    }

}
