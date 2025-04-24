using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class TransportSimulation(ISimulationRandomizer randomizer) : ISimulation
{
    private enum TransportLocation
    {
        Source,
        Destination,
        EnRoute
    }
    
    public string Key => "transport_simulation";
    
    public Task TickAsync(StationContext ctx, CancellationToken _)
    {
        foreach (Transport transport in ctx.Transports)
        {
            Move(transport);
            TransportLocation location = Locate(transport);
            MoveTransport(transport);
        }
        
        return Task.CompletedTask;
    }

    private TransportLocation Locate(Transport transport)
    {
        /*if (transport.Position == transport.Source.Position)
        {
            return TransportLocation.Source;
        }
        if (transport.Position == transport.Destination.Position)
        {
            return TransportLocation.Destination;
        }*/

        return TransportLocation.EnRoute;
    }

    private void ProcessAtSource(Transport transport)
    {
        /*if (transport.Stockpile >= transport.Capacity)
        {
            MoveTransport(transport, transport.Destination.Position);
        }
        else
        {
            LoadFromSource(transport);
        }*/
    }

    private void LoadFromSource(Transport transport)
    {
        
    }

    private void MoveTransport(Transport transport)
    {
        // If transport is at source, attempt to load if possible. Only move once at capacity.
        if (transport.Stockpile >= transport.Capacity)
        {
            Move(transport);
        }
        else
        {
            
        }
        
        // If transport is at destination, atttempt to unload if possible. Only move once empty.
    }
    
    private void UnloadAtDestination(Transport transport)
    {
        // TODO
    }

    private void Move(Transport transport)
    {
        /*if (transport.MovingTowards is null)
        {
            throw new InvalidOperationException("Cannot move without a target.");
        }*/
        
        
    }
}
