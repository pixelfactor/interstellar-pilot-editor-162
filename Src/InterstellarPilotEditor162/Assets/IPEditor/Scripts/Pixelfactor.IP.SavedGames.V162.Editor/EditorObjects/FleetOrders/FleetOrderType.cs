namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public enum FleetOrderType
    {
        None,
        CollectCargo,
        Dock,

        /// <summary>
        /// Manual Path
        /// </summary>
        Patrol,
        /// <summary>
        /// Patrol order that uses the <see cref="SectorPatrolPath"/> object. Used by scenarios and not sandbox
        /// </summary>
        PatrolPath,
        RTB,
        Scavenge,
        Wait,
        AttackTarget,
        /// <summary>
        /// AVOID USING IN 1.6.X due to reader bug in the game
        /// </summary>
        AttackFleet,
        UniverseTrade,
        ManualTrade,
        Mine,
        MoveTo,
        SellCargo,
        Trade,
        /// <summary>
        /// AVOID USING IN 1.6.X due to reader bug in the game
        /// </summary>
        JoinFleet,
        DisposeCargo,
        Protect,
        UniversePassengerTransport,
        UniverseRoam,
        UniverseBountyHunter,
        ManualRepair,
        Explore,
        RepairAtNearest,
        MoveToNearestFriendlyStation
    }
}
