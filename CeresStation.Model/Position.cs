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
    
    public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Position operator +(Position a, double b) => new(a.X + b, a.Y + b, a.Z + b);
    public static Position operator -(Position a, Position b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Position operator -(Position a, double b) => new(a.X - b, a.Y - b, a.Z - b);
    public static double operator *(Position a, Position b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    public static Position operator *(Position a, double b) => new(a.X * b, a.Y * b, a.Z * b);
    public static Position operator /(Position a, double b) => new(a.X / b, a.Y / b, a.Z / b);
    
    public double MagnitudeSquared() => X * X + Y * Y + Z * Z;
    public double Magnitude() => Math.Sqrt(MagnitudeSquared());
    public Position Normalized()
    {
        double magnitude = Magnitude();
        return new Position(X / magnitude, Y / magnitude, Z / magnitude);
    }
}
