using Z2;

namespace UI
{
    public partial class BoardUI : Form
    {

        enum GameMode
        {
            Human,
            Tile,
            Mobility,
            Corners,
            Weighted,
            Random
        }

        GameManager manager;
        Game game;
        private GameMode whiteMode = GameMode.Human;
        private GameMode blackMode = GameMode.Human;
        private int whitePlyVal = 5;
        private bool whitePrune = true;
        private int blackPlyVal = 5;
        private bool blackPrune = true;
        private DataGridView gameBoard;
        private const int BOARD_SIZE = 8;
        private Bitmap blank;
        private Bitmap black;
        private Bitmap white;
        private Bitmap hint;
        private int bitmapPadding = 6;

        private bool automaticPlay = false;

        Dictionary<Tuple<int, int>, Play> playable;


        public BoardUI()
        {
            //TODO: Files loaded badly.  Must be in /bin already
            // place the images in the bin folder

            blank = (Bitmap)Image.FromFile("./green.bmp");
            black = (Bitmap)Image.FromFile("./black.bmp");
            white = (Bitmap)Image.FromFile("./white.bmp");
            hint = (Bitmap)Image.FromFile("./hint.bmp");

            manager = new GameManager(BOARD_SIZE);
            game = manager.GetGame();

            InitializeComponent();

            //add the data grid that has all the images 
            gameBoard = new DataGridView
            {
                BackColor = SystemColors.ButtonShadow,
                ForeColor = SystemColors.ControlText,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Size = new Size(855, 582),
                AutoSize = false,
                Name = "gameBoard",
            };

            gameBoard.AllowUserToAddRows = false;

            //mostly from online 
            ConfigureForm();
            SizeGrid();
            CreateColumns();
            CreateRows();


            playable = game.PossiblePlays();

            UpdateBoard();
        }

        private void ConfigureForm()
        {
            AutoSize = true;

            gameBoard.AllowUserToAddRows = false;
            gameBoard.CellClick += new
                DataGridViewCellEventHandler(ClickCell);
            gameBoard.SelectionChanged += new
                EventHandler(Change_Selection);

            GamePanel.Controls.Add(gameBoard);
        }

        private void SizeGrid()
        {
            gameBoard.ColumnHeadersVisible = false;
            gameBoard.RowHeadersVisible = false;
            gameBoard.AllowUserToResizeColumns = false; ;
            gameBoard.AllowUserToResizeRows = false;
            gameBoard.BorderStyle = BorderStyle.None;

            //Add twice the padding for the top of the cell 
            //and the bottom.
            gameBoard.RowTemplate.Height = blank.Height +
                2 * bitmapPadding + 1;

            gameBoard.AutoSize = true;
        }

        private void CreateColumns()
        {
            DataGridViewImageColumn imageColumn;
            int columnCount = 0;
            do
            {
                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();

                //Add twice the padding for the left and 
                //right sides of the cell.
                imageColumn.Width = blank.Width + 2 * bitmapPadding + 1;

                imageColumn.Image = unMarked;
                gameBoard.Columns.Add(imageColumn);
                columnCount++;
            }
            while (columnCount < game.Size());
        }


        private void CreateRows()
        {
            for (int i = 0; i < game.Size(); i++)
            {
                gameBoard.Rows.Add();
            }
        }

        private void Change_Selection(object sender, EventArgs e)
        {
            this.gameBoard.ClearSelection();
        }

        //whenever we click on a cell
        private void ClickCell(object sender, DataGridViewCellEventArgs e)
        {
            Tuple<int, int> destCoords = Tuple.Create(e.ColumnIndex, e.RowIndex);

            //if there exists a valid play at this coordinate, get object
            playable.TryGetValue(destCoords, out Play p);
            Play humanPlay = manager.OutsidePlay(p);
            if (humanPlay == null) return;
            Game next = manager.Next(blackPrune);
            if (next != null)
            {
                game = next;
            }
            else
            {
                throw new ArgumentException("No human player/other game manager error");
            }
            playable = game.PossiblePlays();
            UpdateBoard();
            if (this.automaticPlay)
            {
                this.NextMove(sender, e);
            }
        }

