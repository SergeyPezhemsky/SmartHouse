﻿namespace Domain.Rooms;

class Room : IRoom
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Room(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Room(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}