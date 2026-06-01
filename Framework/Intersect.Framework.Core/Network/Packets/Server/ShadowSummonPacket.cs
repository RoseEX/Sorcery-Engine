using MessagePack;

namespace Intersect.Network.Packets.Server;

/// <summary>
/// Sent to the client when a player tames or permanently loses a shadow summon,
/// so the UI can refresh the summon list.
/// </summary>
[MessagePackObject]
public partial class ShadowSummonPacket : IntersectPacket
{
    /// <summary>The descriptor ID that was tamed or lost.</summary>
    [Key(0)]
    public Guid DescriptorId { get; set; }

    /// <summary>True = just tamed, False = just lost.</summary>
    [Key(1)]
    public bool Tamed { get; set; }

    /// <summary>Full current list of tamed shadow IDs — always sent so the client stays in sync.</summary>
    [Key(2)]
    public List<Guid> TamedList { get; set; } = new();
}
