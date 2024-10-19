using System;
using System.Linq;
using TextAdventure.Location;

namespace TextAdventure.Player;

/// <summary>
/// Handles player inputs
/// </summary>
public static class Input
{
    /// <summary>
    /// Waits for player input to perform actions
    /// </summary>
    /// <param name="player">The player that's making commands</param>
    public static void WaitForInput(Player player)
    {
        Position pointToMove = player.Position;
        Directions directionToMove = Directions.North;
        string? input = Console.ReadLine();

        switch (input)
        {
            case "n":
            pointToMove.Y++;
            directionToMove = Directions.North;
            break;

            case "w":
            pointToMove.X--;
            directionToMove = Directions.West;
            break;

            case "e":
            pointToMove.X++;
            directionToMove = Directions.East;
            break;

            case "s":
            pointToMove.Y--;
            directionToMove = Directions.South;
            break;

            default:
            Console.WriteLine("Invalid input");
            break;
        }

        if (player.CurrentRegion.Rooms[player.Position.X][player.Position.Y].Exits.Contains(directionToMove))
        {
            player.Move(pointToMove);
        }

        else
        {
            Console.WriteLine("Nothing there");
        }
    }
}