using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// This class will spawn a fleet of ships<br />
    /// The engine will keep track of the spawned fleet and then only respawn when the fleet has been destroyed.
    /// </summary>
    public class EditorFleetSpawner : MonoBehaviour
    {
        public float SpawnTimeRandomness = 0f;
        public bool RespawnWhenNoObjectives = false;
        public bool RespawnWhenNoPilots = false;
        public bool AllowRespawnInActiveScene = true;
        public EditorUnit FleetHomeBase;
        public EditorSector FleetHomeSector;
        public EditorFaction OwnerFaction;
        public double NextSpawnTime;
        public float MinTimeBeforeSpawn = 120f;
        public float MaxTimeBeforeSpawn = 240f;
        public int MinShipCount = 1;
        public int MaxShipCount = 3;
        /// <summary>
        /// This type doesn't allow custom settings. But instead uses serveral predefined profiles.
        /// </summary>
        public EditorFleetSpawnerFleetType FleetType = EditorFleetSpawnerFleetType.GenericGroup;
        public EditorFleetSpawnerPilotType PilotType = EditorFleetSpawnerPilotType.AIGenericPilot;
    }
}
