using System;

namespace TextAdventure.Interactibles;

public interface IInteractable
{
    public string Name { get; }
    void Interact();
}