using System.Diagnostics;

namespace UI
{
    partial class BoardUI
    {
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Button StopOrClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            blackPly = new NumericUpDown();
            whitePly = new NumericUpDown();
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
            label3 = new Label();
            label2 = new Label();
            StopOrClear = new Button();
            pruneCheckbox = new CheckBox();
            lblFullBoard = new Label();
            OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blackPly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)whitePly).BeginInit();
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
            OptionsPanel.Controls.Add(button3);
            OptionsPanel.Controls.Add(button2);
            OptionsPanel.Controls.Add(button1);
            OptionsPanel.Controls.Add(radioButton2);
            OptionsPanel.Controls.Add(radioButton1);
            OptionsPanel.Controls.Add(label5);
            OptionsPanel.Controls.Add(label4);
            OptionsPanel.Controls.Add(label1);
            OptionsPanel.Controls.Add(blackPly);
            OptionsPanel.Controls.Add(whitePly);
            OptionsPanel.Controls.Add(blackHeuristic);
            OptionsPanel.Controls.Add(whiteHeuristic);
            OptionsPanel.Controls.Add(NextMoveBtn);
            OptionsPanel.Controls.Add(label3);
            OptionsPanel.Controls.Add(label2);
            OptionsPanel.Controls.Add(StopOrClear);
            OptionsPanel.Controls.Add(pruneCheckbox);
            OptionsPanel.Location = new Point(118, 12);
            OptionsPanel.Margin = new Padding(4, 3, 4, 3);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(533, 249);
            OptionsPanel.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(262, 143);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(80, 31);
            button3.TabIndex = 20;
            button3.Text = "Load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(178, 143);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(80, 31);
            button2.TabIndex = 19;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(184, 205);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(164, 31);
            button1.TabIndex = 18;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(206, 121);
            radioButton2.Margin = new Padding(4, 3, 4, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(90, 19);
            radioButton2.TabIndex = 17;
            radioButton2.TabStop = true;
            radioButton2.Tag = "ManualPlay";
            radioButton2.Text = "Manual Play";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.Click += UnSetAutomaticPlay;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(206, 99);
            radioButton1.Margin = new Padding(4, 3, 4, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(106, 19);
            radioButton1.TabIndex = 16;
            radioButton1.Tag = "AutoPlay";
            radioButton1.Text = "Automatic Play";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Click += SetAutomaticPlay;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(166, 56);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(165, 13);
            label5.TabIndex = 15;
            label5.Text = "Logic and Solution by Filip Strózik";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(350, 179);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 14;
            label4.Text = "White Plies";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 178);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 12;
            label1.Text = "Black Plies";
            // 
            // blackPly
            // 
            blackPly.Location = new Point(127, 176);
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
            // whitePly
            // 
            whitePly.Location = new Point(458, 176);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(166, 44);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(182, 13);
            label3.TabIndex = 7;
            label3.Text = "UI by Luke Meier and Drew Hayward";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft New Tai Lue", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(178, 3);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 35);
            label2.TabIndex = 6;
            label2.Text = "reversi z2";
            // 
            // StopOrClear
            // 
            StopOrClear.Location = new Point(12, 205);
            StopOrClear.Margin = new Padding(4, 3, 4, 3);
            StopOrClear.Name = "StopOrClear";
            StopOrClear.Size = new Size(164, 32);
            StopOrClear.TabIndex = 5;
            StopOrClear.Text = "Stop / Clear";
            StopOrClear.UseVisualStyleBackColor = true;
            StopOrClear.Click += Reset;
            // 
            // pruneCheckbox
            // 
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
            ((System.ComponentModel.ISupportInitialize)blackPly).EndInit();
            ((System.ComponentModel.ISupportInitialize)whitePly).EndInit();
            blackHeuristic.ResumeLayout(false);
            blackHeuristic.PerformLayout();
            whiteHeuristic.ResumeLayout(false);
            whiteHeuristic.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Label label5;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Button button2;
        private Button button3;
        // windows forms checkbox button
        private CheckBox pruneCheckbox;
    }
}