using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class TransportSimulation(ISimulationRandomizer randomizer) : ISimulation
{
    public string Key => "transport_simulation";
    
    public Task TickAsync(StationContext ctx, CancellationToken _)
    {
        foreach (Transport transport in ctx.Transports)
        {
            Move(transport);
        }
        
        return Task.CompletedTask;
    }

    private void Move(Transport transport)
    {
        int index = transport.NextWaypointIndex;
        int previousIndex = index > 0 ? index - 1 : transport.Route.Waypoints.Count - 1;
        EntityBase nextWaypoint = transport.Route.WaypointEntities[index];
        EntityBase previousWaypoint = transport.Route.WaypointEntities[previousIndex];

        float a = randomizer.NextGaussian(transport.Acceleration, transport.StandardDeviation);
        // If more than 50% of way to next waypoint, decelerate.
        float progress = RouteProgress(transport.Position, previousWaypoint.Position, nextWaypoint.Position);

        if (progress >= 0.5f)
        {
            a *= -1;
        }
        
        // We have v0. We have p0. We have t (forced to be 1). We want to compute p1 and v1.
        float v0 = transport.SpeedLastTick;
        float v1 = v0 + a;
        Position direction = (nextWaypoint.Position - previousWaypoint.Position).Normalized();
        Position p0 = transport.Position;
        Position p1 = p0 + direction * (v0 + 0.5 * a);
        
        // Recompute progress. If past target, set to target.
        float nextProgress = RouteProgress(p1, previousWaypoint.Position, nextWaypoint.Position);
        if (nextProgress > 1.0f)
        {
            p1 = nextWaypoint.Position;
        }
        
        // Update
        transport.SpeedLastTick = v1;
        transport.Position = p1;
    }

    private float RouteProgress(Position transportPosition, Position previousWaypoint, Position nextWaypoint)
    {
        Position routeVector = nextWaypoint - previousWaypoint;
        Position currentVector = transportPosition - previousWaypoint;

        double routeLengthSquared = routeVector.MagnitudeSquared();
        if (routeLengthSquared == 0)
        {
            return 0f;
        }

        double dotProduct = currentVector * routeVector;
        return (float)(dotProduct / routeLengthSquared);
    }
}
