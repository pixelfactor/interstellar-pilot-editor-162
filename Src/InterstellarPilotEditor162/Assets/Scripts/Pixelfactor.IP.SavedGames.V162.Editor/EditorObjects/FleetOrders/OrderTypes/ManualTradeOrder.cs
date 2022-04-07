using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class ManualTradeOrder : FleetOrder
    {
        public int MinBuyQuantity { get; set; }
        public float MinBuyCargoPercentage { get; set; }
        public CustomTradeRoute CustomTradeRoute { get; set; }
    }
}
