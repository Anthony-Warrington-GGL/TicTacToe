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
    // replace 3x3 method with actual
    [TestMethod]
    public void TryPlaceMarker__when_position_is_out_of_range__returns_false()
    {
        // Arrange
        Position position = new() { X = 4, Y = 4};
        GameBoard gameBoard = Create3x3Board();
        bool expected = false;

        // Act
        var actual = gameBoard.TryPlaceMarker(Marker.X, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(2, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty_and_position_is_in_range__returns_true(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = Create3x3Board();

        var expected = true;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(2, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_empty_and_position_is_in_range__space_is_set_to_marker(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = Create3x3Board();
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
    [DataRow(2, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void TryPlaceMarker__when_space_is_not_empty_and_position_is_in_range__returns_false(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = Create3x3Board();
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
    [DataRow(2, 1, Marker.X, Marker.O)]
    [DataRow(0, 2, Marker.X, Marker.O)]
    public void TryPlaceMarker__when_space_is_not_empty_and_position_is_in_range__original_marker_in_space_does_not_change(int posX, int posY, Marker originalMarker, Marker newMarker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY};
        GameBoard gameBoard = Create3x3Board();
        _ = gameBoard.TryPlaceMarker(originalMarker, position);
        var expected = originalMarker;

        // Act
        _ = gameBoard.TryPlaceMarker(newMarker, position);
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(-1, 0, Marker.X)]
    [DataRow(0, -1, Marker.O)]
    [DataRow(3, 0, Marker.X)]
    [DataRow(0, 3, Marker.O)]
    public void TryPlaceMarker__when_position_is_out_of_range_on_valid_board__returns_false(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = Create3x3Board();
        bool expected = false;

        // Act
        var actual = gameBoard.TryPlaceMarker(marker, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // Not sure about this test - there's no reason it would happen with a dictionary, but if the
    // implementation ever changes from a dictionary, I feel like its still something that needs to be covered
    [TestMethod]
    [DataRow(-1, 0, Marker.X)]
    [DataRow(0, -1, Marker.O)]
    [DataRow(3, 0, Marker.X)]
    [DataRow(0, 3, Marker.O)]
    public void TryPlaceMarker__when_position_is_out_of_range__adjacent_valid_position_remains_null(int posX, int posY, Marker marker)
    {
        // Arrange
        Position outOfBounds = new() { X = posX, Y = posY };
        Position adjacentValid = new() { X = 0, Y = 0 };
        GameBoard gameBoard = Create3x3Board();

        // Act
        _ = gameBoard.TryPlaceMarker(marker, outOfBounds);
        var actual = gameBoard.GetMarkerAtPosition(adjacentValid);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    [DataRow(0, 0, Marker.X, 1, 1, Marker.O)]
    [DataRow(0, 0, Marker.O, 2, 2, Marker.X)]
    [DataRow(1, 0, Marker.X, 0, 1, Marker.O)]
    // TODO: when a marker is placed, none of the markers at other positions change
    public void TryPlaceMarker__when_two_markers_placed_at_different_positions__each_position_holds_correct_marker(
        int posX1, int posY1, Marker marker1, int posX2, int posY2, Marker marker2)
    {
        // Arrange
        Position position1 = new() { X = posX1, Y = posY1 };
        Position position2 = new() { X = posX2, Y = posY2 };
        GameBoard gameBoard = Create3x3Board();

        // Act
        _ = gameBoard.TryPlaceMarker(marker1, position1);
        _ = gameBoard.TryPlaceMarker(marker2, position2);
        var actual1 = gameBoard.GetMarkerAtPosition(position1);
        var actual2 = gameBoard.GetMarkerAtPosition(position2);

        // Assert
        Assert.AreEqual(marker1, actual1);
        Assert.AreEqual(marker2, actual2);
    }

    // <------------------------- GetMarkerAtPosition ------------------------->

    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(1, 0)]
    [DataRow(2, 1)]
    [DataRow(0, 2)]
    public void GetMarkerAtPosition__when_position_has_no_marker__returns_null(int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = Create3x3Board();

        // Act
        var actual = gameBoard.GetMarkerAtPosition(position);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    [DataRow(0, 1, Marker.O)]
    [DataRow(1, 0, Marker.O)]
    [DataRow(2, 1, Marker.X)]
    [DataRow(0, 2, Marker.X)]
    public void GetMarkerAtPosition__when_position_has_marker__returns_marker(int posX, int posY, Marker marker)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = Create3x3Board();
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
    public void GetMarkerAtPosition__when_position_is_out_of_range__throws_ArgumentOutOfRangeException(int posX, int posY)
    {
        // Arrange
        Position position = new() { X = posX, Y = posY };
        GameBoard gameBoard = Create3x3Board();

        // Act
        void act() {gameBoard.GetMarkerAtPosition(position);}

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}