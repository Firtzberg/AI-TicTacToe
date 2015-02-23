using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Number of games X has won
        /// </summary>
        private int XWonCount;
        /// <summary>
        /// Number of games O has won
        /// </summary>
        private int OWonCount;
        /// <summary>
        /// Number of ties
        /// </summary>
        private int TieCount;
        /// <summary>
        /// It's X's turn to be first
        /// </summary>
        private bool XGoesFirst;
        /// <summary>
        /// Number of human players
        /// </summary>
        private int NumberOfPlayers;

        public Form1()
        {
            InitializeComponent();
            XWonCount = 0;
            OWonCount = 0;
            TieCount = 0;
            NumberOfPlayers = 1;
            this.XGoesFirst = true;
        }

        // Start a new game
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.btnStart.Enabled = false;
            // Get number of players (and remember until next start)
            this.NumberOfPlayers = (int)this.nudPlayerCount.Value;
            // Determine who goes first and set appropriate text
            this.XGoesFirst = !this.XGoesFirst;
            if (this.XGoesFirst)
                this.lblStateAdviser.Text = "X goes first.";
            else this.lblStateAdviser.Text = "O goes first.";
            // Reset the board
            this.Board.Reset(this.XGoesFirst);

            // Check if the agent (computer) has to make the first move
            switch (this.NumberOfPlayers)
            {
                case 0:
                    TicTacToeAgent.Agent.MakeBestMove(this.Board);
                    break;
                case 2:
                    break;
                default:
                    if (!this.Board.XsTurn)
                        TicTacToeAgent.Agent.MakeBestMove(this.Board);
                    break;
            }

            this.btnStart.Enabled = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Game ended (or restarted)
        private void Board_GameStateChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // Update statistics
            switch (this.Board.State)
            {
                case TicTacToeControl.GameState.OWon:
                    this.lblOsScore.Text = (++OWonCount).ToString();
                    this.lblStateAdviser.Text = "Victory! O has won!";
                    break;
                case TicTacToeControl.GameState.XWon:
                    this.lblXsScore.Text = (++XWonCount).ToString();
                    this.lblStateAdviser.Text = "Victory! X has won!";
                    break;
                case TicTacToeControl.GameState.Tie:
                    this.lblTieCount.Text = (++TieCount).ToString();
                    this.lblStateAdviser.Text = "It's a tie.";
                    break;
            }
            if (Board.State != TicTacToeControl.GameState.Running)
            {
                this.lblTotalGames.Text = (XWonCount + OWonCount + TieCount).ToString();
                this.btnResetStatictics.Enabled = true;
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //reset statistics (don't you say)
        private void btnResetStatictics_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.TieCount = 0;
            this.XWonCount = 0;
            this.OWonCount = 0;
            this.lblOsScore.Text = "0";
            this.lblTieCount.Text = "0";
            this.lblTotalGames.Text = "0";
            this.lblXsScore.Text = "0";
            this.btnResetStatictics.Enabled = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Next player's turn.
        private void Board_MoveDone(object sender, EventArgs e)
        {
            if (Board.XsTurn)
                this.lblStateAdviser.Text = "X's turn";
            else this.lblStateAdviser.Text = "O's turn";
            switch (NumberOfPlayers)
            {
                case 0:
                    TicTacToeAgent.Agent.MakeBestMove(this.Board);
                    break;
                case 2:
                    break;
                default:
                    if (!Board.XsTurn)
                        TicTacToeAgent.Agent.MakeBestMove(this.Board);
                    break;
            }
        }
    }
}
