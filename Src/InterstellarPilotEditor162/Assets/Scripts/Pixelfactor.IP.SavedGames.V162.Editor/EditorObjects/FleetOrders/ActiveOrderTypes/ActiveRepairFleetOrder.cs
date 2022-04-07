using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveRepairFleetOrder : ActiveFleetOrder
    {
        public ActiveRepairFleetOrderState RepairState { get; set; }
        public EditorUnit CurrentRepairLocationUnit { get; set; }
    }
}
