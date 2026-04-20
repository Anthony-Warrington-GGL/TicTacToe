namespace TicTacToe.Models;

//TODO: Write unit tests to check things like the built-in equality inherited from being a 'record'
public readonly record struct Position
{
    public int X 
    {
        get;
        init;
    }

    public int Y 
    {
        get;
        init;
    }
}