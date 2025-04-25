using CeresStation.Model;

namespace CeresStation.Simulation;

public static class PositionExtensions
{
    public static double SquaredMagnitude(this Position position) =>
        position.X * position.X +
        position.Y * position.Y +
        position.Z * position.Z;
}
