using System;
using System.Diagnostics.Contracts;
using System.IO;
using Newtonsoft.Json;

public class Scene
{
    public dynamic LoadJson(string json)
    {
        object array;
        using (StreamReader reader = new StreamReader(json))
        {
            string jsonText = reader.ReadToEnd();
            array = JsonConvert.DeserializeObject(jsonText);
        }
        return array;
    }
    public void StartScene(dynamic json)
    {
        foreach (var item in json)
        {
            string name = item.Name.ToString();
            string text = item.Value.ToString();

            
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine($"{name}: {text}");
            }
        }
    }
}