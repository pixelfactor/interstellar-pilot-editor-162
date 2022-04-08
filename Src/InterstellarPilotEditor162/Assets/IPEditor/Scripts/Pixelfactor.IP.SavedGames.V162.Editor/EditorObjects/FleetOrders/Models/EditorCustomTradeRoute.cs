using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models
{
    public class EditorCustomTradeRoute : MonoBehaviour
    {
        public CargoClass CargoClass;

        public EditorUnit BuyLocation;

        public EditorUnit SellLocation;

        public float BuyPriceMultiplier = 1.0f;
    }
}
