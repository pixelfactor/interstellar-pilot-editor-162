using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes.Models;
using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveSellCargoOrder : ActiveFleetOrder
    {
        public double SellExpireTime { get; set; }
        public CargoClass SellCargoClass { get; set; }
        public ActiveSellCargoOrderState State { get; set; }
        public EditorUnit TraderTargetUnit { get; set; }
    }
}
