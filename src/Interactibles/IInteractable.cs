namespace TextAdventure.Interactibles;

public interface IInteractable
{
    public string Name { get; }
    void Interact(Player.Player player);
}