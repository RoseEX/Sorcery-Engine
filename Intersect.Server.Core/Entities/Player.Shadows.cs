using System.ComponentModel.DataAnnotations.Schema;
using Intersect.GameObjects;
using Intersect.Server.Maps;
using Intersect.Server.Networking;
using Newtonsoft.Json;

namespace Intersect.Server.Entities;

public partial class Player
{
    // ── Persistence ───────────────────────────────────────────────────────────

    /// <summary>
    /// Serialized list of ShadowSummonDescriptor IDs the player has tamed.
    /// Stored as a JSON array string in the Players table.
    /// </summary>
    [Column("TamedShadows")]
    public string TamedShadowsJson
    {
        get => JsonConvert.SerializeObject(_tamedShadows);
        set => _tamedShadows = string.IsNullOrWhiteSpace(value)
            ? new HashSet<Guid>()
            : JsonConvert.DeserializeObject<HashSet<Guid>>(value) ?? new HashSet<Guid>();
    }

    [NotMapped, JsonIgnore]
    private HashSet<Guid> _tamedShadows = new();

    /// <summary>Read-only view of which shadow summons this player has tamed.</summary>
    [NotMapped, JsonIgnore]
    public IReadOnlySet<Guid> TamedShadows => _tamedShadows;

    // ── Runtime ───────────────────────────────────────────────────────────────

    /// <summary>Currently active summon instances for this player.</summary>
    [NotMapped, JsonIgnore]
    public List<ShadowSummonInstance> ActiveSummons { get; } = new();

    // ── Taming (called by quest/event system on boss defeat) ──────────────────

    /// <summary>
    /// Grants the player a tamed shadow. Call this from your quest event
    /// when the player defeats the shikigami boss.
    /// </summary>
    public bool TameShadow(Guid descriptorId)
    {
        var desc = ShadowSummonDescriptor.Get(descriptorId);
        if (desc == null) return false;

        if (_tamedShadows.Add(descriptorId))
        {
            PacketSender.SendActionMsg(this, $"Tamed: {desc.Name}!", CustomColors.Combat.Status);
            PacketSender.SendShadowTamedPacket(this, descriptorId, Tamed: true);
            return true;
        }

        return false; // already tamed
    }

    /// <summary>Returns true if the player has tamed the given shadow.</summary>
    public bool HasTamedShadow(Guid descriptorId) => _tamedShadows.Contains(descriptorId);

    /// <summary>
    /// Permanently removes a shadow from the player's tamed list.
    /// Called by ShadowSummonManager when a PermanentDeath summon dies.
    /// </summary>
    public void LoseShadow(Guid descriptorId)
    {
        if (_tamedShadows.Remove(descriptorId))
        {
            var desc = ShadowSummonDescriptor.Get(descriptorId);
            PacketSender.SendActionMsg(this, $"{desc?.Name ?? "Shadow"} has been lost forever!", CustomColors.Combat.TrueDamage);
            PacketSender.SendShadowTamedPacket(this, descriptorId, Tamed: false);
        }
    }
}
