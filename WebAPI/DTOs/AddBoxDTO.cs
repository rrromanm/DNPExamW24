namespace WebAPI.DTOs;

public class AddBoxDTO
{
    public int RoomId { get; set; }
    public string Label { get; set; }
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}