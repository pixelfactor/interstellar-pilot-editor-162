namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveCollectCargoOrder : ActiveFleetOrder
    {
        public EditorUnit TractorTargetUnit { get; set; }
        public bool AutoFindCargoEnabled { get; set; }
        public bool AutoTractorCargoEnabled { get; set; }
    }
}
