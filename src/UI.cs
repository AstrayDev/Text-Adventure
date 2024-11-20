using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using TextAdventure.Player;

public enum UIStates
{
    MainMenu,
    Action,
    Move,
    Examine,
    Scene
}

public static class UI
{
    private static List<UIStates> StateList = new List<UIStates>() { UIStates.MainMenu };
    public static UIStates? State { get; private set; } = StateList[StateList.Count - 1];
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
            panel.Padding(2,2,2,2);
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

        return table;
    }

    private static IRenderable DrawMoveMenu(Player player)
    {
        var table = new Table();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < player.GetCurrentRoom().Exits.Length; i++)
        {
            sb.Append($"Go {player.GetCurrentRoom().Exits[i]}\n");
        };

        table.AddColumn(new TableColumn("Choose a direction")).Centered();
        table.AddRow(new Markup(sb.ToString()));
        table.Border = TableBorder.Simple;

        return table;
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