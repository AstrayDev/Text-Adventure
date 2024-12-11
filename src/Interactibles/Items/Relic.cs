namespace TextAdventure.Interactibles;

public class Relic : Item
{
    public Relic(string name, string description, SceneFlags flag) : base(name, description, flag)
    {
    }

    public override void Interact(Player.Player player)
    {
        base.Interact(player);
    }
}