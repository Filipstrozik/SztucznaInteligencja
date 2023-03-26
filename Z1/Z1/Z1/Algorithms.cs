namespace Z1
{
    public class Algorithms
    {
        public static void Dijkstra(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);

                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost;
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");

            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time Dijkstra {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");

        }

        public static int AStarTimePrint(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time A* time {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");
            return (int)totalTime;
        }

        public static int AStarTimeTabu(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            //Console.WriteLine("------------------------");

            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            //Console.WriteLine($"Total time A* changes {totalTime}");
            //Console.WriteLine($"Total visted nodes: {howMany}");
            return (int)totalTime;
        }


        public static int AStarChanges(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.LineChangeCost(came_from[current], next);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time A* changes {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");
            return (int)totalTime;
        }

        public static int AStarChangesTabu(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.LineChangeCost(came_from[current], next);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode);
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            return (int)totalTime;
        }


        public static void AStarChangesStrike(Graph graph, string startPoint, string endPoint, TimeSpan startTime)
        {
            Node startNode = graph.MergedNodes[startPoint];
            Node endNode = graph.MergedNodes[endPoint];

            var frontier = new PriorityQueue<Node, int>();
            frontier.Enqueue(startNode, 0);
            var came_from = new Dictionary<Node, Edge>();
            var cost_so_far = new Dictionary<Node, int>();
            came_from[startNode] = null;
            cost_so_far[startNode] = 0;
            Node lastNode = null;
            int howMany = 0;
            var currentTime = startTime;

            var lines_strikes = new Dictionary<string, int>();
            string currentLineStrike = "";
            var strikeMultiplier = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                lastNode = current;

                if (current.Name == endPoint) break;

                if (came_from[current] != null)
                {
                    if (came_from[current].Line == currentLineStrike)
                    {
                        strikeMultiplier -= strikeMultiplier > 0 ? 10 : 0;
                    }
                    else
                    {
                        strikeMultiplier = 130;
                        currentLineStrike = came_from[current].Line;
                    }
                }


                foreach (var next in graph.NeighbourEdgesForStartNodeMergedAll(current, currentTime))
                {
                    var strikeCost = 0;
                    if (next.Line != currentLineStrike)
                    {
                        strikeCost = strikeMultiplier;
                    }
                    howMany++;
                    var new_cost = cost_so_far[current] + graph.CalculateCost(current, next, currentTime) + Graph.LineChangeCost(came_from[current], next);
                    if (!cost_so_far.ContainsKey(next.EndNode) || new_cost < cost_so_far[next.EndNode])
                    {
                        cost_so_far[next.EndNode] = new_cost;
                        var priority = new_cost
                            + Graph.EuklidesHeuristic(endNode, next.EndNode)
                            + strikeCost;
                        frontier.Enqueue(next.EndNode, priority);
                        came_from[next.EndNode] = next;
                    }
                }
                currentTime = came_from[frontier.Peek()].ArrivalTime;
            }

            var final_list = new List<Edge>();
            Console.WriteLine("------------------------");
            while (came_from[lastNode] != null)
            {
                final_list.Add(came_from[lastNode]);
                lastNode = came_from[lastNode].StartNode;
            }
            final_list.Reverse();
            foreach (var edge in final_list)
            {
                Console.WriteLine(edge + " " + cost_so_far[edge.EndNode]);
            }
            var totalTime = currentTime.TotalMinutes - startTime.TotalMinutes;
            Console.WriteLine($"Total time A* changes + strike {totalTime}");
            Console.WriteLine($"Total visted nodes: {howMany}");
        }

        internal static void PathFinding(Graph g, string startPoint, string endPoint, string mode, TimeSpan currentTime)
        {
            switch (mode)
            {
                case "t":
                    AStarTimePrint(g, startPoint, endPoint, currentTime);
                    return;
                case "p":
                    AStarChanges(g, startPoint, endPoint, currentTime);
                    return;
                default:
                    break;
            }
        }


        public static List<string> TabuSearch(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime, int maxIterations,bool ifTime)
        {
            var time = currentTime;
            var currPoint = startPoint;
            var bestRoute = new List<string>(pointsToVisit);
            var newRoute = new List<string>(pointsToVisit);
            var bestTime = ComputeRouteTime(g, startPoint, pointsToVisit, currentTime, ifTime);
            var tabuList = new HashSet<string>();
            var iteration = 0;
            var aspirationCriteriaMet = false;

            while (iteration < maxIterations)
            {
                // Generate candidate solutions by swapping adjacent cities
                var candidates = GenerateNeighbors(newRoute);

                // Evaluate candidate solutions and choose the best one that is not on the Tabu list

                var bestCandidate = candidates
                    .Where(c => !tabuList.Contains(string.Join("-", c)))
                    .OrderBy(c => ComputeRouteTime(g, startPoint, c, time, ifTime))
                    .FirstOrDefault();

                foreach (var candidate in candidates)
                {
                    tabuList.Add(string.Join("-", candidate));
                }

                if ( bestCandidate == null ) {
                    break;
                }

                // Update the current solution and the Tabu list
                var newTime = ComputeRouteTime(g, startPoint, bestCandidate, time, ifTime);
                newRoute = new List<string>(bestCandidate);

                if (newTime <= bestTime)
                {
                    bestRoute = newRoute;
                    bestTime = newTime;
                }
                // Advance to the next iteration
                iteration++;
            }

            Console.WriteLine($"Best time Tabu {bestTime}");

            return bestRoute;
        }


        private static List<List<string>> GenerateCandidates(List<string> route)
        {
            var candidates = new List<List<string>>();

            for (var i = 0; i < route.Count - 1; i++)
            {
                var candidate = new List<string>(route);
                var tmp = candidate[i];
                candidate[i] = candidate[i + 1];
                candidate[i + 1] = tmp;
                candidates.Add(candidate);
            }
            return candidates;
        }

        public static List<List<string>> GenerateNeighbors(List<string> solution)
        {
            List<List<string>> neighbors = new List<List<string>>();
            int n = solution.Count;
            for (int i = 0; i < n; i++)
            {
                List<string> neighbor = new List<string>(solution);
                int j = (i + 1) % n;
                string temp = neighbor[i];
                neighbor[i] = neighbor[j];
                neighbor[j] = temp;
                neighbors.Add(neighbor);
            }
            return neighbors;
        }

        private static double ComputeRouteTime(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime, bool ifTime)
        {
            var time = currentTime;
            var currPoint = startPoint;
            foreach (var point in pointsToVisit)
            {
                if (ifTime)
                {
                    time = time.Add(TimeSpan.FromMinutes(AStarTimeTabu(g, currPoint, point, time)));
                } else
                {
                    time = time.Add(TimeSpan.FromMinutes(AStarChangesTabu(g, currPoint, point, time)));
                }
                
                currPoint = point;
            }
            if (ifTime)
            {
                time = time.Add(TimeSpan.FromMinutes(AStarTimeTabu(g, currPoint, startPoint, time)));
            }
            else
            {
                time = time.Add(TimeSpan.FromMinutes(AStarChangesTabu(g, currPoint, startPoint, time)));
            }
            return time.TotalMinutes - currentTime.TotalMinutes;
        }

        private static IEnumerable<string> GetTabuMoves(List<string> oldRoute, List<string> newRoute)
        {
            for (var i = 0; i < oldRoute.Count; i++)
            {
                if (oldRoute[i] != newRoute[i])
                {
                    //yield return $"{oldRoute[i]}-{newRoute[i]}";
                    yield return string.Join("-", oldRoute);
                }
            }
        }

        public static void ComputeRouteTimePrint(Graph g, string startPoint, List<string> pointsToVisit, TimeSpan currentTime, bool ifTime)
        {
            var time = currentTime;
            var currPoint = startPoint;
            foreach (var point in pointsToVisit)
            {
                if (ifTime)
                {
                    time = time.Add(TimeSpan.FromMinutes(AStarTimePrint(g, currPoint, point, time)));
                }
                else
                {
                    time = time.Add(TimeSpan.FromMinutes(AStarChanges(g, currPoint, point, time)));
                }
                currPoint = point;
            }
            if (ifTime)
            {
                time = time.Add(TimeSpan.FromMinutes(AStarTimePrint(g, currPoint, startPoint, time)));
            }
            else
            {
                time = time.Add(TimeSpan.FromMinutes(AStarChanges(g, currPoint, startPoint, time)));
            }
            
        }

    }
}

