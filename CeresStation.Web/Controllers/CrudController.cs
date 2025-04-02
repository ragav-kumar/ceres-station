using CeresStation.Core;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[ApiController]
[Route("api/[controller]")]
public abstract class CrudController<TModel, TDto> : ControllerBase where TModel : class
{
    protected abstract TModel NewModel();
    protected abstract void ApplyDto(TModel model, TDto dto, StationContext ctx);
    protected abstract Guid GetId(TModel model);
    protected abstract TModel? GetFromId(StationContext ctx, Guid id);
    protected abstract TDto ToDto(TModel model);
    
    [HttpGet("{id:guid}")]
    public TDto GetOne(Guid id)
    {
        using StationContext ctx = new();
        return ToDto(GetFromId(ctx, id)!);
    }

    [HttpPost]
    public async Task<TDto> Create(TDto dto)
    {
        await using StationContext ctx = new();

        TModel model = NewModel();
        ApplyDto(model, dto, ctx);
        Guid id = GetId(model);
        ctx.Set<TModel>().Add(model!);
        await ctx.SaveChangesAsync();

        return ToDto(GetFromId(ctx, id)!);
    }

    [HttpPut("{id:guid}")]
    public async Task<TDto> Update(Guid id, TDto dto)
    {
        await using StationContext ctx = new();
        
        TModel? model = GetFromId(ctx, id);
        if (model is null)
        {
            throw new InvalidOperationException("Model not found");
        }
        ApplyDto(model, dto, ctx);
        await ctx.SaveChangesAsync();

        return ToDto(GetFromId(ctx, id)!);
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await using StationContext ctx = new();
        
        TModel? model = GetFromId(ctx, id);
        if (model is not null)
        {
            ctx.Set<TModel>().Remove(model);
            await ctx.SaveChangesAsync();
        }
    }
}
