using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

public class Position
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    // ReSharper disable once UnusedMember.Global
    public Position()
    {
    }

    public Position(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Position(Position position)
    {
        X = position.X;
        Y = position.Y;
        Z = position.Z;
    }
    
    public static Position Origin => new(0, 0, 0); 
}
