using System;
using TextAdventure.Player;

namespace TextAdventure.Interactibles;

public class Item : IInteractable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SceneFlags Flag { get; }

    public Item(string name, string description, SceneFlags flag = SceneFlags.None)
    {
        Name = name;
        Description = description;
        Flag = flag;
        
    }

    public virtual void Interact(Player.Player player)
    {
        Console.WriteLine($"You found a {Name}.");
        Console.WriteLine($"Description: {Description}");
        player.Flags.Add(Flag);
    }
}