# C# Text Adventure

### A small text adventure I'm working on for learning and "fun".

### Features

- [x] Basic movment through areas
- [x] Dialogue System
- [x] Interconnected regions
- [ ] Branching dialogue
- [x] Items
- [ ] Towns
- [ ] Combat

## Rough Design Principle

In this project I'm trying to make it "easy" to create regions and their respective rooms, allowing quick development of short and simple experinces.

### For Example

```
namespace TextAdventure.Location;

public class Field : Region
{

    public Field(string name, Position startPosition, int x, int y) : base(name, startPosition, x, y)
    {
        AddRoom
        (
            new Position(startPosition.X, startPosition.Y),
            new Room
            (
            [Directions.North],
            "A large opening with flowers and a nearby lake")
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
            new Room([Directions.West],
            "Near A shore with crashing waves")
        );
    }
}
```

This is how regions are created, inherting from the base class Region which defines the regions name, entrance point, and size in its constructor. Then the region your making has rooms defined in its constructor.

 Probably not the best but it allows the regions creation to be in one place with the other classes doing the rest of the work.