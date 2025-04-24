namespace CeresStation.Simulation;

public interface ISimulationRandomizer
{
    public float NextGaussian(float mean, float standardDeviation);
}
