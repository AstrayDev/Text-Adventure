using System;

namespace TextAdventure.Interactibles;

public class Potion : Item
{
    public Potion(string name, string description) : base(name, description)
    {
    }

    public override void Interact()
    {
        base.Interact();
    }
}