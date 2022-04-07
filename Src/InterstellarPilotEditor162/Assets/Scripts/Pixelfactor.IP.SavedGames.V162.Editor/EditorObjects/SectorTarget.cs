using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class SectorTarget
    {
        public Vector3 Position { get; set; }

        public EditorSector Sector { get; set; }

        public EditorUnit TargetUnit { get; set; }

        public Fleet TargetFleet { get; set; }

        /// <summary>
        /// True when the order had a valid target unit or target fleet
        /// </summary>
        public bool HadValidTarget { get; set; }
    }
}
