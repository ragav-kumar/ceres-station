using CeresStation.Model;

namespace CeresStation.Core.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid ironId = new("37E6568D-ECCF-42A3-9F52-B305E270CE6A");
    private readonly Guid copperId = new("30EA256F-AFAA-42EA-A0F1-637C7334E597");
    private readonly Guid silicatesId = new("CC39FBB1-DD46-4CB3-9DD6-29F510041EC7");
    private readonly Guid carbonId = new("09C30143-50E7-46CB-ABDD-2303D5CCD2CA");
    private readonly Guid waterId = new("CF059BEA-41BC-4197-8674-E27F8D323ADC");
    private readonly Guid hydrogenId = new("56CEFE84-6F62-41A9-9322-F8C1879C5DEC");
    private readonly Guid oxygenId = new("3E758F98-A84F-4C56-8ABE-6E23EB4E4CBB");
    
    internal async Task Resources()
    {
        ctx.Add(new Resource { Id = ironId, Name = "Iron" });
        ctx.Add(new Resource { Id = copperId, Name = "Copper" });
        ctx.Add(new Resource { Id = silicatesId, Name = "Silicates" });
        ctx.Add(new Resource { Id = carbonId, Name = "Carbon" });
        ctx.Add(new Resource { Id = waterId, Name = "Water" });
        ctx.Add(new Resource { Id = hydrogenId, Name = "Hydrogen" });
        ctx.Add(new Resource { Id = oxygenId, Name = "Oxygen" });
        await ctx.SaveChangesAsync();
        
        // Not Listable, so no columns
    }
}
