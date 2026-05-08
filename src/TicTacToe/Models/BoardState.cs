using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace TicTacToe.Models;
// TODO: Who are the potential consumers of this?

public readonly record struct BoardState
{     
    BoardStateCellContent[,] BoardStateCells {get;}

    public BoardState(BoardStateCellContent[,] markers)
    {
        BoardStateCells = (BoardStateCellContent[,])markers.Clone();
    }

    public BoardStateCellContent this[Position position]
    {
        get
        {
            return BoardStateCells[position.Y, position.X];
        }
    }
};