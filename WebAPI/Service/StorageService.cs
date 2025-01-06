using WebAPI.Entities;

namespace WebAPI.Service;

public class StorageService : IStorageService
{
    public List<StorageRoom> StorageRooms { get; set; }

    public StorageService()
    {
        List<Box> boxes = new List<Box>();
        boxes.Add(new Box(1, "Box 1", new Dimensions(1, 1, 1)));
        boxes.Add(new Box(2, "Box 2", new Dimensions(2, 2, 2)));
        boxes.Add(new Box(3, "Box 3", new Dimensions(3, 3, 3)));


        StorageRooms = new List<StorageRoom>();
        StorageRooms.AddRange(new List<StorageRoom>
        {
            new StorageRoom{Id = 1, Location = "row 4, aisle 7", Dimensions = new Dimensions(100, 100, 20), Boxes = boxes},
            new StorageRoom{Id = 2, Location = "row 2, aisle 1", Dimensions = new Dimensions(50, 50, 10), Boxes = new ()},
            new StorageRoom{Id = 3, Location = "row 3, aisle 2", Dimensions = new Dimensions(75, 100, 10), Boxes = new()},
            new StorageRoom{Id = 4, Location = "row 4, aisle 4", Dimensions = new Dimensions(25, 75, 10), Boxes = boxes},
            new StorageRoom{Id = 5, Location = "row 5, aisle 1", Dimensions = new Dimensions(100, 100, 30), Boxes = new ()},
        });
    }

    public async Task<StorageRoom> getRoom(int roomId)
    {
        var room = StorageRooms.FirstOrDefault(r => r.Id == roomId);
        return room;
    }

    public async Task<StorageRoom> addBoxToRoom(int roomId, Box box)
    {
        var room = StorageRooms.FirstOrDefault(r => r.Id == roomId);
        box.Id = room.Boxes.Max(p => p.Id) + 1;
        room.Boxes.Add(box);
        return room;
    }

    public async Task<List<Box>> getBoxesInRoom(int roomId)
    {
        var room = StorageRooms.FirstOrDefault(r => r.Id == roomId);
        return room.Boxes;
    }

    public async Task removeBoxFromRoom(int roomId, int boxId)
    {
        var room = StorageRooms.FirstOrDefault(r => r.Id == roomId);
        var box = room.Boxes.FirstOrDefault(b => b.Id == boxId);
        room.Boxes.Remove(box); 
    }

    public async Task<List<StorageRoom>> getAllRooms()
    {
        return StorageRooms;
    }
}