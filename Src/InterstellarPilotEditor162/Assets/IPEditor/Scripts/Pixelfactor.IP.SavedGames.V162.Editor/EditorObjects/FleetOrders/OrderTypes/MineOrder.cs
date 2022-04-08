using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class MineOrder : FleetOrder
    {
        public float MaxCargoDistance { get; set; }
        public bool CompleteWhenCargoFull { get; set; }
        public CollectCargoOwnerMode CollectOwnerMode { get; set; }
        public EditorUnit ManualMineTarget { get; set; }
    }
}
