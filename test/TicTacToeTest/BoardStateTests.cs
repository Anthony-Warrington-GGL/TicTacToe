using System.Data;
using TicTacToe.Models;

namespace TicTacToeTest;

[TestClass]
public sealed class BoardStateTests
{
    [TestMethod]
    [DataRow(-1,1)]
    [DataRow(-5,2)]
    [DataRow(-99,3)]
    public void IndexOperator__when_positionX_is_less_than_bounds__throws_index_out_of_range_exception(int posX, int posY)
    {
        // Arrange
        var position = new Position{X = posX, Y = posY};
        var markers = new BoardStateCellContent[3,3]
        {
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},    // [0, ?]
            {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},        // [1, ?]
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}     // [2, ?]
        };

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [TestMethod]
    [DataRow(7,1)]
    [DataRow(100,1)]
    [DataRow(101,1)]
    public void IndexOperator__when_positionX_is_greater_than_bounds__throws_index_out_of_range_exception(int posX, int posY)
    {
        // Arrange
        var position = new Position{X = posX, Y = posY};
        var markers = new BoardStateCellContent[3,3]
        {
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},    // [0, ?]
            {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},        // [1, ?]
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}     // [2, ?]
        };

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [TestMethod]
    public void IndexOperator__when_positionY_is_less_than_bounds__throws_index_out_of_range_exception()
    {
        // Arrange
        var position = new Position{X = 1, Y = -1};
        var markers = new BoardStateCellContent[3,3]
        {
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},    // [0, ?]
            {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},        // [1, ?]
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}     // [2, ?]
        };

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }
    
    [TestMethod]
    public void IndexOperator__when_positionY_is_greater_than_bounds__throws_index_out_of_range_exception()
    {
        // Arrange
        var position = new Position{X = 1, Y = 100};
        var markers = new BoardStateCellContent[3,3]
        {
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X},    // [0, ?]
            {BoardStateCellContent.O, BoardStateCellContent.X, BoardStateCellContent.X},        // [1, ?]
            {BoardStateCellContent.O, BoardStateCellContent.empty, BoardStateCellContent.X}     // [2, ?]
        };

        // Act
        var board = new BoardState(markers);
        void act() { _ = board[position]; }

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);        
    }

    [TestMethod]
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
    public void IndexOperator__when_position_is_not_on_board__throws_index_out_of_range_exception()
    {
        // Arrange
        // Create a position that will not be on the board
        var position = new Position{X = 99, Y = 99};

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
        void act() { _ = board[position]; }

        // Assert
        // Check that the actual value returned is the value we expect
        Assert.Throws<IndexOutOfRangeException>(act);
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
// TODO: Could you write an implementation that would cause the test to pass when it shouldn't?

// TODO: How does this deal with different board sizes?