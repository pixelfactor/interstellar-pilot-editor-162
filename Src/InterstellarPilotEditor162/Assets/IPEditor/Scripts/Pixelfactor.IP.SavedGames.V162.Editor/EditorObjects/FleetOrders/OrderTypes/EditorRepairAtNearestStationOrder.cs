using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.Models;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorRepairAtNearestStationOrder : EditorFleetOrderBase
    {
        public RepairFleetInsufficientCreditsMode InsufficientCreditsMode = RepairFleetInsufficientCreditsMode.Wait;
    }
}
