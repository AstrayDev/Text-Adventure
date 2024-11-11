using System;
using TextAdventure.Location;
using Region = TextAdventure.Location.Region;
using TextAdventure.Player;

class Program
{
    static void Main(string[] args)
    {
        Region fields = new Field("Fields", new Position(0, 0), 5, 5);
        Player player = new Player("John", new Position(0, 0));
        player.Flags.Add(SceneFlags.FieldsIntro);
        player.CurrentRegion = fields;

        while (true)
        {
            UI.Draw(player);
            Input.WaitForInput(player);
            Console.Clear();
        }
    }
}
