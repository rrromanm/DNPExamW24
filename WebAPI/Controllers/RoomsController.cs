using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.Service;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IStorageService _storageService;
    
    public RoomsController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    
    [HttpPost]
    public async Task<IResult> addBoxToRoom([FromBody] AddBoxDTO dto)
    {
        try
        {
            var selectedRoom = await _storageService.getRoom(dto.RoomId);
            if (selectedRoom == null)
            {
                return Results.NotFound("Room not found");
            }
            var box = new Box(dto.Label, new Dimensions(dto.Lenght, dto.Width, dto.Height));
            await _storageService.addBoxToRoom(dto.RoomId, box);
            return Results.Created($"rooms/{dto.RoomId}", box);
        }
        catch (Exception e)
        {
            return Results.NotFound("Room not found");
        }
    }
    
    [HttpGet("{roomId}")]
    public async Task<IResult> getBoxesInRoom(int roomId)
    {
        try
        {
            var boxes = await _storageService.getBoxesInRoom(roomId);
            return Results.Ok(boxes);
        }
        catch (Exception e)
        {
            return Results.NotFound("Room not found");
        }
    }
    
    [HttpDelete("{roomId}/{boxId}")]
    public async Task<IResult> removeBoxFromRoom(int roomId, int boxId)
    {
        try
        {
            await _storageService.removeBoxFromRoom(roomId, boxId);
            return Results.Ok("Box removed");
        }
        catch (Exception e)
        {
            return Results.NotFound("Room not found");
        }
    }
    
    [HttpGet("GetAllRooms")]
    public async Task<IResult> getAllRooms([FromQuery] double? volume, [FromQuery] int? boxCount)
    {
        try
        {
            var rooms = await _storageService.getAllRooms();
            var filteredRooms = rooms
                .Where(b => (!boxCount.HasValue || b.Boxes.Count < boxCount) 
                                                 && (!volume.HasValue || b.Dimensions.getVolume() > volume))
                .ToList();
            return Results.Ok(filteredRooms);
        }
        catch (Exception e)
        {
            return Results.NotFound("Rooms not found");
        }
    }
}