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
            GamePanel.Location = new Point(29, 279);
            GamePanel.Margin = new Padding(4, 3, 4, 3);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(723, 652);
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
            OptionsPanel.Location = new Point(118, 12);
            OptionsPanel.Margin = new Padding(4, 3, 4, 3);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(533, 249);
            OptionsPanel.TabIndex = 6;
            // 
            // loadButton
            // 
            loadGameButton.Location = new Point(262, 143);
            loadGameButton.Margin = new Padding(4, 3, 4, 3);
            loadGameButton.Name = "button3";
            loadGameButton.Size = new Size(80, 31);
            loadGameButton.TabIndex = 20;
            loadGameButton.Text = "Load";
            loadGameButton.UseVisualStyleBackColor = true;
            loadGameButton.Click += button3_Click;
            // 
            // saveButton
            // 
            saveGameButton.Location = new Point(178, 143);
            saveGameButton.Margin = new Padding(4, 3, 4, 3);
            saveGameButton.Name = "button2";
            saveGameButton.Size = new Size(80, 31);
            saveGameButton.TabIndex = 19;
            saveGameButton.Text = "Save";
            saveGameButton.UseVisualStyleBackColor = true;
            saveGameButton.Click += SaveButton_Click;
            // 
            // startAutomaticPlayButton
            // 
            startAutomaticPlayButton.Location = new Point(184, 205);
            startAutomaticPlayButton.Margin = new Padding(4, 3, 4, 3);
            startAutomaticPlayButton.Name = "button1";
            startAutomaticPlayButton.Size = new Size(164, 31);
            startAutomaticPlayButton.TabIndex = 18;
            startAutomaticPlayButton.Text = "Start Automatic Play";
            startAutomaticPlayButton.UseVisualStyleBackColor = true;
            startAutomaticPlayButton.Click += StartAutomaticPlayButton_Click;
            // 
            // manualPlayRadioButton
            // 
            manualPlayRadioButton.AutoSize = true;
            manualPlayRadioButton.Checked = true;
            manualPlayRadioButton.Location = new Point(206, 121);
            manualPlayRadioButton.Margin = new Padding(4, 3, 4, 3);
            manualPlayRadioButton.Name = "radioButton2";
            manualPlayRadioButton.Size = new Size(90, 19);
            manualPlayRadioButton.TabIndex = 17;
            manualPlayRadioButton.TabStop = true;
            manualPlayRadioButton.Tag = "ManualPlay";
            manualPlayRadioButton.Text = "Manual Play";
            manualPlayRadioButton.UseVisualStyleBackColor = true;
            manualPlayRadioButton.Click += UnSetAutomaticPlay;
            // 
            // automaticPlayRadioButton1
            // 
            automaticPlayRadioButton.AutoSize = true;
            automaticPlayRadioButton.Location = new Point(206, 99);
            automaticPlayRadioButton.Margin = new Padding(4, 3, 4, 3);
            automaticPlayRadioButton.Name = "radioButton1";
            automaticPlayRadioButton.Size = new Size(106, 19);
            automaticPlayRadioButton.TabIndex = 16;
            automaticPlayRadioButton.Tag = "AutoPlay";
            automaticPlayRadioButton.Text = "Automatic Play";
            automaticPlayRadioButton.UseVisualStyleBackColor = true;
            automaticPlayRadioButton.Click += SetAutomaticPlay;
            // 
            // craditsLabel
            // 
            creditsLabel.AutoSize = true;
            creditsLabel.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            creditsLabel.Location = new Point(197, 53);
            creditsLabel.Margin = new Padding(4, 0, 4, 0);
            creditsLabel.Name = "label5";
            creditsLabel.Size = new Size(115, 13);
            creditsLabel.TabIndex = 15;
            creditsLabel.Text = "Solution by Filip Strózik";
            // 
            // whiteDepthLabel
            // 
            whiteDepthLabel.AutoSize = true;
            whiteDepthLabel.Location = new Point(350, 179);
            whiteDepthLabel.Margin = new Padding(4, 0, 4, 0);
            whiteDepthLabel.Name = "label4";
            whiteDepthLabel.Size = new Size(73, 15);
            whiteDepthLabel.TabIndex = 14;
            whiteDepthLabel.Text = "White Depth";
            // 
            // blackDepthLabel
            // 
            blackDepthLabel.AutoSize = true;
            blackDepthLabel.Location = new Point(19, 178);
            blackDepthLabel.Margin = new Padding(4, 0, 4, 0);
            blackDepthLabel.Name = "label1";
            blackDepthLabel.Size = new Size(70, 15);
            blackDepthLabel.TabIndex = 12;
            blackDepthLabel.Text = "Black Depth";
            // 
            // blackDepth
            // 
            blackDepth.Location = new Point(127, 176);
            blackDepth.Margin = new Padding(4, 3, 4, 3);
            blackDepth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            blackDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            blackDepth.Name = "blackDepth";
            blackDepth.Size = new Size(37, 23);
            blackDepth.TabIndex = 11;
            blackDepth.Tag = "black";
            blackDepth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            blackDepth.ValueChanged += SetDepth;
            // 
            // whiteDepth
            // 
            whiteDepth.Location = new Point(458, 176);
            whiteDepth.Margin = new Padding(4, 3, 4, 3);
            whiteDepth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            whiteDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            whiteDepth.Name = "whiteDepth";
            whiteDepth.Size = new Size(37, 23);
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
            blackHeuristic.Location = new Point(13, 7);
            blackHeuristic.Margin = new Padding(4, 3, 4, 3);
            blackHeuristic.Name = "blackHeuristic";
            blackHeuristic.Padding = new Padding(4, 3, 4, 3);
            blackHeuristic.Size = new Size(164, 168);
            blackHeuristic.TabIndex = 9;
            blackHeuristic.TabStop = false;
            blackHeuristic.Text = "Black Heuristic";
            // 
            // humanBlack
            // 
            humanBlack.AutoSize = true;
            humanBlack.Checked = true;
            humanBlack.Location = new Point(6, 142);
            humanBlack.Margin = new Padding(4, 3, 4, 3);
            humanBlack.Name = "humanBlack";
            humanBlack.Size = new Size(100, 19);
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
            weightedBlack.Location = new Point(7, 117);
            weightedBlack.Margin = new Padding(4, 3, 4, 3);
            weightedBlack.Name = "weightedBlack";
            weightedBlack.Size = new Size(102, 19);
            weightedBlack.TabIndex = 3;
            weightedBlack.Tag = "weightedBlack";
            weightedBlack.Text = "Weighted Tiles";
            weightedBlack.UseVisualStyleBackColor = true;
            weightedBlack.CheckedChanged += ChangeGameMode;
            // 
            // cornersBlack
            // 
            cornersBlack.AutoSize = true;
            cornersBlack.Location = new Point(6, 92);
            cornersBlack.Margin = new Padding(4, 3, 4, 3);
            cornersBlack.Name = "cornersBlack";
            cornersBlack.Size = new Size(66, 19);
            cornersBlack.TabIndex = 2;
            cornersBlack.Tag = "cornersBlack";
            cornersBlack.Text = "Corners";
            cornersBlack.UseVisualStyleBackColor = true;
            cornersBlack.CheckedChanged += ChangeGameMode;
            // 
            // mobilityBlack
            // 
            mobilityBlack.AutoSize = true;
            mobilityBlack.Location = new Point(6, 69);
            mobilityBlack.Margin = new Padding(4, 3, 4, 3);
            mobilityBlack.Name = "mobilityBlack";
            mobilityBlack.Size = new Size(106, 19);
            mobilityBlack.TabIndex = 1;
            mobilityBlack.Tag = "mobilityBlack";
            mobilityBlack.Text = "Actual Mobility";
            mobilityBlack.UseVisualStyleBackColor = true;
            mobilityBlack.CheckedChanged += ChangeGameMode;
            // 
            // tileBlack
            // 
            tileBlack.AutoSize = true;
            tileBlack.Location = new Point(6, 43);
            tileBlack.Margin = new Padding(4, 3, 4, 3);
            tileBlack.Name = "tileBlack";
            tileBlack.Size = new Size(79, 19);
            tileBlack.TabIndex = 0;
            tileBlack.Tag = "tileBlack";
            tileBlack.Text = "Tile Count";
            tileBlack.UseVisualStyleBackColor = true;
            tileBlack.CheckedChanged += ChangeGameMode;
            // 
            // randomBlack
            // 
            randomBlack.AutoSize = true;
            randomBlack.Location = new Point(6, 18);
            randomBlack.Margin = new Padding(4, 3, 4, 3);
            randomBlack.Name = "randomBlack";
            randomBlack.Size = new Size(70, 19);
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
            whiteHeuristic.Location = new Point(350, 3);
            whiteHeuristic.Margin = new Padding(4, 3, 4, 3);
            whiteHeuristic.Name = "whiteHeuristic";
            whiteHeuristic.Padding = new Padding(4, 3, 4, 3);
            whiteHeuristic.Size = new Size(164, 172);
            whiteHeuristic.TabIndex = 10;
            whiteHeuristic.TabStop = false;
            whiteHeuristic.Text = "White Heuristic";
            // 
            // humanWhite
            // 
            humanWhite.AutoSize = true;
            humanWhite.Checked = true;
            humanWhite.Location = new Point(10, 146);
            humanWhite.Margin = new Padding(4, 3, 4, 3);
            humanWhite.Name = "humanWhite";
            humanWhite.Size = new Size(100, 19);
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
            weightedWhite.Location = new Point(10, 123);
            weightedWhite.Margin = new Padding(4, 3, 4, 3);
            weightedWhite.Name = "weightedWhite";
            weightedWhite.Size = new Size(102, 19);
            weightedWhite.TabIndex = 3;
            weightedWhite.Tag = "weightedWhite";
            weightedWhite.Text = "Weighted Tiles";
            weightedWhite.UseVisualStyleBackColor = true;
            weightedWhite.CheckedChanged += ChangeGameMode;
            // 
            // cornersWhite
            // 
            cornersWhite.AutoSize = true;
            cornersWhite.Location = new Point(10, 98);
            cornersWhite.Margin = new Padding(4, 3, 4, 3);
            cornersWhite.Name = "cornersWhite";
            cornersWhite.Size = new Size(66, 19);
            cornersWhite.TabIndex = 2;
            cornersWhite.Tag = "cornersWhite";
            cornersWhite.Text = "Corners";
            cornersWhite.UseVisualStyleBackColor = true;
            cornersWhite.CheckedChanged += ChangeGameMode;
            // 
            // mobilityWhite
            // 
            mobilityWhite.AutoSize = true;
            mobilityWhite.Location = new Point(10, 73);
            mobilityWhite.Margin = new Padding(4, 3, 4, 3);
            mobilityWhite.Name = "mobilityWhite";
            mobilityWhite.Size = new Size(106, 19);
            mobilityWhite.TabIndex = 1;
            mobilityWhite.Tag = "mobilityWhite";
            mobilityWhite.Text = "Actual Mobility";
            mobilityWhite.UseVisualStyleBackColor = true;
            mobilityWhite.CheckedChanged += ChangeGameMode;
            // 
            // tileWhite
            // 
            tileWhite.AutoSize = true;
            tileWhite.Location = new Point(10, 47);
            tileWhite.Margin = new Padding(4, 3, 4, 3);
            tileWhite.Name = "tileWhite";
            tileWhite.Size = new Size(79, 19);
            tileWhite.TabIndex = 0;
            tileWhite.Tag = "tileWhite";
            tileWhite.Text = "Tile Count";
            tileWhite.UseVisualStyleBackColor = true;
            tileWhite.CheckedChanged += ChangeGameMode;
            // 
            // randomWhite
            // 
            randomWhite.AutoSize = true;
            randomWhite.Location = new Point(10, 22);
            randomWhite.Margin = new Padding(4, 3, 4, 3);
            randomWhite.Name = "randomWhite";
            randomWhite.Size = new Size(70, 19);
            randomWhite.TabIndex = 0;
            randomWhite.Tag = "randomWhite";
            randomWhite.Text = "Random";
            randomWhite.UseVisualStyleBackColor = true;
            randomWhite.CheckedChanged += ChangeGameMode;
            // 
            // NextMoveBtn
            // 
            NextMoveBtn.Location = new Point(349, 205);
            NextMoveBtn.Margin = new Padding(4, 3, 4, 3);
            NextMoveBtn.Name = "NextMoveBtn";
            NextMoveBtn.Size = new Size(164, 31);
            NextMoveBtn.TabIndex = 8;
            NextMoveBtn.Text = "Next";
            NextMoveBtn.UseVisualStyleBackColor = true;
            NextMoveBtn.Click += NextMove;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft New Tai Lue", 20F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(178, 3);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "label2";
            titleLabel.Size = new Size(138, 35);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "reversi z2";
            // 
            // StopOrClear
            // 
            stopOrClear.Location = new Point(12, 205);
            stopOrClear.Margin = new Padding(4, 3, 4, 3);
            stopOrClear.Name = "StopOrClear";
            stopOrClear.Size = new Size(164, 32);
            stopOrClear.TabIndex = 5;
            stopOrClear.Text = "Stop / Clear";
            stopOrClear.UseVisualStyleBackColor = true;
            stopOrClear.Click += Reset;
            // 
            // pruneCheckbox
            // 
            pruneCheckbox.Checked = true;
            pruneCheckbox.CheckState = CheckState.Checked;
            pruneCheckbox.Location = new Point(206, 74);
            pruneCheckbox.Margin = new Padding(4, 3, 4, 3);
            pruneCheckbox.Name = "pruneCheckbox";
            pruneCheckbox.Size = new Size(80, 19);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 943);
            Controls.Add(OptionsPanel);
            Controls.Add(GamePanel);
            Margin = new Padding(4, 3, 4, 3);
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