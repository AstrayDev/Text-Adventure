namespace TextAdventure.Interactibles;

public class Relic : Item
{
    public Relic() { }
    public Relic(string name, string description, SceneFlags flag) : base(name, description, flag)
    { }
    public Relic(string name, string description) : base(name, description)
    { }

    public override void Interact(Player.Player player)
    {
        base.Interact(player);
    }
}