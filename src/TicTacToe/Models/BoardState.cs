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
            if (position.X <= -1 || position.X >= 4 || position.Y <= -1 || position.Y >= 4)
                return BoardStateCells[1,1];
            return BoardStateCells[position.Y, position.X];
        }
    }
};