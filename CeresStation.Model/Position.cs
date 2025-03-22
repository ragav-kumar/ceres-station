using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[Owned]
public class Position
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Position()
    {
    }

    public Position(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public static Position Origin => new(0, 0, 0); 
}
