using Z2;


uint size = 8;
string filename = "results.txt";
int counter = 0;
int blackMoves = 0;
int whiteMoves = 0;
int timeOfGame = 0;
int timeOfMovesBlackHeauristic = 0;
int sumOfTimesBlackHeuristic = 0;
int timeOfMovesWhiteHeuristic = 0;
int sumOfTimesWhiteHeuristic = 0;
int timer = 0;
int blackVisitedNodes = 0;
int whiteVisitedNodes = 0;
//set to test
bool prune = false;
int depth = 2;
bool custom = true;
int blackDepth = 7;
int whiteDepth = 7;
Tuple<int, int> results;


if (custom)
{
    // custom set
    var blackHeuristic = Tuple.Create<Func<Game, TileColor, int>, string>(ReversiSolver.TileCountHeuristic, "Count");
    var whiteHeuristic = Tuple.Create<Func<Game, TileColor, int>, string>(ReversiSolver.TileCountHeuristic, "Count");
    Console.WriteLine($"Testing: {blackHeuristic.Item2} depth: {blackDepth} against {whiteHeuristic.Item2} depth: {whiteDepth} | prune: {prune}");

    results = TestHeuristic(blackHeuristic.Item1, whiteHeuristic.Item1, blackDepth, whiteDepth, prune, size);
    Tuple<Func<Game, TileColor, int>, string> winner;
    TileColor winnerColor;

    if (results.Item1 > results.Item2)
    {
        winner = blackHeuristic;
        winnerColor = TileColor.BLACK;

    }
    else
    {
        winner = whiteHeuristic;
        winnerColor = TileColor.WHITE;
    }

    Console.WriteLine($"winner: {winnerColor}" +
        $"\nstrategy: {winner.Item2}" +
        $"\nBLACK ({blackHeuristic.Item2}) {results.Item1} - {results.Item2} WHITE ({whiteHeuristic.Item2})" +
        $"\nmoves: {counter}  / 60" +
        $"\ngameTime: {timeOfGame}ms" +
        $"\nblackTime: {sumOfTimesBlackHeuristic}ms with {blackMoves} moves. avg: {Math.Round(((double)sumOfTimesBlackHeuristic / (double)blackMoves), 2)}ms" +
        $"\nwhiteTime: {sumOfTimesWhiteHeuristic}ms with {whiteMoves} moves. avg: {Math.Round(((double)sumOfTimesWhiteHeuristic / (double)whiteMoves), 2)}ms" +
        $"\nblackNodes: {blackVisitedNodes}" +
        $"\nwhiteNodes: {whiteVisitedNodes}" +
        $"\n");
}
else
{

    List<Tuple<Func<Game, TileColor, int>, string>> heuristics = new()
    {
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.TileCountHeuristic,"Count"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.ActualMobilityHeuristic,"ActualMobility"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.CornersHeuristic,"Corners"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.WeightedHeuristic,"Weighted"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.RandomHeuristic,"Random")

    };

    StreamWriter output = null;
    for (; depth < 8; depth++)
    {
        if (output != null) output.Close(); // Close previous file
        output = new StreamWriter("depth_" + depth + "_" + prune + ".csv");

        // Write the titles of the columns
        output.WriteLine("Black Heuristic, White Heuristic, Depth, Prune, Winner, Strategy, Black Score, White Score, Moves, Game Time, Black Time, Black Moves, Black Avg Time, White Time, White Moves, White Avg Time, Black Nodes, White Nodes");

        foreach (var blackHeuristic in heuristics)
        {
            foreach (var whiteHeuristic in heuristics)
            {
                Console.WriteLine($"Testing: {blackHeuristic.Item2} against {whiteHeuristic.Item2} depth: {depth} | prune: {prune}");
                //output.WriteLine($"{blackHeuristic.Item2}, {whiteHeuristic.Item2}, {depth}, {prune},");

                results = TestHeuristic(blackHeuristic.Item1, whiteHeuristic.Item1, depth, depth, prune, size);
                Tuple<Func<Game, TileColor, int>, string> winner;
                TileColor winnerColor;

                if (results.Item1 > results.Item2)
                {
                    winner = blackHeuristic;
                    winnerColor = TileColor.BLACK;

                }
                else
                {
                    winner = whiteHeuristic;
                    winnerColor = TileColor.WHITE;
                }

                // Write the results as a row in the CSV file
                output.WriteLine($"{blackHeuristic.Item2}, {whiteHeuristic.Item2}, {depth}, {prune}, {winnerColor}, {winner.Item2}, {results.Item1}, {results.Item2}, {counter}, " +
                    $"{timeOfGame}, {sumOfTimesBlackHeuristic}, {blackMoves}, " +
                    $"{Math.Round(((double)sumOfTimesBlackHeuristic / (double)blackMoves), 2)}, " +
                    $"{sumOfTimesWhiteHeuristic}, {whiteMoves}, " +
                    $"{Math.Round(((double)sumOfTimesWhiteHeuristic / (double)whiteMoves), 2)}, {blackVisitedNodes}, {whiteVisitedNodes}");

            }
            Console.Write('\n');
        }
    }
    if (output != null) output.Close(); // Close last file



    /*for (; depth < 8; depth++)
    {
        StreamWriter output = new("depth_" + depth + ".txt");
        Console.WriteLine("Depth:" + depth);
        output.WriteLine("Depth: " + depth);
        foreach (var blackHeuristic in heuristics)
        {
            foreach (var whiteHeuristic in heuristics)
            {
                Console.WriteLine($"Testing: {blackHeuristic.Item2} against {whiteHeuristic.Item2} depth: {depth} | prune: {prune}");
                output.WriteLine($"Testing: {blackHeuristic.Item2} against {whiteHeuristic.Item2} depth: {depth} | prune: {prune}");


                results = TestHeuristic(blackHeuristic.Item1, whiteHeuristic.Item1, depth, depth, prune, size);
                Tuple<Func<Game, TileColor, int>, string> winner;
                TileColor winnerColor;

                if (results.Item1 > results.Item2)
                {
                    winner = blackHeuristic;
                    winnerColor = TileColor.BLACK;

                }
                else
                {
                    winner = whiteHeuristic;
                    winnerColor = TileColor.WHITE;
                }

                Console.WriteLine($"winner: {winnerColor}" +
                    $"\nstrategy: {winner.Item2}" +
                    $"\nBLACK ({blackHeuristic.Item2}) {results.Item1} - {results.Item2} WHITE ({whiteHeuristic.Item2})" +
                    $"\nmoves: {counter} / 60" +
                    $"\ngameTime: {timeOfGame}ms" +
                    $"\nblackTime: {sumOfTimesBlackHeuristic}ms with {blackMoves} moves. avg: {Math.Round(((double)sumOfTimesBlackHeuristic / (double)blackMoves), 2)}ms" +
                    $"\nwhiteTime: {sumOfTimesWhiteHeuristic}ms with {whiteMoves} moves. avg: {Math.Round(((double)sumOfTimesWhiteHeuristic / (double)whiteMoves), 2)}ms" +
                    $"\nblackNodes: {blackVisitedNodes}" +
                    $"\nwhiteNodes: {whiteVisitedNodes}" +
                    $"\n");
                output.WriteLine($"winner: {winnerColor}" +
                    $"\nstrategy: {winner.Item2}" +
                    $"\nBLACK ({blackHeuristic.Item2}) {results.Item1} - {results.Item2} WHITE ({whiteHeuristic.Item2})" +
                    $"\nmoves: {counter} / 60" +
                    $"\ngameTime: {timeOfGame}ms" +
                    $"\nblackTime: {sumOfTimesBlackHeuristic}ms with {blackMoves} moves. avg: {Math.Round(((double)sumOfTimesBlackHeuristic / (double)blackMoves), 2)}ms" +
                    $"\nwhiteTime: {sumOfTimesWhiteHeuristic}ms with {whiteMoves} moves. avg: {Math.Round(((double)sumOfTimesWhiteHeuristic / (double)whiteMoves), 2)}ms" +
                    $"\nblackNodes: {blackVisitedNodes}" +
                    $"\nwhiteNodes: {whiteVisitedNodes}" +
                    $"\n");
            }
            Console.Write('\n');
            output.Write('\n');
        }
        output.Close();
    }*/
}

