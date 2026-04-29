using System.Security.Cryptography.X509Certificates;

namespace TicTacToe.Models;

/// <summary>
/// 
/// </summary>
public class GameBoard : IGameBoard
{
    public BoardState CurrentState => throw new NotImplementedException();

    private Dictionary<Position, Marker> boardMap = [];

    private readonly int _width;

    private readonly int _height;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public GameBoard(int width, int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), 
                $"Width must be greater than 0, but was {width}.");
        }
        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), 
                $"Height must be greater than 0, but was {height}.");
        }
        
        _width = width;
        _height = height;
    }

    /// <summary>
    /// Tries to place a given marker at a given position on the board
    /// </summary>
    /// <param name="marker"> The given marker </param>
    /// <param name="position"> The given position </param>
    /// <returns> True when the position is empty, otherwise false </returns>
    public bool TryPlaceMarker(Marker marker, Position position)
    {
        if (IsPositionOutOfBounds(position) || boardMap.ContainsKey(position))
        {
            return false;
        }

        boardMap.Add(position, marker);
        return true;
    }
  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public Marker? GetMarkerAtPosition(Position position)
    {
        ValidatePosition(position);

        if (boardMap.ContainsKey(position))
        {
            return boardMap[position];
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void ValidatePosition(Position position)
    {
        if (IsPositionOutOfBounds(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), 
                $"Position ({position.X}, {position.Y}) is out of bounds for a {_width}x{_height} board.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private bool IsPositionOutOfBounds(Position position)
    {
        return position.X < 0 || position.X >= _width || position.Y < 0 || position.Y >= _height;
    }
}