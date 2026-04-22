using System.Data;
using System.Diagnostics;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class GameBoardTests
{
    private const int DefaultBoardWidth = 3;
    private const int DefaultBoardHeight = 3;
    private static GameBoard CreateDefaultBoard() => new(DefaultBoardWidth, DefaultBoardHeight);

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty__returns_true(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = CreateDefaultBoard();

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
        GameBoard gameBoard = CreateDefaultBoard();
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
        GameBoard gameBoard = CreateDefaultBoard();
        var expected = false;
        _ = gameBoard.TryPlaceMarker(marker, position);

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);
        
        // Assert
        Assert.AreEqual(expected, actual);
    }

    // try to place marker when space is not empty, original value in that space doesn't change
    [TestMethod]
    [DataRow(0, 1, Marker.O, Marker.X)]
    [DataRow(1, 0, Marker.O, Marker.X)]
    [DataRow(3, 1, Marker.X, Marker.O)]
    [DataRow(0, 2, Marker.X, Marker.O)]
    public void TryPlaceMarker__when_space_is_not_empty__original_marker_in_space_does_not_change(int posX, int posY, Marker originalMarker, Marker newMarker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = CreateDefaultBoard();
        _ = gameBoard.TryPlaceMarker(originalMarker, position);
        var expected = originalMarker;

        // Act
        _ = gameBoard.TryPlaceMarker(newMarker, position);
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(1, 0)]
    [DataRow(3, 1)]
    [DataRow(0, 2)]
    public void GetMarkerAtPosition__when_position_has_no_marker__returns_null(int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = CreateDefaultBoard();

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(3, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void GetMarkerAtPosition__when_position_has_marker__returns_marker(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = CreateDefaultBoard();
        _ = gameBoard.TryPlaceMarker(marker, position);
        var expected = marker;

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(3, 3)]
    [DataRow(99, 99)]
    public void GetMarkerAtPosition__when_position_is_out_of_range__returns_null(int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = CreateDefaultBoard();

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNull(actual);
    }
}