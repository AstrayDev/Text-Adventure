using System.Collections.Generic;
using TextAdventure.Interactibles;
using TextAdventure.Dialogue;

namespace TextAdventure.Location;

public class Fields : Region
{
    public Fields(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room.Builder()
            .AddExits([Directions.North])
            .AddDescription("A larger opening")
            .AddScene(new Scene("src\\Scenes\\Dialogue\\Dialogue.json", SceneFlags.FieldsIntro))
            .AddItems(new List<IInteractable> { new Key("Key", "An old key", SceneFlags.None), new Stone("Stone", "Old Stone") })
        );

        AddRoom
        (
            new Position(0, 1),
            new Room.Builder()
            .AddExits([Directions.South, Directions.East])
            .AddDescription("A small alcove")
            .AddItems(new List<IInteractable> {new Relic("Relic", "An odd relic", SceneFlags.FieldsHasRelic)})
        );

        AddRoom
        (
            new Position(1, 1),
            new Room.Builder()
            .AddExits([Directions.West, Directions.AreaChange])
            .AddDescription("Near the shore")
            .AddConnectedRegion(OverWorld.RegionTable.Mountains)
            .AddScene(new Scene("src\\Scenes\\Dialogue\\Dialogue.json", SceneFlags.FieldsHasRelic))
            .AddKey(new Key("", "", SceneFlags.None))
            .SetLocked(true)
        );
    }
}