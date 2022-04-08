using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class PlayerWaypoint
    {
        public Vector3 Position { get; set; }
        public EditorSector Sector { get; set; }
        public EditorUnit TargetUnit { get; set; }
        public bool HadTargetObject { get; set; }
    }
}
