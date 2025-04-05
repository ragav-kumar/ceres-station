namespace CeresStation.Simulation;

internal static class RandomExtensions
{
    internal static float NextGaussian(this Random random, float mean, float standardDeviation)
    {
        // Box-Muller transform
        float u1 = 1.0f - random.NextSingle();
        float u2 = 1.0f - random.NextSingle();
        float randStdNormal = MathF.Sqrt(-2.0f * MathF.Log(u1)) * MathF.Sin(2.0f * MathF.PI * u2);
        return mean + standardDeviation * randStdNormal;
    }
}
