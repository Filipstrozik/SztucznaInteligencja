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
            whiteHeuristic = new GroupBox();
            humanWhite = new RadioButton();
            weightedWhite = new RadioButton();
            cornersWhite = new RadioButton();
            mobilityWhite = new RadioButton();
            tileWhite = new RadioButton();
            NextMoveBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            StopOrClear = new Button();
            button1 = new Button();
            OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blackPly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)whitePly).BeginInit();
            blackHeuristic.SuspendLayout();
            whiteHeuristic.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.Location = new Point(3, 437);
            GamePanel.Margin = new Padding(7, 6, 7, 6);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(783, 733);
            GamePanel.TabIndex = 5;
            // 
            // OptionsPanel
            // 
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
            OptionsPanel.Location = new Point(3, 3);
            OptionsPanel.Margin = new Padding(7, 6, 7, 6);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(887, 431);
            OptionsPanel.TabIndex = 6;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(353, 242);
            radioButton2.Margin = new Padding(7, 6, 7, 6);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(152, 34);
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
            radioButton1.Location = new Point(353, 198);
            radioButton1.Margin = new Padding(7, 6, 7, 6);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(178, 34);
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
            label5.Location = new Point(284, 112);
            label5.Margin = new Padding(7, 0, 7, 0);
            label5.Name = "label5";
            label5.Size = new Size(291, 24);
            label5.TabIndex = 15;
            label5.Text = "Logic and Solution by Filip Strózik";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 324);
            label4.Margin = new Padding(7, 0, 7, 0);
            label4.Name = "label4";
            label4.Size = new Size(116, 30);
            label4.TabIndex = 14;
            label4.Text = "White Plies";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 317);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 30);
            label1.TabIndex = 12;
            label1.Text = "Black Plies";
            // 
            // blackPly
            // 
            blackPly.Location = new Point(209, 313);
            blackPly.Margin = new Padding(7, 6, 7, 6);
            blackPly.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            blackPly.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            blackPly.Name = "blackPly";
            blackPly.Size = new Size(63, 35);
            blackPly.TabIndex = 11;
            blackPly.Tag = "black";
            blackPly.Value = new decimal(new int[] { 5, 0, 0, 0 });
            blackPly.ValueChanged += SetPly;
            // 
            // whitePly
            // 
            whitePly.Location = new Point(785, 318);
            whitePly.Margin = new Padding(7, 6, 7, 6);
            whitePly.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            whitePly.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            whitePly.Name = "whitePly";
            whitePly.Size = new Size(63, 35);
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
            blackHeuristic.Location = new Point(10, 0);
            blackHeuristic.Margin = new Padding(7, 6, 7, 6);
            blackHeuristic.Name = "blackHeuristic";
            blackHeuristic.Padding = new Padding(7, 6, 7, 6);
            blackHeuristic.Size = new Size(281, 296);
            blackHeuristic.TabIndex = 9;
            blackHeuristic.TabStop = false;
            blackHeuristic.Text = "Black Heuristic";
            // 
            // humanBlack
            // 
            humanBlack.AutoSize = true;
            humanBlack.Checked = true;
            humanBlack.Location = new Point(14, 242);
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
            weightedBlack.Location = new Point(14, 192);
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
            cornersBlack.Location = new Point(12, 142);
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
            mobilityBlack.Location = new Point(12, 96);
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
            tileBlack.Location = new Point(12, 44);
            tileBlack.Margin = new Padding(7, 6, 7, 6);
            tileBlack.Name = "tileBlack";
            tileBlack.Size = new Size(132, 34);
            tileBlack.TabIndex = 0;
            tileBlack.Tag = "tileBlack";
            tileBlack.Text = "Tile Count";
            tileBlack.UseVisualStyleBackColor = true;
            tileBlack.CheckedChanged += ChangeGameMode;
            // 
            // whiteHeuristic
            // 
            whiteHeuristic.Controls.Add(humanWhite);
            whiteHeuristic.Controls.Add(weightedWhite);
            whiteHeuristic.Controls.Add(cornersWhite);
            whiteHeuristic.Controls.Add(mobilityWhite);
            whiteHeuristic.Controls.Add(tileWhite);
            whiteHeuristic.Location = new Point(600, 6);
            whiteHeuristic.Margin = new Padding(7, 6, 7, 6);
            whiteHeuristic.Name = "whiteHeuristic";
            whiteHeuristic.Padding = new Padding(7, 6, 7, 6);
            whiteHeuristic.Size = new Size(281, 296);
            whiteHeuristic.TabIndex = 10;
            whiteHeuristic.TabStop = false;
            whiteHeuristic.Text = "White Heuristic";
            // 
            // humanWhite
            // 
            humanWhite.AutoSize = true;
            humanWhite.Checked = true;
            humanWhite.Location = new Point(14, 242);
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
            weightedWhite.Location = new Point(14, 192);
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
            cornersWhite.Location = new Point(14, 146);
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
            mobilityWhite.Location = new Point(12, 96);
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
            tileWhite.Location = new Point(12, 44);
            tileWhite.Margin = new Padding(7, 6, 7, 6);
            tileWhite.Name = "tileWhite";
            tileWhite.Size = new Size(132, 34);
            tileWhite.TabIndex = 0;
            tileWhite.Tag = "tileWhite";
            tileWhite.Text = "Tile Count";
            tileWhite.UseVisualStyleBackColor = true;
            tileWhite.CheckedChanged += ChangeGameMode;
            // 
            // NextMoveBtn
            // 
            NextMoveBtn.Location = new Point(600, 360);
            NextMoveBtn.Margin = new Padding(7, 6, 7, 6);
            NextMoveBtn.Name = "NextMoveBtn";
            NextMoveBtn.Size = new Size(281, 62);
            NextMoveBtn.TabIndex = 8;
            NextMoveBtn.Text = "Next";
            NextMoveBtn.UseVisualStyleBackColor = true;
            NextMoveBtn.Click += NextMove;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(284, 88);
            label3.Margin = new Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new Size(316, 24);
            label3.TabIndex = 7;
            label3.Text = "UI by Luke Meier and Drew Hayward";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft New Tai Lue", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(305, 6);
            label2.Margin = new Padding(7, 0, 7, 0);
            label2.Name = "label2";
            label2.Size = new Size(237, 62);
            label2.TabIndex = 6;
            label2.Text = "reversi z2";
            // 
            // StopOrClear
            // 
            StopOrClear.Location = new Point(22, 360);
            StopOrClear.Margin = new Padding(7, 6, 7, 6);
            StopOrClear.Name = "StopOrClear";
            StopOrClear.Size = new Size(281, 64);
            StopOrClear.TabIndex = 5;
            StopOrClear.Text = "Stop / Clear";
            StopOrClear.UseVisualStyleBackColor = true;
            StopOrClear.Click += Reset;
            // 
            // button1
            // 
            button1.Location = new Point(317, 360);
            button1.Margin = new Padding(7, 6, 7, 6);
            button1.Name = "button1";
            button1.Size = new Size(281, 62);
            button1.TabIndex = 18;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BoardUI
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 1192);
            Controls.Add(OptionsPanel);
            Controls.Add(GamePanel);
            Margin = new Padding(7, 6, 7, 6);
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
    }
}