namespace TextAdventure.Location;

public class Dungeon : Region
{
    public Dungeon(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room.Builder()
            .AddExits([])
            .AddDescription("")
        );
    }
}