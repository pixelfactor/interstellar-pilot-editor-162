namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class ProtectOrder : FleetOrder
    {
        public bool CompleteOnReachTarget { get; set; }
        public float ArrivalThreshold { get; set; }
        public bool MatchTargetOrientation { get; set; }
        public SectorTarget Target { get; set; }
    }
}
