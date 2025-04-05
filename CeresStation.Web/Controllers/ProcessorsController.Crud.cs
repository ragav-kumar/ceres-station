using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public partial class ProcessorsController
{
    protected override Processor NewModel() => new()
    {
        Id = Guid.NewGuid(),
        Name = "New Processor",
        Position = Position.Origin,
        TimeStep = 0f,
        Inputs = [],
        Outputs = [],
    };

    protected override void ApplyDto(Processor model, ProcessorDto dto, StationContext ctx)
    {
        // Intentionally skip dto.Id.
        
        if (dto.Name is not null)
            model.Name = dto.Name;
        if (dto.Position is not null)
            model.Position = dto.Position.ToModel();
        if (dto.TimeStep is not null)
            model.TimeStep = dto.TimeStep.Value;
        if (dto.Inputs is not null)
        {
            SyncReagents(model.Inputs, dto.Inputs, ctx);
        }

        if (dto.Outputs is not null)
        {
            SyncReagents(model.Outputs, dto.Outputs, ctx);
        }
    }

    private static void SyncReagents(IEnumerable<Reagent> reagents, IList<ReagentDto> dtos, StationContext ctx)
    {
        HashSet<Reagent> modelSet = reagents.ToHashSet();
        HashSet<ReagentDto> dtoSet = dtos.ToHashSet();
        
        List<Reagent> toDelete = modelSet
            .Where(o => dtoSet.All(d => d.Id != o.Id))
            .ToList();
        ctx.Reagents.RemoveRange(toDelete);
        
        List<Reagent> toAdd = dtoSet
            .Where(o => modelSet.All(m => m.Id != o.Id))
            .Select(CreateReagentFromDto)
            .ToList();
        ctx.Reagents.AddRange(toAdd);
        
        List<ReagentDto> toUpdate = dtoSet
            .Where(o => modelSet.Any(m => m.Id == o.Id))
            .ToList();

        foreach (ReagentDto dto in toUpdate)
        {
            Reagent model = modelSet.Single(m => m.Id == dto.Id);
            ApplyDto(model, dto);
        }
    }

    private static Reagent CreateReagentFromDto(ReagentDto dto) => new()
    {
        Id = Guid.NewGuid(),
        Count = dto.Count ?? 0,
        StockpileCapacity = dto.StockpileCapacity ?? 0,
        ResourceId = dto.Resource?.Id ?? throw new InvalidOperationException("Resource id must be specified."),
    };

    private static void ApplyDto(Reagent model, ReagentDto dto)
    {
        if (dto.Count is not null)
            model.Count = dto.Count.Value;
        if (dto.StockpileCapacity is not null)
            model.StockpileCapacity = dto.StockpileCapacity.Value;
        if (dto.Resource is not null)
            model.ResourceId = dto.Resource.Id;
    }

    protected override Guid GetId(Processor model) => model.Id;

    protected override Processor? GetFromId(StationContext ctx, Guid id) => ctx.Processors.SingleOrDefault(p => p.Id == id);
    protected override ProcessorDto ToDto(Processor model) => new(
        Id: model.Id,
        Name: model.Name,
        Position: model.Position.ToDto(),
        TimeStep: model.TimeStep,
        Inputs: model.Inputs.ToDto().ToList(),
        Outputs: model.Outputs.ToDto().ToList()
    );
}
