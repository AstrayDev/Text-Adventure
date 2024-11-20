using System.Collections.Generic;
using TextAdventure.Location;

namespace TextAdventure.Player;

public class Player
{
    public string Name { get; private set; }
    public Position Position { get;  set; }
    public Region CurrentRegion { get; set; }
    public bool InGame = false;
    public List<SceneFlags> Flags = new List<SceneFlags>();

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

    public Room GetCurrentRoom()
    {
        return CurrentRegion.Rooms[Position.X][Position.Y];
    }
}