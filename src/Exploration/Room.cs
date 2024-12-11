using System.Collections.Generic;
using TextAdventure.Interactibles;
using TextAdventure.Dialogue;

namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits { get; private set; }
    public OverWorld.RegionTable ConnectedRegion { get; private set; }
    public string Description { get; private set; }
    public Scene Scene { get; private set; }
    public Item Key { get; private set; }
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
    private Room() { }

    public class Builder
    {
        private readonly Room room;

        public Builder()
        {
            room = new Room();
        }

        public Builder AddExits(Directions[] exits)
        {
            room.Exits = exits;
            return this;
        }

        public Builder AddDescription(string description)
        {
            room.Description = description;
            return this;
        }

        public Builder AddScene(Scene scene)
        {
            room.Scene = scene;
            return this;
        }

        public Builder AddConnectedRegion(OverWorld.RegionTable connectedRegion)
        {
            room.ConnectedRegion = connectedRegion;
            return this;
        }

        public Builder AddItems(List<IInteractable> items)
        {
            room.Items = items;
            return this;
        }

        public Builder AddKey(Item key)
        {
            room.Key = key;
            return this;
        }

        public Builder SetLocked(bool locked)
        {
            room.Locked = locked;
            return this;
        }

        public Room Build()
        {
            return room;
        }
    }

    public bool ContainsScene()
    {
        return Scene == null ? false : true;
    }
}