# C# Text Adventure

### A small text adventure I'm working on for learning and "fun".

### Features

- [x] Basic movment through areas
- [x] Dialogue System
- [x] Interconnected regions
- [x] Items

## Rough Design Principle

In this project I'm trying to make it "easy" to create regions and their respective rooms, allowing quick development of short and simple experinces.

### For Example

```
namespace TextAdventure.Location;

 public Fields(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room.Builder()
            .AddExits([Directions.North])
            .AddDescription("A larger opening")
            .AddScene(new Scene("src\\Scenes\\Dialogue\\Dialogue.json", SceneFlags.FieldsIntro))
            .AddItems(new List<IInteractable> { new Key("Key", "An old key"), new Stone("Stone", "Old Stone") })
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
            .AddKey(new Key())
            .SetLocked(true)
        );
    }
```

This is how regions are created, inherting from the base class Region which defines the regions name, entrance point, and size in its constructor. Then the region your making has rooms defined in its constructor.

Probably not the best but it allows the regions creation to be in one place with the other classes doing the rest of the work.
