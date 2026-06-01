using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject]
public partial class ParryEventPacket : IntersectPacket
{
    public ParryEventPacket() { }

    public ParryEventPacket(Guid defenderId, Guid attackerId, bool perfectBlock)
    {
        DefenderId = defenderId;
        AttackerId = attackerId;
        PerfectBlock = perfectBlock;
    }

    [Key(0)]
    public Guid DefenderId { get; set; }

    [Key(1)]
    public Guid AttackerId { get; set; }

    [Key(2)]
    public bool PerfectBlock { get; set; }
}