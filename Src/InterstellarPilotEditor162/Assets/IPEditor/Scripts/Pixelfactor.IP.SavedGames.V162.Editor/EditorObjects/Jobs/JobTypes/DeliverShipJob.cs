using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.JobTypes
{
    public class DeliverShipJob : Job
    {
        public UnitClass UnitClass { get; set; }
        public EditorUnit DestinationUnit { get; set; }
    }
}
