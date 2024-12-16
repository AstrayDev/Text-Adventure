namespace TextAdventure.Interactibles;

public class Key : Item
{
    public Key() { }
    public Key(string description) : base(description)
    { }
    public Key(string name, string description, SceneFlags flag) : base(name, description, flag)
    { }
    public Key(string name, string description) : base(name, description)
    { }

    public override void Interact(Player.Player player)
    {
        base.Interact(player);
    }
}