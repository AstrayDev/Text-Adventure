using System.Collections.Generic;
using TextAdventure.Interactibles;

namespace TextAdventure.Location;

public class Fields : Region
{
    public Fields(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room
            (
                [Directions.North],
                "A large opening with flowers and a nearby lake",
                new List<IInteractable>
                {
                    new Key("Key", "Unlocks doors...of some kind"),
                    new Stone("Stone", "Just an old stone")
                })
        );

        AddRoom
        (
            new Position(0, 1),
            new Room([Directions.South, Directions.East],
                "A small alcove with vines and overgrowth",
                new Scene
                (
                    "src\\Scenes\\Dialogue\\Dialogue.json",
                    SceneFlags.FieldsIntro
                ))
        );

        AddRoom
        (
            new Position(1, 1),
            new Room([Directions.West, Directions.AreaChange],
                "Near A shore with crashing waves",
                OverWorld.RegionTable.Mountains,
                new Key("", ""), true)
        );
    }
}