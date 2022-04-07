using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.ActiveJobs
{
    public class ActiveDestroyUnitsJob : ActiveJob
    {
        public List<EditorUnit> TargetUnits { get; set; } = new List<EditorUnit>();
        public bool HasSetGroupHostileToPlayer { get; set; }
        public EditorFaction TargetFaction { get; set; }
        public EditorSector TargetSector { get; set; }
        public EditorFleet TargetFleet { get; set; }
    }
}
