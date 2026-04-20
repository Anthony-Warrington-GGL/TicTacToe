using System.Security.Cryptography.X509Certificates;

namespace TicTacToe.Models;

/// <summary>
/// 
/// </summary>
public class GameBoard : IGameBoard
{
    public BoardState CurrentState => throw new NotImplementedException();

    private Dictionary<Position, Marker> boardMap = [];

    /// <summary>
    /// Tries to place a given marker at a given position on the board
    /// </summary>
    /// <param name="marker"> The given marker </param>
    /// <param name="position"> The given position </param>
    /// <returns> True when the position is empty, otherwise false </returns>
    public bool TryPlaceMarker(Marker marker, Position position)
    {
        if (boardMap.ContainsKey(position))
        {
            return false;
        }

        boardMap.Add(position, marker);
        return true;
    }

    // TODO: Write unit tests for everything you can do with this method...
    // TODO: when bad position is passed (i.e. out of range)
    // TODO: when position is passed for a position containing a marker
    // TODO: when position is passed for a position not containing a marker
    public Marker? GetMarkerAtPosition(Position position)
    {
        if (boardMap.ContainsKey(position))
        {
            return boardMap[position];
        }
        return null;
    }
}