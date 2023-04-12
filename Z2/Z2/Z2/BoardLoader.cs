using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    internal class BoardLoader
    {
        public int[,] Load()
        {
            int[,] board = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                string inputLine = Console.ReadLine();
                string[] inputArray = inputLine.Split(' ');

                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = int.Parse(inputArray[j]);
                }
            }
            return board;
        }
    }
}
