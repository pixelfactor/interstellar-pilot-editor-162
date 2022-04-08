using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveUniversePassengerTransportOrder : ActiveFleetOrder
    {
        public PassengerGroup PassengerGroup { get; set; }
        public double EndBuySellTime { get; set; }
        public double LastStateChangeTime { get; set; }
        public ActiveTransportPassengerOrderState CurrentState { get; set; }
    }
}
