using System;
using System.Collections.Generic;
using TextAdventure.Location;
using TextAdventure.Player;

class Program
{
    static void Main(string[] args)
    {
        // Region fields = new Field("Fields", new Position(0, 0), 5, 5);
        // Player player = new Player("John", new Position(0, 0));
        // player.CurrentRegion = fields;

        // while (true)
        // {
        //     fields.PrintRoomDescription(player.CurrentRegion, player);
        //     Input.WaitForInput(player);
        // }

        Scene s = new Scene();

        object t = s.LoadJson("src/Dialogue.json");
        s.StartScene(t);
    }
}
