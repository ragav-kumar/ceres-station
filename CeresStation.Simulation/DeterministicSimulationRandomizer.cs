namespace CeresStation.Simulation;

public class DeterministicSimulationRandomizer : ISimulationRandomizer
{
    public float NextGaussian(float mean, float standardDeviation) => mean;
}
