namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models
{
    /// <summary>
    /// Determines which cargos can be collected
    /// </summary>
    public enum CollectCargoOwnerMode
    {
        /// <summary>
        /// Collect cargo that is owned by this faction or which has no owner
        /// </summary>
        OwnedOrNoFaction,

        /// <summary>
        /// Collect only cargo that is owned by this faction
        /// </summary>
        OwnedOnly,

        /// <summary>
        /// Collect any cargo, including those that are owned by other factions (steal)
        /// </summary>
        AnyOwnership,

        OwnedNoFactionOrHostile,
    }
}
