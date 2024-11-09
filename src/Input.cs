using System;
using System.Linq;
using Spectre.Console;
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
        switch(UI.State)
        {
            case UIStates.MainMenu:
            MainMenuInput();
            break;

            case UIStates.Action:
            ActionMenuInput(player);
            break;

            case UIStates.Move:
            MoveMenuInput(player);
            break;

            default:
            Console.WriteLine("Unassigned ui state");
            break;
        }
    }

    private static void MainMenuInput()
    {
        var input = AnsiConsole.Prompt
        (
            new SelectionPrompt<string>()
            .AddChoices("Start Game", "Quit")
        );

        switch(input)
        {
            case "Start Game":
            UI.SetState(UIStates.Action);
            break;

            case "Quit":
            Environment.Exit(0);
            break;

            default:
            Console.WriteLine("How did you even mess this up?");
            break;
        }
    }

    private static void ActionMenuInput(Player player)
    {
        var input = AnsiConsole.Prompt
        (
            new TextPrompt<string>("")
        ).ToLower();

        switch(input)
        {
            case "move":
            UI.SetState(UIStates.Move);
            break;
        }
    }

    private static void MoveMenuInput(Player player)
    {
        Position pointToMove = player.Position;
        Directions directionToMove = Directions.North;
        var input = AnsiConsole.Prompt
        (
            new TextPrompt<string>("")
        ).ToLower();

        switch (input)
        {
            case "north":
                pointToMove.Y++;
                directionToMove = Directions.North;
                break;

            case "west":
                pointToMove.X--;
                directionToMove = Directions.West;
                break;

            case "east":
                pointToMove.X++;
                directionToMove = Directions.East;
                break;

            case "south":
                pointToMove.Y--;
                directionToMove = Directions.South;
                break;

            default:
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                break;
        }

        if (player.GetCurrentRoom().Exits.Contains(directionToMove))
        {
            player.Move(pointToMove);
        }

        else
        {
            Console.WriteLine("Nothing there");
            Console.ReadLine();
        }

        if (player.GetCurrentRoom().ContainsScene() && player.GetCurrentRoom().Scene.ShouldScenePlay(player))
        {
            UI.SetState(UIStates.Scene);
        }
    }
}