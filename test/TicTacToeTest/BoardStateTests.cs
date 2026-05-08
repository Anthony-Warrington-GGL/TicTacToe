using System.Data;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class BoardStateTests
{
    [TestMethod]
    // TryPlaceMarker__when_marker_is_placed__every_other_position_remains_unchanged
    // when a position is on the board then it returns the value
    public void IndexOperator__when_position_is_1_1_returns_the_value_at_position()
    {
        // Arrange
            // Create a position that will be on the board
            var position = new Position{X = 1, Y = 1};
            var expected = BoardStateCellContent.empty;

            // Create a 2D array to pass to the board
            var markers = new BoardStateCellContent[3,3]
            {
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}
            };

            // Create a board
            var board = new BoardState(markers);

        // Act
            // Try to get the value at the position
            var actual = board[position];

        // Assert
            // Check that the actual value returned is the value we expect
            Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IndexOperator__when_position_is_1_1_and_is_X__returns_X()
    {
        // Arrange
            // Create a position that will be on the board
            var position = new Position{X = 1, Y = 1};
            var expected = BoardStateCellContent.X;

            // Create a 2D array to pass to the board
            var markers = new BoardStateCellContent[3,3]
            {
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}
            };

            // Create a board
            var board = new BoardState(markers);

        // Act
            // Try to get the value at the position
            var actual = board[position];

        // Assert
            // Check that the actual value returned is the value we expect
            Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IndexOperator__when_position_is_on_board__returns_corresponding_value_at_that_position()
    {
        // Arrange
        var markers = new BoardStateCellContent[3,3]
        {
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},    // [0, ?]
            {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},        // [1, ?]
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}     // [2, ?]
        };
        var board = new BoardState(markers);

        // Act & Assert
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                var expected = markers[r,c];
                var position = new Position{X = c, Y = r};
                var actual = board[position];
                Assert.AreEqual(expected, actual);
            }
        }
    }

    [TestMethod]
    public void IndexOperator__when_array_passed_to_constructor_is_changed__returns_original_value()
    {
        // Arrange
            // Create a 2D array to pass to the board
            var markers = new BoardStateCellContent[3,3]
            {
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},
                {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}
            };
            var expected = BoardStateCellContent.O;

            // Create a board
            var board = new BoardState(markers);

        // Act
            // Try to get the value at the position
            markers[0,0] = BoardStateCellContent.empty;
            var position = new Position {X = 0, Y = 0};
            var actual = board[position];

        // Assert
            // Check that the actual value returned is the value we expect
            Assert.AreEqual(expected, actual);
    }
}