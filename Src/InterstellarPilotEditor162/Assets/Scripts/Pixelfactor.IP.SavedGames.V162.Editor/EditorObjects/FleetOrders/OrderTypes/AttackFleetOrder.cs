namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class AttackFleetOrder : FleetOrder
    {
        public EditorFleet Target { get; set; }
        public float AttackPriority { get; set; }
    }
}
