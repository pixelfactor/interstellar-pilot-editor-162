namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class AttackTargetOrder : FleetOrder
    {
        public EditorUnit TargetUnit { get; set; }
        public float AttackPriority { get; set; }
    }
}
