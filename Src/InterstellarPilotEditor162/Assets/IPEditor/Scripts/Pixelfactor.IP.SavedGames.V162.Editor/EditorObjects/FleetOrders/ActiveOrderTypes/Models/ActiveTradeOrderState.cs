namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models
{
    public enum ActiveTradeOrderState
    {
        /// <summary>
        /// Looking for a trade route
        /// </summary>
        None,

        /// <summary>
        /// We're in space travelling to a buy location
        /// </summary>
        GoBuy,

        /// <summary>
        /// We're docked and buying goods
        /// </summary>
        Buying,

        /// <summary>
        /// We're in space travelling to a sell location
        /// </summary>
        GoSell,

        /// <summary>
        /// We're docked and selling goods
        /// </summary>
        Selling,

        PostSell,
        PostBuy
    }
}
