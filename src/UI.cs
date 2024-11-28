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
    Scene
}

public static class UI
{
    public static UIStates? State { get; private set; } = UIStates.MainMenu;
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
            var panel = new Panel(player.GetCurrentRoom().Description);
            panel.Padding(2, 2, 2, 2);
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

            case UIStates.AreaTransition:
                CurrentUI = DrawAreaTransition(player);
                break;

            case UIStates.Scene:
                DrawScene(player.GetCurrentRoom().Scene.Text);
                player.Flags.Remove(player.GetCurrentRoom().Scene.Flag);
                CurrentUI = DrawActionMenu();
                break;
        }
        AnsiConsole.Write(CurrentUI);
    }

    public static IRenderable DrawMainMenu()
    {
        var table = new Table();

        table.AddColumn("Game").Centered();
        table.Border = TableBorder.Double;

        return table;
    }

    private static IRenderable DrawActionMenu()
    {
        var table = new Table();
        table.AddColumn(new TableColumn("Choose an action")).Centered();
        table.AddRow("Move");
        table.AddRow("Examine");

        return table;
    }

    private static IRenderable DrawExamineMenu(Player player)
    {
        var table = new Table();

        if (player.GetCurrentRoom().Items.Count - 1 > 0)
        {
            table.AddColumn(new TableColumn("Examine which item").Centered());
            for (int i = 1; i < player.GetCurrentRoom().Items.Count; i++)
            {
                table.AddRow(player.GetCurrentRoom().Items[i].ToString().Substring(28));
            }
        }

        else
        {
            return new Panel("Nothing here");
        }

        return table;
    }

    private static IRenderable DrawMoveMenu(Player player)
    {
        var table = new Table();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < player.GetCurrentRoom().Exits.Length; i++)
        {
            if (player.GetCurrentRoom().Exits[i] == Directions.AreaChange)
            {
                sb.Append($"Go to {player.GetCurrentRoom().ConnectedRegion} (leave)");
                continue;
            }
            sb.Append($"Go {player.GetCurrentRoom().Exits[i]}\n");
        };

        table.AddColumn(new TableColumn("Choose a direction")).Centered();
        table.AddRow(new Markup(sb.ToString()));
        table.Border = TableBorder.Simple;

        return table;
    }

    private static IRenderable DrawAreaTransition(Player player)
    {
        // Remove the namespace from region name
        string region = player.CurrentRegion.ToString().Substring(23);

        var panel = new Panel(region);
        panel.Header = new PanelHeader("Entering").Centered();
        panel.Border = BoxBorder.Double;

        Console.Clear();

        return panel;
    }

    private static void DrawScene(IEnumerable<Dialogue> json)
    {
        Console.ReadLine();

        foreach (var item in json)
        {
            if (!item.Name.Equals(""))
            {
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