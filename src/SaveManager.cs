using System;
using System.IO;
using Newtonsoft.Json;
using Spectre.Console;
using TextAdventure.Exceptions;

namespace TextAdventure.Save;

public static class SaveManager
{
    public static void Save<T>(string filePath, T objectToSave)
    {
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            var fileToSave = JsonConvert.SerializeObject(objectToSave, Formatting.Indented, settings);

            using (TextWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(fileToSave);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            AnsiConsole.MarkupLine($"[red]An error occurred when saving[/]");
        }
    }


    public static T Load<T>(string filePath)
    {
        using (TextReader reader = new StreamReader(filePath))
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            string contentToLoad = reader.ReadToEnd();

            if (contentToLoad == "" || !File.Exists(filePath))
            {
                throw new SaveException("Save is empty");
            }

            return JsonConvert.DeserializeObject<T>(contentToLoad, settings);
        }
    }
}