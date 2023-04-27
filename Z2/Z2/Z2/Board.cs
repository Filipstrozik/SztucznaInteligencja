using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    [Serializable]
    public class Board
    {
        public Tile[,] board;
        public uint Size { get;  set; }
        
        [JsonConstructor]
        public Board()
        {

        }

        public Board(uint size)
        {
            board = new Tile[size, size];
            Size = size;
        }

        public Board(Board prevBoard)
        {
            Size = prevBoard.Size;
            board = DeepClone(prevBoard).board;

        }


        private static Board DeepClone(Board obj)
        {
            Board clone = (Board)obj.MemberwiseClone();
            // deep clone the board array
            clone.board = new Tile[obj.Size, obj.Size];
            for (uint row = 0; row < obj.Size; row++)
            {
                for (uint col = 0; col < obj.Size; col++)
                {
                    if (obj.board[row, col] != null)
                    {
                        clone.board[row, col] = new Tile(obj.board[row, col]);
                    }
                }
            }
            return clone;
        }

        //place put a color tile on the board
        public Tile Place(int x, int y, TileColor color)
        {
            //if a tile already exists here, don't place anything
            if (board[x, y] != null)
            {
                return null;
            }
            //create a new tile of the correct color
            Tile placement = new Tile(color);
            //store coordinates in the Tile object, and store the object reference in the board.
            placement.Place(x, y);
            board[x, y] = placement;
            return placement;
        }

        //check if the board has any empty cells
        public bool BoardFull()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (board[x, y] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //access board through [x,y] accessors
        public Tile this[int x, int y]
        {
            get { return board[x, y]; }
        }

        //for each cell in the board, add to a list if
        //  a) it is empty and b) it has at least one adjacent placed tile
        public List<Tuple<int, int>> OpenAdjacentSpots()
        {
            List<Tuple<int, int>> openAdjacent = new List<Tuple<int, int>>();
            //for each cell in the board
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    //both empty and adjacent to a tile
                    if (board[x, y] == null && AdjacentToTile(x, y))
                    {
                        openAdjacent.Add(Tuple.Create(x, y));
                    }
                }
            }
            return openAdjacent;
        }

        //check to see if the cell at x,y is adjacent to any placed tiles
        private bool AdjacentToTile(int x, int y)
        {
            /*
             *  x x x x x
             *  x c c c x 
             *  x c O c x
             *  x c c c x 
             *  x x x x x
             *  
             *  Where x,y is the position of O, 
             *     check each cell c to see if a tile is placed anywhere adjacent
             *  x-1 is right before the position, x+1 is right after. Likewise for y.
             *  
             *  Min and Max so we don't have indexing errors.
             */
            for (int ix = Math.Max(0, x - 1); ix <= x + 1 && ix < Size; ix++)
            {
                for (int iy = Math.Max(0, y - 1); iy <= y + 1 && iy < Size; iy++)
                {
                    if (board[ix, iy] != null) return true;
                }

            }
            return false;
        }


        /// Returns the number of tiles with the given color
        public int GetNumColor(TileColor color)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (board[i, j] != null && board[i, j].color == color)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
