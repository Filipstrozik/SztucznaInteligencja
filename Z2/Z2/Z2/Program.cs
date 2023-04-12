// See https://aka.ms/new-console-template for more information
using Z2;

Console.WriteLine("Paste Input:");
BoardLoader loader = new BoardLoader();
int[,] boardState = loader.Load();

// wyświetlenie stanu planszy

// stworzenie drzewa gry na podstawie wczytanego stanu planszy
GameTree gameTree = new GameTree(boardState, 0);

// dalsze operacje na drzewie gry
// ...