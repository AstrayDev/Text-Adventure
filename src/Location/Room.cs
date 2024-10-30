using System;

namespace TextAdventure.Location;

public class Room
{
    public Directions[] Exits {get; private set;}
    public string Description {get; private set;}
    public Scene Scene {get; private set;}

    /// <summary>
    /// Make a new room
    /// </summary>
    /// <param name="exits">Exits to assign</param>
    /// <param name="description">Room descitpion</param>
    /// <param name="scene">Scene for the room to play</param>
    public Room(Directions[] exits, string description, Scene scene = null)
    {
        Exits = exits;
        Description = description;
        Scene = scene;
    }

    public bool ContainsScene()
    {
        return Scene == null ? false : true;
    }

    public bool SceneViewed()
    {
        return Scene.Viewed == false ? false : true;
    }
}