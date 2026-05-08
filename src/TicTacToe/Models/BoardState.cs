using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace TicTacToe.Models;

// define the behaviour/skeleton
// write unit tests to exercise the interface
// write the interface
// write the implementation
// run the tests

// created by GameBoard
// consumed by anything needing to read the board without being able to modify it

public readonly record struct BoardState
{     
    // 
    BoardStateCellContent[,] BoardStateCells {get;}

    public BoardState(BoardStateCellContent[,] markers)
    {
        // this way of making a defensive array works because BoardStateContent (enum) and 
        // Position (record struct) are value-types and will be copied as such...
        // ...but what if they change? Is this coupling this up to those entities because this
        // will need to change if their behaviour changes in a way that this breaks
        // Is there a better way to make a defensive copy - such as just iterating through markers

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