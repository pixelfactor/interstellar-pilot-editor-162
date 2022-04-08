using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorSellCargoOrder : EditorFleetOrderBase
    {
        public int FreeUnitsCompleteThreshold = -1;
        public float MinBuyPriceMultiplier = 0.0f;
        public bool CompleteWhenNoBuyerFound = true;
        public bool CompleteWhenNoCargoToSell = true;

        /// <summary>
        /// When set, we will only sell to this dock
        /// </summary>
        public EditorUnit ManualBuyerUnit;
        /// <summary>
        /// This quirky value, when not zero, will override the time that the npc loiters at the dock when selling
        /// </summary>
        public float CustomSellCargoTime = 0.0f;

        public bool SellEquipment = false;
    }
}
