namespace WebAPI.Entities;

public class Dimensions
{
    public double lenght { get; set; }
    public double width { get; set; }
    public double height { get; set; }
    
    public Dimensions(double lenght, double width, double height)
    {
        this.lenght = lenght;
        this.width = width;
        this.height = height;
    }
    
    public double getVolume()
    {
        return lenght * width * height;
    }
}