namespace Z2
{
    public class ReversiSolver
    {
        private Func<Game, int> heuristic;

        public int MaxDepth { private set; get; }

        public TileColor Color { private set; get; }

        public bool Prune { private set; get; }

        public ReversiSolver(TileColor color, Func<Game, TileColor, int> heuristic, int maxDepth, bool prune = true)
        {
            Color = color;
            SetHeuristic(heuristic);
            MaxDepth = maxDepth;
            Prune = prune;
        }

        public void SetHeuristic(Func<Game, TileColor, int> heuristic)
        {
            this.heuristic = (game) => heuristic(game, Color);
        }

        // Takes a game object and returns the best move given the heuristic for the current player
        public Tuple<Play, int> ChoosePlay(Game game, bool prune = true)
        {
            int time = Environment.TickCount;

            game = new Game(game);

            var returnedAlphaBeta = AlphaBeta(game, MaxDepth, Prune);
            Play bestPlay = returnedAlphaBeta.Item2;
            int countNodes = returnedAlphaBeta.Item3;
            // return the best play
            time = Environment.TickCount - time;
            // print the time it took to think
            return new Tuple<Play, int>(bestPlay, countNodes);
        }

        // Searches the game tree and returns the a pair of the best play for the current player and it's heuristic value
        private Tuple<int, Play, int> AlphaBeta(Game game, int currentDepth = 5, bool prune = true, bool max = true, int alpha = int.MinValue, int beta = int.MaxValue, int nodesVisited = 0)
        {
            //nie oceniaj możliwych zagrań, jeśli jesteś u podstawy drzewa wyszukiwania
            Dictionary<Tuple<int, int>, Play> possiblePlays = currentDepth != 0 ? game.PossiblePlays() : null;

            // W przypadku wyjścia: wynik nie ulega zmianie z powodu bycia zepchniętym na pozycję bez możliwości ruchu.
            // wyjście jeżeli: doszliśmy do ograniczenia głębokości || gra zakończona || brak możliwych ruchów
            if (currentDepth == 0 || game.GameOver() || possiblePlays.Count == 0)
            {
                // jezeli gracz jakiś wygrał
                if (game.GameOver() && game.Winner != null)
                {
                    return new Tuple<int, Play, int>(99999, null!, 1);
                }
                return new Tuple<int, Play, int>(heuristic(game), null!, 1);

            }
            // jeśli gracz jest czarny, to maksymalilzuj
            // w przeciwnym razie, to minimalizuj
            Func<int, int, int> Optimizer = max ? Math.Max : Math.Min;

            // jeżeli maksymalizujemy/czarny to zacznij od najmniejszego i szukaj maks
            // jeżeli minimalizujemy/bialy to zacznij od najwiekszego i szukaj min
            int bestScore = max ? int.MinValue : int.MaxValue;

            // Najwyższa wartość znaleziona do tej pory przez funkcję.
            // Ustaw najniższą możliwą wartość, aby każda wartość była wyższa.
            Play bestPlay = null;
            int nodesVisitedAtThisLevel = 0;
            // Dla każdej możliwej gry z zagrań Użyj Game.ForkGame(Play), aby wygenerować różne gałęzie
            foreach (KeyValuePair<Tuple<int, int>, Play> pair in game.PossiblePlays())
            {
                nodesVisitedAtThisLevel++;
                // Przyjmuje maksimum między gałęzią a bieżącą wartością minimalną
                var alphaBeta = AlphaBeta(game.ForkGame(pair.Value), currentDepth - 1, prune, !max, alpha, beta);

                int childScore = alphaBeta.Item1;
                int nodes = alphaBeta.Item3;
                //nodesVisitedAtThisLevel += nodes;
                nodesVisited += nodes;

                // Jeśli nowa wartość jest lepsza, zapisz ją i ruch, który ją daje
                if (bestScore != Optimizer(bestScore, childScore))
                {
                    bestPlay = pair.Value;
                    bestScore = childScore;
                }
                //Jeśli wartość zwrócona przez algorytm jest większa niż alfa, zaktualizuj
                //wartość alfa na wartość zwróconą.
                if (max)
                    alpha = Optimizer(alpha, bestScore);
                //Jeśli wartość zwrócona przez algorytm jest mniejsza niż beta, zaktualizuj
                //wartość beta na wartość zwróconą.
                else
                    beta = Optimizer(beta, bestScore);
                // jeśli wartość beta jest mniejsza lub równa alfa, przerwij przeglądanie potomków i zwróć wartość alfa.
                if (prune && (beta <= alpha))
                    break;
            }
            return new Tuple<int, Play, int>(bestScore, bestPlay, nodesVisited);

        }

        #region heuristics

