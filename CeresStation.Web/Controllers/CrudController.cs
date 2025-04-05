using CeresStation.Context;
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
    
    private readonly StationContext _context;

    protected CrudController(StationContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id:guid}")]
    public TDto GetOne(Guid id) => ToDto(GetFromId(_context, id)!);

    [HttpPost]
    public async Task<TDto> Create(TDto dto)
    {
        TModel model = NewModel();
        ApplyDto(model, dto, _context);
        Guid id = GetId(model);
        _context.Set<TModel>().Add(model);
        await _context.SaveChangesAsync();

        return ToDto(GetFromId(_context, id)!);
    }

    [HttpPut("{id:guid}")]
    public async Task<TDto> Update(Guid id, TDto dto)
    {
        TModel? model = GetFromId(_context, id);
        if (model is null)
        {
            throw new InvalidOperationException("Model not found");
        }
        ApplyDto(model, dto, _context);
        await _context.SaveChangesAsync();

        return ToDto(GetFromId(_context, id)!);
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        TModel? model = GetFromId(_context, id);
        if (model is not null)
        {
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
