using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using TextAdventure.Player;

public struct Dialogue
{
    public string Name { get; init; }
    public string Text { get; init; }
}

public class Scene
{
    public IEnumerable<Dialogue> Text;
    public SceneFlags Flag = SceneFlags.Null;
    public bool Viewed = false;

    public Scene(string file) => Text = LoadJson(file);
    public Scene(string file, SceneFlags flag)
    {
        Text = LoadJson(file);
        Flag = flag;
    }

    /// <summary>
    /// Loads Dialogue from a json file
    /// </summary>
    /// <param name="json">json file to load from</param>
    /// <returns>each line of text to be read</returns>
    public IEnumerable<Dialogue> LoadJson(string json)
    {
        using (StreamReader reader = new StreamReader(json))
        {
            string jsonText = reader.ReadToEnd();

            return JObject.Parse(jsonText)["dialogue"]
            .Select(d => new Dialogue
            {
                Name = d["name"].ToString(),
                Text = d["text"].ToString()
            });
        }
    }
    public bool ShouldScenePlay(Player player)
    {
        if (Viewed == true)
        {
            return false;
        }

        return (player.Flags.Contains(Flag) || Flag == SceneFlags.Null) ? true : false;
    }
    public void StartScene(IEnumerable<Dialogue> json)
    {
        foreach (var item in json)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (!item.Name.Equals(""))
                {
                    Console.WriteLine($"{item.Name}: {item.Text}\n");
                }

                else
                {
                    Console.WriteLine($"{item.Text}\n");
                }
            }
        }

        Console.ReadLine();
    }
}