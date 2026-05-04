using System.Data;
using TicTacToe.Models;

namespace TicTacToeTest;
// TODO: First define BoardState, then write Tests for what you want BoardState to do then do implementation

[TestClass]
public sealed class GameBoardTests
{
    private const int DefaultBoardWidth = 3;
    private const int DefaultBoardHeight = 3;
    private static GameBoard Create3x3Board() => new(DefaultBoardWidth, DefaultBoardHeight);

    // <------------------------- Constructor ------------------------->

    [TestMethod]
    [DataRow(3, 3)]
    [DataRow(1, 1)]
    [DataRow(5, 10)]
    public void Constructor__when_given_valid_width_and_height__creates_board_successfully(int width, int height)
    {
        // Arrange / Act
        GameBoard gameBoard = new(width, height);

        // Assert
        Assert.IsNotNull(gameBoard);
    }

    [TestMethod]
    [DataRow(0, 3)]
    [DataRow(3, 0)]
    [DataRow(0, 0)]
    // is it worth splitting this into separate tests for height and width?
    public void Constructor__when_given_zero_width_or_height__throws_ArgumentOutOfRangeException(int width, int height)
    {
        // Act
        void act() { new GameBoard(width, height); }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    // is it worth splitting this into separate tests for height and width?
    [TestMethod]
    [DataRow(-1, 3)]
    [DataRow(3, -1)]
    [DataRow(-1, -1)]
    public void Constructor__when_given_negative_width_or_height__throws_ArgumentOutOfRangeException(int width, int height)
    {
        // Act
        void act() { new GameBoard(width, height); }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    // <------------------------- TryPlaceMarker ------------------------->

    // This could be four tests - Marker.X < 0, X > BoardSize.X, same for Y
    [TestMethod]
    [DataRow(3, 3, 4, 4, Marker.X)]
    [DataRow(1, 1, 1, 1, Marker.O)]
    [DataRow(2, 5, 2, 5, Marker.X)]
    public void TryPlaceMarker__when_position_is_out_of_range__returns_false(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        bool expected = false;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 1, Marker.O)]
    [DataRow(3, 3, 1, 0, Marker.O)]
    [DataRow(4, 4, 3, 3, Marker.X)]
    [DataRow(5, 2, 4, 1, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty_and_position_is_in_range__returns_true(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        var expected = true;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 1, Marker.O)]
    [DataRow(3, 3, 1, 0, Marker.O)]
    [DataRow(4, 4, 3, 3, Marker.X)]
    [DataRow(5, 2, 4, 1, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty_and_position_is_in_range__space_is_set_to_marker(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        var expected = marker;

        // Act
        _ = gameBoard.TryPlaceMarker(marker, position);
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 1, Marker.O)]
    [DataRow(3, 3, 1, 0, Marker.O)]
    [DataRow(4, 4, 3, 3, Marker.X)]
    [DataRow(5, 2, 4, 1, Marker.X)]
    public void TryPlaceMarker__when_space_is_not_empty_and_position_is_in_range__returns_false(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        var expected = false;
        _ = gameBoard.TryPlaceMarker(marker, position);

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 1, Marker.O, Marker.X)]
    [DataRow(3, 3, 1, 0, Marker.O, Marker.X)]
    [DataRow(4, 4, 3, 3, Marker.X, Marker.O)]
    [DataRow(5, 2, 4, 1, Marker.X, Marker.O)]
    public void TryPlaceMarker__when_space_is_not_empty_and_position_is_in_range__original_marker_in_space_does_not_change(int width, int height, int posX, int posY, Marker originalMarker, Marker newMarker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        _ = gameBoard.TryPlaceMarker(originalMarker, position);
        var expected = originalMarker;

        // Act
        _ = gameBoard.TryPlaceMarker(newMarker, position);
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(3, 3, -1, 0, Marker.X)]
    [DataRow(3, 3, 0, -1, Marker.O)]
    [DataRow(4, 4, 4, 0, Marker.X)]
    [DataRow(5, 2, 0, 2, Marker.O)]
    public void TryPlaceMarker__when_position_is_out_of_range_on_valid_board__returns_false(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        bool expected = false;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 0, Marker.X)]
    [DataRow(3, 3, 1, 1, Marker.O)]
    [DataRow(4, 4, 1, 0, Marker.X)]
    public void TryPlaceMarker__when_marker_is_placed__every_other_position_remains_unchanged(
        int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);

        // Act
        _ = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Position otherPosition = new() { X = x, Y = y };
                if (otherPosition == position) continue;
                Assert.IsNull(gameBoard.GetMarkerAtPosition(otherPosition));
            }
        }
    }

    // <------------------------- GetMarkerAtPosition ------------------------->

    [TestMethod]
    [DataRow(3, 3, 0, 1)]
    [DataRow(3, 3, 1, 0)]
    [DataRow(4, 4, 3, 3)]
    [DataRow(5, 2, 4, 1)]
    public void GetMarkerAtPosition__when_position_has_no_marker__returns_null(int width, int height, int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    [DataRow(3, 3, 0, 1, Marker.O)]
    [DataRow(3, 3, 1, 0, Marker.O)]
    [DataRow(4, 4, 3, 3, Marker.X)]
    [DataRow(5, 2, 4, 1, Marker.X)]
    public void GetMarkerAtPosition__when_position_has_marker__returns_marker(int width, int height, int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);
        _ = gameBoard.TryPlaceMarker(marker, position);
        var expected = marker;

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    [DataRow(3, 3, -1, 0)]
    [DataRow(3, 3, 0, -1)]
    [DataRow(3, 3, 3, 3)]
    [DataRow(4, 4, 99, 99)]
    public void GetMarkerAtPosition__when_position_is_out_of_range__throws_ArgumentOutOfRangeException(int width, int height, int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = new(width, height);

        // Act
        void act() { gameBoard.GetMarkerAtPosition(position); }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}