using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Z1
{
    public class DataLoader
    {
        public static void Load()
        {
            String filePath = @"C:\Users\filip\Documents\Sem6\SztucznaInteligencja\Z1\Z1\Z1\connection_graph.csv";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string company = parts[2];
                        string travel_line = parts[3];
                        string departure_time = parts[4];
                        string arrival_time = parts[5];
                        Console.WriteLine(company);
                        Console.WriteLine(travel_line);
                        Console.WriteLine(departure_time);
                        Console.WriteLine(arrival_time);

                    }
                }
            }
            catch(Exception e)
            { 
                Console.WriteLine (e.Message);
            }
            Console.ReadKey();
        }

    }
}
