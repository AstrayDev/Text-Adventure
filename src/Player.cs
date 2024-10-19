using TextAdventure.Location;

namespace TextAdventure.Player;

public class Player
{
    public string Name { get; private set; }
    public Position Position { get; private set; }
    public bool IsInCoversation = false;
    public Region CurrentRegion { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
    }

    /// <summary>
    /// Move one room over in specified direction
    /// </summary>
    /// <param name="direction">Direction to move in</param>
    public void Move(Position direction)
    {
        Position = direction;
    }
}