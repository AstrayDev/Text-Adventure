using System;
using System.Collections.Generic;
using TextAdventure.Interactibles;

namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits { get; private set; }
    public readonly OverWorld.RegionTable ConnectedRegion;
    public readonly string Description;
    public Scene Scene { get; private set; }
    public List<IInteractable> Items { get; private set; } = new List<IInteractable>();

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

    public Room(Directions[] exits, string description, OverWorld.RegionTable connectedRegion)
    {
        Exits = exits;
        Description = description;
        ConnectedRegion = connectedRegion;
    }

    public Room(Directions[] exits, string description, List<IInteractable> items)
    {
        Exits = exits;
        Description = description;
        Items = items;
        Items.Add(new Potion("", ""));
    }

    public bool ContainsScene()
    {
        return Scene == null ? false : true;
    }
}