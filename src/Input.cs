using System;
using System.Linq;
using Spectre.Console;
using TextAdventure.Location;
using TextAdventure.Interactibles;
using TextAdventure.Save;

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
    public static void WaitForInput(ref Player player)
    {
        switch (UI.State)
        {
            case UIStates.MainMenu:
                MainMenuInput(ref player);
                break;

            case UIStates.Action:
                ActionMenuInput();
                break;

            case UIStates.Examine:
                ExamineMenuInput(player);
                break;

            case UIStates.Inventory:
                InventoryInput(player);
                break;

            case UIStates.Move:
                MoveMenuInput(player);
                break;

            case UIStates.AreaTransition:
                AreaTransitionInput();
                break;

            case UIStates.Menu:
                MenuInput(player);
                break;

            default:
                Console.WriteLine("Unassigned ui state");
                break;
        }
    }

    private static void MainMenuInput(ref Player player)
    {
        var input = AnsiConsole.Prompt
        (
            new SelectionPrompt<string>()
            .AddChoices("New Game", "Load", "Quit")
        );

        switch (input)
        {
            case "New Game":
                player.Name = "John";
                player.Position = new Position(0, 0);
                player.Flags.Add(SceneFlags.FieldsIntro);
                player.ChangeRegion("Fields", false);
                player.CurrentRegionName = "Fields";
                UI.SetState(UIStates.Action);
                break;

            case "Load":
                player = SaveManager.Load<Player>("src\\Saves\\PlayerSave.json");
                player.LoadSetup(true);
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

    private static void ActionMenuInput()
    {
        var input = AnsiConsole.Prompt
        (
            new TextPrompt<string>("")
        ).ToLower();

        switch (input)
        {
            case "move":
                UI.SetState(UIStates.Move);
                break;

            case "examine":
                UI.SetState(UIStates.Examine);
                break;

            case "inventory":
                UI.SetState(UIStates.Inventory);
                break;

            case "menu":
                UI.SetState(UIStates.Menu);
                break;
        }
    }

    private static void ExamineMenuInput(Player player)
    {
        if (player.CurrentRoom.Items.Count > 0)
        {
            var input = AnsiConsole.Prompt
            (
                new TextPrompt<string>("")
            ).ToLower();

            var interactable = player.CurrentRoom.Items.FirstOrDefault(i => i.Name.ToLower() == input);

            if (interactable != null)
            {
                interactable.Interact();

                if (interactable is Item)
                {
                    player.Items.Add((Item)interactable);
                }

                player.CurrentRoom.Items.Remove(interactable);
                Console.ReadLine();
            }
            // waits for input then returns so player can keep collecting items
            // since ui state doesn't update it will loop back to examine menu
            if (input == "back")
            {
                UI.SetState(UIStates.Action);
                return;
            }
        }
        // if there are no items go back to action menu
        else
        {
            Console.ReadLine();
            UI.SetState(UIStates.Action);
        }
    }

    private static void InventoryInput(Player player)
    {
        Console.ReadLine();
        UI.SetState(UIStates.Action);
    }

    private static void AreaTransitionInput()
    {
        Console.ReadLine();
        UI.SetState(UIStates.Action);
    }

    private static void MenuInput(Player player)
    {
        var input = AnsiConsole.Prompt
        (
            new TextPrompt<string>("")
        ).ToLower();

        switch (input)
        {
            case "save":
                SaveManager.Save("src\\Saves\\PlayerSave.json", player);
                AnsiConsole.MarkupLine("[green]Save Succesfull![/]");
                Console.ReadLine();
                break;

            case "quit":
                UI.SetState(UIStates.MainMenu);
                break;

            case "back":
                UI.SetState(UIStates.Action);
                break;

            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }

    private static void MoveMenuInput(Player player)
    {
        Position pointToMove = player.Position;
        Directions directionToMove = Directions.Null;

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

            case "leave":
                directionToMove = Directions.AreaChange;
                break;

            case "back":
                UI.SetState(UIStates.Action);
                break;

            default:
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                break;
        }

        if (player.CurrentRoom.Exits.Contains(directionToMove))
        {
            if (directionToMove == Directions.AreaChange)
            {
                player.ChangeRegion(player.CurrentRoom.ConnectedRegion.ToString(), false);
                UI.SetState(UIStates.AreaTransition);
                return;
            }

            player.Move(pointToMove);

            if (player.CurrentRoom.Locked)
            {
                if (!player.Items.Any(item => item.GetType() == player.CurrentRoom.Key.GetType()))
                {
                    Console.WriteLine("EEERRRRRRRRR");
                    Console.ReadLine();
                    player.Move(player.PreviousPosition);
                    return;
                }

                else
                {
                    Item itemToRemove = player.Items.Find(item => item.GetType() == player.CurrentRoom.Key.GetType());
                    player.Items.Remove(itemToRemove);
                    player.CurrentRoom.Locked = false;
                }
            }

            UI.SetState(UIStates.Action);
        }

        if (player.CurrentRoom.ContainsScene() && player.CurrentRoom.Scene.ShouldScenePlay(player))
        {
            UI.SetState(UIStates.Scene);
        }
    }
}