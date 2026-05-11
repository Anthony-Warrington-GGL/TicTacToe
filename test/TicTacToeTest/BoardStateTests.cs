using System.Data;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class BoardStateTests
{
    [TestMethod]
    public void IndexOperator__when_positionX_is_less_than_1__throws_index_out_of_range_exception()
    {
        // Arrange
        var position = new Position{X = 0, Y = 1};
        var markers = new BoardStateCellContent[1, 99];

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(99)]
    public void IndexOperator__when_positionX_is_greater_than_the_board_width__throws_index_out_of_range_exception(int width)
    {
        // Arrange
        var position = new Position{X = width + 1, Y = 1};
        var markers = new BoardStateCellContent[width, 200];

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    // TODO: Y tests

    // TODO: message tests

    // TODO: happy path tests (e.g. 1,1 gives object at array's 0,0)
}
// TODO: Could you write an implementation that would cause the test to pass when it shouldn't?

// TODO: How does this deal with different board sizes?