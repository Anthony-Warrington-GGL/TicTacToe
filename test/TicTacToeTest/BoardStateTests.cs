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

    [TestMethod]
    public void IndexOperator__when_positionY_is_less_than_1__throws_index_out_of_range_exception()
    {
        // Arrange
        var position = new Position{X = 1, Y = 0};
        var markers = new BoardStateCellContent[99, 1];

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(99)]
    public void IndexOperator__when_positionY_is_greater_than_the_board_length__throws_index_out_of_range_exception(int length)
    {
        // Arrange
        var position = new Position{X = 1, Y = length + 1};
        var markers = new BoardStateCellContent[200, length];

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }
    
    [TestMethod]
    public void IndexOperator__when_positionX_is_less_than_1__throws_correct_corresponding_exception_message()
    {
        // Arrange
        var position = new Position{X = 0, Y = 1};
        var markers = new BoardStateCellContent[1, 99];
        var expected = "X is invalid. The value of X cannot be less than 1.";

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        var actual = Assert.Throws<IndexOutOfRangeException>(act).Message;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IndexOperator__when_positionY_is_less_than_1__throws_correct_corresponding_exception_message()
    {
        // Arrange
        var position = new Position{X = 1, Y = 0};
        var markers = new BoardStateCellContent[99, 1];
        var expected = "Y is invalid. The value of Y cannot be less than 1.";

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        var actual = Assert.Throws<IndexOutOfRangeException>(act).Message;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(99)]
    public void IndexOperator__when_positionX_is_greater_than_the_board_width__throws_correct_corresponding_exception_message(int width)
    {
        // Arrange
        var position = new Position{X = width + 1, Y = 1};
        var markers = new BoardStateCellContent[width, 200];
        var expected = $"X is invalid. The value of X cannot be greater than {width}.";

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        var actual = Assert.Throws<IndexOutOfRangeException>(act).Message;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(99)]
    public void IndexOperator__when_positionY_is_greater_than_the_board_length__throws_correct_corresponding_exception_message(int length)
    {
        // Arrange
        var position = new Position{X = 1, Y = length + 1};
        var markers = new BoardStateCellContent[200, length];
        var expected = $"Y is invalid. The value of Y cannot be greater than {length}.";

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        var actual = Assert.Throws<IndexOutOfRangeException>(act).Message;
        Assert.AreEqual(expected, actual);
    }

    //IndexOperator__positionY_is_greater_than_the_board_length_and_positionX_is_greater_than_the_board_width__throws_correct_corresponding_exception_message
    //IndexOperator__positionY_is_less_than_1_and_positionX_is_less_than_1__throws_correct_corresponding_exception_message

    //IndexOperator__positionY_is_greater_than_the_board_length_and_positionX_is_less_than_1__throws_correct_corresponding_exception_message
    //IndexOperator__positionY_is_less_than_1_and_positionX_is_greater_than_the_board_width__throws_correct_corresponding_exception_message

    // TODO: Y tests for out of bounds - done

    // TODO: exception message tests

    // TODO: happy path tests (e.g. 1,1 gives object at array's 0,0. It returns the correct marker)
}
// TODO: Could you write an implementation that would cause the test to pass when it shouldn't?

// TODO: How does this deal with different board sizes?