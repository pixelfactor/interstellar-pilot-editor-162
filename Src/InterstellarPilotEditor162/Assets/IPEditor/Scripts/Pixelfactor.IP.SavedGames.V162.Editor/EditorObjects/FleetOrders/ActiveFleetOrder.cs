namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    /// <summary>
    /// Represents an order that the fleet is currently busy with
    /// </summary>
    public class ActiveFleetOrder
    {
        public double TimeoutTime { get; set; }
        public double StartTime { get; set; }
        public EditorFleetOrderCommon Order { get; set; }
    }
}