Tuple<int, int> TestHeuristic(Func<Game, TileColor, int> blackHeuristic, Func<Game, TileColor, int> whiteHeuristic, int blackDepth = 5, int whiteDepth = 5, bool prune = true, uint size = 8)
{
    int black = 0;
    int white = 0;
    ReversiManager manager = new(blackHeuristic, blackDepth, prune, whiteHeuristic, whiteDepth, prune, size);
    manager.Reset();
    Game game = manager.GetGame();
    timeOfGame = Environment.TickCount;
    sumOfTimesBlackHeuristic = 0;
    sumOfTimesWhiteHeuristic = 0;
    blackVisitedNodes = 0;
    whiteVisitedNodes = 0;
    counter = 0;
    blackMoves = 0;
    whiteMoves = 0;
    bool wasBlack = true;
    while (!game.GameOver())
    {
        if (counter > 100)
        {
            System.Console.WriteLine("100 moves accomplished...");
            break;
        }
        if (game.IsFirstPlayer)// if black
        {
            wasBlack = true;
        }
        else
        {
            wasBlack = false;
        }
        timer = Environment.TickCount;
        game = manager.Next(prune);
        if (wasBlack)
        {
            blackMoves++;
            blackVisitedNodes += manager.visitedNodes;
            timeOfMovesBlackHeauristic = Environment.TickCount - timer;
            sumOfTimesBlackHeuristic += timeOfMovesBlackHeauristic;
        }
        else
        {
            whiteMoves++;
            whiteVisitedNodes += manager.visitedNodes;
            timeOfMovesWhiteHeuristic = Environment.TickCount - timer;
            sumOfTimesWhiteHeuristic += timeOfMovesWhiteHeuristic;
        }
        counter++;
    }
    timeOfGame = Environment.TickCount - timeOfGame;
    black = game.Board.GetNumColor(TileColor.BLACK);
    white = game.Board.GetNumColor(TileColor.WHITE);
    return Tuple.Create(black, white);
}
