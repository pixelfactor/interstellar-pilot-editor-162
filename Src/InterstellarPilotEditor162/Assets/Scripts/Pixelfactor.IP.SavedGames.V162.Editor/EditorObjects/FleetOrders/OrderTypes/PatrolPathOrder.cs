namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class PatrolPathOrder : FleetOrder
    {
        public int PathDirection { get; set; }
        public bool IsLooping { get; set; }
        public SectorPatrolPath PatrolPath { get; set; }
    }
}
