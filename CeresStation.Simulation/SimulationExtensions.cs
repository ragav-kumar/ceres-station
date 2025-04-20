namespace CeresStation.Simulation;

public static class SimulationExtensions
{
    public static List<ISimulation> Simulations => [
        new ExtractorSimulation(),
    ];
}
