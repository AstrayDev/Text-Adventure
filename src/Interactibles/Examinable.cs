using System;

namespace TextAdventure.Interactibles;

public class Examinable : IInteractable
{
    public string Description { get; init; }

    public Examinable(string description)
    {
        Description = description;
    }

    public void Interact()
    {
        Console.WriteLine($"{Description}");
    }
}