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
            LoadAndUnloadTransports(ctx, processor);
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

    private static void LoadAndUnloadTransports(StationContext ctx, Processor processor)
    {
        List<Transport> transports = ctx.GetTransportsAtEntity(processor);
        foreach (Transport transport in transports)
        {
            UnloadInputs(processor, transport);
            LoadOutputs(processor, transport);
        }
    }

    private static void UnloadInputs(Processor processor, Transport transport)
    {
        foreach (Reagent input in processor.Inputs)
        {
            if (
                transport.CargoTypeId != input.ResourceId ||
                transport.Stockpile <= 0f ||
                input.Stockpile >= input.Capacity
            )
            {
                continue;
            }

            float amountToTransfer = MathF.Min(transport.Stockpile, input.Capacity - input.Stockpile);
            transport.Stockpile -= amountToTransfer;
            input.Stockpile += amountToTransfer;
        }
    }

    private static void LoadOutputs(Processor processor, Transport transport)
    {
        foreach (Reagent output in processor.Inputs)
        {
            if (
                transport.CargoTypeId != output.ResourceId ||
                transport.Stockpile >= transport.Capacity ||
                output.Stockpile <= 0f
            )
            {
                continue;
            }

            float amountToTransfer = MathF.Min(transport.Capacity - transport.Stockpile, output.Stockpile);
            transport.Stockpile += amountToTransfer;
            output.Stockpile -= amountToTransfer;
        }
    }
}
