using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Factions
{
    /// <summary>
    /// Brain for a CPU faction
    /// </summary>
    public class FactionAI
    {
        public int GroupMaxJumpDist { get; set; }
        public double NextUnitSpawnTime { get; set; }
        public int NumFleetsSpawned { get; set; }
        public int NumUnitsSpawned { get; set; }
        public EditorSector HomeSector { get; set; }
        public bool SpawnOnlyAtOwnedDocks { get; set; }
        public double LastBuiltUnitTime { get; set; }
        public double LastOrderedPatrolTime { get; set; }
        public FactionSpawnMode SpawnMode { get; set; }
        public List<EditorSector> SpawnSectors { get; set; } = new List<EditorSector>();

        /// <summary>
        /// Any units that the faction ai won't try to control
        /// </summary>
        public List<EditorUnit> ExcludedUnits { get; set; } = new List<EditorUnit>();

        public FactionMercenaryHireInfo FactionMercenaryHireInfo { get; set; }
        public FactionAIType AIType { get; set; }
    }
}
