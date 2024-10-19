using System.Collections.Generic;
using System.Linq.Expressions;

namespace TextAdventure.Location;

public class Field : Region
{
    public Field(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room([Directions.North],
            "A large opening with flowers and a nearby lake"));

        AddRoom
        (
            new Position(0, 1),
            new Room([Directions.South, Directions.East],
            "A small alcove with vines and overgrowth")
        );

        AddRoom
        (
            new Position(1, 1),
            new Room([Directions.West],
            "Near A shore with crashing waves")
        );
    }
}