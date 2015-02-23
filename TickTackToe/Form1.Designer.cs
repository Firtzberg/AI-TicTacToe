namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudPlayerCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnResetStatictics = new System.Windows.Forms.Button();
            this.lblTotalGames = new System.Windows.Forms.Label();
            this.lblTieCount = new System.Windows.Forms.Label();
            this.lblOsScore = new System.Windows.Forms.Label();
            this.lblXsScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStateAdviser = new System.Windows.Forms.Label();
            this.Board = new TicTacToeControl.TicTacToeBoard();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 45);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudPlayerCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New game";
            // 
            // nudPlayerCount
            // 
            this.nudPlayerCount.Location = new System.Drawing.Point(104, 19);
            this.nudPlayerCount.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPlayerCount.Name = "nudPlayerCount";
            this.nudPlayerCount.Size = new System.Drawing.Size(47, 20);
            this.nudPlayerCount.TabIndex = 3;
            this.nudPlayerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of players";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResetStatictics);
            this.groupBox2.Controls.Add(this.lblTotalGames);
            this.groupBox2.Controls.Add(this.lblTieCount);
            this.groupBox2.Controls.Add(this.lblOsScore);
            this.groupBox2.Controls.Add(this.lblXsScore);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // btnResetStatictics
            // 
            this.btnResetStatictics.Enabled = false;
            this.btnResetStatictics.Location = new System.Drawing.Point(6, 71);
            this.btnResetStatictics.Name = "btnResetStatictics";
            this.btnResetStatictics.Size = new System.Drawing.Size(75, 23);
            this.btnResetStatictics.TabIndex = 8;
            this.btnResetStatictics.Text = "Reset";
            this.btnResetStatictics.UseVisualStyleBackColor = true;
            this.btnResetStatictics.Click += new System.EventHandler(this.btnResetStatictics_Click);
            // 
            // lblTotalGames
            // 
            this.lblTotalGames.Location = new System.Drawing.Point(63, 55);
            this.lblTotalGames.Name = "lblTotalGames";
            this.lblTotalGames.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalGames.Size = new System.Drawing.Size(88, 13);
            this.lblTotalGames.TabIndex = 7;
            this.lblTotalGames.Text = "0";
            // 
            // lblTieCount
            // 
            this.lblTieCount.Location = new System.Drawing.Point(63, 42);
            this.lblTieCount.Name = "lblTieCount";
            this.lblTieCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTieCount.Size = new System.Drawing.Size(88, 13);
            this.lblTieCount.TabIndex = 6;
            this.lblTieCount.Text = "0";
            // 
            // lblOsScore
            // 
            this.lblOsScore.Location = new System.Drawing.Point(63, 29);
            this.lblOsScore.Name = "lblOsScore";
            this.lblOsScore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOsScore.Size = new System.Drawing.Size(88, 13);
            this.lblOsScore.TabIndex = 5;
            this.lblOsScore.Text = "0";
            // 
            // lblXsScore
            // 
            this.lblXsScore.Location = new System.Drawing.Point(63, 16);
            this.lblXsScore.Name = "lblXsScore";
            this.lblXsScore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblXsScore.Size = new System.Drawing.Size(88, 13);
            this.lblXsScore.TabIndex = 4;
            this.lblXsScore.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "O\'s score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "X\'s score";
            // 
            // lblStateAdviser
            // 
            this.lblStateAdviser.AutoSize = true;
            this.lblStateAdviser.Location = new System.Drawing.Point(175, 9);
            this.lblStateAdviser.Name = "lblStateAdviser";
            this.lblStateAdviser.Size = new System.Drawing.Size(62, 13);
            this.lblStateAdviser.TabIndex = 4;
            this.lblStateAdviser.Text = "X goes first.";
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.SystemColors.Control;
            this.Board.Location = new System.Drawing.Point(175, 25);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(156, 156);
            this.Board.TabIndex = 0;
            this.Board.GameStateChanged += new System.EventHandler(this.Board_GameStateChanged);
            this.Board.MoveDone += new System.EventHandler(this.Board_MoveDone);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 197);
            this.Controls.Add(this.lblStateAdviser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Board);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tic-Tac-Toe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TicTacToeControl.TicTacToeBoard Board;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudPlayerCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalGames;
        private System.Windows.Forms.Label lblTieCount;
        private System.Windows.Forms.Label lblOsScore;
        private System.Windows.Forms.Label lblXsScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResetStatictics;
        private System.Windows.Forms.Label lblStateAdviser;
    }
}

