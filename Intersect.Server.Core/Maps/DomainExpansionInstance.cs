using Intersect.Framework.Core;
using Intersect.GameObjects;
using Intersect.Server.Entities;
using Intersect.Server.Networking;

namespace Intersect.Server.Maps;

public class DomainExpansionInstance
{
    public Guid Id { get; } = Guid.NewGuid();
    public DomainExpansionDescriptor Descriptor { get; set; }
    public Entity Caster { get; set; }
    public int OriginX { get; set; }
    public int OriginY { get; set; }
    public Guid MapId { get; set; }
    public long ExpiresAt { get; set; }
    public HashSet<Entity> EntitiesInside { get; } = new();

    public bool IsExpired => Timing.Global.Milliseconds >= ExpiresAt;

    public bool Contains(Entity e)
    {
        return e.MapId == MapId &&
               Math.Abs(e.X - OriginX) <= Descriptor.Radius &&
               Math.Abs(e.Y - OriginY) <= Descriptor.Radius;
    }

    public void OnEnter(Entity e)
    {
        EntitiesInside.Add(e);

        if (Descriptor.LockedSpellId != Guid.Empty)
        {
            var spell = SpellDescriptor.Get(Descriptor.LockedSpellId);
            if (spell != null)
                Caster.TryAttack(e, spell);
        }
    }

    public void OnExit(Entity e)
    {
        EntitiesInside.Remove(e);
    }

    public void Tick()
    {
        if (IsExpired)
        {
            Collapse();
            return;
        }

        var map = MapController.Get(MapId);
        if (map == null)
        {
            Collapse();
            return;
        }

        foreach (var e in map.GetEntitiesOnAllInstances())
        {
            var inside = Contains(e);
            var was = EntitiesInside.Contains(e);
            if (inside && !was) OnEnter(e);
            else if (!inside && was) OnExit(e);
        }
    }

    public void Collapse()
    {
        foreach (var e in EntitiesInside.ToList()) OnExit(e);
        DomainExpansionManager.Remove(this);
        PacketSender.SendDomainCollapsed(MapId, Caster.MapInstanceId, Id);
    }
}