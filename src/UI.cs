using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using TextAdventure.Player;

public enum UIStates
{
    MainMenu,
    Action,
    Move,
    AreaTransition,
    Examine,
    Inventory,
    Scene,
    Menu
}

public static class UI
{
    public static UIStates State { get; private set; } = UIStates.MainMenu;
    public static IRenderable CurrentUI { get; private set; }

    public static void SetState(UIStates state)
    {
        if (Enum.IsDefined(typeof(UIStates), state))
        {
            State = state;
        }
        else
        {
            Console.WriteLine("State doesn't exist");
        }
    }

    public static void Draw(Player player)
    {
        if (State != UIStates.Scene && State != UIStates.MainMenu)
        {
            var panel = new Panel(player.CurrentRoom.Description);
            AnsiConsole.Write(panel);
        }
        switch (State)
        {
            case UIStates.MainMenu:
                CurrentUI = DrawMainMenu();
                break;

            case UIStates.Action:
                CurrentUI = DrawActionMenu();
                break;

            case UIStates.Move:
                CurrentUI = DrawMoveMenu(player);
                break;

            case UIStates.Examine:
                CurrentUI = DrawExamineMenu(player);
                break;

            case UIStates.Inventory:
                CurrentUI = DrawInventoryMenu(player);
                break;

            case UIStates.AreaTransition:
                CurrentUI = DrawAreaTransition(player);
                break;

            case UIStates.Menu:
                CurrentUI = DrawMenu(player);
                break;

            case UIStates.Scene:
                DrawScene(player.CurrentRoom.Scene.Text);
                player.Flags.Remove(player.CurrentRoom.Scene.Flag);
                CurrentUI = DrawActionMenu();
                break;
        }
        AnsiConsole.Write(CurrentUI);
    }

    public static IRenderable DrawMainMenu()
    {
        var table = new Table();

        table.AddColumn("Game");
        table.Border = TableBorder.Double;

        return table;
    }

    private static IRenderable DrawActionMenu()
    {
        var table = new Table();
        table.AddColumn(new TableColumn("Choose an action"));
        table.AddRow("Move");
        table.AddRow("Examine");
        table.AddRow("Inventory");
        table.AddRow("Menu");

        return table;
    }

    private static IRenderable DrawExamineMenu(Player player)
    {
        var table = new Table();

        if (player.CurrentRoom.Items.Count > 0)
        {
            table.AddColumn(new TableColumn("Examine which item? Enter back to exit"));

            for (int i = 0; i < player.CurrentRoom.Items.Count; i++)
            {
                table.AddRow(player.CurrentRoom.Items[i].ToString().Substring(28));
            }
        }

        else
        {
            return new Panel("Nothing here");
        }

        return table;
    }

    private static IRenderable DrawInventoryMenu(Player player)
    {
        var table = new Table();
        table.AddColumn("Inventory");

        if (player.Items.Count > 0)
        {
            for (int i = 0; i < player.Items.Count; i++)
            {
                table.AddRow(player.Items[i].ToString().Substring(28));
            }
        }
        else
        {
            return new Panel("No items");
        }

        return table;
    }

    private static IRenderable DrawMoveMenu(Player player)
    {
        var table = new Table();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < player.CurrentRoom.Exits.Length; i++)
        {
            if (player.CurrentRoom.Exits[i] == Directions.AreaChange)
            {
                sb.Append($"Go to {player.CurrentRoom.ConnectedRegion} (leave)");
                continue;
            }
            sb.Append($"Go {player.CurrentRoom.Exits[i]}\n");
        };

        table.AddColumn(new TableColumn("Choose a direction"));
        table.AddRow(new Markup(sb.ToString()));
        table.Border = TableBorder.Simple;

        return table;
    }

    private static IRenderable DrawAreaTransition(Player player)
    {
        // Remove the namespace from region name
        string region = player.CurrentRegion.ToString().Substring(23);

        var panel = new Panel(region);
        panel.Header = new PanelHeader("Entering");
        panel.Border = BoxBorder.Double;

        Console.Clear();

        return panel;
    }

    private static IRenderable DrawMenu(Player player)
    {
        Table table = new Table();
        
        table.AddColumn("Choose an option");
        table.AddRow("Save");
        table.AddRow("Main Menu (quit)");

        return table;
    }

    private static void DrawScene(IEnumerable<Dialogue> json)
    {
        Console.ReadLine();

        foreach (var item in json)
        {
            if (!item.Name.Equals(""))
            {
                if (item.Name.Equals("Player"))
                {
                    AnsiConsole.MarkupLine($"[blue]{item.Name}[/]: {item.Text}\n");
                    Console.ReadLine();
                    continue;
                }
                Console.WriteLine($"{item.Name}: {item.Text}\n");
            }

            else
            {
                Console.WriteLine($"{item.Text}\n");
            }

            Console.ReadLine();
        }
        State = UIStates.Action;
    }
}