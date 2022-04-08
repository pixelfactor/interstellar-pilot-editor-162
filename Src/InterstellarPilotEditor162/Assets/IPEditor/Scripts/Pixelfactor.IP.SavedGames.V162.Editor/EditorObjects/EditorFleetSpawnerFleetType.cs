namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Don't rename these. They are referenced by name in 1.6.x
    /// </summary>
    public enum EditorFleetSpawnerFleetType
    {
        /// <summary>
        /// Unlikely to engage targets
        /// </summary>
        DefensiveGroup,
        /// <summary>
        /// Fairly likely to engage targets
        /// </summary>
        GenericGroup,
        /// <summary>
        /// Fairly likely to engage targets. Won't cloak
        /// </summary>
        GenericGroupNoCloak,
        /// <summary>
        /// Won't attack targets at all
        /// </summary>
        NoAttackGroup,
        /// <summary>
        /// Highly likely to engage targets
        /// </summary>
        OffensiveGroup,
        /// <summary>
        /// Fairly likely to engage targets at short range. Prefers to cloak
        /// </summary>
        StealthAttackGroup
    }
}
