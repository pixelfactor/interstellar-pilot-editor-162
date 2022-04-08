using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorMoveToNearestFriendlyStationOrder : EditorFleetOrderBase
    {
        public bool CompleteOnReachTarget = true;
    }
}
