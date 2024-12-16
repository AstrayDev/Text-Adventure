using System;
using TextAdventure.Player;

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
