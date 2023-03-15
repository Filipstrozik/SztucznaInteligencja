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
            //return $"E: {Line} t1: {DepartureTime} at: {StartNode.Name} \t\t  t2: {ArrivalTime} at: {EndNode.Name}";
            return $" {Line.Substring(0, Math.Min(3, Line.Length)).PadRight(3)} t1: {DepartureTime} at: {StartNode.Name.Substring(0, Math.Min(20, StartNode.Name.Length)).PadRight(20)} t2: {ArrivalTime} at: {EndNode.Name.Substring(0, Math.Min(20, EndNode.Name.Length)).PadRight(20)}";

        }
    }

}
