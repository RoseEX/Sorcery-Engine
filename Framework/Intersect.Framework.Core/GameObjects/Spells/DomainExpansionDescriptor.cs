using Intersect.Models;
using Newtonsoft.Json;

namespace Intersect.GameObjects;

public partial class DomainExpansionDescriptor : DatabaseObject<DomainExpansionDescriptor>, IFolderable
{
    [JsonConstructor]
    public DomainExpansionDescriptor(Guid id) : base(id)
    {
        Name = "New Domain Expansion";
    }

    public DomainExpansionDescriptor()
    {
        Name = "New Domain Expansion";
    }

    // Size of the domain in tiles
    public int Radius { get; set; } = 5;

    // Duration in milliseconds
    public int Duration { get; set; } = 10000;

    // Cooldown in milliseconds
    public int Cooldown { get; set; } = 60000;

    // Whether entities are trapped inside
    public bool TrapsEntities { get; set; } = true;

    // Spell applied to everyone inside
    public Guid LockedSpellId { get; set; } = Guid.Empty;

    // Used for clash resolution — higher wins
    public int DomainPower { get; set; } = 100;

    // Client-side overlay texture name
    public string OverlayTexture { get; set; } = string.Empty;

    // Icon shown in the UI slot
    public string Icon { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Folder { get; set; } = string.Empty;
}