using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

public struct Dialogue
{
    public string Name { get; init; }
    public string Text { get; init; }
}

public class Scene
{
    public IEnumerable<Dialogue> Text;
    public bool Viewed = false;

    public Scene(string file) { Text = LoadJson(file); }

    public IEnumerable<Dialogue> LoadJson(string json)
    {
        // IEnumerable<Dialogue> dialogue;
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