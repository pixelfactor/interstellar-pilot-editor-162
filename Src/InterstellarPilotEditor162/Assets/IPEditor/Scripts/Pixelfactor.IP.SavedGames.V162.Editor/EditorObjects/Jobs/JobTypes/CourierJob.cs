namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.JobTypes
{
    public class CourierJob : Job
    {
        public EditorUnit PickupUnit { get; set; }
        public EditorUnit DestinationUnit { get; set; }
        public EditorComponentUnitCargoDataItem Cargo { get; set; }
    }
}
