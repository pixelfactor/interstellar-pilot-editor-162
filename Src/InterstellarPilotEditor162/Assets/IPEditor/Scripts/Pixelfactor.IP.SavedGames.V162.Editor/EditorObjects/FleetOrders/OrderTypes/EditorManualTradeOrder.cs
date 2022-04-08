using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorManualTradeOrder : EditorFleetOrderBase
    {
        /// <summary>
        /// What is the min amount of cargo that we will attempt to buy and move on to sell
        /// Best to use MinBuyCargoPercentage instead as independant of cargo bay size
        /// </summary>
        public int MinBuyQuantity = 1;

        /// <summary>
        /// What is the minimum percentage of our cargo hold that we will attempt to fill with the target cargo class
        /// </summary>
        public float MinBuyCargoPercentage = 0.05f;
    }
}
