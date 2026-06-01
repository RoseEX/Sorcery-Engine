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
            // Check if caster is already in burnout
            if (Timing.Global.Milliseconds < caster.CTBurnoutEndsAt)
            {
                PacketSender.SendActionMsg(caster, "Technique is still burnt out!", CustomColors.Combat.TrueDamage);
                return;
            }

            var existing = Active.FirstOrDefault(d =>
                d.MapId == caster.MapId && d.Contains(caster));

            if (existing != null)
            {
                ResolveClash(existing, caster, descriptor);
                return;
            }

            // --- JJK Logic: Activate Domain Flags ---
            caster.IsDomainActive = true;
            caster.IsSureHitNeutralized = false;

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
        // If power is greater, collapse the old one and cast new one
        if (desc.DomainPower > existing.Descriptor.DomainPower)
        {
            existing.Collapse(); // This should trigger burnout for the old caster
            TryCast(challenger, desc);
        }
        else
        {
            // If they are clashing (equal power), neutralize sure-hits
            existing.Caster.IsSureHitNeutralized = true;
            challenger.IsSureHitNeutralized = true;
            PacketSender.SendActionMsg(challenger, "DOMAIN CLASH: Sure-hit neutralized!", CustomColors.Combat.Critical);
            PacketSender.SendActionMsg(existing.Caster, "DOMAIN CLASH: Sure-hit neutralized!", CustomColors.Combat.Critical);
        }
    }

    public static void Remove(DomainExpansionInstance d)
    {
        lock (Lock)
        {
            // --- JJK Logic: Trigger Burnout when domain is removed ---
            if (d.Caster != null)
            {
                d.Caster.IsDomainActive = false;
                d.Caster.IsSureHitNeutralized = false;

                // Set the 15 second burnout (15000ms)
                d.Caster.CTBurnoutEndsAt = Timing.Global.Milliseconds + 15000;
                PacketSender.SendActionMsg(d.Caster, "TECHNIQUE BURNOUT", CustomColors.Combat.TrueDamage);
            }

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