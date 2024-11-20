namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits { get; private set; }
    public readonly Region ConnectedRegion;
    public readonly string Description;
    public Scene Scene { get; private set; }

    /// <summary>
    /// Make a new room
    /// </summary>
    /// <param name="exits">Exits to assign</param>
    /// <param name="description">Room descitpion</param>
    /// <param name="scene">Scene for the room to play</param>
    public Room(Directions[] exits, string description, Scene scene = null)
    {
        Exits = exits;
        Description = description;
        Scene = scene;
    }

    public bool ContainsScene()
    {
        return Scene == null ? false : true;
    }
}