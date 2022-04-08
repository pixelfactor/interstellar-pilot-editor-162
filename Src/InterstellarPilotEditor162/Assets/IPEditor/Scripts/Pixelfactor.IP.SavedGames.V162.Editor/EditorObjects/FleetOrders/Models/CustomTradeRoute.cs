using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models
{
    public class CustomTradeRoute
    {
        public CargoClass CargoClass { get; set; }

        public EditorUnit BuyLocation { get; set; }

        public EditorUnit SellLocation { get; set; }

        public float BuyPriceMultiplier { get; set; }
    }
}
