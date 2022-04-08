using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveTradeOrder : ActiveFleetOrder
    {
        public EditorCustomTradeRoute TradeRoute { get; set; }
        public double EndBuySellTime { get; set; }
        public double LastStateChangeTime { get; set; }
        public ActiveTradeOrderState CurrentState { get; set; }
    }
}
