namespace TicTacToe.Models;

/// <summary>
/// An interface to the game board.
/// Exposes the board state and ways to manipulate the board.
/// 
/// </summary>
public interface IGameBoard
{
    /// <summary>
    /// 
    /// </summary>
    public BoardState CurrentState {get;}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="marker"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool TryPlaceMarker(Marker marker, Position position);
}