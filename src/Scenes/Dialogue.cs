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
    public SceneFlags Flag;

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
        return player.Flags.Contains(Flag) && player.CurrentRoom.ContainsScene() ? true : false;
    }
}