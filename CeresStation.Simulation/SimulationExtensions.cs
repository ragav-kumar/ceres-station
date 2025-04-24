namespace CeresStation.Simulation;

public static class SimulationExtensions
{
    public static List<ISimulation> GetSimulations(ISimulationRandomizer randomizer) =>
    [
        new ExtractorSimulation(randomizer),
        new TransportSimulation(randomizer),
        new ProcessorSimulation(randomizer),
        new ConsumerSimulation(randomizer),
    ];
}
