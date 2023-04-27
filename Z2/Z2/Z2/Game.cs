﻿using Newtonsoft.Json;
namespace Z2
{
    [Serializable]
    public class Game
    {
        //FirstPlayer plays black.
        //when true, the active player is player1.
        public bool IsFirstPlayer { set; get; }
        public Board Board { set; get; }
        public bool deadlock = false;
        public TileColor? Winner
        {
            get
            {
                if (GameOver())
                { 
                    if (Board.GetNumColor(TileColor.BLACK) > Board.GetNumColor(TileColor.WHITE))
                    {
                        return TileColor.BLACK;
                    }
                    else if (Board.GetNumColor(TileColor.WHITE) > Board.GetNumColor(TileColor.BLACK))
                    {
                        return TileColor.WHITE;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (deadlock)
                {
                    return TileColor.BLANK;
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonConstructor]
        public Game()
        {

        }

        public Game(uint size)
        {
            Board = new Board(size);
            IsFirstPlayer = true;

            //place first four tiles

            int x = ((int)size - 1) / 2;
            int y = ((int)size - 1) / 2;

            Place(x, y++);
            Place(x++, y);
            Place(x, y--);
            Place(x, y);
        }

        public Game(Game prevGame)
        {
            Board = new Board(prevGame.Board);
            IsFirstPlayer = prevGame.IsFirstPlayer;
            deadlock = prevGame.deadlock;
        }

        //place a tile at a position
        // the color of the tile is determined by whose turn it is
        private Tile Place(int x, int y)
        {
            Tile placement = Board.Place(x, y, IsFirstPlayer ? TileColor.BLACK : TileColor.WHITE);
            if (placement != null)
            {
                NextTurn();
            }
            return placement;
        }

        private void NextTurn()
        {
            IsFirstPlayer = !IsFirstPlayer;
        }

        //play a play at a given position
        public void UsePlay(Play p)
        {
            Place(p.Coords.Item1, p.Coords.Item2);
            foreach (Tile tile in p.AffectedTiles)
            {
                //check this shit
                //Console.WriteLine(tile.Coords.Item1);
                //Console.WriteLine(tile.Coords.Item2);
                Board[tile.Coords.Item1, tile.Coords.Item2].Flip();
            }
            int i = 0;
            // Handle case where next player has no moves
            // so player passes a turn
            while (i <= 2 && PossiblePlays().Count == 0)
            {
                i++;
                NextTurn();
            }
            if (i >= 2)
                deadlock = true;
        }


        /// Returns a new game advanced by the single move play

        public Game ForkGame(Play play)
        {
            Game g = new(this);
            g.UsePlay(play);
            return g;
        }

        public TileColor ColorAt(int x, int y)
        {
            if (Board[x, y] == null) return TileColor.BLANK;
            return Board[x, y].color;
        }


        // find all possible plays given the current game state 
        // this takes into consideration whose turn it is
        public Dictionary<Tuple<int, int>, Play> PossiblePlays(bool otherPlayer = false)
        {
            //for all open spots on the board that are adjacent to any tiles
            List<Tuple<int, int>> possiblePositions = Board.OpenAdjacentSpots();
            Dictionary<Tuple<int, int>, Play> results = new Dictionary<Tuple<int, int>, Play>();

            TileColor playerColor = IsFirstPlayer ? TileColor.BLACK : TileColor.WHITE;

            // If calcualting potential moves for the other player switch the color
            if (otherPlayer)
            {
                playerColor = IsFirstPlayer ? TileColor.WHITE : TileColor.BLACK; ;
            }

            foreach (Tuple<int, int> coord in possiblePositions)
            {

                Play possiblePlay = new Play(Board, playerColor, coord);

                if (possiblePlay.AffectedTiles != null)
                {
                    results.Add(coord, possiblePlay);
                }
            }
            return results;
        }


        //right now, our only game over condition is a full board or the game is in deadlock.
        public bool GameOver()
        {
            return deadlock || Board.BoardFull();
        }

        public uint Size()
        {
            return Board.Size;
        }


    }
}
