using Intersect.Models;
using Newtonsoft.Json;

namespace Intersect.GameObjects;

public enum ShadowType
{
    DivineDog    = 0,
    DivineDogKai = 1, // Unlocked after taming both Divine Dogs
    Nue          = 2,
    Toad         = 3,
    GreatSerpent = 4,
    MaxElephant  = 5,
    Rabbit       = 6,
    Tiger        = 7,
    Owl          = 8,
    Mahoraga     = 9,
}

public partial class ShadowSummonDescriptor : DatabaseObject<ShadowSummonDescriptor>, IFolderable
{
    [JsonConstructor]
    public ShadowSummonDescriptor(Guid id) : base(id) { Name = "New Shadow Summon"; }
    public ShadowSummonDescriptor() { Name = "New Shadow Summon"; }

    public ShadowType ShadowType   { get; set; } = ShadowType.DivineDog;

    /// <summary>NPC template to spawn as the allied shikigami.</summary>
    public Guid SummonNpcId        { get; set; } = Guid.Empty;

    public int  SummonCost         { get; set; } = 20;
    public int  MaxActive          { get; set; } = 1;

    /// <summary>If true, death in combat permanently removes it from the player's tamed list.</summary>
    public bool PermanentDeath     { get; set; } = false;

    public string Icon             { get; set; } = string.Empty;
    public string Description      { get; set; } = string.Empty;
    public string Folder           { get; set; } = string.Empty;
}
