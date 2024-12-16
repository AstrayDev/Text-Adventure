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
    /// Make a new room using a builder to allow individual componets to be addes easily
    /// </summary>
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