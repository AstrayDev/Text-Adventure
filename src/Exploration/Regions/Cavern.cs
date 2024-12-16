using System.Collections.Generic;
using TextAdventure.Interactibles;
using TextAdventure.Dialogue;

namespace TextAdventure.Location;

public class Cavern : Region
{
    public Cavern(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room.Builder()
            .AddExits([Directions.North, Directions.East, Directions.West])
            .AddDescription("Outside the ominous cave")
            .AddScene(new Scene("src\\Scenes\\Dialogue\\Dialogue.json", SceneFlags.Intro))
        );

        AddRoom
        (
            new Position(0, 0),
            new Room.Builder()
            .AddExits([Directions.East])
            .AddDescription("A small opening with lots of fallen trees you playing on earlier")
            .AddItems(new List<IInteractable> {new Key("Key", "The key to the old door of the cavern")})
        );

        AddRoom
        (
            new Position(2, 0),
            new Room.Builder()
            .AddExits([Directions.West])
            .AddDescription("The beginning a trail. This isn't where you lost the key")
        );

        AddRoom
        (
            new Position(1, 1),
            new Room.Builder()
            .AddExits([Directions.West, Directions.AreaChange])
            .AddDescription("The entrance of the cave...")
            .AddKey(new Key("You need to key to unlock the door"))
            .SetLocked(true)
            .AddConnectedRegion(OverWorld.RegionTable.Dungeon)
        );
    }
}