namespace UI
{
    partial class BoardUI
    {
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Button StopOrClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NextMoveBtn;
        private System.Windows.Forms.GroupBox blackHeuristic;
        private System.Windows.Forms.RadioButton cornersBlack;
        private System.Windows.Forms.RadioButton mobilityBlack;
        private System.Windows.Forms.RadioButton tileBlack;
        private System.Windows.Forms.RadioButton humanBlack;
        private System.Windows.Forms.RadioButton weightedBlack;
        private System.Windows.Forms.GroupBox whiteHeuristic;
        private System.Windows.Forms.RadioButton humanWhite;
        private System.Windows.Forms.RadioButton weightedWhite;
        private System.Windows.Forms.RadioButton cornersWhite;
        private System.Windows.Forms.RadioButton mobilityWhite;
        private System.Windows.Forms.RadioButton tileWhite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown whitePly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown blackPly;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GamePanel = new Panel();
            OptionsPanel = new Panel();
            label4 = new Label();
            whitePly = new NumericUpDown();
            label1 = new Label();
            blackPly = new NumericUpDown();
            whiteHeuristic = new GroupBox();
            humanWhite = new RadioButton();
            weightedWhite = new RadioButton();
            cornersWhite = new RadioButton();
            mobilityWhite = new RadioButton();
            tileWhite = new RadioButton();
            blackHeuristic = new GroupBox();
            humanBlack = new RadioButton();
            weightedBlack = new RadioButton();
            cornersBlack = new RadioButton();
            mobilityBlack = new RadioButton();
            tileBlack = new RadioButton();
            NextMoveBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            StopOrClear = new Button();
            label5 = new Label();
            OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)whitePly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blackPly).BeginInit();
            whiteHeuristic.SuspendLayout();
            blackHeuristic.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.Location = new Point(1, 0);
            GamePanel.Margin = new Padding(4, 3, 4, 3);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(687, 677);
            GamePanel.TabIndex = 5;
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(label5);
            OptionsPanel.Controls.Add(label4);
            OptionsPanel.Controls.Add(whitePly);
            OptionsPanel.Controls.Add(label1);
            OptionsPanel.Controls.Add(blackPly);
            OptionsPanel.Controls.Add(whiteHeuristic);
            OptionsPanel.Controls.Add(blackHeuristic);
            OptionsPanel.Controls.Add(NextMoveBtn);
            OptionsPanel.Controls.Add(label3);
            OptionsPanel.Controls.Add(label2);
            OptionsPanel.Controls.Add(StopOrClear);
            OptionsPanel.Location = new Point(696, 3);
            OptionsPanel.Margin = new Padding(4, 3, 4, 3);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(254, 650);
            OptionsPanel.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 507);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 14;
            label4.Text = "White Plies";
            // 
            // whitePly
            // 
            whitePly.Location = new Point(158, 504);
            whitePly.Margin = new Padding(4, 3, 4, 3);
            whitePly.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            whitePly.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            whitePly.Name = "whitePly";
            whitePly.Size = new Size(37, 23);
            whitePly.TabIndex = 13;
            whitePly.Tag = "white";
            whitePly.Value = new decimal(new int[] { 5, 0, 0, 0 });
            whitePly.ValueChanged += SetPly;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 308);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 12;
            label1.Text = "Black Plies";
            // 
            // blackPly
            // 
            blackPly.Location = new Point(158, 306);
            blackPly.Margin = new Padding(4, 3, 4, 3);
            blackPly.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            blackPly.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            blackPly.Name = "blackPly";
            blackPly.Size = new Size(37, 23);
            blackPly.TabIndex = 11;
            blackPly.Tag = "black";
            blackPly.Value = new decimal(new int[] { 5, 0, 0, 0 });
            blackPly.ValueChanged += SetPly;
            // 
            // whiteHeuristic
            // 
            whiteHeuristic.Controls.Add(humanWhite);
            whiteHeuristic.Controls.Add(weightedWhite);
            whiteHeuristic.Controls.Add(cornersWhite);
            whiteHeuristic.Controls.Add(mobilityWhite);
            whiteHeuristic.Controls.Add(tileWhite);
            whiteHeuristic.Location = new Point(46, 350);
            whiteHeuristic.Margin = new Padding(4, 3, 4, 3);
            whiteHeuristic.Name = "whiteHeuristic";
            whiteHeuristic.Padding = new Padding(4, 3, 4, 3);
            whiteHeuristic.Size = new Size(164, 148);
            whiteHeuristic.TabIndex = 10;
            whiteHeuristic.TabStop = false;
            whiteHeuristic.Text = "White Heuristic";
            // 
            // humanWhite
            // 
            humanWhite.AutoSize = true;
            humanWhite.Checked = true;
            humanWhite.Location = new Point(8, 121);
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
            weightedWhite.Location = new Point(8, 96);
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
            cornersWhite.Location = new Point(8, 73);
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
            mobilityWhite.Location = new Point(7, 48);
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
            tileWhite.Location = new Point(7, 22);
            tileWhite.Margin = new Padding(4, 3, 4, 3);
            tileWhite.Name = "tileWhite";
            tileWhite.Size = new Size(79, 19);
            tileWhite.TabIndex = 0;
            tileWhite.Tag = "tileWhite";
            tileWhite.Text = "Tile Count";
            tileWhite.UseVisualStyleBackColor = true;
            tileWhite.CheckedChanged += ChangeGameMode;
            // 
            // blackHeuristic
            // 
            blackHeuristic.Controls.Add(humanBlack);
            blackHeuristic.Controls.Add(weightedBlack);
            blackHeuristic.Controls.Add(cornersBlack);
            blackHeuristic.Controls.Add(mobilityBlack);
            blackHeuristic.Controls.Add(tileBlack);
            blackHeuristic.Location = new Point(46, 151);
            blackHeuristic.Margin = new Padding(4, 3, 4, 3);
            blackHeuristic.Name = "blackHeuristic";
            blackHeuristic.Padding = new Padding(4, 3, 4, 3);
            blackHeuristic.Size = new Size(164, 148);
            blackHeuristic.TabIndex = 9;
            blackHeuristic.TabStop = false;
            blackHeuristic.Text = "Black Heuristic";
            // 
            // humanBlack
            // 
            humanBlack.AutoSize = true;
            humanBlack.Checked = true;
            humanBlack.Location = new Point(8, 121);
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
            weightedBlack.Location = new Point(8, 96);
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
            cornersBlack.Location = new Point(8, 73);
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
            mobilityBlack.Location = new Point(7, 48);
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
            tileBlack.Location = new Point(7, 22);
            tileBlack.Margin = new Padding(4, 3, 4, 3);
            tileBlack.Name = "tileBlack";
            tileBlack.Size = new Size(79, 19);
            tileBlack.TabIndex = 0;
            tileBlack.Tag = "tileBlack";
            tileBlack.Text = "Tile Count";
            tileBlack.UseVisualStyleBackColor = true;
            tileBlack.CheckedChanged += ChangeGameMode;
            // 
            // NextMoveBtn
            // 
            NextMoveBtn.Location = new Point(46, 555);
            NextMoveBtn.Margin = new Padding(4, 3, 4, 3);
            NextMoveBtn.Name = "NextMoveBtn";
            NextMoveBtn.Size = new Size(164, 31);
            NextMoveBtn.TabIndex = 8;
            NextMoveBtn.Text = "Next";
            NextMoveBtn.UseVisualStyleBackColor = true;
            NextMoveBtn.Click += NextMove;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(42, 108);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(168, 13);
            label3.TabIndex = 7;
            label3.Text = "UI by Luke Meier and Drew Hayward";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft New Tai Lue", 35F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 37);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(237, 62);
            label2.TabIndex = 6;
            label2.Text = "reversi z2";
            // 
            // StopOrClear
            // 
            StopOrClear.Location = new Point(46, 603);
            StopOrClear.Margin = new Padding(4, 3, 4, 3);
            StopOrClear.Name = "StopOrClear";
            StopOrClear.Size = new Size(164, 32);
            StopOrClear.TabIndex = 5;
            StopOrClear.Text = "Stop / Clear";
            StopOrClear.UseVisualStyleBackColor = true;
            StopOrClear.Click += Reset;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(42, 121);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(165, 13);
            label5.TabIndex = 15;
            label5.Text = "Logic and Solution by Filip Strózik";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 679);
            Controls.Add(OptionsPanel);
            Controls.Add(GamePanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "reversi z2";
            OptionsPanel.ResumeLayout(false);
            OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)whitePly).EndInit();
            ((System.ComponentModel.ISupportInitialize)blackPly).EndInit();
            whiteHeuristic.ResumeLayout(false);
            whiteHeuristic.PerformLayout();
            blackHeuristic.ResumeLayout(false);
            blackHeuristic.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
    }
}