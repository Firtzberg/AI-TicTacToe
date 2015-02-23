using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToeControl;

namespace TicTacToeAgent
{
    public static class Agent
    {
        /// <summary>
        /// Finds index of best move in game.
        /// If more moves are equaly good, return a random one among them.
        /// </summary>
        /// <param name="Squares">A Symbol array which represents the states on the board.
        /// Should have length 9.</param>
        /// <param name="Xgoes">Determins if X is to play next.</param>
        /// <returns>-1 if no move possible or number of squares different from 9.
        /// An inteeger 0-9 indicating the position of best move.</returns>
        public static int BestMove(Symbol[] Squares, bool Xgoes)
        {
            if (Squares.Length != 9)
                return -1;
            int i;
            List<int> GoodMoves = new List<int>();
            Symbol Result = Symbol.None;
            for (i = 0; i < 9; i++)
                if (Squares[i] == Symbol.None)
                {
                    if (Xgoes)
                        Squares[i] = Symbol.X;
                    else Squares[i] = Symbol.O;
                    Result = DetermineWinner(Squares, !Xgoes);
                    Squares[i] = Symbol.None;

                    // Player surely wins
                    if ((Result == Symbol.X && Xgoes) ||
                        (Result == Symbol.O && !Xgoes))
                        return i;
                    // A possible Tie
                    if (Result == Symbol.None)
                        GoodMoves.Add(i);
                }
            // If no good move could be found
            if (GoodMoves.Count == 0)
            {
                // Return first empty position
                for (i = 0; i < 9; i++)
                    if (Squares[i] == Symbol.None)
                        return i;
                return -1;
            }
            Random rand = new Random();
            i = rand.Next(0, GoodMoves.Count);
            return GoodMoves[i];
        }

        /// <summary>
        /// This method finds the best move and makes it on the specified board.
        /// </summary>
        /// <param name="Board">The board to make a move on.</param>
        public static void MakeBestMove(ITicTacToeBoard Board)
        {
            int m = BestMove(Board.GetFieldSymbols(), Board.XsTurn);
            if (m != -1)
                Board.SetMark(m);
        }

        /// <summary>
        /// Determins the winner using shorted Min-Max algorithm
        /// </summary>
        /// <param name="Squares">Board States, remain unchanged on method exit</param>
        /// <param name="Xgoes">Is it x's turn?</param>
        /// <returns>Symbol of the winner, or None if it's a tie.</returns>
        private static Symbol DetermineWinner(Symbol[] Squares, bool Xgoes)
        {
            // Check diagonals
            if (Squares[4] != Symbol.None)
            {
                if ((Squares[0] == Squares[4]
                    && Squares[8] == Squares[4]) ||
                    (Squares[2] == Squares[4]
                    && Squares[6] == Squares[4]))
                    return Squares[4];
            }
            // Check horizontals and verticals
            for (int i = 0; i < 3; i++)
            {
                if (Squares[i * 3] != Symbol.None)
                    if (Squares[i * 3] == Squares[i * 3 + 1] &&
                        Squares[i * 3] == Squares[i * 3 + 2])
                        return Squares[i * 3];
                if (Squares[i] != Symbol.None)
                    if (Squares[i] == Squares[i + 3] &&
                        Squares[i] == Squares[i + 6])
                        return Squares[i];
            }
            bool CanBeTie = false;
            Symbol Result = Symbol.None;
            for (int i = 0; i < 9; i++)
                if (Squares[i] == Symbol.None)
                {
                    // Set player's symbol
                    if(Xgoes)
                        Squares[i] = Symbol.X;
                    else Squares[i] = Symbol.O;
                    // Recursion
                    Result = DetermineWinner(Squares, !Xgoes);
                    // Reverse setting player's symbol
                    Squares[i] = Symbol.None;

                    // Player will win
                    if ((Result == Symbol.X && Xgoes)||
                        (Result == Symbol.O && !Xgoes))
                        return Result;
                    // Can be a Tie
                    if (Result == Symbol.None)
                        CanBeTie = true;
                }
            if (CanBeTie)
                return Symbol.None;
            // The other player wins for sure
            else return Result;
        }
    }
}
