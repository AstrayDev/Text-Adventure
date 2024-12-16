namespace TextAdventure.Interactibles;

public class Stone : Examinable
{
    public Stone(string name, string description) : base(name, description)
    {
    }

    public override void Interact(Player.Player player)
    {
        base.Interact(player);
    }
}