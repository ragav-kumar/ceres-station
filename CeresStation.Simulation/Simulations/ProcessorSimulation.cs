using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class ProcessorSimulation(ISimulationRandomizer randomizer) : ISimulation
{
    public string Key => "processor_simulation";
    
    public Task TickAsync(StationContext ctx, CancellationToken _)
    {
        foreach (Processor processor in ctx.Processors)
        {
            ProgressTimeStep(processor);
        }
        
        return Task.CompletedTask;
    }

    private static void ProgressTimeStep(Processor processor)
    {
        if (!HaveEnoughInputs(processor) || !HaveOutputCapacity(processor))
        {
            return;
        }

        ConsumeInputs(processor);
        GenerateOutputs(processor);
    }

    private static bool HaveEnoughInputs(Processor processor) => processor
        .Inputs
        .All(reagent =>
            reagent.Stockpile >= reagent.ProcessRate / processor.TimeStep
        );

    private static bool HaveOutputCapacity(Processor processor) => processor
        .Outputs
        .All(reagent =>
            reagent.Capacity >= reagent.ProcessRate / processor.TimeStep + reagent.Stockpile
        );

    private static void ConsumeInputs(Processor processor)
    {
        foreach (Reagent input in processor.Inputs)
        {
            input.Stockpile -= input.ProcessRate / processor.TimeStep;
        }
    }

    private static void GenerateOutputs(Processor processor)
    {
        foreach (Reagent output in processor.Outputs)
        {
            output.Stockpile += output.ProcessRate / processor.TimeStep;
        }
    }
}
