using System;
using System.Collections.Generic;

namespace TextAdventure.Location;

public abstract class Region
{
    public string Name { get; private set; }
    public List<List<Room>> Rooms = new List<List<Room>>();
    private Position StartPosition;
    private int MaxX;
    private int MaxY;

    /// <summary>
    /// Instantiates a new region 
    /// </summary>
    /// <param name="name">name of the region</param>
    /// <param name="startPosition">the starting point for the region</param>
    /// <param name="maxX">max width</param>
    /// <param name="maxY">max height</param>
    public Region(string name, Position startPosition, int maxX, int maxY)
    {
        Rooms = new List<List<Room>>(maxX);
        MaxX = maxX;
        MaxY = maxY;

        Name = name;
        StartPosition = startPosition;

        // Needs every item in the list to be null otherwise it'll trow an error
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
}