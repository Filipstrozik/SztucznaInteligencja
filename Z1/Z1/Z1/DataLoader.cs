using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Z1
{
    public class DataLoader
    {
        public static void Load(Graph g)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            String filePath = @"C:\Users\filip\Documents\Sem6\SztucznaInteligencja\Z1\Z1\Z1\connection_graph.csv";
            string line;
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string id = parts[1];
                    string company = parts[2];
                    string travel_line = parts[3];
                    string departure_time = parts[4];
                    string arrival_time = parts[5];
                    string start_stop = parts[6];
                    string end_stop = parts[7];
                    string start_stop_lat = parts[8];
                    string start_stop_lon = parts[9];
                    string end_stop_lat = parts[10];
                    string end_stop_lon = parts[11];

                    Node startNode = new Node(start_stop, Double.Parse(start_stop_lat), Double.Parse(start_stop_lon));
                    Node endNode = new Node(end_stop, Double.Parse(end_stop_lat), Double.Parse(end_stop_lon));
                    Edge edge = new Edge(Int32.Parse(id), company, travel_line, startNode, endNode, TimeSpan.Parse(arrival_time), TimeSpan.Parse(departure_time));

                    g.AddNode(startNode);
                    g.AddNode(endNode);
                    g.AddEdge(edge);

                }
            }
        }

        public static void LoadMerge(Graph g)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            String filePath = @"C:\Users\filip\Documents\Sem6\SztucznaInteligencja\Z1\Z1\Z1\connection_graph.csv";
            string line;
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string id = parts[1];
                    string company = parts[2];
                    string travel_line = parts[3];
                    string departure_time = parts[4];
                    string arrival_time = parts[5];
                    string start_stop = parts[6];
                    string end_stop = parts[7];
                    string start_stop_lat = parts[8];
                    string start_stop_lon = parts[9];
                    string end_stop_lat = parts[10];
                    string end_stop_lon = parts[11];

                    Node startNode = new Node(start_stop, Double.Parse(start_stop_lat), Double.Parse(start_stop_lon));
                    Node endNode = new Node(end_stop, Double.Parse(end_stop_lat), Double.Parse(end_stop_lon));
                    Edge edge = new Edge(Int32.Parse(id), company, travel_line, startNode, endNode, TimeSpan.Parse(arrival_time), TimeSpan.Parse(departure_time));

                    g.AddNodeMerged(startNode);
                    g.AddNodeMerged(endNode);
                    g.AddEdgeMerged(edge);

                    //Console.WriteLine(startNode);
                    //Console.WriteLine(id);
                    //Console.WriteLine(endNode);
                }
            }
        }
    }
}
