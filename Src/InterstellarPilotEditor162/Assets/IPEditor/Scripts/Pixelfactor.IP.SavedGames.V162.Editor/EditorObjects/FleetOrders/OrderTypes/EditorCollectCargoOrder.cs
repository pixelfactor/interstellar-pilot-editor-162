using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.Models;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorCollectCargoOrder : EditorFleetOrderBase
    {
        public float MaxCargoDistance = 1500.0f;
        public bool CompleteWhenCargoFull = true;
        /// <summary>
        /// Determines how this order interacts with cargo ownership
        /// </summary>
        public CollectCargoOwnerMode CollectOwnerMode = CollectCargoOwnerMode.OwnedOrNoFaction;
        public bool OresOnly = false;
    }
}
