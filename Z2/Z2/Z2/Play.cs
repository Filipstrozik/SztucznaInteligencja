using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    public class Play
    {
        public TileColor Color { private set; get; }
        public Tuple<int, int> Coords { private set; get; }
        public List<Tile> AffectedTiles { private set; get; }


        public Play(TileColor color, Tuple<int, int> coords, List<Tile> affected)
        {
            this.Color = color;
            this.Coords = coords;
            this.AffectedTiles = affected;
        }

        /*public Play(Board board, TileColor color, Tuple<int, int> coords)
        {
            //store given information
            this.Color = color;
            this.Coords = coords;

            // -------------------------------------
            // calculate affected tiles 


            //takes play
            TileColor playerColor = color;
            TileColor opponentColor = color == TileColor.BLACK ? TileColor.WHITE : TileColor.BLACK;

            int x = coords.Item1;
            int y = coords.Item2;

            //generate "ray" to check in each direction
            //  if the first tile on the ray isn't an opponent's, stop persuing that ray
            for (double theta = 0.0f; theta < 2 * Math.PI; theta += (Math.PI / 4))
            {
                //a list of all the tiles in this ray
                // add to the affectTiles of the play is valid in this direction
                List<Tile> rayTiles = new List<Tile>();

                // Defines the ray to look along
                int dx = (int)Math.Round(Math.Cos(theta), MidpointRounding.AwayFromZero);
                int dy = (int)Math.Round(Math.Sin(theta), MidpointRounding.AwayFromZero);

                // Keeps track of the current position in the ray
                int ix = x + dx;
                int iy = y + dy;

                // while the ray is in bounds
                while (ix < board.Size && ix >= 0 && iy < board.Size && iy >= 0)
                {

                    // Break if an empty tile is found
                    if (board[ix, iy] == null)
                    {
                        break;
                    }

                    //only check the ray if it has an opponent tile as the start of the ray
                    if (ix == x + dx && iy == y + dy && board[ix, iy].color != opponentColor)
                    {
                        break;
                    }


                    // If a player tile is found after an opponent tile, (x,y) is a valid move
                    if (board[ix, iy].color == playerColor)
                    {
                        this.AddAffected(rayTiles);
                        break;
                    }

                    rayTiles.Add(board[ix, iy]);

                    ix += dx;
                    iy += dy;
                }
            }
        }*/

        public Play(Board board, TileColor color, Tuple<int, int> coords)
        {
            //store given information
            this.Color = color;
            this.Coords = coords;

            // -------------------------------------
            // calculate affected tiles 

            //takes play
            TileColor playerColor = color;
            TileColor opponentColor = color == TileColor.BLACK ? TileColor.WHITE : TileColor.BLACK;

            int x = coords.Item1;
            int y = coords.Item2;

            // generate pre-calculated array of direction vectors
            var directionVectors = new[] { new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(-1, 1),
                                   new Tuple<int, int>(0, -1),                         new Tuple<int, int>(0, 1),
                                   new Tuple<int, int>(1, -1),  new Tuple<int, int>(1, 0),  new Tuple<int, int>(1, 1) };


            // iterate over each direction vector
            foreach (var dir in directionVectors)
            {
                // a fixed-length array of all the tiles in this ray
                List<Tile> rayTiles = new List<Tile>();
                int counter = 0;
                // Keeps track of the current position in the ray
                int ix = x + dir.Item1;
                int iy = y + dir.Item2;

                // while the ray is in bounds
                while (ix >= 0 && ix < board.Size && iy >= 0 && iy < board.Size)
                {
                    var tile = board.board[ix, iy];

                    // Break if an empty tile is found
                    if (tile == null)
                        break;

                    //only check the ray if it has an opponent tile as the start of the ray
                    if (ix == x + dir.Item1 && iy == y + dir.Item2 && tile.color != opponentColor)
                        break;

                    // If a player tile is found after an opponent tile, (x,y) is a valid move
                    // If a player tile is found after an opponent tile, (x,y) is a valid move
                    if (board[ix, iy].color == playerColor)
                    {
                        this.AddAffected(rayTiles);
                        break;
                    }
                    // create another counter or index that will add new tile to array of rayTiles
                    rayTiles.Add(board[ix, iy]);
                    ix += dir.Item1;
                    iy += dir.Item2;
                }
            }
        }

        // change this method to use a fixed-length array
        private void AddAffected(List<Tile> affected)
        {
            if (AffectedTiles == null)
            {
                AffectedTiles = new List<Tile>();
            }
            AffectedTiles.AddRange(affected);
        }
    }
}
