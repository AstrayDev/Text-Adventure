using System;
using System.Collections.Generic;
using TextAdventure.Player;

namespace TextAdventure.Location;

public abstract class Region
{
    public string Name { get; private set; }
    public List<List<Room>> Rooms { get; private set; }
    private Position StartPosition;
    private int MaxX;
    private int MaxY;

    public Region(string name, Position startPosition, int maxX, int maxY)
    {
        Rooms = new List<List<Room>>(maxX);
        MaxX = maxX;
        MaxY = maxY;

        Name = name;
        StartPosition = startPosition;

        for (int i = 0; i < maxX; i++)
        {
            Rooms.Add(new List<Room>(maxY));
            for (int j = 0; j < maxY; j++)
            {
                Rooms[i].Add(null);
            }
        }
    }
    /// <summary>
    /// Adds a room to the region
    /// </summary>
    /// <param name="room">Room to add to region</param>
    /// <param name="position">Position to create room</param>
    protected void AddRoom(Position position, Room room)
    {
        try
        {
            if (Rooms[position.X][position.Y] == null)
            {
                Rooms[position.X][position.Y] = room;
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Position out of bounds, max is ({MaxX}, {MaxY}), the position you're adding is ({position.X}, {position.Y}).\nProblem{e.StackTrace}. Exiting");
            Environment.Exit(0);
        }
    }

    internal void PrintRoomDescription(Region region, TextAdventure.Player.Player player)
    {
        if (region.Rooms[player.Position.X][player.Position.Y] != null)
        {
            Console.WriteLine(region.Rooms[player.Position.X][player.Position.Y].Description);

            for (int i = 0; i < region.Rooms[player.Position.X][player.Position.Y].Exits.Length; i++)
            {
                Console.WriteLine($"Go {region.Rooms[player.Position.X][player.Position.Y].Exits[i]}");
            }
        }

        else
        {
            Console.WriteLine($"Room is null, check the {region}.cs file to ensure room placement is correct.\nExiting");
            Environment.Exit(0);
        }
    }
}