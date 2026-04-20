using System.Data;
using System.Diagnostics;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class GameBoardTests
{
    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty__returns_true(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = new();
        var expected = true;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty__space_is_set_to_marker(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = new();
        var expected = marker;

        // Act
        _ = gameBoard.TryPlaceMarker(marker, position);        
        var actual = gameBoard.GetMarkerAtPosition(position);
        
        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_not_empty__returns_false(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = new();
        var expected = false;
        _ = gameBoard.TryPlaceMarker(marker, position);

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);
        
        // Assert
        Assert.AreEqual(expected, actual);
    }

    // try to place marker when space is not empty, original value in that space doesn't change
    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_not_empty__original_marker_in_space_does_not_change(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = new();
        _ = gameBoard.TryPlaceMarker(Marker.X, position);
        var expected = gameBoard.GetMarkerAtPosition(position);

        // Act
        var oppositeMarker = marker == Marker.X 
            ? Marker.O
            : Marker.X;
        _ = gameBoard.TryPlaceMarker(oppositeMarker, position);
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}