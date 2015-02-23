using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeControl
{
    /// <summary>
    /// Interface as additional abstraction layer
    /// </summary>
    public interface ITicTacToeBoard
    {
        bool XsTurn { get; }
        Symbol[] GetFieldSymbols();
        void SetMark(int pos);
    }

    /// <summary>
    /// Possible game states
    /// </summary>
    public enum GameState
    {
        Running,
        Tie,
        XWon,
        OWon
    }

    /// <summary>
    /// Possible square Symbols
    /// </summary>
    public enum Symbol
    {
        None,
        X,
        O
    }

    public static class EnumConverter
    {
        public static GameState GameStateFromSymbol(Symbol symbol)
        {
            switch (symbol)
            {
                case Symbol.O:
                    return GameState.OWon;
                case Symbol.X:
                    return GameState.XWon;
                default:
                    return GameState.Tie;
            }
        }
    }
}
