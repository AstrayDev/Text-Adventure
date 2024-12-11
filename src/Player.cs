using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TextAdventure.Interactibles;
using TextAdventure.Location;

namespace TextAdventure.Player;

public class Player
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public Position PreviousPosition { get; set; }
    public string CurrentRegionName { get; set; }
    [JsonIgnore]
    public Region CurrentRegion { get; set; }
    [JsonIgnore]
    public Room CurrentRoom { get; set; }
    public List<SceneFlags>? Flags = new List<SceneFlags>();
    public List<Item> Items = new List<Item>();

    public Player()
    {
    }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
    }

    public void NewGameSetup()
    {
        ChangeRegion("Fields", false);
        Position = CurrentRegion.StartPosition;
        Flags.Add(SceneFlags.FieldsIntro);
        CurrentRegionName = "Fields";
        UI.SetState(UIStates.Scene);
    }

    public void Load(bool loadUp)
    {
        ChangeRegion(CurrentRegionName, loadUp);
        CurrentRoom = CurrentRegion.Rooms[Position.X][Position.Y];
    }

    /// <summary>
    /// Move one room over in specified direction
    /// </summary>
    /// <param name="direction">Direction to move in</param>
    public void Move(Position direction)
    {
        PreviousPosition = Position;
        Position = direction;
        CurrentRoom = CurrentRegion.Rooms[Position.X][Position.Y];
    }

    public void ChangeRegion(string region, bool loadUp)
        {
        Region newRegion = null;
        switch (region)
        {
            case "Fields":
                newRegion = new Fields("Fields", new Position(0, 0), 5, 5);
                break;

            case "Mountains":
                newRegion = new Mountains("Mountains", new Position(0, 0), 5, 5);
                break;
        }

        CurrentRegion = newRegion;
        CurrentRegionName = CurrentRegion.Name;
        if (!loadUp)
        {
            Position = newRegion.StartPosition;
        }
        CurrentRoom = newRegion.Rooms[Position.X][Position.Y];
    }
}