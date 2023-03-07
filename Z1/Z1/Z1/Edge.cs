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
            return $"\tEdge(\n\tId={Id},\n\tCompany={Company}, \n\tLine={Line}, \n\tStartNode={StartNode}, \n\tEndNode={EndNode}, \n\tDepartureTime={DepartureTime}, \n\tArrivalTime={ArrivalTime})";
        }
    }

}
