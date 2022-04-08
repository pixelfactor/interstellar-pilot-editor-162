using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorMoveToOrder : EditorFleetOrderBase
    {
        public bool CompleteOnReachTarget = true;
        public float ArrivalThreshold = 100.0f;
        public bool MatchTargetOrientation = false;
        public Transform Target;
    }
}
