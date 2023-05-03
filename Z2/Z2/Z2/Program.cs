using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
bool prune = true;
int depth = 2;
int blackVisitedNodes = 0;
int whiteVisitedNodes = 0;

Tuple<int, int> results;

List<Tuple<Func<Game, TileColor, int>, string>> heuristics = new List<Tuple<Func<Game, TileColor, int>, string>>
            {
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.TileCountHeuristic,"Count"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.ActualMobilityHeuristic,"ActualMobility"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.CornersHeuristic,"Corners"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.WeightedHeuristic,"Weighted"),
                Tuple.Create<Func<Game, TileColor, int>,string>(ReversiSolver.RandomHeuristic,"Random")

            };

for (; depth < 9; depth++)
{
    StreamWriter output = new StreamWriter("depth_" + depth + ".txt");
    Console.WriteLine("Depth:" + depth);
    output.WriteLine("Depth: " + depth);
    foreach (var blackHeuristic in heuristics)
    {
        foreach (var whiteHeuristic in heuristics)
        {
            Console.WriteLine($"Testing: {blackHeuristic.Item2} against {whiteHeuristic.Item2} depth: {depth} | prune: {prune}");

            output.WriteLine("Testing: " + blackHeuristic.Item2 + " against " + whiteHeuristic.Item2);

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
                $"\nmoves: {counter}" +
                $"\ngameTime: {timeOfGame}ms" +
                $"\nblackTime: {sumOfTimesBlackHeuristic}ms with {blackMoves} moves. avg: {Math.Round(((double)sumOfTimesBlackHeuristic/ (double)blackMoves), 2)}ms" +
                $"\nwhiteTime: {sumOfTimesWhiteHeuristic}ms with {whiteMoves} moves. avg: {Math.Round(((double)sumOfTimesWhiteHeuristic / (double)whiteMoves), 2)}ms" +
                $"\nblackNodes: {blackVisitedNodes}" +
                $"\nwhiteNodes: {whiteVisitedNodes}" +
                $"\n");
            output.Write(winnerColor + " " + winner.Item2 + " " + results.Item1 + "-" + results.Item2 + '\n');
        }
        Console.Write('\n');
        output.Write('\n');
    }
    output.Close();
}


 Tuple<int, int> TestHeuristic(Func<Game, TileColor, int> h1, Func<Game, TileColor, int> h2, int ply1 = 5, int ply2 = 5, bool prune = true, uint size = 8)
{
    int black = 0;
    int white = 0;
    GameManager manager = new(h1, ply1, prune, h2, ply2, prune, size);
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
            System.Console.WriteLine("AHHHHHH");
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
