using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.Models;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorMineOrder : EditorFleetOrderBase
    {
        /// <summary>
        /// We will head to any cargos found within this distance
        /// This should probably be the scan range
        /// </summary>
        public float MaxCargoDistance = 1500.0f;
        public bool CompleteWhenCargoFull = true;
        public CollectCargoOwnerMode CollectOwnerMode = CollectCargoOwnerMode.OwnedOrNoFaction;

        /// <summary>
        /// Optionally set this to a specific asteroid
        /// </summary>
        public EditorUnit ManualMineTarget;
    }
}
