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
            // TODO: check the position is not out of bounds
            validatePositionIsInBounds(position);
            //return BoardStateCells[position.X, position.Y];
            return BoardStateCellContent.X;
        }
    }

    private void validatePositionIsInBounds(Position position)
    {
        if (position.X < 1)
            throw new IndexOutOfRangeException();
            
        if (position.X > BoardStateCells.GetLength(0))
            throw new IndexOutOfRangeException();

        // TODO:...
        // is X valid
        // is Y valid
        // if they're both invalid, throw X + Y invalid
        // if one invalid, throw exception for that 
        // else continue
    }

    // TODO: Expose height/width
    // TODO: check height / width out of bounds
};