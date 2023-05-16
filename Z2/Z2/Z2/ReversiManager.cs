using Newtonsoft.Json;

namespace Z2
{
    public class ReversiManager
    {
        public Game game;
        public ReversiSolver[] Agents = new ReversiSolver[2];
        public Play[] humanPlay = new Play[2];
        public int play;
        public int visitedNodes = 0;


        //construct manager for computer vs computer play
        public ReversiManager(Func<Game, TileColor, int> blackHeuritic, int blackDepth, bool prune1, Func<Game, TileColor, int> whiteHeuristic, int whiteDepth, bool prune2, uint size = 8)
        {
            game = new Game(size);
            Agents[0] = new ReversiSolver(TileColor.BLACK, blackHeuritic, blackDepth, prune1);
            Agents[1] = new ReversiSolver(TileColor.WHITE, whiteHeuristic, whiteDepth, prune2);
            play = 0;
        }

        //c onstruct manager for human vs computer play
        public ReversiManager(Func<Game, TileColor, int> heuristic, int ply, TileColor color, bool prune, uint size = 8)
        {
            game = new Game(size);
            int index = color == TileColor.BLACK ? 0 : 1;
            Agents[index] = new ReversiSolver(color, heuristic, ply, prune);
            play = 0;
        }

        // create game manager for human vs human play
        public ReversiManager(uint size = 8)
        {
            game = new Game(size);
            play = 0;
        }
        // json constructor for loading game state (WIP)
        [JsonConstructor]
        public ReversiManager()
        {

        }

        public void LoadGameState(string filepath)
        {

            string json = File.ReadAllText(filepath);
            ReversiManager loaded = JsonConvert.DeserializeObject<ReversiManager>(json);
            Agents = loaded.Agents;
            game = loaded.game;
            humanPlay = loaded.humanPlay;
            play = loaded.play;
        }

        public void SaveGameState(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            SaveJsonToFile(json, filePath);
        }

        public static void SaveJsonToFile(string json, string filePath)
        {
            using StreamWriter writer = new(filePath);
            writer.Write(json);
        }



        // play on behalf of a human
        // play must be valid given the current state of the board 
        public Play OutsidePlay(Play p)
        {
            if (p == null) return null;
            int index = p.Color == TileColor.BLACK ? 0 : 1;
            ReversiSolver agent = Agents[index];

            //if you try to play on behalf of an AI
            if (agent != null)
            {
                Console.WriteLine("Tried to play as AI");
                return null;
            }


            // if the player is the right color 
            // unsafe, since the human player could play on the AI's behalf
            if (game.IsFirstPlayer && p.Color != TileColor.BLACK
                || !game.IsFirstPlayer && p.Color != TileColor.WHITE)
            {
                throw new ArgumentException("Not your turn!");
            }

            humanPlay[index] = p;
            return p;
        }

        public Game GetGame()
        {
            return new Game(game);
        }

        public Game Next(bool prune)
        {
            int index = game.IsFirstPlayer ? 0 : 1;

            play++;
            ReversiSolver agent = Agents[index];

            // human player
            if (agent == null)
            {
                if (humanPlay[index] == null) return null!;
                game.UsePlay(humanPlay[index]);
                // new play should remove all other queued plays
                humanPlay[0] = null!;
                humanPlay[1] = null!;
            }
            else
            {
                var chosenResult = agent.ChoosePlay(game, prune);
                visitedNodes = chosenResult.Item2;
                if (chosenResult.Item1 is Play p)
                {
                    game.UsePlay(p);
                }
                else
                {
                    // This should never happen...
                    throw new ArgumentException();

                }
            }
            return GetGame();
        }

        public void Reset()
        {
            game = new Game(game.Size());
        }

    }
}
