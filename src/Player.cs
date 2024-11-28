using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TextAdventure.Location;

namespace TextAdventure.Player;

public class Player
{
    public string Name { get; private set; }
    public Position Position { get;  set; }
    public Region CurrentRegion { get; set; }
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

    public void ChangeRegion(string region)
    {
        Region newRegion = null;
        switch (region)
        {
            case "Fields":
               newRegion = new Fields("Fields", new Position(0, 0), 5, 5);
            break;

            case "Mountains":
                newRegion = new Mountains("Mountains", new Position(0, 0), 5, 5);
            break;
        }

        CurrentRegion = newRegion;
        Position = newRegion.StartPosition;
    }

    public Room GetCurrentRoom()
    {
        return CurrentRegion.Rooms[Position.X][Position.Y];
    }
}