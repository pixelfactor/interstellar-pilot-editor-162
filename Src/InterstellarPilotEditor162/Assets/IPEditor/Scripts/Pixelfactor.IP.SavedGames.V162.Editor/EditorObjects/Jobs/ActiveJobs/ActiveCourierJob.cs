namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.ActiveJobs
{
    public class ActiveCourierJob : ActiveJob
    {
        public EditorUnit PickupUnit { get; set; }
        public EditorUnit DestinationUnit { get; set; }
        public EditorComponentUnitCargoDataItem CargoItem { get; set; }
        public bool HasPlayerPickedUpCargo { get; set; }
    }
}
