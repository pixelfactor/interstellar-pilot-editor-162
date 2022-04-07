using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveUniverseRoamOrder : ActiveFleetOrder
    {
        public EditorSector CurrentTargetSector { get; set; }
        public Vector3 CurrentTargetPosition { get; set; }
    }
}
