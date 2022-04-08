using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveExploreOrder : ActiveFleetOrder
    {
        public EditorSector CurrentTargetSector { get; set; }
        public Vector3 CurrentTargetPosition { get; set; }
    }
}
