using System;
using TextAdventure.Location;
using Region = TextAdventure.Location.Region;
using TextAdventure.Player;
using TextAdventure.Save;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();

        while (true)
        {
            UI.Draw(player);
            Input.WaitForInput(ref player);
            Console.Clear();
        }
    }
}
