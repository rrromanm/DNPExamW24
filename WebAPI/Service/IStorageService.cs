using WebAPI.Entities;

namespace WebAPI.Service;

public interface IStorageService
{
    public Task<StorageRoom> getRoom(int roomId);
    public Task<StorageRoom> addBoxToRoom(int roomId, Box box);
    public Task<List<Box>> getBoxesInRoom(int roomId);
    public Task removeBoxFromRoom(int roomId, int boxId);
    public Task<List<StorageRoom>> getAllRooms();
}