        //set gameboard view to represent the game's board state
        private void UpdateBoard()
        {
            for (int x = 0; x < game.Size(); x++)
            {
                for (int y = 0; y < game.Size(); y++)
                {
                    DataGridViewImageCell cell = (DataGridViewImageCell)gameBoard.Rows[y].Cells[x];
                    switch (game.ColorAt(x, y))
                    {
                        case TileColor.BLACK:
                            cell.Value = black;
                            break;
                        case TileColor.WHITE:
                            cell.Value = white;
                            break;
                        default:
                            //if a place is playable, show as a hint
                            if (playable != null && playable.ContainsKey(Tuple.Create(x, y)))
                            {
                                cell.Value = hint;
                            }
                            else
                            {
                                cell.Value = blank;
                            }
                            break;
                    }
                }
            }

            // Print out heuristic values for the current board for debugging
            string player = game.IsFirstPlayer ? "Black" : "White";
            TileColor playerColor = game.IsFirstPlayer ? TileColor.BLACK : TileColor.WHITE;

            // Count Heuristic
            //System.Console.WriteLine("The tile counting heuristic returns: " + ReversiSolver.TileCountHeuristic(game, playerColor) + " for " + player);
            // Corners Heuristic
            //System.Console.WriteLine("The corners heuristic returns: " + ReversiSolver.CornersHeuristic(game, playerColor) + " for " + player);
            // Weighted Heuristic
            //System.Console.WriteLine("The weighted heuristic returns: " + ReversiSolver.WeightedHeuristic(game, playerColor) + " for " + player);
            // Mobility Heuristic
            //System.Console.WriteLine("The mobility heuristic returns: " + ReversiSolver.ActualMobilityHeuristic(game, playerColor) + " for " + player);
            // Random Heuristic
            //System.Console.WriteLine("The random heuristic returns: " + ReversiSolver.RandomHeuristic(game, playerColor) + " for " + player);
        }

        private void ChangeGameMode(object sender, EventArgs e)
        {
            RadioButton c = (RadioButton)sender;
            if (!c.Checked) return;
            switch (c.Tag)
            {
                case "cornersWhite":
                    whiteMode = GameMode.Corners;
                    break;
                case "cornersBlack":
                    blackMode = GameMode.Corners;
                    break;
                case "humanWhite":
                    whiteMode = GameMode.Human;
                    break;
                case "humanBlack":
                    blackMode = GameMode.Human;
                    break;
                case "weightedWhite":
                    whiteMode = GameMode.Weighted;
                    break;
                case "weightedBlack":
                    blackMode = GameMode.Weighted;
                    break;
                case "tileWhite":
                    whiteMode = GameMode.Tile;
                    break;
                case "tileBlack":
                    blackMode = GameMode.Tile;
                    break;
                case "randomWhite":
                    whiteMode = GameMode.Random;
                    break;
                case "randomBlack":
                    blackMode = GameMode.Random;
                    break;
            }
            SetNewGame();
        }

