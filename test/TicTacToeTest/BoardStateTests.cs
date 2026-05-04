using System.Data;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class BoardStateTests
{
    [TestMethod]
    [DataRow(3, 3, 0, 0)]
    [DataRow(3, 3, 1, 1)]
    [DataRow(4, 4, 2, 2)]
    [DataRow(5, 2, 4, 1)]
    public void When_position_is_in_range_and_has_no_marker__returns_null(int width, int height, int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        BoardState boardState = gameBoard.CurrentState;

        // Act
        var actual = boardState[position];

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 0, Marker.X)]
    [DataRow(3, 3, 1, 1, Marker.O)]
    [DataRow(4, 4, 3, 3, Marker.X)]
    [DataRow(5, 2, 4, 1, Marker.O)]
    public void When_position_is_in_range_and_has_marker__returns_correct_marker(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        _ = gameBoard.TryPlaceMarker(marker, position);
        BoardState boardState = gameBoard.CurrentState;
        var expected = marker;

        // Act
        var actual = boardState[position];

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    [DataRow(3, 3, -1, 0)]
    [DataRow(3, 3, 0, -1)]
    [DataRow(3, 3, 3, 0)]
    [DataRow(4, 4, 0, 4)]
    [DataRow(5, 2, 5, 0)]
    public void When_position_is_out_of_range__returns_null(int width, int height, int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        BoardState boardState = gameBoard.CurrentState;

        // Act
        var actual = boardState[position];

        // Assert
        Assert.IsNull(actual);
    }

    // TODO: "When board state is snapshot does not reflect subsequent changes to board"?
    // i.e. when BoardState captures the board, any subsequent changes madeto the GameBoard aren't visible
    // through it
}