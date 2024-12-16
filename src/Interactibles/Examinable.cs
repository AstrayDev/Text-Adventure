using System;

namespace TextAdventure.Interactibles;

public class Examinable : IInteractable
{
    public string Name { get; init;}
    public string Description { get; init; }

    public Examinable(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Interact(Player.Player player)
    {
        Console.WriteLine($"It's a {Name}");
        Console.WriteLine($"{Description}");
    }
}