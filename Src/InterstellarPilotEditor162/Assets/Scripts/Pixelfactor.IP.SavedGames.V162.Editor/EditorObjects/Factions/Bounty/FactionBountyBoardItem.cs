using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Factions.Bounty
{
    public class FactionBountyBoardItem
    {
        public EditorPerson TargetPerson { get; set; }
        public int Reward { get; set; }
        public EditorUnit LastKnownTargetUnit { get; set; }
        public EditorSector LastKnownTargetSector { get; set; }
        public Vector3? LastKnownTargetPosition { get; set; }
        /// <summary>
        /// The faction that added the bounty
        /// </summary>
        public EditorFaction SourceFaction { get; set; }
    }
}
