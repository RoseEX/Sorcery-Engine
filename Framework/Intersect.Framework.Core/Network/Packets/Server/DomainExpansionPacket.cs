using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject]
public partial class DomainExpansionOpenedPacket : IntersectPacket
{
    public DomainExpansionOpenedPacket() { }

    public DomainExpansionOpenedPacket(Guid instanceId, Guid casterId, Guid mapId,
        int originX, int originY, int radius, string overlayTexture, long duration)
    {
        InstanceId = instanceId;
        CasterId = casterId;
        MapId = mapId;
        OriginX = originX;
        OriginY = originY;
        Radius = radius;
        OverlayTexture = overlayTexture;
        Duration = duration;
    }

    [Key(0)] public Guid InstanceId { get; set; }
    [Key(1)] public Guid CasterId { get; set; }
    [Key(2)] public Guid MapId { get; set; }
    [Key(3)] public int OriginX { get; set; }
    [Key(4)] public int OriginY { get; set; }
    [Key(5)] public int Radius { get; set; }
    [Key(6)] public string OverlayTexture { get; set; }
    [Key(7)] public long Duration { get; set; }
}

[MessagePackObject]
public partial class DomainExpansionCollapsedPacket : IntersectPacket
{
    public DomainExpansionCollapsedPacket() { }

    public DomainExpansionCollapsedPacket(Guid instanceId, Guid mapId)
    {
        InstanceId = instanceId;
        MapId = mapId;
    }

    [Key(0)] public Guid InstanceId { get; set; }
    [Key(1)] public Guid MapId { get; set; }
}