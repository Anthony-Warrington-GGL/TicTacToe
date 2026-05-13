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
            // TODO: check the position is not out of bounds - done
            ValidatePositionIsInBounds(position);
            return BoardStateCells[position.X, position.Y];
            //return BoardStateCellContent.X;
        }
    }

    private void ValidatePositionIsInBounds(Position position)
    {
        // check X or Y aren't less than 1
        if (position.X < 1)
            // TODO: make error messages consts?
            throw new IndexOutOfRangeException("X is invalid. The value of X cannot be less than 1.");

        if (position.Y < 1)
            throw new IndexOutOfRangeException("Y is invalid. The value of Y cannot be less than 1.");
            
        if (position.X > BoardStateCells.GetLength(0))
            throw new IndexOutOfRangeException($"X is invalid. The value of X cannot be greater than {BoardStateCells.GetLength(0)}.");
        
        if (position.Y > BoardStateCells.GetLength(1))
            throw new IndexOutOfRangeException($"Y is invalid. The value of Y cannot be greater than {BoardStateCells.GetLength(1)}.");

        // TODO:...
        // if just X invalid, throw X invalid message
        // is just Y invalid, throw Y invalid message
        // if they're both invalid, throw X + Y invalid message
    }

    // TODO: Expose height/width
    // TODO: check height / width out of bounds
};