using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class RepairAtNearestStationOrder : FleetOrder
    {
        public RepairFleetInsufficientCreditsMode InsufficientCreditsMode { get; set; }
    }
}