        // Calculates the heuristic value based on the difference of black tiles and white tiles
        public static int RandomHeuristic(Game game, TileColor color)
        {
            Random rand = new();
            int randomValue = rand.Next(100); // generates a random integer value between 0 and 100
            return randomValue;

        }

        // Calculates the heuristic value based on the difference of black tiles and white tiles
        public static int TileCountHeuristic(Game game, TileColor color)
        {
            int black = game.Board.GetNumColor(TileColor.BLACK);
            int white = game.Board.GetNumColor(TileColor.WHITE);

            if (black + white == 0)
            {
                return 0;
            }

            if (color == TileColor.BLACK)
            {
                return 100 * (black - white) / (black + white);
            }
            else if (color == TileColor.WHITE)
            {
                return 100 * (white - black) / (black + white);
            }

            return 0;
        }


        // Calculates a heuristic based on how many moves a player has relative to how many moves the opponent has
        public static int ActualMobilityHeuristic(Game game, TileColor color)
        {
            TileColor currentPlayer = game.IsFirstPlayer ? TileColor.BLACK : TileColor.WHITE;
            TileColor maxPlayer = color;
            TileColor minPlayer = color == TileColor.BLACK ? TileColor.WHITE : TileColor.BLACK;

            int maxMobility;
            int minMobility;

            // Sets the max and min mobilities
            if (currentPlayer == maxPlayer)
            {
                maxMobility = game.PossiblePlays().Count;
                minMobility = game.PossiblePlays(true).Count;
            }
            else
            {
                maxMobility = game.PossiblePlays(true).Count;
                minMobility = game.PossiblePlays().Count;
            }

            // Return the normalized difference between the mobilities
            if ((maxMobility + minMobility) > 0)
            {
                return 100 * (maxMobility - minMobility) / (maxMobility + minMobility);
            }
            else
            {
                return 0;
            }

        }

        // Calculates a score based on how many more corners one player has than the other

        public static int CornersHeuristic(Game game, TileColor color)
        {
            TileColor currentPlayer = game.IsFirstPlayer ? TileColor.BLACK : TileColor.WHITE;

            List<Tuple<int, int>> corners = new()
            {
                Tuple.Create(0, 0),
                Tuple.Create((int) game.Board.Size - 1, 0),
                Tuple.Create(0, (int) game.Board.Size - 1),
                Tuple.Create((int) game.Board.Size - 1, (int) game.Board.Size - 1)
            };

            int maxScore = 0, minScore = 0;
            foreach (Tuple<int, int> corner in corners)
            {
                if (game.Board[corner.Item1, corner.Item2] != null)
                {
                    if (game.Board[corner.Item1, corner.Item2].color == color)
                    {
                        maxScore++;
                    }
                    else if (game.Board[corner.Item1, corner.Item2].color != TileColor.BLANK)
                    {
                        minScore++;
                    }
                }
            }
            int score = 0;
            if (maxScore + minScore > 0) score = (100 * (maxScore - minScore)) / (minScore + maxScore);
            return score;
        }

        // Calculates the score of a board based on a set of pre-defined weights of each tile
        public static int WeightedHeuristic(Game game, TileColor color)
        {
            if (game.Size() != 8)
            {
                throw new ArgumentException("The game board must be size 8x8 for the weighted heuristic");
            }

            int[,] weights = new int[(int)game.Size(), (int)game.Size()];
            int score = 0;

            #region weights
            weights[0, 0] = 4;
            weights[0, 1] = -3;
            weights[0, 2] = 2;
            weights[0, 3] = 2;

            weights[1, 0] = -3;
            weights[1, 1] = -4;
            weights[1, 2] = -1;
            weights[1, 3] = -1;

            weights[2, 0] = 2;
            weights[2, 1] = -1;
            weights[2, 2] = 1;
            weights[2, 3] = 0;

            weights[3, 0] = 2;
            weights[3, 1] = -1;
            weights[3, 2] = 0;
            weights[3, 3] = 1;

            // weights
            // 4  -3  2  2
            // -3 -4 -1 -1
            // 2  -1  1  0
            // 2  -1  0  1
            #endregion


            for (int i = 0; i < game.Size(); i++)
            {
                for (int j = 0; j < game.Size(); j++)
                {
                    // Mirrors the weights to all 4 corners

                    int im = i < 4 ? i : 3 - i % 4;
                    int jm = j < 4 ? j : 3 - j % 4;

                    if (game.Board[i, j] != null)
                    {
                        if (game.Board[i, j].color == color)
                        {
                            score += weights[im, jm];
                        }
                        else if (game.Board[i, j].color != TileColor.BLANK)
                        {
                            score -= weights[im, jm];
                        }
                    }
                }
            }
            return score;
        }


        #endregion
    }
}
