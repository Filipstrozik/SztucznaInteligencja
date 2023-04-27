using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    public enum TileColor
    {
        WHITE = 0,
        BLACK = 1,
        BLANK = 2
    }

    [Serializable]
    public class Tile
    {
        //If the tile is white, flip it to black and vice versa 
        //If the tile is blank, do nothing. 
        public TileColor Flip()
        {
            color = (color == TileColor.WHITE) ? TileColor.BLACK : TileColor.WHITE;
            return color;
        }       
        
/*        public TileColor Flip()
        {
            if (color == TileColor.WHITE)
            {
                color = TileColor.BLACK;
            }
            else
            {
                color = TileColor.WHITE;
            }
            return color;
        }*/

        // place a tile in an x,y coordinate.  
        public Tuple<int, int> Place(int x, int y)
        {
            //tiles cannot be placed twice.
            if (placed) throw new InvalidOperationException("Tile already placed!");
            //store the final position for the tile 
            Coords = Tuple.Create(x, y);
            placed = true;
            return Coords;
        }

        [JsonConstructor]
        public Tile(Tile tile)
        {
            color = tile.color;
            Coords = tile.Coords;
            placed = tile.placed;
        }

        public Tile(TileColor color)
        {
            this.color = color;
            Coords = Tuple.Create(-1, -1);
        }


        public TileColor color { get; private set; }
        private bool placed = false;
        public Tuple<int, int> Coords { private set; get; }
    }
}
