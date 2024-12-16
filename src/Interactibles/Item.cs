using System;

namespace TextAdventure.Interactibles;

public class Item : IInteractable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SceneFlags Flag { get; }


    public Item() {}
    // This will be used as message if this item is needed for a locked room
    public Item(string description)
    {
        Description = description;
    }
    public Item(string name, string description, SceneFlags flag)
    {
        Name = name;
        Description = description;
        Flag = flag;
    }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Interact(Player.Player player)
    {
        Console.WriteLine($"You found a {Name}.");
        Console.WriteLine($"Description: {Description}");
        player.Flags.Add(Flag);
    }
}