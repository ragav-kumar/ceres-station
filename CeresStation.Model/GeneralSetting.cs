namespace CeresStation.Model;

/// <summary>
/// Strongly typed settings.
/// </summary>
public class GeneralSetting
{
    /// <summary>
    /// Needed for EF.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Available funds for Ceres Station.
    /// </summary>
    public required long Money { get; set; }
}