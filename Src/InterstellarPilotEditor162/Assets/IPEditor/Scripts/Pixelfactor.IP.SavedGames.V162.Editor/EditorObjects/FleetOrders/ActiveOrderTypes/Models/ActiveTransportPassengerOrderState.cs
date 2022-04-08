namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models
{
    public enum ActiveTransportPassengerOrderState
    {
        /// <summary>
        /// Looking for a trade route
        /// </summary>
        None,

        /// <summary>
        /// We're in space travelling to a buy location
        /// </summary>
        GoPickup,

        /// <summary>
        /// We're docked and buying goods
        /// </summary>
        PickingUp,

        /// <summary>
        /// We're in space travelling to a sell location
        /// </summary>
        Transporting,

        /// <summary>
        /// We're docked and selling goods
        /// </summary>
        Disembarking,

        PostDeliver,
        PostPickup
    }
}
