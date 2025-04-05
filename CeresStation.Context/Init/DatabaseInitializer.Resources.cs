using CeresStation.Model;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid _ironId = new("37E6568D-ECCF-42A3-9F52-B305E270CE6A");
    private readonly Guid _copperId = new("30EA256F-AFAA-42EA-A0F1-637C7334E597");
    private readonly Guid _silicatesId = new("CC39FBB1-DD46-4CB3-9DD6-29F510041EC7");
    private readonly Guid _carbonId = new("09C30143-50E7-46CB-ABDD-2303D5CCD2CA");
    private readonly Guid _waterId = new("CF059BEA-41BC-4197-8674-E27F8D323ADC");
    private readonly Guid _hydrogenId = new("56CEFE84-6F62-41A9-9322-F8C1879C5DEC");
    private readonly Guid _oxygenId = new("3E758F98-A84F-4C56-8ABE-6E23EB4E4CBB");
    
    internal async Task Resources()
    {
        _ctx.Resources.Add(new Resource { Id = _ironId, Name = "Iron" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _copperId, Name = "Copper" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _silicatesId, Name = "Silicates" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _carbonId, Name = "Carbon" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _waterId, Name = "Water" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _hydrogenId, Name = "Hydrogen" });
        await _ctx.SaveChangesAsync();
        _ctx.Resources.Add(new Resource { Id = _oxygenId, Name = "Oxygen" });
        await _ctx.SaveChangesAsync();
        
        // Not Listable, so no columns
    }
}
