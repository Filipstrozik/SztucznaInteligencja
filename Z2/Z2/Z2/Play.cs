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

        public Play(Board board, TileColor color, Tuple<int, int> coords)
        {
            //store given information
            this.Color = color;
            this.Coords = coords;

            TileColor playerColor = color;
            TileColor opponentColor = color == TileColor.BLACK ? TileColor.WHITE : TileColor.BLACK;

            int x = coords.Item1;
            int y = coords.Item2;

            var directionVectors = new[]
            {
                new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(0, -1),                              new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, -1),  new Tuple<int, int>(1, 0),  new Tuple<int, int>(1, 1)
            };


            // iterate over each direction vector
            foreach (var dir in directionVectors)
            {
                // a fixed-length array of all the tiles in this ray
                List<Tile> rayTiles = new List<Tile>();
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

        private void AddAffected(List<Tile> affected)
        {
            AffectedTiles ??= new List<Tile>();
            AffectedTiles.AddRange(affected);
        }
    }
}
