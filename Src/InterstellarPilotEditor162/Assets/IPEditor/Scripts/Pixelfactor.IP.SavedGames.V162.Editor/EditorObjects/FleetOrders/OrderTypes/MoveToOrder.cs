namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class MoveToOrder : FleetOrder
    {
        public bool CompleteOnReachTarget { get; set; }
        public float ArrivalThreshold { get; set; }
        public bool MatchTargetOrientation { get; set; }
        public SectorTarget Target { get; set; }
    }
}
