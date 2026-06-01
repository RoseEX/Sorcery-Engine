using Intersect.Framework.Core;
using Intersect.GameObjects;
using Intersect.Server.Entities;
using Intersect.Server.Networking;

namespace Intersect.Server.Maps;

public static class DomainExpansionManager
{
    private static readonly List<DomainExpansionInstance> Active = new();
    private static readonly object Lock = new();

    public static void TryCast(Entity caster, DomainExpansionDescriptor descriptor)
    {
        lock (Lock)
        {
            var existing = Active.FirstOrDefault(d =>
                d.MapId == caster.MapId && d.Contains(caster));

            if (existing != null)
            {
                ResolveClash(existing, caster, descriptor);
                return;
            }

            var instance = new DomainExpansionInstance
            {
                Descriptor = descriptor,
                Caster = caster,
                OriginX = caster.X,
                OriginY = caster.Y,
                MapId = caster.MapId,
                ExpiresAt = Timing.Global.Milliseconds + descriptor.Duration
            };

            Active.Add(instance);
            Console.WriteLine($"Opening domain {descriptor.Name}");
            PacketSender.SendDomainOpened(caster.MapId, caster.MapInstanceId, instance);
        }
    }

    private static void ResolveClash(DomainExpansionInstance existing, Entity challenger, DomainExpansionDescriptor desc)
    {
        if (desc.DomainPower > existing.Descriptor.DomainPower)
        {
            existing.Collapse();
            TryCast(challenger, desc);
        }
    }

    public static void Remove(DomainExpansionInstance d)
    {
        lock (Lock)
        {
            Active.Remove(d);
        }
    }

    public static void UpdateAll()
    {
        lock (Lock)
        {
            foreach (var d in Active.ToList())
                d.Tick();
        }
    }

    public static DomainExpansionInstance? GetDomain(Entity entity)
    {
        lock (Lock)
        {
            return Active.FirstOrDefault(d => d.Contains(entity));
        }
    }
}