        private void SetNewGame()
        {
            Func<Game, TileColor, int> whiteHeuristic = null;
            Func<Game, TileColor, int> blackHeuristic = null;
            switch (whiteMode)
            {
                case GameMode.Corners:
                    whiteHeuristic = ReversiSolver.CornersHeuristic;
                    break;
                case GameMode.Tile:
                    whiteHeuristic = ReversiSolver.TileCountHeuristic;
                    break;
                case GameMode.Weighted:
                    whiteHeuristic = ReversiSolver.WeightedHeuristic;
                    break;
                case GameMode.Mobility:
                    whiteHeuristic = ReversiSolver.ActualMobilityHeuristic;
                    break;
                case GameMode.Random:
                    whiteHeuristic = ReversiSolver.RandomHeuristic;
                    break;
            }

            switch (blackMode)
            {
                case GameMode.Corners:
                    blackHeuristic = ReversiSolver.CornersHeuristic;
                    break;
                case GameMode.Tile:
                    blackHeuristic = ReversiSolver.TileCountHeuristic;
                    break;
                case GameMode.Weighted:
                    blackHeuristic = ReversiSolver.WeightedHeuristic;
                    break;
                case GameMode.Mobility:
                    blackHeuristic = ReversiSolver.ActualMobilityHeuristic;
                    break;
                case GameMode.Random:
                    blackHeuristic = ReversiSolver.RandomHeuristic;
                    break;
            }

            if (whiteMode == GameMode.Human && blackMode == GameMode.Human)
            {
                manager = new GameManager();
            }
            else if (whiteMode == GameMode.Human)
            {
                manager = new GameManager(blackHeuristic, blackPlyVal, TileColor.BLACK, blackPrune);
            }
            else if (blackMode == GameMode.Human)
            {
                manager = new GameManager(whiteHeuristic, whitePlyVal, TileColor.WHITE, whitePrune);
            }
            else
            {
                manager = new GameManager(blackHeuristic, blackPlyVal, blackPrune, whiteHeuristic, whitePlyVal, whitePrune);
            }

            manager.Reset();
            game = manager.GetGame();
            playable = game.PossiblePlays();
            UpdateBoard();
        }

        private void NextMove(object sender, EventArgs e)
        {
            if (game.Winner != null)
            {
                Console.WriteLine(game.Winner);
                lblFullBoard.Text = $"Winner is: {game.Winner}";
                MessageBox.Show(lblFullBoard.Text, game.Winner.ToString());
                return;
            }
            Game next = manager.Next(blackPrune);
            if (next != null) game = next;
            playable = game.PossiblePlays();
            UpdateBoard();
        }

        private void Reset(object sender, EventArgs e)
        {
            manager.Reset();
            game = manager.GetGame();
            playable = game.PossiblePlays();
            UpdateBoard();
        }

        private void SetPly(object sender, EventArgs e)
        {
            NumericUpDown c = (NumericUpDown)sender;
            switch (c.Tag)
            {
                case "white":
                    whitePlyVal = Convert.ToInt32(c.Value);
                    break;
                case "black":
                    blackPlyVal = Convert.ToInt32(c.Value);
                    break;
            }
            SetNewGame();
        }

        private void SetAutomaticPlay(object sender, EventArgs e)
        {
            automaticPlay = true;
        }

        private void UnSetAutomaticPlay(object sender, EventArgs e)
        {
            automaticPlay = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                while (game.Winner == null)
                {
                    NextMove(sender, e);
                }
                Console.WriteLine(game.Winner);
                Console.WriteLine($"WHITE: {game.Board.GetNumColor(TileColor.WHITE)} \n BLACK: {game.Board.GetNumColor(TileColor.BLACK)}");
                lblFullBoard.Text = $"Winner is: {game.Winner}\nWHITE: {game.Board.GetNumColor(TileColor.WHITE)}\nBLACK: {game.Board.GetNumColor(TileColor.BLACK)}";
                // Create a new popup dialog box to display the label control
                MessageBox.Show(lblFullBoard.Text, game.Winner.ToString());
                return;
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Call your custom save method with the selected file path
                string filePath = saveFileDialog.FileName;
                manager.SaveGameState(filePath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Call your custom save method with the selected file path
                manager.Reset();
                game = manager.GetGame();
                string filePath = openFileDialog.FileName;
                manager.LoadGameState(filePath);
                game = manager.GetGame();
                playable = game.PossiblePlays();
                UpdateBoard();
            }
        }

        private void SetPrune(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            whitePrune = c.Checked;
            blackPrune = c.Checked;
        }
    }
}