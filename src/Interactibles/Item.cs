using System;

namespace TextAdventure.Interactibles;

public class Item : IInteractable
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Interact()
    {
        Console.WriteLine($"You found a {Name}.");
        Console.WriteLine($"Description: {Description}");
    }
}