using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TextAdventure.Interactibles;

namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits { get; }
    public readonly OverWorld.RegionTable ConnectedRegion;
    public readonly string Description;
    public Scene Scene { get; }
    public Item Key { get; }
    public bool Locked = false;
    public List<IInteractable> Items { get; private set; } = new List<IInteractable>();

    /// <summary>
    /// Make a new room
    /// </summary>
    /// <param name="exits">Exits to assign</param>
    /// <param name="description">Room descitpion</param>
    /// <param name="scene">Scene for the room to play</param>
    /// <param name="connectedRegion">Region that you can switch to</param>>
    /// <param name="items">List of items in the room</param>>
    /// <param name="key">Necessary item to continue</param>>
    /// <param name="locked">Sets if the room is locked or not</param>
    public Room(Directions[] exits, string description, Scene scene, OverWorld.RegionTable connectedRegion,
        List<IInteractable> items, Item key, bool locked)
    {
        Exits = exits;
        Description = description;
        Scene = scene;
        ConnectedRegion = connectedRegion;
        Items = items;
        Key = key;
        Locked = locked;
    }

    public Room(Directions[] exits, string description, OverWorld.RegionTable connectedRegion, Item key, bool locked)
    {
        Exits = exits;
        Description = description;
        ConnectedRegion = connectedRegion;
        Key = key;
        Locked = locked;
    }

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
    }

    public bool ContainsScene()
    {
        return Scene == null ? false : true;
    }
}