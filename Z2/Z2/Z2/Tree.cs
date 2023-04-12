using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    public class Node
    {
        public int Value { get; set; } // wartość wierzchołka
        public int[,] BoardState { get; set; } // stan planszy
        public List<Node> Children { get; set; } // lista dzieci (możliwe ruchy)

        public Node(int[,] boardState, int value)
        {
            BoardState = boardState;
            Value = value;
            Children = new List<Node>();
        }

        // funkcja do dodawania dziecka do wierzchołka
        public void AddChild(Node child)
        {
            Children.Add(child);
        }
    }

    public class GameTree
    {
        public Node Root { get; set; }

        public GameTree(int[,] boardState, int value)
        {
            Root = new Node(boardState, value);
            CreateTree(Root, 2, 0);
        }

        // funkcja do tworzenia drzewa
        private void CreateTree(Node node, int player, int depth)
        {
            if (depth >= 3) return; // wyjście z rekurencji, gdy osiągnięto poziom 3

            // pobranie możliwych ruchów z aktualnego stanu planszy
            List<int[,]> possibleMoves = GetPossibleMoves(node.BoardState, player);

            // utworzenie wierzchołków-dzieci dla każdego możliwego ruchu trzeba ograniczyc
            foreach (int[,] move in possibleMoves)
            {
                PrintBoardState(move);
                int value = CalculateBoardValue(move, player);
                Console.WriteLine(value);
                //Node child = new(move, value); // nadać wartość min/max stanu gry
                //node.AddChild(child);
                //CreateTree(child, 3 - player, depth + 1); // rekurencyjne tworzenie drzewa dla każdego dziecka
            }
        }


        // funkcja zwracająca listę możliwych ruchów z danego stanu planszy
        private List<int[,]> GetPossibleMoves(int[,] boardState, int player)
        {
            int opponent = 3 - player; // kolor przeciwnika
            List<int[,]> possibleMoves = new List<int[,]>();

            // iteracja po wszystkich polach planszy
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // sprawdzenie, czy pole jest puste
                    if (boardState[i, j] == 0)
                    {
                        // sprawdzenie, czy ruch jest możliwy
                        int[,] newState = CheckMove(boardState, i, j, player, opponent);
                        if (newState != null)
                        {
                            possibleMoves.Add(newState);
                        }
                    }
                }
            }

            return possibleMoves;
        }

        // funkcja sprawdzająca, czy dany ruch jest możliwy
        //private int[,] CheckMove(int[,] boardState, int row, int col, int player, int opponent)
        //{
        //    int[,] newState = (int[,])boardState.Clone();

        //    bool isValidMove = false;
        //    int countFlips = 0;

        //    // iteracja po wszystkich kierunkach
        //    for (int i = -1; i <= 1; i++)
        //    {
        //        for (int j = -1; j <= 1; j++)
        //        {
        //            if (i == 0 && j == 0) continue;

        //            int r = row + i;
        //            int c = col + j;

        //            // sprawdzenie, czy pierwsze pole w danym kierunku należy do przeciwnika
        //            if (r >= 0 && r < 8 && c >= 0 && c < 8 && boardState[r, c] == opponent)
        //            {
        //                r += i;
        //                c += j;

        //                // przeszukiwanie w danym kierunku aż do końca planszy lub znalezienia pola pustego lub pola gracza
        //                while (r >= 0 && r < 8 && c >= 0 && c < 8)
        //                {
        //                    //if (boardState[r, c] == player)
        //                    if (boardState[r, c] == player)
        //                    {
        //                        isValidMove = true;
        //                        break;
        //                    }
        //                    else if (boardState[r, c] == 0)
        //                    {
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        countFlips++;
        //                    }

        //                    r += i;
        //                    c += j;
        //                }

        //                if (isValidMove)
        //                {
        //                    // przeszukiwanie w danym kierunku w celu odwrócenia pionków przeciwnika
        //                    r = row + i;
        //                    c = col + j;

        //                    while (r >= 0 && r < 8 && c >= 0 && c < 8)
        //                    {
        //                        //if(r == 7 || c == 7)
        //                        //{
        //                        //    Console.WriteLine("ciekawe");
        //                        //}

        //                        if (boardState[r, c] == player)
        //                        {
        //                            break;
        //                        }

        //                        newState[r, c] = player;
        //                        countFlips--;

        //                        if (countFlips == 0)
        //                        {
        //                            break;
        //                        }

        //                        r += i;
        //                        c += j;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (isValidMove)
        //    {
        //        newState[row, col] = player;
        //        return newState;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        private int[,] CheckMove(int[,] boardState, int row, int col, int player, int opponent)
        {
            int[,] newState = (int[,])boardState.Clone();

            bool isValidMove = false;

            // iteracja po sąsiednich polach
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int r = row + i;
                    int c = col + j;

                    // sprawdzenie, czy pierwsze pole w danym kierunku należy do przeciwnika
                    if (r >= 0 && r < 8 && c >= 0 && c < 8 && boardState[r, c] == opponent)
                    {
                        int countFlips = 0;

                        r += i;
                        c += j;

                        // przeszukiwanie w danym kierunku aż do znalezienia pola pustego lub pola gracza
                        while (r >= 0 && r < 8 && c >= 0 && c < 8)
                        {
                            if (boardState[r, c] == player)
                            {
                                isValidMove = true;
                                break;
                            }
                            else if (boardState[r, c] == 0)
                            {
                                break;
                            }
                            else
                            {
                                countFlips++;
                            }

                            r += i;
                            c += j;
                        }

                        if (isValidMove)
                        {
                            // przeszukiwanie w danym kierunku w celu odwrócenia pionków przeciwnika
                            r = row + i;
                            c = col + j;

                            while (r >= 0 && r < 8 && c >= 0 && c < 8 && boardState[r, c] == opponent)
                            {
                                newState[r, c] = player;
                                countFlips--;

                                if (countFlips == 0)
                                {
                                    break;
                                }

                                r += i;
                                c += j;
                            }
                        }
                    }
                }
            }

            if (isValidMove)
            {
                newState[row, col] = player;
                return newState;
            }
            else
            {
                return null;
            }
        }


        private int CalculateBoardValue(int[,] board, int player)
        {
            int value = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == player) // dla gracza aktualnej wartości stanu planszy zwiększamy wartość o 1
                    {
                        value++;
                    }
                }
            }

            return value;
        }


        private static void PrintBoardState(int[,] boardState)
        {
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(boardState[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
