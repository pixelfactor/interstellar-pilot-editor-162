using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.ActiveJobs
{
    public class ActiveDeliverShipJob : ActiveJob
    {
        public UnitClass UnitClass { get; set; }
        public EditorUnit DestinationUnit { get; set; }
    }
}
