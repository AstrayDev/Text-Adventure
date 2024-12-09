using System;

namespace TextAdventure.Interactibles;

public class Key : Item
{
    public Key(string name, string description) : base(name, description)
    {
    }

    public override void Interact()
    {
        base.Interact();
    }
}