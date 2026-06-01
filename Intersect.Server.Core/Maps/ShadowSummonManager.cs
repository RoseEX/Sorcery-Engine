using Intersect.Enums;
using Intersect.Framework.Core;
using Intersect.GameObjects;
using Intersect.Server.Entities;
using Intersect.Server.Networking;

namespace Intersect.Server.Maps;

/// <summary>
/// Handles summoning, dismissing, and permanent death for 10 Shadows shikigami.
/// </summary>
public static class ShadowSummonManager
{
    // ── Summon ────────────────────────────────────────────────────────────────

    public static bool TrySummon(Player owner, Guid descriptorId)
    {
        var desc = ShadowSummonDescriptor.Get(descriptorId);
        if (desc == null) return false;

        // Must have tamed it first via quest boss defeat
        if (!owner.HasTamedShadow(descriptorId))
        {
            PacketSender.SendActionMsg(owner, "You haven't tamed this shikigami!", CustomColors.Combat.TrueDamage);
            return false;
        }

        // Check how many of this type are already active
        var activeCount = owner.ActiveSummons.Count(s => s.DescriptorId == descriptorId);
        if (activeCount >= desc.MaxActive)
        {
            PacketSender.SendActionMsg(owner, $"{desc.Name} is already active!", CustomColors.Combat.Status);
            return false;
        }

        // Check mana cost
        if (owner.GetVital(Vital.Mana) < desc.SummonCost)
        {
            PacketSender.SendActionMsg(owner, "Not enough cursed energy!", CustomColors.Combat.TrueDamage);
            return false;
        }

        // Find the map instance the player is on
        if (!MapController.TryGetInstanceFromMap(owner.MapId, owner.MapInstanceId, out var mapInstance))
            return false;

        // Deduct mana
        owner.SubVital(Vital.Mana, desc.SummonCost);

        // Spawn one tile in front of the player
        var spawnX = (byte)Math.Clamp(owner.X + DirectionDeltaX(owner.Dir), 0, Options.Instance.Map.MapWidth  - 1);
        var spawnY = (byte)Math.Clamp(owner.Y + DirectionDeltaY(owner.Dir), 0, Options.Instance.Map.MapHeight - 1);

        var npc = mapInstance.SpawnNpc(spawnX, spawnY, owner.Dir, desc.SummonNpcId, despawnable: true);
        if (npc == null) return false;

        // Tag so the death hook knows who owns it
        npc.SummonOwner = owner;

        owner.ActiveSummons.Add(new ShadowSummonInstance
        {
            DescriptorId = descriptorId,
            OwnerId      = owner.Id,
            Entity       = npc,
            SummonedAt   = Timing.Global.Milliseconds,
        });

        PacketSender.SendActionMsg(owner, $"Summoned: {desc.Name}!", CustomColors.Combat.Status);
        return true;
    }

    // ── Dismiss ───────────────────────────────────────────────────────────────

    /// <summary>Dismisses all active instances of one specific shikigami.</summary>
    public static void Dismiss(Player owner, Guid descriptorId)
    {
        foreach (var instance in owner.ActiveSummons.Where(s => s.DescriptorId == descriptorId).ToList())
        {
            KillSummonEntity(instance);
            owner.ActiveSummons.Remove(instance);
        }
    }

    /// <summary>Dismisses every active shikigami the player has out (e.g. on logout/death).</summary>
    public static void DismissAll(Player owner)
    {
        foreach (var instance in owner.ActiveSummons.ToList())
            KillSummonEntity(instance);

        owner.ActiveSummons.Clear();
    }

    // ── Death hook (called from Npc.Die) ──────────────────────────────────────

    /// <summary>
    /// Called by Npc.Die() when the dying NPC has a SummonOwner set.
    /// Handles permanent death and removes it from the owner's active list.
    /// </summary>
    public static void OnSummonDied(Npc npc)
    {
        if (npc.SummonOwner is not Player owner) return;

        var instance = owner.ActiveSummons.FirstOrDefault(s => s.Entity == npc);
        if (instance == null) return;

        owner.ActiveSummons.Remove(instance);

        if (instance.Descriptor?.PermanentDeath == true)
        {
            // Shikigami is gone forever — remove from tamed list
            owner.LoseShadow(instance.DescriptorId);
        }
        else
        {
            // Returns to shadows safely
            PacketSender.SendActionMsg(owner,
                $"{instance.Descriptor?.Name ?? "Shikigami"} returned to the shadows.",
                CustomColors.Combat.Status);
        }
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static void KillSummonEntity(ShadowSummonInstance instance)
    {
        if (instance.Entity != null && !instance.Entity.IsDead)
        {
            lock (instance.Entity.EntityLock)
            {
                instance.Entity.Die(false);
            }
        }
    }

    private static int DirectionDeltaX(Direction dir) => dir switch
    {
        Direction.Right => 1,
        Direction.Left  => -1,
        _               => 0,
    };

    private static int DirectionDeltaY(Direction dir) => dir switch
    {
        Direction.Down => 1,
        Direction.Up   => -1,
        _              => 0,
    };
}
