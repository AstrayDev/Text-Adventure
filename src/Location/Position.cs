namespace TextAdventure.Location;

/// <summary>
/// Handles positioning for player and rooms
/// </summary>
public struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}