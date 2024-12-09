using System;
using System.IO;
using Newtonsoft.Json;

namespace TextAdventure.Save;

public static class SaveManager
{
    public static void Save<T>(string filePath, T objectToSave) where T : new()
    {
        try
        {
            var fileToSave = JsonConvert.SerializeObject(objectToSave, Formatting.Indented);

            using (TextWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(fileToSave);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Couldn't save: {ex.Message}");
        }
    }


    public static T Load<T>(string filePath) where T : new()
    {
        using (TextReader reader = new StreamReader(filePath))
        {
            try
            {
                string contentToLoad = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<T>(contentToLoad);
            }

            catch (Exception e)
            {
                Console.WriteLine("Couldn't load save");
                return default;
            }
        }
    }
}