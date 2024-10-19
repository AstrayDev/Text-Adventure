namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits {get; private set;}
    public string Description {get; private set;}

    /// <summary>
    /// Make a new room
    /// </summary>
    /// <param name="exits">Exits to assign</param>
    /// <param name="description">Room descitpion</param>
    public Room(Directions[] exits, string description)
    {
        Exits = exits;
        Description = description;
    }
}