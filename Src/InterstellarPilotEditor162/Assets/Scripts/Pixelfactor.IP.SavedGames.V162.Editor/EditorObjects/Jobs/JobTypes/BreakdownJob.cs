using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs.JobTypes
{
    public class BreakdownJob : Job
    {
        public EditorSector BreakdownDestinationSector { get; set; }
        public Vector3 BreakdownDestinationPosition { get; set; }
        public UnitClass BreakdownUnitClass { get; set; }
    }
}
