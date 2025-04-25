namespace CeresStation.Simulation;

public static class SimulationExtensions
{
    public static List<ISimulation> GetSimulations(ISimulationRandomizer randomizer) =>
    [
        // Transports must be processed either first or last.
        new TransportSimulation(randomizer),
        
        new ExtractorSimulation(randomizer),
        new ProcessorSimulation(randomizer),
        new ConsumerSimulation(randomizer),
    ];
}
