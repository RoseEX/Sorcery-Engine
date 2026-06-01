using Intersect.GameObjects;
using Intersect.Server.Entities;

namespace Intersect.Server.Maps;

/// <summary>
/// Tracks one live shikigami that has been summoned by a player.
/// </summary>
public class ShadowSummonInstance
{
    public Guid DescriptorId { get; init; }
    public Guid OwnerId      { get; init; }

    /// <summary>The actual NPC entity on the map.</summary>
    public Npc  Entity       { get; init; }

    public long SummonedAt   { get; init; }

    public ShadowSummonDescriptor? Descriptor =>
        ShadowSummonDescriptor.Get(DescriptorId);
}
