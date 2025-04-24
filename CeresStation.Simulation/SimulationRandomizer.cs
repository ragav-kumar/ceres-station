namespace CeresStation.Simulation;

public class SimulationRandomizer : ISimulationRandomizer
{
    private readonly Random _random = Random.Shared;
    
    public float NextGaussian(float mean, float standardDeviation)
    {
        // Box-Muller transform
        float u1 = 1.0f - _random.NextSingle();
        float u2 = 1.0f - _random.NextSingle();
        float randStdNormal = MathF.Sqrt(-2.0f * MathF.Log(u1)) * MathF.Sin(2.0f * MathF.PI * u2);
        return mean + standardDeviation * randStdNormal;
    }
}
