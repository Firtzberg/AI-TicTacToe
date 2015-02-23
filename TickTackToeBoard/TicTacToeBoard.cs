using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeControl
{
    /// <summary>
    /// Tic-Tac-Toe Board
    /// </summary>
    [DefaultEvent("GameStateChanged")]
    public partial class TicTacToeBoard: UserControl, ITicTacToeBoard
    {
        /// <summary>
        /// Squares of Board
        /// </summary>
        TicTacToeSquare[] Squares;

        public TicTacToeBoard()
        {
            Squares = new TicTacToeSquare[9];
            for (int i = 0; i < 9; i++)
            {
                Squares[i] = new TicTacToeSquare();
                this.Controls.Add(Squares[i]);
            }
            InitializeComponent();
            //you may change this
            for(int i=0;i<9;i++)
                Squares[i].MouseDown += TicTacToeSquare_MouseDown;
        }

        //you may change this
        private void TicTacToeSquare_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            for (i = 0; i < 9; i++)
                if (sender == Squares[i])
                    this.SetMark(i);
        }

        /// <summary>
        /// True if X plays next.
        /// </summary>
        bool xsTurn = true;
        /// <summary>
        /// Determins if it's X's turn.
        /// </summary>
        [Description("Determins if it's X's turn.")]
        public bool XsTurn
        {
            get { return xsTurn; }
        }

        /// <summary>
        /// Occurs when a player makes a valid move.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when a player makes a valid move.")]
        public event EventHandler MoveDone;
        /// <summary>
        /// Raises the MoveDone EventHandler.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected virtual void OnMoveDone(EventArgs e)
        {
            EventHandler eh = this.MoveDone;
            if (eh != null)
                eh(this, e);
        }

        /// <summary>
        /// Gets current symbols put on board.
        /// </summary>
        /// <returns>Symbol array of length 9.</returns>
        public Symbol[] GetFieldSymbols()
        {
            Symbol[] Symbols = new Symbol[9];
            for (int i = 0; i < 9; i++)
                Symbols[i] = Squares[i].Mark;
            return Symbols;
        }

        /// <summary>
        /// Sets the current player's mark on the specified position if the move is valid.
        /// </summary>
        /// <param name="pos">The zero-based position of the field. 0 is top-right, 2 is top-left.</param>
        public void SetMark(int pos)
        {
            if (state != GameState.Running)
                return;
            if (pos < 0 || pos > 8)
                return;
            if (Squares[pos].Mark != Symbol.None)
                return;
            if (xsTurn)
                Squares[pos].Mark = Symbol.X;
            else Squares[pos].Mark = Symbol.O;
            xsTurn = !xsTurn;
            GameState NewState = DetermineGameState();
            if (NewState != this.state)
            {
                this.state = NewState;
                this.OnMoveDone(EventArgs.Empty);
                this.OnGameStateChanged(EventArgs.Empty);
                return;
            }
            this.OnMoveDone(EventArgs.Empty);
        }

        /// <summary>
        /// Determins the current game state
        /// </summary>
        /// <returns>GameState which can be Running, Tie, XWon or OWon</returns>
        private GameState DetermineGameState()
        {
            //Check diagonals
            if (Squares[4].Mark != Symbol.None)
            {
                //One diagonal
                if (Squares[0].Mark == Squares[4].Mark
                    && Squares[8].Mark == Squares[4].Mark)
                {
                    this.SuspendLayout();
                    Squares[0].BackColor = this.highlightColor;
                    Squares[4].BackColor = this.highlightColor;
                    Squares[8].BackColor = this.highlightColor;
                    this.ResumeLayout(false);
                    this.PerformLayout();
                    return EnumConverter.GameStateFromSymbol(Squares[4].Mark);
                }
                //Other diagonal
                if (Squares[2].Mark == Squares[4].Mark
                    && Squares[6].Mark == Squares[4].Mark)
                {
                    this.SuspendLayout();
                    Squares[2].BackColor = this.highlightColor;
                    Squares[4].BackColor = this.highlightColor;
                    Squares[6].BackColor = this.highlightColor;
                    this.ResumeLayout(false);
                    this.PerformLayout();
                    return EnumConverter.GameStateFromSymbol(Squares[4].Mark);
                }
            }
            //Check vertical and horizontal lines
            for (int i = 0; i < 3; i++)
            {
                //Check horizontal lines
                if (Squares[i * 3].Mark != Symbol.None)
                    if (Squares[i * 3].Mark == Squares[i * 3 + 1].Mark &&
                        Squares[i * 3].Mark == Squares[i * 3 + 2].Mark)
                    {
                        this.SuspendLayout();
                        Squares[i * 3].BackColor = this.highlightColor;
                        Squares[i * 3 + 1].BackColor = this.highlightColor;
                        Squares[i * 3 + 2].BackColor = this.highlightColor;
                        this.ResumeLayout(false);
                        this.PerformLayout();
                        return EnumConverter.GameStateFromSymbol(Squares[i * 3].Mark);
                    }
                //Check vertical lines
                if (Squares[i].Mark != Symbol.None)
                    if (Squares[i].Mark == Squares[i + 3].Mark &&
                        Squares[i].Mark == Squares[i + 6].Mark)
                    {
                        this.SuspendLayout();
                        Squares[i].BackColor = this.highlightColor;
                        Squares[i + 3].BackColor = this.highlightColor;
                        Squares[i + 6].BackColor = this.highlightColor;
                        this.ResumeLayout(false);
                        this.PerformLayout();
                        return EnumConverter.GameStateFromSymbol(Squares[i].Mark);
                    }
            }
            //Check for free places
            for (int i = 0; i < 9; i++)
                if (Squares[i].Mark == Symbol.None)
                    return GameState.Running;
            return GameState.Tie;
        }

        /// <summary>
        /// Current state of the game.
        /// </summary>
        private GameState state = GameState.Running;
        /// <summary>
        /// Gets current state of the game.
        /// </summary>
        [Description("Gets current state of the game."),
        DefaultValue(GameState.Running)]
        public GameState State
        {
            get { return state; }
        }
        /// <summary>
        /// Occurs when the game ends or is reset after end.
        /// </summary>
        [Category("Property Changed")]
        [Description("Occurs when the game ends or is reset after end.")]
        public event EventHandler GameStateChanged;
        /// <summary>
        /// Raises the GameStateChanged EventHandler.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected virtual void OnGameStateChanged(EventArgs e)
        {
            EventHandler eh = this.GameStateChanged;
            if (eh != null)
                eh(this, e);
        }

        /// <summary>
        /// Background color of the fields which make 3 same in a straight line
        /// </summary>
        private Color highlightColor = System.Drawing.Color.Salmon;
        /// <summary>
        /// Get or sets the background color of the fields which make 3 same in a straight line
        /// </summary>
        [Description("Get or sets the background color of the fields which make 3 same in a straight line"),
        Category("Appearance")]
        public Color HighlightColor
        {
            get { return this.highlightColor; }
            set
            {
                if (this.highlightColor != value)
                {
                    this.highlightColor = value;
                    if(this.state == GameState.OWon || this.state == GameState.XWon)
                        this.DetermineGameState();//Refreshes the background color of highlighted sqares
                    this.OnHighlightColorChanged(EventArgs.Empty);
                }
            }
        }

        //Needed for editing in Designer
        public bool ShouldSerializeHighlightColor()
        {
            return highlightColor != Color.Salmon;
        }

        //Needed for editing in Designer
        public void ResetHighlightColor()
        {
            HighlightColor = Color.Salmon;
        }


        /// <summary>
        /// Occurs when the HighlightColor property of the control is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Occurs when the HighlightColor property of the control is changed.")]
        public event EventHandler HighlightColorChanged;
        /// <summary>
        /// Raises the HighlightColorChanged EventHandler.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected virtual void OnHighlightColorChanged(EventArgs e)
        {
            EventHandler eh = this.HighlightColorChanged;
            if (eh != null)
                eh(this, e);
        }

        /// <summary>
        /// Cleans the board.
        /// </summary>
        /// <param name="XGoesFirst">Determins if the player X goes first</param>
        public void Reset(bool XGoesFirst = true)
        {
            this.xsTurn = XGoesFirst;
            this.SuspendLayout();
            for (int i = 0; i < 9; i++)
            {
                Squares[i].Mark = Symbol.None;
                Squares[i].BackColor = this.BackColor;
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            if (state != GameState.Running)
            {
                this.state = GameState.Running;
                this.OnGameStateChanged(EventArgs.Empty);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Pen pen = new Pen(this.ForeColor, 3);
            //Draw #
            pe.Graphics.DrawLine(pen, new Point(this.Width / 3 - 1, 0), new Point(this.Width / 3 - 1, this.Height));
            pe.Graphics.DrawLine(pen, new Point(this.Width * 2 / 3, 0), new Point(this.Width * 2 / 3, this.Height));
            pe.Graphics.DrawLine(pen, new Point(0, this.Height / 3 - 1), new Point(this.Width, this.Height / 3 - 1));
            pe.Graphics.DrawLine(pen, new Point(0, this.Height * 2 / 3), new Point(this.Width, this.Height * 2 / 3));

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Size s = new Size((this.Width - 6) / 3, (this.Height - 6) / 3);
            base.OnSizeChanged(e);
            //Reposition squares
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Squares[i * 3 + j].Size = s;
                    Squares[i * 3 + j].Location = new Point(i * this.Width / 3 + i, j * this.Height / 3 + j);
                }
        }
    }
}
