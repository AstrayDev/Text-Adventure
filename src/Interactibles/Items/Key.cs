using System;
using TextAdventure.Player;

namespace TextAdventure.Interactibles;

public class Key : Item
{
    public Key(string name, string description, SceneFlags flag) : base(name, description, flag)
    {
    }

    public override void Interact(Player.Player player)
    {
        base.Interact(player);
    }
}