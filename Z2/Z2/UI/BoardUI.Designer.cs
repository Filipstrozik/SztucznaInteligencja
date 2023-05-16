namespace UI
{
    partial class BoardUI
    {
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Button stopOrClear;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lblFullBoard;
        private System.Windows.Forms.Button NextMoveBtn;
        private System.Windows.Forms.GroupBox blackHeuristic;
        private System.Windows.Forms.RadioButton cornersBlack;
        private System.Windows.Forms.RadioButton mobilityBlack;
        private System.Windows.Forms.RadioButton tileBlack;
        private System.Windows.Forms.RadioButton randomBlack;
        private System.Windows.Forms.RadioButton humanBlack;
        private System.Windows.Forms.RadioButton weightedBlack;
        private System.Windows.Forms.GroupBox whiteHeuristic;
        private System.Windows.Forms.RadioButton humanWhite;
        private System.Windows.Forms.RadioButton weightedWhite;
        private System.Windows.Forms.RadioButton cornersWhite;
        private System.Windows.Forms.RadioButton mobilityWhite;
        private System.Windows.Forms.RadioButton tileWhite;
        private System.Windows.Forms.RadioButton randomWhite;
        private System.Windows.Forms.Label whiteDepthLabel;
        private System.Windows.Forms.NumericUpDown whiteDepth;
        private System.Windows.Forms.Label blackDepthLabel;
        private System.Windows.Forms.NumericUpDown blackDepth;
        private System.ComponentModel.IContainer components = null;

        //  Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            GamePanel = new Panel();
            OptionsPanel = new Panel();
            loadGameButton = new Button();
            saveGameButton = new Button();
            startAutomaticPlayButton = new Button();
            manualPlayRadioButton = new RadioButton();
            automaticPlayRadioButton = new RadioButton();
            creditsLabel = new Label();
            whiteDepthLabel = new Label();
            blackDepthLabel = new Label();
            blackDepth = new NumericUpDown();
            whiteDepth = new NumericUpDown();
            blackHeuristic = new GroupBox();
            humanBlack = new RadioButton();
            weightedBlack = new RadioButton();
            cornersBlack = new RadioButton();
            mobilityBlack = new RadioButton();
            tileBlack = new RadioButton();
            randomBlack = new RadioButton();
            whiteHeuristic = new GroupBox();
            humanWhite = new RadioButton();
            weightedWhite = new RadioButton();
            cornersWhite = new RadioButton();
            mobilityWhite = new RadioButton();
            tileWhite = new RadioButton();
            randomWhite = new RadioButton();
            NextMoveBtn = new Button();
            titleLabel = new Label();
            stopOrClear = new Button();
            pruneCheckbox = new CheckBox();
            lblFullBoard = new Label();
            OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blackDepth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)whiteDepth).BeginInit();
            blackHeuristic.SuspendLayout();
            whiteHeuristic.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.Location = new Point(50, 523);
            GamePanel.Margin = new Padding(7, 6, 7, 6);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(1239, 1367);
            GamePanel.TabIndex = 5;
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(loadGameButton);
            OptionsPanel.Controls.Add(saveGameButton);
            OptionsPanel.Controls.Add(startAutomaticPlayButton);
            OptionsPanel.Controls.Add(manualPlayRadioButton);
            OptionsPanel.Controls.Add(automaticPlayRadioButton);
            OptionsPanel.Controls.Add(creditsLabel);
            OptionsPanel.Controls.Add(whiteDepthLabel);
            OptionsPanel.Controls.Add(blackDepthLabel);
            OptionsPanel.Controls.Add(blackDepth);
            OptionsPanel.Controls.Add(whiteDepth);
            OptionsPanel.Controls.Add(blackHeuristic);
            OptionsPanel.Controls.Add(whiteHeuristic);
            OptionsPanel.Controls.Add(NextMoveBtn);
            OptionsPanel.Controls.Add(titleLabel);
            OptionsPanel.Controls.Add(stopOrClear);
            OptionsPanel.Controls.Add(pruneCheckbox);
            OptionsPanel.Location = new Point(202, 24);
            OptionsPanel.Margin = new Padding(7, 6, 7, 6);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(914, 498);
            OptionsPanel.TabIndex = 6;
            // 
            // loadGameButton
            // 
            loadGameButton.Location = new Point(449, 286);
            loadGameButton.Margin = new Padding(7, 6, 7, 6);
            loadGameButton.Name = "loadGameButton";
            loadGameButton.Size = new Size(137, 62);
            loadGameButton.TabIndex = 20;
            loadGameButton.Text = "Load";
            loadGameButton.UseVisualStyleBackColor = true;
            loadGameButton.Click += LoadButton_Click;
            // 
            // saveGameButton
            // 
            saveGameButton.Location = new Point(305, 286);
            saveGameButton.Margin = new Padding(7, 6, 7, 6);
            saveGameButton.Name = "saveGameButton";
            saveGameButton.Size = new Size(137, 62);
            saveGameButton.TabIndex = 19;
            saveGameButton.Text = "Save";
            saveGameButton.UseVisualStyleBackColor = true;
            saveGameButton.Click += SaveButton_Click;
            // 
            // startAutomaticPlayButton
            // 
            startAutomaticPlayButton.Location = new Point(315, 410);
            startAutomaticPlayButton.Margin = new Padding(7, 6, 7, 6);
            startAutomaticPlayButton.Name = "startAutomaticPlayButton";
            startAutomaticPlayButton.Size = new Size(281, 62);
            startAutomaticPlayButton.TabIndex = 18;
            startAutomaticPlayButton.Text = "Start Automatic Play";
            startAutomaticPlayButton.UseVisualStyleBackColor = true;
            startAutomaticPlayButton.Click += StartAutomaticPlayButton_Click;
            // 
            // manualPlayRadioButton
            // 
            manualPlayRadioButton.AutoSize = true;
            manualPlayRadioButton.Checked = true;
            manualPlayRadioButton.Location = new Point(353, 242);
            manualPlayRadioButton.Margin = new Padding(7, 6, 7, 6);
            manualPlayRadioButton.Name = "manualPlayRadioButton";
            manualPlayRadioButton.Size = new Size(152, 34);
            manualPlayRadioButton.TabIndex = 17;
            manualPlayRadioButton.TabStop = true;
            manualPlayRadioButton.Tag = "ManualPlay";
            manualPlayRadioButton.Text = "Manual Play";
            manualPlayRadioButton.UseVisualStyleBackColor = true;
            manualPlayRadioButton.Click += UnSetAutomaticPlay;
            // 
            // automaticPlayRadioButton
            // 
            automaticPlayRadioButton.AutoSize = true;
            automaticPlayRadioButton.Location = new Point(353, 198);
            automaticPlayRadioButton.Margin = new Padding(7, 6, 7, 6);
            automaticPlayRadioButton.Name = "automaticPlayRadioButton";
            automaticPlayRadioButton.Size = new Size(178, 34);
            automaticPlayRadioButton.TabIndex = 16;
            automaticPlayRadioButton.Tag = "AutoPlay";
            automaticPlayRadioButton.Text = "Automatic Play";
            automaticPlayRadioButton.UseVisualStyleBackColor = true;
            automaticPlayRadioButton.Click += SetAutomaticPlay;
            // 
            // creditsLabel
            // 
            creditsLabel.AutoSize = true;
            creditsLabel.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            creditsLabel.Location = new Point(338, 106);
            creditsLabel.Margin = new Padding(7, 0, 7, 0);
            creditsLabel.Name = "creditsLabel";
            creditsLabel.Size = new Size(203, 24);
            creditsLabel.TabIndex = 15;
            creditsLabel.Text = "Solution by Filip Strózik";
            // 
            // whiteDepthLabel
            // 
            whiteDepthLabel.AutoSize = true;
            whiteDepthLabel.Location = new Point(600, 358);
            whiteDepthLabel.Margin = new Padding(7, 0, 7, 0);
            whiteDepthLabel.Name = "whiteDepthLabel";
            whiteDepthLabel.Size = new Size(131, 30);
            whiteDepthLabel.TabIndex = 14;
            whiteDepthLabel.Text = "White Depth";
            // 
            // blackDepthLabel
            // 
            blackDepthLabel.AutoSize = true;
            blackDepthLabel.Location = new Point(33, 356);
            blackDepthLabel.Margin = new Padding(7, 0, 7, 0);
            blackDepthLabel.Name = "blackDepthLabel";
            blackDepthLabel.Size = new Size(124, 30);
            blackDepthLabel.TabIndex = 12;
            blackDepthLabel.Text = "Black Depth";
            // 
            // blackDepth
            // 
            blackDepth.Location = new Point(218, 352);
            blackDepth.Margin = new Padding(7, 6, 7, 6);
            blackDepth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            blackDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            blackDepth.Name = "blackDepth";
            blackDepth.Size = new Size(63, 35);
            blackDepth.TabIndex = 11;
            blackDepth.Tag = "black";
            blackDepth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            blackDepth.ValueChanged += SetDepth;
            // 
            // whiteDepth
            // 
            whiteDepth.Location = new Point(785, 352);
            whiteDepth.Margin = new Padding(7, 6, 7, 6);
            whiteDepth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            whiteDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            whiteDepth.Name = "whiteDepth";
            whiteDepth.Size = new Size(63, 35);
            whiteDepth.TabIndex = 13;
            whiteDepth.Tag = "white";
            whiteDepth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            whiteDepth.ValueChanged += SetDepth;
            // 
            // blackHeuristic
            // 
            blackHeuristic.Controls.Add(humanBlack);
            blackHeuristic.Controls.Add(weightedBlack);
            blackHeuristic.Controls.Add(cornersBlack);
            blackHeuristic.Controls.Add(mobilityBlack);
            blackHeuristic.Controls.Add(tileBlack);
            blackHeuristic.Controls.Add(randomBlack);
            blackHeuristic.Location = new Point(22, 14);
            blackHeuristic.Margin = new Padding(7, 6, 7, 6);
            blackHeuristic.Name = "blackHeuristic";
            blackHeuristic.Padding = new Padding(7, 6, 7, 6);
            blackHeuristic.Size = new Size(281, 336);
            blackHeuristic.TabIndex = 9;
            blackHeuristic.TabStop = false;
            blackHeuristic.Text = "Black Heuristic";
            // 
            // humanBlack
            // 
            humanBlack.AutoSize = true;
            humanBlack.Checked = true;
            humanBlack.Location = new Point(10, 284);
            humanBlack.Margin = new Padding(7, 6, 7, 6);
            humanBlack.Name = "humanBlack";
            humanBlack.Size = new Size(168, 34);
            humanBlack.TabIndex = 4;
            humanBlack.TabStop = true;
            humanBlack.Tag = "humanBlack";
            humanBlack.Text = "Human Player";
            humanBlack.UseVisualStyleBackColor = true;
            humanBlack.CheckedChanged += ChangeGameMode;
            // 
            // weightedBlack
            // 
            weightedBlack.AutoSize = true;
            weightedBlack.Location = new Point(12, 234);
            weightedBlack.Margin = new Padding(7, 6, 7, 6);
            weightedBlack.Name = "weightedBlack";
            weightedBlack.Size = new Size(174, 34);
            weightedBlack.TabIndex = 3;
            weightedBlack.Tag = "weightedBlack";
            weightedBlack.Text = "Weighted Tiles";
            weightedBlack.UseVisualStyleBackColor = true;
            weightedBlack.CheckedChanged += ChangeGameMode;
            // 
            // cornersBlack
            // 
            cornersBlack.AutoSize = true;
            cornersBlack.Location = new Point(10, 184);
            cornersBlack.Margin = new Padding(7, 6, 7, 6);
            cornersBlack.Name = "cornersBlack";
            cornersBlack.Size = new Size(109, 34);
            cornersBlack.TabIndex = 2;
            cornersBlack.Tag = "cornersBlack";
            cornersBlack.Text = "Corners";
            cornersBlack.UseVisualStyleBackColor = true;
            cornersBlack.CheckedChanged += ChangeGameMode;
            // 
            // mobilityBlack
            // 
            mobilityBlack.AutoSize = true;
            mobilityBlack.Location = new Point(10, 138);
            mobilityBlack.Margin = new Padding(7, 6, 7, 6);
            mobilityBlack.Name = "mobilityBlack";
            mobilityBlack.Size = new Size(178, 34);
            mobilityBlack.TabIndex = 1;
            mobilityBlack.Tag = "mobilityBlack";
            mobilityBlack.Text = "Actual Mobility";
            mobilityBlack.UseVisualStyleBackColor = true;
            mobilityBlack.CheckedChanged += ChangeGameMode;
            // 
            // tileBlack
            // 
            tileBlack.AutoSize = true;
            tileBlack.Location = new Point(10, 86);
            tileBlack.Margin = new Padding(7, 6, 7, 6);
            tileBlack.Name = "tileBlack";
            tileBlack.Size = new Size(132, 34);
            tileBlack.TabIndex = 0;
            tileBlack.Tag = "tileBlack";
            tileBlack.Text = "Tile Count";
            tileBlack.UseVisualStyleBackColor = true;
            tileBlack.CheckedChanged += ChangeGameMode;
            // 
            // randomBlack
            // 
            randomBlack.AutoSize = true;
            randomBlack.Location = new Point(10, 36);
            randomBlack.Margin = new Padding(7, 6, 7, 6);
            randomBlack.Name = "randomBlack";
            randomBlack.Size = new Size(116, 34);
            randomBlack.TabIndex = 0;
            randomBlack.Tag = "randomBlack";
            randomBlack.Text = "Random";
            randomBlack.UseVisualStyleBackColor = true;
            randomBlack.CheckedChanged += ChangeGameMode;
            // 
            // whiteHeuristic
            // 
            whiteHeuristic.Controls.Add(humanWhite);
            whiteHeuristic.Controls.Add(weightedWhite);
            whiteHeuristic.Controls.Add(cornersWhite);
            whiteHeuristic.Controls.Add(mobilityWhite);
            whiteHeuristic.Controls.Add(tileWhite);
            whiteHeuristic.Controls.Add(randomWhite);
            whiteHeuristic.Location = new Point(600, 6);
            whiteHeuristic.Margin = new Padding(7, 6, 7, 6);
            whiteHeuristic.Name = "whiteHeuristic";
            whiteHeuristic.Padding = new Padding(7, 6, 7, 6);
            whiteHeuristic.Size = new Size(281, 344);
            whiteHeuristic.TabIndex = 10;
            whiteHeuristic.TabStop = false;
            whiteHeuristic.Text = "White Heuristic";
            // 
            // humanWhite
            // 
            humanWhite.AutoSize = true;
            humanWhite.Checked = true;
            humanWhite.Location = new Point(17, 292);
            humanWhite.Margin = new Padding(7, 6, 7, 6);
            humanWhite.Name = "humanWhite";
            humanWhite.Size = new Size(168, 34);
            humanWhite.TabIndex = 4;
            humanWhite.TabStop = true;
            humanWhite.Tag = "humanWhite";
            humanWhite.Text = "Human Player";
            humanWhite.UseVisualStyleBackColor = true;
            humanWhite.CheckedChanged += ChangeGameMode;
            // 
            // weightedWhite
            // 
            weightedWhite.AutoSize = true;
            weightedWhite.Location = new Point(17, 246);
            weightedWhite.Margin = new Padding(7, 6, 7, 6);
            weightedWhite.Name = "weightedWhite";
            weightedWhite.Size = new Size(174, 34);
            weightedWhite.TabIndex = 3;
            weightedWhite.Tag = "weightedWhite";
            weightedWhite.Text = "Weighted Tiles";
            weightedWhite.UseVisualStyleBackColor = true;
            weightedWhite.CheckedChanged += ChangeGameMode;
            // 
            // cornersWhite
            // 
            cornersWhite.AutoSize = true;
            cornersWhite.Location = new Point(17, 196);
            cornersWhite.Margin = new Padding(7, 6, 7, 6);
            cornersWhite.Name = "cornersWhite";
            cornersWhite.Size = new Size(109, 34);
            cornersWhite.TabIndex = 2;
            cornersWhite.Tag = "cornersWhite";
            cornersWhite.Text = "Corners";
            cornersWhite.UseVisualStyleBackColor = true;
            cornersWhite.CheckedChanged += ChangeGameMode;
            // 
            // mobilityWhite
            // 
            mobilityWhite.AutoSize = true;
            mobilityWhite.Location = new Point(17, 146);
            mobilityWhite.Margin = new Padding(7, 6, 7, 6);
            mobilityWhite.Name = "mobilityWhite";
            mobilityWhite.Size = new Size(178, 34);
            mobilityWhite.TabIndex = 1;
            mobilityWhite.Tag = "mobilityWhite";
            mobilityWhite.Text = "Actual Mobility";
            mobilityWhite.UseVisualStyleBackColor = true;
            mobilityWhite.CheckedChanged += ChangeGameMode;
            // 
            // tileWhite
            // 
            tileWhite.AutoSize = true;
            tileWhite.Location = new Point(17, 94);
            tileWhite.Margin = new Padding(7, 6, 7, 6);
            tileWhite.Name = "tileWhite";
            tileWhite.Size = new Size(132, 34);
            tileWhite.TabIndex = 0;
            tileWhite.Tag = "tileWhite";
            tileWhite.Text = "Tile Count";
            tileWhite.UseVisualStyleBackColor = true;
            tileWhite.CheckedChanged += ChangeGameMode;
            // 
            // randomWhite
            // 
            randomWhite.AutoSize = true;
            randomWhite.Location = new Point(17, 44);
            randomWhite.Margin = new Padding(7, 6, 7, 6);
            randomWhite.Name = "randomWhite";
            randomWhite.Size = new Size(116, 34);
            randomWhite.TabIndex = 0;
            randomWhite.Tag = "randomWhite";
            randomWhite.Text = "Random";
            randomWhite.UseVisualStyleBackColor = true;
            randomWhite.CheckedChanged += ChangeGameMode;
            // 
            // NextMoveBtn
            // 
            NextMoveBtn.Location = new Point(598, 410);
            NextMoveBtn.Margin = new Padding(7, 6, 7, 6);
            NextMoveBtn.Name = "NextMoveBtn";
            NextMoveBtn.Size = new Size(281, 62);
            NextMoveBtn.TabIndex = 8;
            NextMoveBtn.Text = "Next";
            NextMoveBtn.UseVisualStyleBackColor = true;
            NextMoveBtn.Click += NextMove;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft New Tai Lue", 20F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(305, 6);
            titleLabel.Margin = new Padding(7, 0, 7, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(237, 62);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "reversi z2";
            // 
            // stopOrClear
            // 
            stopOrClear.Location = new Point(21, 410);
            stopOrClear.Margin = new Padding(7, 6, 7, 6);
            stopOrClear.Name = "stopOrClear";
            stopOrClear.Size = new Size(281, 64);
            stopOrClear.TabIndex = 5;
            stopOrClear.Text = "Stop / Clear";
            stopOrClear.UseVisualStyleBackColor = true;
            stopOrClear.Click += Reset;
            // 
            // pruneCheckbox
            // 
            pruneCheckbox.Checked = true;
            pruneCheckbox.CheckState = CheckState.Checked;
            pruneCheckbox.Location = new Point(353, 148);
            pruneCheckbox.Margin = new Padding(7, 6, 7, 6);
            pruneCheckbox.Name = "pruneCheckbox";
            pruneCheckbox.Size = new Size(137, 38);
            pruneCheckbox.TabIndex = 0;
            pruneCheckbox.Tag = "pruneCheckbox";
            pruneCheckbox.Text = "Prune";
            pruneCheckbox.UseVisualStyleBackColor = true;
            pruneCheckbox.CheckedChanged += SetPrune;
            // 
            // lblFullBoard
            // 
            lblFullBoard.AutoSize = true;
            lblFullBoard.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFullBoard.Location = new Point(50, 50);
            lblFullBoard.Name = "lblFullBoard";
            lblFullBoard.Size = new Size(200, 20);
            lblFullBoard.TabIndex = 0;
            // 
            // BoardUI
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1335, 1924);
            Controls.Add(OptionsPanel);
            Controls.Add(GamePanel);
            Margin = new Padding(7, 6, 7, 6);
            Name = "BoardUI";
            Text = "reversi z2";
            OptionsPanel.ResumeLayout(false);
            OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blackDepth).EndInit();
            ((System.ComponentModel.ISupportInitialize)whiteDepth).EndInit();
            blackHeuristic.ResumeLayout(false);
            blackHeuristic.PerformLayout();
            whiteHeuristic.ResumeLayout(false);
            whiteHeuristic.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Label creditsLabel;
        private RadioButton manualPlayRadioButton;
        private RadioButton automaticPlayRadioButton;
        private Button startAutomaticPlayButton;
        private Button saveGameButton;
        private Button loadGameButton;
        private CheckBox pruneCheckbox;
    }
}