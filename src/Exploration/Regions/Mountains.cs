namespace TextAdventure.Location;

public class Mountains : Region
{
    public Mountains(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room
            (
                [Directions.AreaChange],
                "Beeeeg Mountain",
                OverWorld.RegionTable.Fields
            )
        );
    }
}